var AccountLogin = function () {

    var eventos = function () {
        $('#frmLogin').on('submit', function (e) {
            if (!$(this).valid()) {
                e.preventDefault();
            } else {
                webApp.showLoading();
            }
            return true;
        });
    };
    return {
        //main function to initiate page
        init: function () {
            eventos();
        }
    };
}();

$(function () { AccountLogin.init(); });