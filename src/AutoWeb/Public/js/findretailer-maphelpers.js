var MapHelpers = (function () {

    // builds the content portion of the info window.
    var buildInfoContent = function (retailerLocation, count) {
        var container = document.createElement("div");
        container.setAttribute('class', 'content');
        container.style.cssText = "font-size: 14px;";
        container.innerHTML = '<h3 style="margin-top:0">' + retailerLocation["Name"] + '</h3>' +
                        retailerLocation["Address"] + "<br />" +
                        retailerLocation["City"] + ", " + retailerLocation["Province"] + ", " + retailerLocation["Postal"] + "<br />" +
                        retailerLocation["RetailPhone"];

        return container;
    };
    
    // builds the html for the right side of the info window.
    var buildInfoButtons = function (retailerLocation, strings) {
        var container = document.createElement('div');
        container.setAttribute('class', 'buttons');
        container.appendChild(generateButton(strings.bookTestDriveLbl, { 'href': '#TestDrive', 'data-toggle': 'modal', 'id': 'mapBookTestDrive', 'class': 'mapBookTestDrive', 'onclick': '$("#TestDrive").modal({backdrop:"static",keyboard:false});', 'data-province-value': retailerLocation.ProvinceShort, 'data-retailer-number-value': retailerLocation.InternalRetailerID },'/Public/img/ico/buttons/testdrive.png'));
        container.appendChild(generateButton(strings.directionsLbl, { 'href': 'https://maps.google.com/maps?saddr=&daddr=' + encodeURIComponent(retailerLocation.Address) + ',+' + encodeURIComponent(retailerLocation.City) + ',+' + encodeURIComponent(retailerLocation.ProvinceShort) + ',+Canada&hl=en&z=14', 'target': '_blank' }, '/Public/img/ico/buttons/directions.png'));
        container.appendChild(generateButton(strings.serviceLbl, { 'href': '#serviceAppointmentModal', 'data-toggle': 'modal', 'id': 'mapServiceAppointment', 'class': 'mapServiceAppointment', 'onclick': '$("#serviceAppointmentModal").modal({backdrop:"static",keyboard:false})', 'data-province-value': retailerLocation.ProvinceShort, 'data-retailer-number-value': retailerLocation.InternalRetailerID }, '/Public/img/ico/buttons/scheduleservice.png'));
        container.appendChild(generateButton(strings.dealerSiteLbl, { 'href': retailerLocation.Website, target: '_blank' }, '/Public/img/ico/buttons/website.png'));

        return container;
    };

    var buildCCRCInfoContent = function (retailerLocation, count) {
        var container = document.createElement("div");
        container.setAttribute('class', 'content');
        container.style.cssText = "font-size: 14px;";
        container.innerHTML = '<h3 style="margin-top:0">' + retailerLocation["Name"] + '</h3>' +
                        retailerLocation["StreetAddress"] + "<br />" +
                        retailerLocation["City"] + ", " + retailerLocation["Province"] + ", " + retailerLocation["Postal"] + "<br />" +
                        retailerLocation["Telephone"];

        return container;
    };

    var buildCCRCInfoButtons = function (retailerLocation, strings) {
        var container = document.createElement('div');
        container.setAttribute('class', 'buttons');
        container.appendChild(generateButton(strings.directionsLbl, { 'href': 'https://maps.google.com/maps?saddr=&daddr=' + encodeURIComponent(retailerLocation.StreetAddress) + ',+' + encodeURIComponent(retailerLocation.City) + ',+' + encodeURIComponent(retailerLocation.ProvinceShort) + ',+Canada&hl=en&z=14', 'target': '_blank' }, '/Public/img/ico/buttons/directions.png'));

        return container;
    };

    var generateButton = function (text, attrs, imgSrc) {
        var linkButton = document.createElement('a');
        for (var attr in attrs) {
            linkButton.setAttribute(attr, attrs[attr]);
        }

        linkButton.setAttribute('class', 'btn btn-primary gradient-grey shadow btn-md btn-block ico-btn');

        var image = document.createElement('img');
        image.setAttribute('src', imgSrc);
        linkButton.appendChild(image);

        var content = document.createTextNode(text);
        linkButton.appendChild(content);

        return linkButton;
    };

    // closes all the info boxes in the infoBoxesArray
    var closeInfoBoxes = function (infoBoxes) {
        _.each(infoBoxesArray, function (ib) {
            ib.close();
        });
    };

    // closes all the info boxes in the infoBoxesArray
    var closeMarkers = function (markersArray) {
        _.each(markersArray, function (m) {
            m.setMap(null);
        });
    };

    // generates an event trigger to open the infobox from outside the map
    var generateTriggerCallback = function (object, eventType) {
        return function () {
            google.maps.event.trigger(object, eventType);
        };
    };

    // calculates the distance between 2 points
    // https://www.zipcodeworld.com/samples/distance.js.html
    var calculateDistance = function (lat1, lon1, lat2, lon2, unit) {
        var radlat1 = Math.PI * lat1 / 180
        var radlat2 = Math.PI * lat2 / 180
        var radlon1 = Math.PI * lon1 / 180
        var radlon2 = Math.PI * lon2 / 180
        var theta = lon1 - lon2
        var radtheta = Math.PI * theta / 180
        var dist = Math.sin(radlat1) * Math.sin(radlat2) + Math.cos(radlat1) * Math.cos(radlat2) * Math.cos(radtheta);
        dist = Math.acos(dist)
        dist = dist * 180 / Math.PI
        dist = dist * 60 * 1.1515
        if (unit == "K") { dist = dist * 1.609344 }
        if (unit == "N") { dist = dist * 0.8684 }
        return dist
    };

    var infoBoxesOpen = function (infoBoxesArray) {
        for (var i = 0; i < infoBoxesArray.length; i++) {
            var ib = infoBoxesArray[i];
            if (ib.getMap() != null) return true;
        }

        return false;
    };

    return {
        buildInfoButtons: buildInfoButtons,
        buildInfoContent: buildInfoContent,
        buildCCRCInfoButtons: buildCCRCInfoButtons,
        buildCCRCInfoContent: buildCCRCInfoContent,
        closeInfoBoxes: closeInfoBoxes,
        closeMarkers: closeMarkers,
        generateTriggerCallback: generateTriggerCallback,
        calculateDistance: calculateDistance,
        infoBoxesOpen: infoBoxesOpen
    };

})();