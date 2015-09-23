UsuarioIndex = function() {
    var mensajeSeleccionarRegistro;
    var toolbarActions;
    var gridName;
    var urlExportar;

    var aplicarHandlers = function () {

        $('#btnDownload').on('click', function () {
            webApp.ExportarExcel(urlExportar);
        });
    };    

    return {
        init: function(parametros) {
            mensajeSeleccionarRegistro = parametros.mensajeSeleccionarRegistro;
            toolbarActions = parametros.toolbarActions;
            gridName = parametros.gridName;
            urlExportar = parametros.urlExportar;
            aplicarHandlers();
        },
        toolbarClick: function (args) {
            if (args.itemName === toolbarActions.add.name) {
                args.cancel = true;
                window.location.href = toolbarActions.add.url;
            } else if (args.itemName === toolbarActions.edit.name || args.itemName === toolbarActions.delete.name) {
                args.cancel = true; 
               
                if (this.getSelectedRecords().length > 0) {
                    var usuarioId = this.getSelectedRecords()[0].Id;

                    if (args.itemName === toolbarActions.edit.name)
                        window.location.href = toolbarActions.edit.url + "/" + usuarioId;
                    else if (args.itemName === toolbarActions.delete.name) {

                        var parametroEliminar = { Id: usuarioId };

                        webApp.showConfirmDialog(function() {
                            webApp.showLoading();

                            $.ajax({
                                url: toolbarActions.delete.url,
                                type: 'POST',
                                data: parametroEliminar,
                                success: function (response) {
                                    if (response.Success === true) {
                                        $(gridName).ejGrid("refreshContent");
                                        webApp.showMessageDialog(response.Message);
                                    }
                                    else
                                        webApp.showMessageDialog(response.Message);
                                },
                                error: function (x, xh, xhr) {
                                    console.error(xh);
                                },
                                complete: function () { webApp.hideLoading(); }
                            });
                        });
                    }

                } else
                    webApp.showMessageDialog(mensajeSeleccionarRegistro);
            }
        },
        actionFilterbegin: function (args) {
            if (args.requestType === "filtering") {
                if (args.currentFilteringColumn === "UserName")
                    args.currentFilterObject[0].operator = "startswith";
                else if (args.currentFilteringColumn === "NombreCompleto")
                    args.currentFilterObject[0].operator = "contains";
                else if (args.currentFilteringColumn === "AgenciaNombre")
                    args.currentFilterObject[0].operator = "contains";
                else if (args.currentFilteringColumn === "Email")
                    args.currentFilterObject[0].operator = "contains";
                else if (args.currentFilteringColumn === "RolNombre")
                    args.currentFilterObject[0].operator = "contains";
            }
        }
    }
}();
