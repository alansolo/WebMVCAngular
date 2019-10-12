var app = angular.module("MyApp", []);

app.controller("MyController", function ($scope, $http, $window) {

    $scope.ApellidoPaterno = "Lopez";

    $scope.ApellidoMaterno = "Marquez";

    $scope.Desabilitar = false;

    $scope.ClaseCss = "boton_azul";

    $scope.HolaMundo = "Hola mundo 2.";

    $scope.Boton = "Da click";

    $scope.MostrarBoton = true;

    $scope.ControlText = "Escribe algo";

    //SE EJECUTA DE INICIO
    $.ajax({
        type: "POST",
        url: "/Informacion/Inicializar",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (datos) {

            $scope.FormularioNuevo = datos;

            $scope.$apply();

        },
        error: function (error) {

        }
    });



    $scope.FuncionModel = function()
    {
        var dos = $scope.ControlText;
    }

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

                $scope.Desabilitar = true;

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

    $scope.LlenarFormulario = function ()
    {
        $.ajax({
            type: "POST",
            url: "/Informacion/LlenarFormulario",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (datos) {

                $scope.Formulario_Model = datos;

                $scope.$apply();

            },
            error: function (error) {

            }
        });
    }

    $scope.VerFormulario = function () {

        var formu = $scope.Formulario_Model;
    }

    $scope.PasarDatos = function () {

        var datos = $scope.Formulario_Model;

        $.ajax({
            type: "POST",
            url: "/Informacion/PasarDatos",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(
                {
                    'Formulario_JSON': datos
                }),
            success: function (datos) {

                $scope.ListaFormulario = datos;

                $scope.$apply();

            },
            error: function (error) {

            }
        });
    }

    $scope.EditarFormulario = function(elemento)
    {
        $.ajax({
            type: "POST",
            url: "/Informacion/EditarFormulario",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(
                {
                    'Formulario_Editar': elemento
                }),
            success: function (datos) {

                //$scope.ListaFormulario = datos;

                if (datos == "OK")
                {
                    alert("Se actualizo de forma correcta");
                }
                else
                {
                    alert("Ocurrio un error");
                }

                $scope.$apply();

            },
            error: function (error) {

            }
        });
    }

    $scope.InsertarFormulario = function () {

        var elemento = $scope.FormularioNuevo;

        $.ajax({
            type: "POST",
            url: "/Informacion/InsertFormulario",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(
                {
                    'Formulario_Insert': elemento
                }),
            success: function (datos) {

                //$scope.ListaFormulario = datos;

                if (datos != null) {

                    $scope.ListaFormulario.push(datos);

                }

                $scope.$apply();

            },
            error: function (error) {

            }
        });
    }

});