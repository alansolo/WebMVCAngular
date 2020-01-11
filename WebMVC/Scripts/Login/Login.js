var app = angular.module("MyApp", []);

//funcion inicial para agregar las empresas
app.controller("MyController", function ($scope, $http, $window) {

    $scope.usuario = "";
    $scope.password = "";

    $scope.ValidarLogin = function (usuario, password) {

        /*
        $.ajax({
            type: "POST",
            url: "/Login/ValidarLogin",
            data: JSON.stringify(
                {
                    'usuario': usuario,
                    'password': password
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                if (datos === "OK")
                {
                    $window.location.href = "/Informacion/VistaAngular";
                }
                else {
                    $scope.visibleError = true;
                    $scope.mensaje = datos;
                }

                $scope.$apply();

            },
            error: function (error) {

            }
        });
        */
        $window.location.href = "/Informacion/VistaAngular";

        return;
    };

});