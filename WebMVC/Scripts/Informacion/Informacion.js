var app = angular.module("MyApp", []);

app.controller("MyController", function ($scope, $http, $window) {

    $scope.Desabilitar = true;

    $scope.ClaseCss = "boton_azul";

    $scope.HolaMundo = "Hola mundo 2.";

    $scope.Boton = "Da click";

    $scope.MostrarBoton = true;

    $scope.ControlText = "Escribe algo";

    $scope.ClickBoton = function () {
        $scope.HolaMundo = "Ya realizaste click.";
        $scope.ClaseCss = "boton_rojo";
    }

    $scope.DobleClickBoton = function (texto, texto2) {
        $scope.HolaMundo = "Ya realizaste doble click.";

        $scope.Boton = texto + "-" + texto2;

        $scope.Desabilitar = false;
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

    $scope.Validar = function () {
        if ($scope.ControlText.length > 0) {
            return false;
        }
        else
        {
            return true;
        }
    }

    $scope.Presionar = function () {
        alert("Se presiono");
    }

    $scope.FuncionSeleccion = function (data) {

        var dato2 = JSON.parse(data);

        alert(dato2.Descripcion);
    }

});