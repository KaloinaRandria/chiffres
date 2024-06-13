app.controller('MyController',function ($interval,$scope,MyService,$http){
    const baseURL = "http://localhost:5238";
    $scope.message="HELLO EVERYONE JS";
    $scope.randomNumber=-1;
    $scope.randomSeven = [];
    $scope.timer = 60;
    $scope.listJoueur = [];
    $scope.timeOut = "";
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
        $scope.timer = 60;
        $http.get(`${baseURL}/index/number`).then(
            function (response) {
                $scope.randomNumber = -1;
            }
        );
        console.log($scope.randomNumber);
    }
    
    
    $scope.title="DES LETTRES ET DES CHIFFRES";
    $scope.getMessage();
});