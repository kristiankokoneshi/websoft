(function () {

    var dutchFlag = document.getElementById("dutch")
    var russianFlag = document.getElementById("russian")
    var germanFlag = document.getElementById("german")
    var flagArea = document.getElementById("flag")
    var topOfFlag = document.getElementById("top")
    var midOfFlag = document.getElementById("mid")
    var botOfFLag = document.getElementById("bot")


    dutchFlag.addEventListener("click", function () {
        flagArea.style.visibility = "visible";
        topOfFlag.style.backgroundColor = 'red';
        midOfFlag.style.backgroundColor = 'white';
        botOfFLag.style.backgroundColor = 'blue';
    })

    germanFlag.addEventListener("click", function () {
        flagArea.style.visibility = "visible";
        topOfFlag.style.backgroundColor = 'black';
        midOfFlag.style.backgroundColor = 'red';
        botOfFLag.style.backgroundColor = 'yellow';
    })

    russianFlag.addEventListener("click", function () {
        flagArea.style.visibility = "visible";
        topOfFlag.style.backgroundColor = 'white';
        midOfFlag.style.backgroundColor = 'blue';
        botOfFLag.style.backgroundColor = 'red';
    })

    flagArea.addEventListener("click", function () {
        flagArea.style.visibility = "hidden";
    })

})();
