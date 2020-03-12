<?php
/**
 * A page controller
 */
require "config.php";
require "src/functions.php";

include 'views/header.php';


$search = $_GET["search"] ?? null;
$like = "%$search%";

if ($search) {
    $db = connectDatabase($dsn);


    $sql = <<<EOD
SELECT
    *
FROM tech
WHERE
    id = ?
    OR label LIKE ?
    OR type LIKE ?
;
EOD;
    $stmt = $db->prepare($sql);
    $stmt->execute([$search, $like, $like]);

    $res = $stmt->fetchAll();
}




?><h1>Database search</h1>

<form>
    <p>
        <label>Search:
            <input type="text" name="search" value="<?= $search ?>">
        </label>
    </p>
</form>

<?php if ($search) : ?>
    <table>
        <tr>
            <th>Label</th>
            <th>Type</th>
        </tr>

    <?php foreach ($res as $row) : ?>
        <tr>
            <td><?= $row["id"] ?></td>
            <td><?= $row["label"] ?></td>
            <td><?= $row["type"] ?></td>
        </tr>
    <?php endforeach; ?>

    </table>
<?php endif; ?>


<?php include 'views/footer.php';?>
