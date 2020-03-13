using System.Collections.Generic;
using System.IO;
using WebApp.Models;
using Newtonsoft.Json;


namespace WebApp.Services
{
    public class FileReader
    {
        public static List<Account> GetJson()
        {
            List<Account> getJson;
            using (StreamReader r = new StreamReader("C:/Users/user/Desktop/WebSoft/websoft/work/account.json"))
            {
                string file = r.ReadToEnd();
                getJson = JsonConvert.DeserializeObject<List<Account>>(file);
            }

            return getJson;
        }
    }
}