var FormularioIndex = function () {
    var urlObtenerPermisos;
    var seleccioneFormulario;
    var seleccioneFormularioNoModulo;
    var formulario = "frmPermiso";
    var divCheckList = "PermisoListDiv";

    return {
        init: function (parametros) {
            urlObtenerPermisos = parametros.urlObtenerPermisos;
            seleccioneFormulario = parametros.seleccioneFormulario;
            seleccioneFormularioNoModulo = parametros.seleccioneFormularioNoModulo;
            FormularioIndex.eventos();
            FormularioIndex.cleanInputCheckList();
        },
        eventos : function () {        
            $('#' + formulario).on('submit', function (e) {
                e.preventDefault();

                var form = webApp.getDataForm(this);
                var checksSelected = new Array();
                jQuery('#' + divCheckList + ' input[type=checkbox]').each(function (index, item) {
                    if (jQuery(this).prop('checked')) {
                        var tipo = jQuery(this).prop('id').replace("TipoPermiso", "");
                        checksSelected.push({ Tipo: tipo, Estado: true });
                    }
                });

                webApp.showConfirmDialog(function () {
                    webApp.showLoading();
                    $.ajax({
                        url: form.url,
                        type: form.type,
                        data: {
                            model: {
                                FormularioId: jQuery('#FormularioId').val(),
                                RolId: jQuery('#RolId').val(),
                                PermisoList: checksSelected
                            }
                        },
                        success: function (response) {
                            if (response.Success == true) {
                                webApp.showMessageDialog(response.Message);
                                FormularioIndex.cleanInputCheckList();
                                $("#" + divCheckList).hide();
                            }
                            else webApp.showMessageDialog(response.Message);
                        },
                        error: function (x, xh, xhr) {
                            console.error(xh);
                        },
                        complete: function () { webApp.hideLoading(); }
                    });
                });

                return false;
            });
        },
        assign: function (permisoRolDto) {    
            jQuery.each(permisoRolDto.PermisoList, function (index, item) {
                if (item.Estado === true) {
                    jQuery('#TipoPermiso' + item.Tipo).prop('checked', true);
                }
            });
        },
        cleanInputCheckList: function () {
            jQuery('#' + divCheckList + ' input[type=checkbox]').each(function (index, item) {
                jQuery(this).prop('checked', false);
            });

            $("#" + formulario + " button").hide();
            $("#NombreFormulario").text('');
            $("#NombreRol").text('');    
        },
        onClickRol: function (args) {
            $("#" + formulario + " button").removeClass('hide');
            FormularioIndex.cleanInputCheckList();
            var grid = $("#RolGrid").ejGrid("instance");
            var indexGrid = this.element.closest("tr").index();
            var recordGrid = grid.getCurrentViewData()[indexGrid];

            $("#NombreRol").text(recordGrid["Nombre"]);
            $("#RolId").val(recordGrid["Id"]);

            var rolId = $("#RolId").val();
            var formularioId = $("#FormularioId").val();
            var orden = $("#Orden").val();

            if (orden != "0") {

                if (rolId != "0" && formularioId != "0") {

                    var opcionesAjax = {
                        url: urlObtenerPermisos + '?idFormulario=' + formularioId + '&idRol=' + rolId
                    }

                    webApp.Ajax(opcionesAjax, function (response) {
                        var respuestaPermisos = response.Data;
                        $("#NombreFormulario").text(respuestaPermisos.NombreFormulario);
                        $("#NombreRol").text(respuestaPermisos.NombreRol);

                        FormularioIndex.assign(respuestaPermisos);
                        $("#" + formulario + " button").show();
                        $("#" + divCheckList).show();
                    });
                }
                else {
                    webApp.showMessageDialog(seleccioneFormulario);
                }
            } else {
                webApp.showMessageDialog(seleccioneFormularioNoModulo);
            }

        },
        rowSelectedTree: function (args) {
            var treeGrid = $("#TreeGridContainer").data("ejTreeGrid");
            var indexTreeGrid = args.recordIndex;
            var recordTreeGrid = treeGrid.getCurrentViewData()[indexTreeGrid];
            $("#NombreFormulario").text(recordTreeGrid["ResourceKey"]);
            $("#FormularioId").val(recordTreeGrid["Id"]);

            $("#Orden").val(recordTreeGrid["Orden"]);
            $("#" + formulario + " button").hide();
            $("#" + divCheckList).hide();
        }
    };
}();