app.controller('MyController',function ($interval,$scope,MyService,$http){
    const baseURL = "http://localhost:5238";
    $scope.message="HELLO EVERYONE JS";
    $scope.randomNumber=-1;
    $scope.randomSeven = [];
    $scope.timer = 60;
    $scope.listJoueur = [];
    $scope.timeOut = "";
    $scope.validation= "";
    $scope.canVerify= -1;
    $scope.tour = -1;
    $scope.winner = -1;
    $scope.color = "black";
    
    $scope.targetNumber = -1;
    $scope.sevenNumber = [];
    
    $scope.getMessage = function () {
        MyService.getMessage().then(
            function (response) {
                console.log(response.data.kdj);
                $scope.message = response.data.kdj;
            }
        )
    }
    
    
    
    $scope.startGame = function () {
        $scope.startTime = $interval(function () {
            if ($scope.timer > 0 && $scope.randomNumber != -1) {
                $scope.timer--;
                if ($scope.timer <=30 && $scope.timer > 10) {
                    $scope.color = "orange";    
                } else if($scope.timer <=10) {
                    $scope.color = "red";
                }
            } else {
                $interval.cancel($scope.startTime);
                $scope.timeOut = "Temps ecoule !!"
            }
        },1000);
        $http.get(`${baseURL}/index/number`).then(
            function (response) {
                $scope.randomNumber = response.data.nb;
            }
        ).catch(function (error) {
            console.error("Error : " + error);
        });
        $http.get(`${baseURL}/index/sevenRandom`).then(
            function (response) {
                $scope.randomSeven = response.data.sevenNb;
                console.log($scope.randomSeven);
            }
        ).catch(function (error) {
            console.error("Error : " + error);
        });
    }
    $scope.endGame = function () {
        if ($scope.randomNumber != -1) {
            let number_1 = document.querySelector('#number_1').value;
            let number_2 = document.querySelector('#number_2').value;
            if ($scope.tour == -1 && number_1 == "" && number_2 == "") {
                $scope.stop();
            } else {
                $scope.j1Response();
                $scope.j2Response();
            }
        }
        $scope.stop();
        console.log($scope.randomNumber);
    }
    
    $scope.j1Response = function () {
        let choice = -1;
        if (document.querySelector('#number_1').value != "")
        {
            choice=document.querySelector('#number_1').value;
        }
        if ($scope.validation =="")
        {
            $scope.validation = "1_"+choice;
        }
        else
        {
            $scope.validation += "&1_"+choice;
            $interval.cancel($scope.startTime);
            $scope.canVerify = 1;
        }
        document.querySelector('#number_1').value = choice;
        document.querySelector('#number_1').readOnly = true;
        
        $http.get(`${baseURL}/index/reponseEnvoye/` + $scope.validation +'/'+ $scope.randomNumber).then(
            function (response) {
                $scope.listJoueur = response.data.players;
                $scope.tour = response.data.tour;
            }
        )
    };
    
    $scope.j2Response = function () {
        let choice = -1;
        if (document.querySelector('#number_2').value != "")
        {
            choice=document.querySelector('#number_2').value;
        }
        if ($scope.validation =="")
        {
            $scope.validation = "2_"+choice;
        }
        else
        {
            $scope.validation += "&2_"+choice;
            $interval.cancel($scope.startTime);
            $scope.canVerify = 1;
        }

        document.querySelector('#number_2').value = choice;
        document.querySelector('#number_2').readOnly = true;
        
        $http.get(`${baseURL}/index/reponseEnvoye/` + $scope.validation +'/'+ $scope.randomNumber).then(
            function (response) {
                $scope.listJoueur = response.data.players;
                $scope.tour = response.data.tour;
            }
        )
    }
    $scope.check = function () {
        var combinaison = document.querySelector('#combinaison').value;
        $http.get(`${baseURL}/Index/checkCombinaison/` + $scope.validation +'/'+ $scope.randomNumber +'/'+ combinaison +'/'+ JSON.stringify($scope.randomSeven)).then(
            function (response) {
                $scope.winner = response.data.winner;
            }
        )
    }
    $scope.stop = function () {
        $scope.timer = 60;
        $scope.winner = -1;
        $scope.randomNumber = -1;
        $scope.randomSeven = [];
        $scope.listJoueur = [];
        $scope.tour = -1;
        $scope.canVerify = -1;
        $scope.validation = "";
        $scope.color = "black";
    };
    
    $scope.shoWinner = function () {
        $scope.stop();
    };
    
    // $scope.restartGame = function () {
    //     $scope.endGame();
    //     $scope.startGame();
    // };
    //
    $scope.title="DES LETTRES ET DES CHIFFRES";
    $scope.getMessage();
    
});