;(function () {

    var FollowWindow = Auto.FollowWindow = function (options) {
        options || (options = {});
        this.initialize.apply(this, arguments);
    };

    _.extend(FollowWindow.prototype, {
        initialize: function (options) {
            this.handleEvents();
        },

        handleEvents: function () {
            // handles follow link clicks / hovers
            //$('#follow-trigger').on('click', function (e) {
            //    e.preventDefault();
            //    return false;
            //});
           
		// OPEN SHARE CONTAINER 	
		//$('#follow-trigger').on('mouseover',function () {
		//    $('#follow-container').show();
	    //});
	    
		// CLOSE SHARE CONTAINER 
	    //$('#main-share').on('mouseleave',function () {
		// $('#follow-container').hide();
	    //}); 
		
        }
    });

}).call(this);

