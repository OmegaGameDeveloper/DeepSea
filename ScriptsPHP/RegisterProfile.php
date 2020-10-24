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
    
    $cekQuery = "SELECT * FROM gameplay_table WHERE username='$username'";
                 
    $connection = mysqli_connect($server, $usernamedb, $password,$database);
    
    $resultcek = mysqli_query($connection,$cekQuery);
    $resultcek = mysqli_num_rows($resultcek);
    
    if($resultcek>0){
        echo "Duplikat";
    }else{
        if(empty($score)){
            $score = 0;
        }
        if(empty($oxyStage)){
            $oxyStage = 0;
        }
        if(empty($boosterStage)){
            $boosterStage = 0;
        }
        if(empty($kaboomStage)){
            $kaboomStage = 0;
        }
        if(empty($shieldStage)){
            $shieldStage = 0;
        }
        if(empty($CoinQty)){
            $CoinQty = 0;
        }
        $insert   = "INSERT INTO `gameplay_table` (`uid`, `username`, `score`, `oxyStage`, `boosterStage`, `kaboomStage`, `shieldStage`, `CoinQty`) VALUES (null,'$username','$score','$oxyStage','$boosterStage','$shieldStage','$kaboomStage','$CoinQty')";
        $result = mysqli_query($connection,$insert);
	    if($result){
		    echo "Berhasil";
	    }else{
		    echo "Gagal";
	    }
    }
    mysqli_close($connection);
?>