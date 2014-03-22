(function () {

    // watch for specific hash's in the url and react accordingly.
    var watcher = new Auto.URLWatcher();

    var isMobile = {
        Android: function () {
            return navigator.userAgent.match(/Android/i) ? true : false;
        },
        BlackBerry: function () {
            return navigator.userAgent.match(/BlackBerry/i) ? true : false;
        },
        iOS: function () {
            return navigator.userAgent.match(/iPhone|iPod/i) ? true : false;
        },
        tablet: function () {
            return navigator.userAgent.match(/iPad/i) ? true : false;
        },
        Windows: function () {
            return navigator.userAgent.match(/IEMobile/i) ? true : false;
        },
        any: function () {
            return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Windows());
        }
    };


    window.isIE7 = function () {
        return $.browser.msie && parseInt($.browser.version) < 8
    }

    //    // if the request includes nomobile=1 then we will skip sending them to mobile.
    var query = window.location.search;
    if (isMobile.any()) {
        window.location.href = "http://m.domain.com";
    } else if (isIE7()) {
        window.location = '/sorry';
    } else {
        var followWindow = new Auto.FollowWindow();
        var configLauncher = new Auto.ConfigLauncher();
        var ccrcLauncher = new Auto.CCRCLauncher();
    }

    // IF IE 8 -- FILL IN PLACEHOLDER TEXT 
    if ($.browser.msie) {
        $('input[placeholder]').each(function () {
            var input = $(this);
            $(input).val(input.attr('placeholder'));
            $(input).focus(function () {
                if (input.val() == input.attr('placeholder')) { input.val(''); }
            });
            $(input).blur(function () {
                if (input.val() == '' || input.val() == input.attr('placeholder')) {
                    input.val(input.attr('placeholder'));
                }
            });
        });
    };
}).call(this);