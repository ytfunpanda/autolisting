+function ($) {

    var MainNavigation = function (element, options) {
        this.options = options
        this.$element = $(element)
    };

    MainNavigation.prototype.toggle = function (e) {
        this.$element.hasClass('open') ? hideEl(this.$elemeng) : showEl(this.$element);
    };

    var old = $.fn.MainNavigation;

    $.fn.mainnavigation = function (option) {
        return this.each(function () {
            var $this = $(this)
            var data = $this.data('bs.MainNavigation')
            var options = $.extend({}, $this.data(), typeof option == 'object' && option)

            if (!data) $this.data('bs.MainNavigation', (data = new MainNavigation(this, options)));
            if (typeof option == 'string') data[option]();
        })
    };

    $.fn.mainnavigation.Constructor = MainNavigation;

    $.fn.mainnavigation.noConflict = function () {
        $.fn.mainnavigation = old;
        return this;
    };

    var hideOpen = function (currentTarget) {
        $(document).find('.open').each(function () {
            if (!currentTarget) {
                $(this).hide();
                $(this).removeClass('open');
            }
            if ('#' + $(this).attr('id') !== currentTarget) {
                $(this).hide();
                $(this).removeClass('open');
            }
        });
    };

    var hideEl = function (el) {
        el.removeClass('open');
        el.hide();
    };

    var showEl = function (el) {
        el.addClass('open');
        el.show();
    };

    var hideTimer = window.hideTimer;
    $(document).on('mouseover.bs.MainNavigation.data-api', '[data-mainnavigation=toggle]', function (e) {
        var target = $(this).attr('data-target');

        hideOpen();

        $(target).mainnavigation('toggle');
    });

    $(document).on('mouseout.bs.MainNavigation.data-api', '[data-mainnavigation=toggle]', function (e) {
        var target = $(this).attr('data-target');

        window.hideTimer = setTimeout(hideOpen, 20000);

        $(target).on('mouseenter', function () {
            clearTimeout(window.hideTimer);

            $(target).on('mouseleave', function () {
                hideOpen();
            });
        });
    });


} (window.jQuery);