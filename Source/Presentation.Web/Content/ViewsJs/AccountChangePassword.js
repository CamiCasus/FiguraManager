var AccountChangePassword = function () {

    var divResponse = "respuestaChangePassword";
    var formulario = "frmChangePassword";

    var eventos = function () {
        $('#' + formulario).on('submit', function (e) {
            e.preventDefault();

            webApp.clearResponse(divResponse);
            if (!$(this).valid()) return false;

            webApp.showConfirmDialog(function () {
                var form = webApp.getDataForm($('#' + formulario));
                webApp.showLoading();
                $.ajax({
                    url: form.url,
                    type: form.type,
                    data: form.data,
                    success: function (response) {
                        webApp.formatResponse(response, divResponse);
                    },
                    error: function (x, xh, xhr) {
                        console.error(xh);
                    },
                    complete: function () { webApp.hideLoading(); }
                });
            });
        });

        $("#cerrarChangePassword, div.modal-header button").on("click", function (e) {
            webApp.clearResponse(divResponse);

            $('#' + formulario).find('div.form-group').each(function () {
                
                if ($(this).find('span.field-validation-error').length > 0) {
                    $(this).removeClass('error');
                    $(this).find('input.form-control').removeClass('error');
                    $(this).find('input.form-control').removeClass('input-validation-error');
                    $(this).find('span.field-validation-error').text('');
                }
            });

            webApp.clearForm(formulario);
        });

    };
    return {
        //main function to initiate page
        init: function () {
            eventos();
        }
    };
}();

$(function () { AccountChangePassword.init(); });