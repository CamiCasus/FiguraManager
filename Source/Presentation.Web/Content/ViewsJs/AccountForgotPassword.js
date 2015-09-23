var AccountForgotPassword = function () {

    var divResponse = "respuestaForgotPassword";
    var formulario = "frmForgotPassword";

    var eventos = function () {
        $('#' + formulario).on('submit', function (e) {
            e.preventDefault();
            webApp.clearResponse(divResponse);

            if (!$(this).valid()) {
                return false;
            }

            var form = webApp.getDataForm(this);
            webApp.showLoading();

            $.ajax({
                url: form.url,
                type: form.type,
                data: form.data,
                success: function (response) {
                    webApp.hideLoading();
                    webApp.formatResponse(response, divResponse);
                },
                error: function (x, xh, xhr) {
                    webApp.hideLoading();
                    console.error(xh);
                }
            });
            return false;
        });
    };
    return {
        //main function to initiate page
        init: function () {
            eventos();
        }
    };
}();

$(function () { AccountForgotPassword.init(); });