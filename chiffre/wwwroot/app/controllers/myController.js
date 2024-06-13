app.controller('MyController',function ($interval,$scope,MyService){
    $scope.message="HELLO EVERYONE JS";
    $scope.randomNumber=-1;
    $scope.randomSeven = [];
    $scope.timer = 60;
    $scope.nbJoueur = 2;
    $scope.listJoueur = [];
    $scope.getMessage = function () {
        MyService.getMessage().then(
            function (response) {
                console.log(response.data.kdj);
                $scope.message = response.data.kdj;
            }
        )
    }
    
    $scope.startTime = $interval(function () {
        if ($scope.timer > 0 && $scope.randomNumber != -1) {
            $scope.timer--;
        } else {
            $interval.cancel($scope.startTime);
        }
    },1000);
    
    $scope.startGame = function () {
        $scope.startTime;   
        
        MyService.genererJoueurService($scope.nbJoueur).then(
            function (response) {
                $scope.listJoueur = response.data.j;
            }
        ).catch(function (error) {
            console.error("Error : " + error);
        });
        MyService.getRandomNumberService().then(
            function (response) {
                $scope.randomNumber = response.data.nb;
            }
        ).catch(function (error) {
            console.error("Error : " + error);
        });
        MyService.getRandomSevenNumberService().then(
            function (response) {
                $scope.randomSeven = response.data.sevenNb;
                console.log($scope.randomSeven);
            }
        ).catch(function (error) {
            console.error("Error : " + error);
        });
    }
    $scope.endGame = function () {
        $scope.timer = 60;
        MyService.getRandomNumberService().then(
            function (response) {
                $scope.randomNumber = -1;
            }
        );
        console.log($scope.randomNumber);
    }
    
    
    $scope.title="DES LETTRES ET DES CHIFFRES";
    $scope.getMessage();
});