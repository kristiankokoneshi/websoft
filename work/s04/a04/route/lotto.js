"use strict";

var express = require("express");
var url = require("url");
var router  = express.Router();

let data = {};

router.get("/", (req, res) => {

    data.numbers = Array.from({length: 7}, () => Math.floor(Math.random() * 35)+1);

    res.render("lotto", data);
});


router.get("/lotto-json", (req, res) => {
    const queryObject = url.parse(req.url,true).query;
console.log(queryObject);

var draft = JSON.parse("[" + data.numbers+ "]");
var guess = JSON.parse("[" + queryObject.row+ "]");

var myData = {
    draft: draft,
    guess: guess,
    correct: numberOfCorrectGuesses(draft, guess)
}

res.render("lotto-result",myData)

});


function numberOfCorrectGuesses(draft, guess){
    var returnVal = 0

    for (let i = 0; i < draft.length; i++) {
        if(draft[i]==guess[i]){
            returnVal++;
        }
      }

return returnVal

}



module.exports = router;
