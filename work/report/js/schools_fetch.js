
(function () {

    var schoolSelect = document.getElementById("schoolSelect")
    var schoolTable = document.getElementById("schoolTable")

    fetch('data/kommun.json')
        .then(res => { return res.json() })
        .then(jsonObj => {
         //   console.log(jsonObj)

            for (var i = 0; i < jsonObj.Kommun.length; i++) {
                var opt = document.createElement('option');
                var kommun = jsonObj.Kommun[i];
                opt.appendChild(document.createTextNode(kommun.Namn))
                opt.value = kommun.Kommunkod
                kommunNr = kommun.Kommunkod
                schoolSelect.appendChild(opt)
            }

            schoolSelect.addEventListener("change", function () {
                var kommunNr = schoolSelect.options[schoolSelect.selectedIndex].value
                fetch('data/'+kommunNr +'.json')
                    .then(res => { return res.json() })
                    .then(jsonObj => {
                        //  console.log(jsonObj)


                      // Creating table and filling it with data from json file
                        var rowCount = schoolTable.rows.length;
                        for (var x = rowCount-1; x >= 0; x--) {
                            schoolTable.deleteRow(x);
                        }

                        var row = schoolTable.insertRow(0)
                        var cell = row.insertCell(0)
                        var cell1 = row.insertCell(1)
                        var cell2 = row.insertCell(2)
                        var cell3 = row.insertCell(3)
                        cell.innerHTML = 'Skolenhetskod'
                        cell1.innerHTML = 'Skolenhetsnamn'
                        cell2.innerHTML = 'Kommunkod'
                        cell3.innerHTML = 'PeOrgNr'

                        for (var i = 0; jsonObj.Skolenheter.length; i++) {
                            var school = jsonObj.Skolenheter[i]
                            row = schoolTable.insertRow(i + 1)
                            cell = row.insertCell(0)
                            cell1 = row.insertCell(1)
                            cell2 = row.insertCell(2)
                            cell3 = row.insertCell(3)

                            cell.innerHTML = school.Skolenhetskod
                            cell1.innerHTML = school.Skolenhetsnamn
                            cell2.innerHTML = school.Kommunkod
                            cell3.innerHTML = school.PeOrgNr
                        }

                    })
            });
        })
})()
