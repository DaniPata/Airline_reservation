<?php

        if(isset($_FILES["fileToUpload"])){
            $file = $_FILES['fileToUpload'];

            $fileName = $_FILES["fileToUpload"]["name"];
            $fileTmpName = $_FILES["fileToUpload"]["tmp_name"];
            $fileSize = $_FILES["fileToUpload"]["size"];
            $fileError = $_FILES["fileToUpload"]["error"];
            $fileType = $_FILES["fileToUpload"]["type"];

            $fileExt = explode('.', $fileName);
            $fileActualExt = strtolower(end($fileExt));

            $allowed = array('jpg', 'jpeg', 'png');

            if(in_array($fileActualExt, $allowed)){
                //Image code
                if($fileError === 0){
                    if($fileSize < 500000){

                        $fileDestination = 'uploads/'.$fileName;


                        move_uploaded_file($fileTmpName, $fileDestination);
                    //    header("Location: server.php?uploadsuccess");
                        //Display image here <----------
header("Location:index.php?filename=$fileDestination");

                    }else{
                        echo "Your file is too big!";
                    }
                }else{
                    echo "There was an error while uploading your file!";
                }
            }else{

                if(isset($_FILES["fileToUpload"])){
                    $file = $_FILES["fileToUpload"]["name"];
                    echo "File: ".$file;
                }
            }

        }

    ?>