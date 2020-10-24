<?php

    $server   = "localhost";
    $usernamedb = "id15201146_root";
    $password = "oO}#O~#9svO%T{qP";

    $database = "id15201146_deepsea_db";
    $table    = "gameplay_table";
    
    $select   = "SELECT * FROM `gameplay_table` ORDER BY score DESC LIMIT 5";
   
    $connection = mysqli_connect($server, $usernamedb, $password,$database);
    
    $result = mysqli_query($connection,$select);

    $resultDB = array();
    while($row=mysqli_fetch_array($result)){
        $resultDB[] = array(
        'uid' => $row['uid'],
        'username' => $row['username'],
        'scores' => $row['score']);
    }  
    echo json_encode($resultDB);
    
    mysqli_close($connection);
?>