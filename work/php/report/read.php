<?php include 'views/header.php';?>
<?php


require "config.php";
require "src/functions.php";

$db = connectDatabase($dsn);

$stmt = $db->prepare("SELECT * FROM tech");
$stmt->execute();
$res = $stmt->fetchAll();

?>

<h1>Table content</h1>

<table>
    <tr>
        <th>Label</th>
        <th>Type</th>
    </tr>

<?php foreach($res as $row) : ?>
    <tr>
        <td><?= $row["id"] ?></td>
        <td><?= $row["label"] ?></td>
        <td><?= $row["type"] ?></td>
    </tr>
<?php endforeach; ?>

</table>
