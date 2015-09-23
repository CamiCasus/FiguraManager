/*
 *  Document   : webApp.js
 *  Description: Custom scripts and plugin initializations
 */

var webApp = function () {
    var _popupEspera = "popupEspera";
    var _popupMensaje = "popupMensaje";
    var _popupConfirmacion = "popupConfirmacion";
    var _mensajeEspera = "";
    var _tituloPopupMensaje = "";
    var _tituloPopupComfirmacion = "";
    var _mensajePopupConfirmacion = "";
    var _btnCancelar = "";
    var _btnAceptar = "";
    var _codigoIdioma = "";
    var _formatoFecha = "";
    var _cookModuleCurrent = "cookModuleCurrent";
    var _cookFormCurrent = "cookFormCurrent";
    var _unAuthorizedState = "";
    var _toolbar = {};
    var toolbarActions;
    var mensajeSeleccionarRegistro = "";

    var uiInit = function () {
        var t = $("#page-content");
        t.css("min-height", $(window).height() - ($("header").height() + $("footer").outerHeight()) + "px"), $(window).resize(function () {
            t.css("min-height", $(window).height() - ($("header").height() + $("footer").outerHeight()) + "px")
        })
        , $("header").hasClass("navbar-fixed-top") ? $("#page-container").addClass("header-fixed-top") : $("header").hasClass("navbar-fixed-bottom") && $("#page-container").addClass("header-fixed-bottom")
        , $("thead input:checkbox").click(function () {
            var a = $(this).prop("checked"),
                e = $(this).closest("table");
            $("tbody input:checkbox", e).each(function () {
                $(this).prop("checked", a)
            })
        })
        , $('[data-toggle="tabs"] a').click(function (a) {
            a.preventDefault(), $(this).tab("show")
        })
        , $(".scrollable").slimScroll({
            height: "100px",
            size: "3px",
            touchScrollStep: 100
        })
        , $(".scrollable-tile").slimScroll({
            height: "130px",
            size: "3px",
            touchScrollStep: 100
        })
        , $(".scrollable-tile-2x").slimScroll({
            height: "330px",
            size: "3px",
            touchScrollStep: 100
        });
        $(".select-select2").select2({
            language: _codigoIdioma
        });
        $("textarea.textarea-elastic").elastic();
        $(".input-timepicker").timepicker();
        $(".input-datepicker").datepicker({
            autoclose: true,
            isRTL: false,
            format: _formatoFecha,
            language: _codigoIdioma
        });
    };

    var primaryNav = function () {
        var a = $("#primary-nav > ul > li > a");
        a.filter(function () {
            return $(this).next().is("ul")
        }).each(function (a, e) {
            $(e).append("<span class='SB-Arrow'></span>")
        }), a.click(function () {
            var a = $(this);
            window.localStorage.setItem(_cookModuleCurrent, a[0].innerText);
            return a.next("ul").length > 0 ? (a.parent().hasClass("active") !== !0 && (a.hasClass("open") ? a.removeClass("open").next().slideUp(250) : ($("#primary-nav li > a.open").removeClass("open").next().slideUp(250), a.addClass("open").next().slideDown(250))), !1) : !0
        })
    };

    var secondNav = function () {
        var a = $("#primary-nav > ul > li > ul > li > a");
        a.click(function () {
            var a = $(this);
            window.localStorage.setItem(_cookFormCurrent, a[0].innerText);
        });
    };

    var activarNav = function () {
        var cookFormNow = window.localStorage.getItem(_cookFormCurrent);
        var cookModuleNow = window.localStorage.getItem(_cookModuleCurrent);
        
        $("#primary-nav > ul > li > ul > li > a").each(function (index, item) {
            var a = $(this);
            if (a[0].innerText === cookFormNow) {
                a.addClass("active");
                $("#ModuloMenu").append(cookModuleNow);
                $("#OperacionMenu").append(cookFormNow);
                return a.parent().parent().parent().children().first().trigger("click");
            }
        });
    };

    var scrollToTop = function () {
        var a = $("#to-top");
        $(window).scroll(function () {
            $(this).scrollTop() > 150 ? a.fadeIn(150) : a.fadeOut(150)
        }), a.click(function () {
            return $("html, body").animate({
                scrollTop: 0
            }, 300), !1
        })

    };

    $(".SB-groupIt").click(function () {
     
        if ($(this).hasClass("downArrow")) {
            $(this).next().hide(300, 'linear', function () { refreshScroller() });
            $(this).removeClass("downArrow");
            $(this).addClass("rightArrow");
        }
        else {
            $(this).next().show(300, 'linear', function () { refreshScroller() });
            $(this).removeClass("rightArrow");
            $(this).addClass("downArrow");
        }
    });

    function refreshScroller() {
    };

    var formValidBootstrap = function () {
        $('form').validateBootstrap(true);
    };

    var createLoading = function () {
        var urlImgLoading = location.protocol + "//" + location.host + "/Content/img/loading.gif";
        $("body").append('<div id="' + _popupEspera + '" tabindex="-1" role="dialog" aria-hidden="true" class="modal fade" data-backdrop="static" style="z-index:100000;"><div class="modal-dialog"><div class="modal-content"><div class="modal-body"><h4 class="text-center"><img alt="" src="' + urlImgLoading + '" /> ' + _mensajeEspera + '</h4></div></div></div></div>');
    };

    var createMessageDialog = function () {
        var dialogMessage = "<div id='" + _popupMensaje + "' tabindex='-1' role='dialog' aria-hidden='true' class='modal fade' data-backdrop='static' style='z-index:100000;'>";
        dialogMessage += "<div class='modal-dialog'>";
        dialogMessage += "<div class='modal-content'>";
        dialogMessage += "<div class='modal-header'>";
        dialogMessage += '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>';
        dialogMessage += "<h4 class='modal-title'>" + _tituloPopupMensaje + "</h4>";
        dialogMessage += "</div>";
        dialogMessage += "<div class='modal-body'></div>";
        dialogMessage += "<div class='modal-footer' style='margin-top: 0px; margin-bottom: 0px;'>";
        dialogMessage += "<button class='btn btn-primary btn-aceptar' data-dismiss='modal'><i class='fa fa-thumbs-o-up'></i> " + _btnAceptar + "</button>";
        dialogMessage += "</div>";
        dialogMessage += "</div>";
        dialogMessage += "</div>";

        $("body").append(dialogMessage);
    };

    var createConfirmDialog = function () {
        var dialogConfirm = "<div id='" + _popupConfirmacion + "' tabindex='-1' role='dialog' aria-hidden='true' class='modal fade' data-backdrop='static' style='z-index:100000;'>";
        dialogConfirm += "<div class='modal-dialog'>";
        dialogConfirm += "<div class='modal-content'>";
        dialogConfirm += "<div class='modal-header'><h4 class='modal-title'>" + _tituloPopupComfirmacion + "</h4></div>";
        dialogConfirm += "<div class='modal-body'><p></p></div>";
        dialogConfirm += "<div class='modal-footer' style='margin-top: 0px; margin-bottom: 0px;'>";
        dialogConfirm += "<button class='btn btn-primary' data-dismiss='modal'><i class='fa fa-thumbs-o-up'></i> " + _btnAceptar + "</button>";
        dialogConfirm += "<button class='btn btn-danger' data-dismiss='modal'><i class='fa fa-remove'></i> " + _btnCancelar + "</button> ";
        dialogConfirm += "</div>";
        dialogConfirm += "</div>";
        dialogConfirm += "</div>";

        $("body").append(dialogConfirm);
    };

    var getDataForm = function (form) {
        var that = $(form);
        var url = that.attr('action');
        var type = that.attr('method');
        var data = {};

        var namex = "";
        that.find('[name]').each(function (index, value) {
            var that = $(this);
            var name = that.attr('name');
            var value = that.val();

            if (that.attr('type') === 'radio') {
                if (that.is(':checked')) {
                    data[name] = value;
                }
            } else if (that.attr('type') === 'checkbox') {
                if (that.is(':checked') && namex != name) {
                    data[name] = value;
                    namex = name;
                } else if (namex == name) {
                    namex = "";
                } 
            }
            else if (namex == name && that.attr('type') === 'hidden') {
                namex = "";
            }
            else {
                data[name] = value;
            }
        });

        var obj = {
            url: url,
            type: type,
            data: data
        };

        return obj;
    };

    // function toolbarClick of grid
    var toolbarClick = function (args) {
        if (args.itemName === toolbarActions.add.name) {
            args.cancel = true;
            window.location.href = toolbarActions.add.url;
        } else if (args.itemName === toolbarActions.edit.name || args.itemName === toolbarActions.delete.name) {
            args.cancel = true;

            if (this.getSelectedRecords().length > 0) {
                var entityId = this.getSelectedRecords()[0].Id;

                if (args.itemName === toolbarActions.edit.name)
                    window.location.href = toolbarActions.edit.url + "/" + entityId;

                else if (args.itemName === toolbarActions.delete.name) {
                    var parametroEliminar = { Id: entityId };

                    webApp.showConfirmDialog(function () {
                        webApp.showLoading();

                        $.ajax({
                            url: toolbarActions.delete.url,
                            type: 'POST',
                            data: parametroEliminar,
                            success: function (response) {
                                if (response.Success === true) {
                                    $(toolbarActions.gridName).ejGrid("refreshContent");
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
                alert(mensajeSeleccionarRegistro);
        }
    };

    // function Submit of Form
    var accionSubmitForm = function(idform) {
        if (!$("#" + idform).valid()) {
            return;
        }

        var form = webApp.getDataForm($("#" + idform));

        webApp.showConfirmDialog(function () {
            webApp.showLoading();
            $.ajax({
                url: form.url,
                type: form.type,
                data: form.data,
                success: function (response) {
                    if (typeof  $("#" + idform)[0].functionAceptarMensaje == "function") {;
                        webApp.showMessageDialog(response.Message, $("#" + idform)[0].functionAceptarMensaje);
                    } else {
                        webApp.showMessageDialog(response.Message);
                    }
                },
                error: function (x, xh, xhr) {
                    console.error(xh);
                },
                complete: function() {
                    webApp.hideLoading();
                }
            });
        });

        //e.preventDefault();
    }

    var removeFilterStatusBar = function(args, that) {
        if (args != null && args.requestType === "filtering") {
            // Remove the pager message element
            that.getPager().find(".e-pagermessage").remove();
        }
    }
    
    var agregarTextosBotonesToolbar = function (grid) {
        if (grid.initialRender) {
            $("#" + grid._id + "_add").append("<span class='span-BotonToolbar'>" + _toolbar.nuevoText + "</span>");
            $("#" + grid._id + "_edit").append("<span class='span-BotonToolbar'>" + _toolbar.editarText + "</span>");
            $("#" + grid._id + "_delete").append("<span class='span-BotonToolbar'>" + _toolbar.eliminarText + "</span>");
            $("#" + grid._id + "_printGrid").append("<span class='span-BotonToolbar'>" + _toolbar.imprimirText + "</span>");
        }
    }

    var setToolbarOptionText = function (toolbar) {
        if (toolbar != null)
            $.extend(_toolbar, toolbar);
    }

    var authorizedFunctionHandler = function() {
        $.urlParam = function (name) {
            var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
            if (results == null) {
                return null;
            }
            else {
                return results[1] || 0;
            }
        }
    }

    var verifyPageAuthorization = function() {
        if ($.urlParam('state') === _unAuthorizedState) {
            alert("No autorizado");
        }
    };

    var exportarExcel = function (urlExportar) {
        webApp.showLoading();

        var iframe_ = document.createElement("iframe");
        iframe_.style.display = "none";
        iframe_.setAttribute("src", urlExportar);
        iframe_.frameBorder = 0;

        if (navigator.userAgent.indexOf("MSIE") > -1 && !window.opera) {
            // Si es Internet Explorer
            iframe_.onreadystatechange = function () {
                switch (this.readyState) {
                    case "loading":
                        webApp.showLoading();
                        break;
                    case "complete":
                    case "interactive":
                    case "uninitialized":
                        webApp.hideLoading();
                        getCookie("DescargaCompleta");
                        break;
                    default:
                        webApp.hideLoading();
                        delCookie("DescargaCompleta");
                        break;
                }
            };
        } else {
            // Si es Firefox o Chrome
            document.body.appendChild(iframe_);

            var _timer = setInterval(function () {
                var success = getCookie("DescargaCompleta");
                if (success === "1") {
                    clearInterval(_timer);
                    webApp.hideLoading();
                    delCookie("DescargaCompleta");
                }
            }, 1000);
            return;
        }
        document.body.appendChild(iframe_);
    };

    var disableAllFormElements = function (formId) {
        $('#' + formId).find('input, textarea, button, select').attr('disabled', 'disabled');
    };

    var mayuscula = function (e, elemento) {
        elemento.value = elemento.value.toUpperCase();
    };

    var sumaFecha = function (d, fecha) {
        
        var Fecha = new Date();
        var sFecha = fecha || (Fecha.getDate() + "/" + (Fecha.getMonth() + 1) + "/" + Fecha.getFullYear());
        var sep = sFecha.indexOf('/') != -1 ? '/' : '-';
        var aFecha = sFecha.split(sep);
        var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
        fecha = new Date(fecha);
        fecha.setDate(fecha.getDate() + parseInt(d));
        var anno = fecha.getFullYear();
        var mes = fecha.getMonth() + 1;
        var dia = fecha.getDate();
        mes = (mes < 10) ? ("0" + mes) : mes;
        dia = (dia < 10) ? ("0" + dia) : dia;
        var fechaFinal = dia + sep + mes + sep + anno;
        return (fechaFinal);
    };

    var number_format = function (number, decimals, dec_point, thousands_sep) {
        // *     example 1: number_format(1234.56);
        // *     returns 1: '1,235'
        // *     example 2: number_format(1234.56, 2, ',', ' ');
        // *     returns 2: '1 234,56'
        // *     example 3: number_format(1234.5678, 2, '.', '');
        // *     returns 3: '1234.57'
        // *     example 4: number_format(67, 2, ',', '.');
        // *     returns 4: '67,00'
        // *     example 5: number_format(1000);
        // *     returns 5: '1,000'
        // *     example 6: number_format(67.311, 2);
        // *     returns 6: '67.31'
        // *     example 7: number_format(1000.55, 1);
        // *     returns 7: '1,000.6'
        // *     example 8: number_format(67000, 5, ',', '.');
        // *     returns 8: '67.000,00000'
        // *     example 9: number_format(0.9, 0);
        // *     returns 9: '1'
        // *    example 10: number_format('1.20', 2);
        // *    returns 10: '1.20'
        // *    example 11: number_format('1.20', 4);
        // *    returns 11: '1.2000'
        // *    example 12: number_format('1.2000', 3);
        // *    returns 12: '1.200'
        var n = !isFinite(+number) ? 0 : +number,
            prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
            sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
            dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
            toFixedFix = function (n, prec) {
                // Fix for IE parseFloat(0.55).toFixed(0) = 0;
                var k = Math.pow(10, prec);
                return Math.round(n * k) / k;
            },
            s = (prec ? toFixedFix(n, prec) : Math.round(n)).toString().split('.');
        if (s[0].length > 3) {
            s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
        }
        if ((s[1] || '').length < prec) {
            s[1] = s[1] || '';
            s[1] += new Array(prec - s[1].length + 1).join('0');
        }
        return s.join(dec);
    };

    return {
        init: function (parametros) {
            if (parametros) {
                _mensajeEspera = parametros.mensajeEspera;
                _tituloPopupMensaje = parametros.tituloPopupMensaje;
                _tituloPopupComfirmacion = parametros.tituloPopupComfirmacion;
                _mensajePopupConfirmacion = parametros.mensajePopupConfirmacion;
                _btnCancelar = parametros.btnCancelar;
                _btnAceptar = parametros.btnAceptar;
                _codigoIdioma = parametros.codigoIdioma;
                _formatoFecha = parametros.formatoFecha;
                _unAuthorizedState = parametros.unAuthorizedState;
                
                if (!_toolbar.nuevoText)
                    _toolbar.nuevoText = (parametros.toolbar!=undefined)? parametros.toolbar.nuevoText:'';
                if (!_toolbar.editarText)
                    _toolbar.editarText = (parametros.toolbar!=undefined)? parametros.toolbar.editarText:'';
                if (!_toolbar.eliminarText)
                    _toolbar.eliminarText = (parametros.toolbar != undefined) ? parametros.toolbar.eliminarText : '';
                if (!_toolbar.imprimirText)
                    _toolbar.imprimirText = (parametros.toolbar != undefined) ? parametros.toolbar.imprimirText : '';
            }
            uiInit(); // Initialize UI Code
            primaryNav(); // Primary Navigation functionality
            secondNav(); // Second Navigation functionality
            activarNav(); // Activar Menúes
            scrollToTop(); // Scroll to top functionality
            formValidBootstrap();
            createLoading();
            createMessageDialog();
            createConfirmDialog();
            authorizedFunctionHandler();
            verifyPageAuthorization();
        },
        getDataForm: getDataForm,
        showLoading: function () {
            $('#' + _popupEspera).modal("show");
        },
        hideLoading: function () {
            $('#' + _popupEspera).modal("hide");
        },
        showMessageDialog: function (message, fnAceptar) {
            $('#' + _popupMensaje + ' .modal-body').html(message);
            $('#' + _popupMensaje).modal('show');

            if ($.isFunction(fnAceptar)) {
                $('#' + _popupMensaje + ' .btn-aceptar').off('click');
                $('#' + _popupMensaje + ' .close').off('click');
                $('#' + _popupMensaje + ' .btn-aceptar').on('click', fnAceptar);
                $('#' + _popupMensaje + ' .close').on('click', fnAceptar);
            }
        },
        showConfirmDialog: function (fnSuccess, message, fnCancel) {
            var popup = $('#' + _popupConfirmacion);
            var btnSuccess = $(popup).find('.btn-primary');
            var btnCancel = $(popup).find('.btn-danger');

            btnSuccess.off('click');
            if ($.isFunction(fnSuccess)) {
                btnSuccess.on('click', function () { fnSuccess(); })
            }

            btnCancel.off('click');
            if ($.isFunction(fnCancel)) {
                btnCancel.on('click', function () { fnCancel(); })
            }

            if (message != null && message != '') {
                $('#' + _popupConfirmacion + ' .modal-body p').text(message);
            } else {
                $('#' + _popupConfirmacion + ' .modal-body p').text(_mensajePopupConfirmacion);
            }

            popup.modal('show');
        },
        formatResponse: function (respuesta, contenedor) {
            var estado = "";
            if (respuesta.Success) {
                if (!respuesta.Warning) {
                    estado = "alert-success";
                }
            } else {
                estado = "alert-danger";
            }
            $("#" + contenedor).append("<div class='alert " + estado + "'>" + respuesta.Message + "</div>");
        },
        clearResponse: function (contenedor) {
            $("#" + contenedor).html('');
        },
        clearForm: function (form) {

            $('#' + form).find('[name]').each(function (index, value) {
                var that = $(this);
                var name = that.attr('name');
                var value = that.val();

                if (that.attr('type') === 'radio') {
                    if (that.is(':checked')) {
                        that.attr('checked', false)
                    }
                } else if (that.attr('type') === 'checkbox') {
                    if (that.is(':checked')) {
                        that.attr('checked', false)
                    }
                } else {
                    that.val('');
                }
            });
        },
        Ajax: function (opciones, successCallback, failureCallback, errorCallback) {

            if (opciones.url == null)
                opciones.url = "";

            if (opciones.parametros == null)
                opciones.parametros = {};

            if (opciones.async == null)
                opciones.async = true;

            if (opciones.datatype == null)
                opciones.datatype = "json";

            if (opciones.contentType == null)
                opciones.contentType = "application/json; charset=utf-8";

            if (opciones.type == null)
                opciones.type = "POST";

            $.ajax({
                type: opciones.type,
                url: opciones.url,
                contentType: opciones.contentType,
                dataType: opciones.datatype,
                async: opciones.async,
                data: opciones.datatype == "json" ? JSON.stringify(opciones.parametros) : opciones.parametros,
                success: function (response) {
                    if (successCallback != null && typeof (successCallback) == "function")
                        successCallback(response);
                },
                failure: function (msg) {
                    alert(msg);
                    if (failureCallback != null && typeof (failureCallback) == "function")
                        failureCallback(msg);
                },
                error: function (xhr, status, error) {
                    alert(error);
                    if (errorCallback != null && typeof (errorCallback) == "function")
                        errorCallback(xhr);
                }
            });
        },
        toolbarClick: toolbarClick,
        actionComplete: function (args) {
            var that = this;
            removeFilterStatusBar(args, that);
            agregarTextosBotonesToolbar(that);
        },
        setToolbarOptionText: function (toolbar) {
            setToolbarOptionText(toolbar);
        },
        initGrid: function (parametros) {
            mensajeSeleccionarRegistro = parametros.mensajeSeleccionarRegistro;
            toolbarActions = parametros.toolbarActions;
        },
        accionSubmitForm: accionSubmitForm,
        toolbarChangeText: function (parametros) {
            if (!_toolbar.nuevoText)
                _toolbar.nuevoText = (parametros.add != undefined) ? parametros.add.name : '';
            if (!_toolbar.editarText)
                _toolbar.editarText = (parametros.edit != undefined) ? parametros.edit.name : '';
            if (!_toolbar.eliminarText)
                _toolbar.eliminarText = (parametros.delete != undefined) ? parametros.delete.name : '';
            if (!_toolbar.imprimirText)
                _toolbar.imprimirText = (parametros.printGrid != undefined) ? parametros.printGrid.imprimirText : '';

        },
        ExportarExcel: function (url) {
            
            exportarExcel(url);
        },
        gridRemoveFilterBar: function () {
            $("#" + this._id + " .e-filterbar").remove();
        },
        disableAllFormElements: disableAllFormElements,
        mayuscula: mayuscula,
        sumaFecha: sumaFecha,
        number_format: number_format
    }
}();

function getCookie(name) {
    var pairs = document.cookie.split("; "),
        count = pairs.length,
        parts;
    while (count--) {
        parts = pairs[count].split("=");
        if (parts[0] === name)
            return parts[1];
    }
    return false;
}

function delCookie(name) {
    var date = new Date();
    date.setDate(date.getDate() - 1);
    document.cookie = name + "=" + '=;expires=' + date + "; path=/";
}
