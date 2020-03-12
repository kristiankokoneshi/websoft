<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <title>Schools Information</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="icon" href="favicon.ico">
</head>

<?php include 'views/header.php';?>

<body>


    <div id="duck" class="duck"></div>

    <p>Chose a municipality to display infromation about the schools</p>

    <select id="schoolSelect">

    </select>

    <p>
        <table id="schoolTable"></table>
    </p>

    <script type="text/javascript" src="js/duck.js"></script>
    <script type="text/javascript" src="js/schools_fetch.js"></script>
</body>

<?php include 'views/footer.php';?>

</html>
