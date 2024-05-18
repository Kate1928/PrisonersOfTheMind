<?php
    include "db.php";

    $dt = $_GET;

    $userData = array(
        "id" => 0,
        "level"=>0,
    );

    $error = array(
        "textError"=>"empty",
        "isError" => false
    );

    $userData = array(
        "userData" => $userData,
        "error" => $error
    );

    if(isset($dt['type']) == "Loginning")
    {
        if(isset($dt['login']) && isset($dt['password']))
        {

        }
    }else if(isset($dt['type']) == "register"){

        if(isset($dt['login']) && isset($dt['password1']) && isset($dt['password2']))
        {

        }
    }

    echo json_encode($userData, JSON_UNESCAPED_UNICODE);
?>