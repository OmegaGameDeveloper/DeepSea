<?php
    $username = $_POST['username'];
	$score = $_POST['score'];
	$oxyStage = $_POST['oxyStage'];
	$boosterStage = $_POST['boosterStage'];
    $kaboomStage = $_POST['kaboomStage'];
    $shieldStage = $_POST['shieldStage'];
    $CoinQty = $_POST['CoinQty'];

    $server   = "localhost";
    $usernamedb = "id15201146_root";
    $password = "oO}#O~#9svO%T{qP";
    
    $database = "id15201146_deepsea_db";
    $table    = "gameplay_table";

    $update = "UPDATE gameplay_table SET score='$score',oxyStage='$oxyStage',boosterStage='$boosterStage',kaboomStage='$kaboomStage',shieldStage='$shieldStage',CoinQty='$CoinQty' WHERE username='$username'";


    $connection = mysqli_connect($server, $usernamedb, $password,$database);
    
    $result = mysqli_query($connection,$update);
	    if($result){
		    echo "Berhasil";
	    }else{
		    echo "Gagal";
	    }
    
    mysqli_close($connection);
?>