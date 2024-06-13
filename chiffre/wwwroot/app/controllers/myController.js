app.controller('MyController',function ($scope,MyService){
    $scope.message="HELLO EVERYONE JS";
    $scope.randomNumber=-1;
    $scope.randomSeven = [];
    $scope.getMessage = function () {
        MyService.getMessage().then(
            function (response) {
                console.log(response.data.kdj);
                $scope.message = response.data.kdj;
            }
        )
    }
    $scope.startGame = function () {
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
    
    $scope.title="DES LETTRES ET DES CHIFFRES";
    $scope.getMessage();
});