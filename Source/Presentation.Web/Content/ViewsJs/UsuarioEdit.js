UsuarioEdit = function () {
    var urlIndex;

    function aplicarHandlers() {
        $("#frmUsuario").on("submit", function (e) {

            if (!$(this).valid()) {
                e.preventDefault();
                return;
            }

            var form = webApp.getDataForm(this);

            webApp.showConfirmDialog(function () {
                webApp.showLoading();
                $.ajax({
                    url: form.url,
                    type: form.type,
                    data: form.data,
                    success: function (response) {
                        if (response.Success === true) {
                            webApp.showMessageDialog(response.Message, function () { window.location.href = urlIndex; });
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

            e.preventDefault();
        });
    }

    return {
        init: function (parametros) {
            urlIndex = parametros.urlIndex;
            aplicarHandlers();
        }
    }
}();