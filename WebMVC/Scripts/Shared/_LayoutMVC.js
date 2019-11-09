var app = angular.module("MyApp", []);

app.controller("MyController", function ($scope, $http, $window) {

    $scope.ApellidoPaterno = "Lopez";

    $scope.ApellidoMaterno = "Marquez";

    $scope.VariableGlobal = "Nace en Master Page";

    $scope.Usuario = "Rosa";

    $scope.CambiarVGPrueba1 = function () {
        $scope.VariableGlobal = "Modificada por Prueba";
    };
});