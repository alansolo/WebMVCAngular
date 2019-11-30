var app = angular.module("MyApp", []);

app.controller("MyController", function ($scope, $http, $window) {
    $scope.ClaseShow = "d-block";

    $scope.CambiarCSS = function () {

        if ($scope.ClaseShow === "d-none") {
            $scope.ClaseShow = "d-block";
        }
        else {
            $scope.ClaseShow = "d-none";
        }
        
    };
});