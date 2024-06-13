app.factory('MyService',function ($http){
    var service = {};
    const baseURL = "http://localhost:5238";
    service.getMessage = function (){
        return $http.get(`${baseURL}/index`);
    }
    service.getRandomNumberService = function () {
        return $http.get(`${baseURL}/index/number`);
    }
    service.getRandomSevenNumberService = function () {
        return $http.get(`${baseURL}/index/sevenRandom`);
    }
    service.genererJoueurService = function (nbPlayer) {
        return $http.get(`${baseURL}/index/genererJoueur/` + nbPlayer);
    }
    return service;
});