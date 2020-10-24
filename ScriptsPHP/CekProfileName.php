<?php
    
    $username = $_POST['username'];
	
    $server   = "localhost";
    $usernamedb = "id15201146_root";
    $password = "oO}#O~#9svO%T{qP";
    
    
    $database = "id15201146_deepsea_db";
    $table    = "gameplay_table";

    $insert   = "SELECT * FROM `gameplay_table` WHERE username='$username'";
                     
    $connection = mysqli_connect($server, $usernamedb, $password,$database);
    
    $result = mysqli_query($connection,$insert);

    $resultDB = array();
    while($row=mysqli_fetch_array($result)){
        $resultDB[] = array(
        'uid' => $row['uid'],
        'username' => $row['username'],
        'scores' => $row['score'],
        'shieldStages' => $row['shieldStage'],
        'kaboomStages' => $row['kaboomStage'],
        'boosterStages' => $row['boosterStage'],
        'oxyStages' => $row['oxyStage'],
        'CoinQtys' => $row['CoinQty']);
    
    }  
    if(empty($resultDB)){
        echo "Kosong";
    }else{
    if($result){
            echo json_encode($resultDB);
        }else{
            echo "Kosong";
        }
    }
    mysqli_close($connection);
?>