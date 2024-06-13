app.controller('MyController',function ($interval,$scope,MyService){
    $scope.message="HELLO EVERYONE JS";
    $scope.randomNumber=-1;
    $scope.randomSeven = [];
    $scope.timer = 60;
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
            $interval.cancel(intervalPromise);
        }
    },1000);
    $scope.startGame = function () {
        $scope.startTime;
        MyService.getRandomNumberService().then(
            function (response) {
                $scope.randomNumber = response.data.nb;
            }
        );
        MyService.getRandomSevenNumberService().then(
            function (response) {
                $scope.randomSeven = response.data.sevenNb;
                console.log($scope.randomSeven);
            }
        );
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