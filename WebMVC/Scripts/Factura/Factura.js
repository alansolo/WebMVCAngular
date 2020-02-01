var app = angular.module("MyApp", []);

app.controller("MyController", function ($scope, $http, $window) {

    $.ajax({
        type: "POST",
        url: "/Factura/GuardarFactura",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        //data: JSON.stringify(
        //    {
        //        'cadenaEncriptada': cadenaEncriptar
        //    }),
        success: function (datos) {

            if (datos === "") {
                alert("Se guardo correctamente");
            }
            else {
                alert("Existio un problema");
            }

            $scope.$apply();

        },
        error: function (error) {

        }
    });

    $scope.GuardarFactura = function () {

        $.ajax({
            type: "POST",
            url: "/Factura/GuardarFactura",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            //data: JSON.stringify(
            //    {
            //        'cadenaEncriptada': cadenaEncriptar
            //    }),
            success: function (datos) {

                if (datos === "") {
                    alert("Se guardo correctamente");
                }
                else {
                    alert("Existio un problema");
                }

                $scope.$apply();

            },
            error: function (error) {

            }
        });
    };

});