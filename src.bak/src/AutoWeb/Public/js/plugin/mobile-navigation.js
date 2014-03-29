+function ($) {
  var open = false;

  var MobileNavigation = function (element, options) {
    this.options = options
    this.$element = $(element)
  };

  MobileNavigation.prototype.STATE = "CLOSED";

  MobileNavigation.prototype.open = function (e) {
    var target = this.$element;
    var that = this;
    if (this.STATE === 'CLOSED') {
      $(target).animate({
        right: "+=220"
      }, 500, function () {
        $('#burger').css('right', '220px');
        that.STATE = "OPEN";
      });
    }
  };

  MobileNavigation.prototype.close = function (e) {
    var target = this.$element;
    var that = this;
    if (this.STATE === 'OPEN') {
      $(target).animate({
        right: "-=220"
      }, 500, function () {
        $('#burger').css('right', '-10px');
        that.STATE = "CLOSED";
      });
    }


  };

  var old = $.fn.MobileNavigation;

  $.fn.mobilenavigation = function (option) {
    return this.each(function () {
      var $this = $(this)
      var data = $this.data('bs.MobileNavigation')
      var options = $.extend({}, $this.data(), typeof option == 'object' && option)

      if (!data) $this.data('bs.MobileNavigation', (data = new MobileNavigation(this, options)));
      if (typeof option == 'string') data[option]();
    })
  };

  $.fn.mobilenavigation.Constructor = MobileNavigation;

  $.fn.mobilenavigation.noConflict = function () {
    $.fn.mobilenavigation = old;
    return this;
  };

  $(document).on('click.bs.MobileNavigation.data-api', '[data-navigation=toggle]', function (e) {
    var $this = $(this);
    var target = $this.attr('data-target');
    var $target = $(target);

    $(target).mobilenavigation('close');
    $(target).mobilenavigation('open');

    e.preventDefault();
  });

} (window.jQuery);