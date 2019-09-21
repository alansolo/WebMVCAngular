var app = angular.module("MyApp", []);

app.controller("MyController", function ($scope, $http, $window) {

    $scope.HolaMundo = "Hola mundo 2.";

    $scope.Boton = "Da click";

    $scope.MostrarBoton = true;

    $scope.ControlText = "Escribe algo";

    $scope.ClickBoton = function () {
        $scope.HolaMundo = "Ya realizaste click.";
    }

    $scope.DobleClickBoton = function (texto, texto2) {
        $scope.HolaMundo = "Ya realizaste doble click.";

        $scope.Boton = texto + "-" + texto2;
    }

    $scope.LlamarControlador = function()
    {
        $.ajax({
            type: "POST",
            url: "/Informacion/CargarTabla",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.ListaDatos = datos;

                $scope.$apply();

            },
            error: function (error) {

            }
        });
    }

    $scope.ModificarColumna = function(tablaDatos)
    {
        tablaDatos.Nombre = tablaDatos.Nombre + "-Nuevo";

        $scope.$apply();
    }

    $scope.AgregarElemento = function (tablaDatos) {

        $.ajax({
            type: "POST",
            url: "/Informacion/AgregarRegistroTabla",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                datos.Id = 4;
                datos.Nombre = "Nombre 1A";
                datos.Descripcion = "Descripcion 1A";

                $scope.ListaDatos.push(datos);

                $scope.$apply();

            },
            error: function (error) {

            }
        });

        //$scope.$apply();
    }

    $scope.AgregarElemento2 = function () {

        $.ajax({
            type: "POST",
            url: "/Informacion/AgregarRegistroTabla2",
            data: JSON.stringify(
                {
                    'ListaDatos': $scope.ListaDatos
                }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.ListaDatos = datos;

                $scope.$apply();

            },
            error: function (error) {

            }
        });


    }

});