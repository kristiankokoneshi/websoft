using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class Api : Controller
    {
        // GET
        [HttpGet("/accounts")]
        public ActionResult Accounts()
        {
            List<Account> accounts = FileReader.GetJson();

            return Ok(accounts);
        }

        [HttpGet("/accounts/{number}")]
        public ActionResult Accounts(int number)
        {
            List<Account> accounts = FileReader.GetJson();

            foreach (var account in accounts)
            {
                if (number == account.number)
                {
                    return Ok(account);
                }
            }

            return Ok("ERROR");
        }

        [HttpPost("/accounts/{accountFrom}/{accountTo}/{amount}")]
        public ActionResult Accounts(int accountFrom, int accountTo, int amount)
        {
            List<Account> file = FileReader.GetJson();

            int accountToMoveTo = -1;
            int accountToMoveFrom = -1;
            var amountToMoveInt32 = Convert.ToInt32(amount);

            for (int i = 0; i < file.Count; i++)
            {
                if (accountFrom == file[i].number)
                {
                    accountToMoveFrom = i;
                }

                if (accountTo == file[i].number)
                {
                    accountToMoveTo = i;
                }

                if (accountToMoveFrom != -1 && accountToMoveTo != -1)
                {
                    file[accountToMoveFrom].balance -= amountToMoveInt32;
                    file[accountToMoveTo].balance += amountToMoveInt32;
                    //update json file

                    string output = JsonConvert.SerializeObject(file);
                    System.IO.File.WriteAllText(@"C:/Users/user/Desktop/WebSoft/websoft/work/account.json",
                        output);

                    break;
                }

            }
            return Ok("DONE");

        }
    }
}