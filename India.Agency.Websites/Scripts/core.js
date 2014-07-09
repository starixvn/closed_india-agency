/* File Created: July 8, 2014 */
/* global Namespace, India, moment */
'use strict';

Namespace.Register("India.Agency.Core");
India.Agency.Core = function () {
    var $this = this;

    // Common formats.
    $this.Formats = {
        DateFormat: 'MM/DD/YYYY',
        FullDateFormat: 'MM/DD/YYYY hh:mm:ss A',
        MonthFormat: 'MM-YYYY',
        DecimalFormat: '0,0.00',
        PercentageFormat: '0,0.00%',
        IntegerFormat: '0,0',
        EmptyStringFormat: '---'
    };

    // Settings for Javascript using purpose.
    $this.AppSettings = {};

    // Default page size values
    $this.PageSizes = [10, 20, 50, 100, 500];
    $this.DefaultPageSize = 50;

    // Auto refresh intervals.
    $this.AutoRefreshIntervals = [15, 30, 45, 60, 75];

    // Resolve URL.
    $this.ResolveUrl = function (url) {
        var rootUrl = this.AppSettings.RootUrl;

        if (url.substr(0, 2) === '~/') {
            url = url.substr(2);
        } else if (url.substr(0, 1) === '/') {
            url = url.substr(1);
        }

        return rootUrl + url;
    };

    // Block the whole page when making a request to server.
    $this.BlockUI = function () {
        if ($('div.block-overlay').length === 0) {
            $('body').append('<div class="block-overlay"></div>');
            $('body').append('<div class="block-loading"></div>');
        }

        $('div.block-overlay').show();
        $('div.block-loading').show();
    };

    // Unload the page.
    $this.UnblockUI = function () {
        $('div.block-overlay').hide();
        $('div.block-loading').hide();
    };

    // Scroll to the top of document.
    $this.ScrollTop = function () {
        $('html, body').animate({ scrollTop: 0 }, "fast");
    };

    // Scroll to a specific element.
    $this.ScrollTo = function (element) {
        var viewportHeight = $(window).height(),
            $element = $(element),
            elHeight = $element.height(),
            elOffset = $element.offset();

        $('html, body').animate({ scrollTop: elOffset.top + (elHeight / 2) - (viewportHeight / 2) }, 'fast');
    };

    // Check whether the page is scrolled into the middle of an element.
    $this.IsScrolledIntoView = function (element) {
        var $element = $(element),
            $window = $(window),
            docViewTop = $window.scrollTop(),
            docViewBottom = docViewTop + $window.height(),
            elementTop = $element.offset().top,
            elementBottom = elementTop + $element.height();

        return (elementBottom <= docViewBottom) && (elementTop >= docViewTop);
    };

    // Show error message.
    $this.ShowErrorMsg = function (message) {
        // @@TODO: Implement.
    };

    // Show information message.
    $this.ShowInfoMsg = function (message) {
        // @@TODO: Implement.
    };

    // Show confirmation popup.
    $this.ShowConfirmMsg = function (message, callbackFunction) {
        // @@TODO: Implement.
    };

    $this.HideMsg = function () {
        // @@TODO: Implement.
    };

    // Get parameter's value by its name from query string.
    $this.GetParameterByName = function (name) {
        var regex = new RegExp('[\\?&]{0}=([^&#]*)'.format(name)),
            results = regex.exec(location.search);

        return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
    };

    // Remove a parameter from query string.
    $this.RemoveUrlParameter = function (url, parameter) {
        var urlParts = url.split('?'),
            parameterName,
            parameters;

        if (urlParts.length >= 2) {
            parameters = urlParts[1].split(/[&;]/g);
            parameterName = encodeURIComponent(parameter) + '+';

            for (var index = parameters.length; index-- > 0; ) {
                if (parameters[index].lastIndexOf(parameterName, 0) !== -1) {
                    parameters.splice(index, 1);
                }
            }

            url = urlParts[0] + '?' + parameters.join('&');
        }

        return url;
    };

    // Encode error messages.
    $this.EncodeMessages = function (messages) {
        var messageArray = [],
            message;

        for (var index = 0; index < messages.length; index++) {
            message = messages[index];
            messageArray.push(message.ErrCode.toString());
            messageArray.push(message.ErrMsg);
        }
        return encodeURIComponent(messageArray.join('|'));
    };

    // Decode error messages.
    $this.DecodeMessages = function (message) {
        var messageArray = decodeURIComponent(message).split('|'),
            length = messageArray.length / 2,
            messages = [],
            errCode,
            errMsg;

        if (messageArray.length % 2 !== 0) {
            return message;
        }

        for (var i = 0; i < length; i++) {
            errCode = parseInt(messageArray[i * 2]);
            errMsg = messageArray[i * 2 + 1];
            messages.push({
                ErrCode: errCode,
                ErrMsg: errMsg
            });
        }

        return messages;
    };

    // Initialize common tasks.
    $this.Initialize = function () {
        $this.AppSettings = window.appSettings || window.parent.window.appSettings;
        $this.AppSettings.EnableReCheckIn = false;
        $this.AppSettings.ReloadInterval = 3000;

        // Customize scrollbars.
        if ($.fn.niceScroll) {
            $('html').niceScroll({
                cursorcolor: "#8a8a8a",
                autohidemode: false
            });

            $('body').mutate('height width', function () {
                $('html').getNiceScroll().resize();
            });
        }

        // Setup Select2 for dropdown list.
        if ($.fn.select2) {
            $('select.select2').select2();
        }

        // Set language for MomentJs and Fanex.Grid.
        if (typeof moment !== 'undefined') {
            moment.lang($this.AppSettings.SelectedLanguage.toLowerCase());
        }

        if (window.language) {
            window.language.Initialize($this.AppSettings.SelectedLanguage);
        }

        if ($.fn.fanexGrid) {
            $.fn.fanexGrid.defaults.scrollWidth = 24;
            $.fn.fanexGrid.defaults.language = $this.AppSettings.SelectedLanguage;
            $.fn.fanexGrid.defaults.timeZone = $this.AppSettings.ServerUtcOffset;
        }

        if ($this.AppSettings.EnableReCheckIn && window.frames['MainContent']) {
            setTimeout(reCheckIn, 3000);
        }
    };

    // Re-check in.
    var reCheckIn = function () {
        $.ajax({
            type: 'POST',
            url: $this.ResolveUrl('~/Account/ReCheckIn'),
            dataType: 'json',
            async: true,
            timeout: 120000
        }).done(function (result) {
            if (result.ErrCode !== 0) {
                // @@TODO: Display error.
            } else {
                setTimeout(reCheckIn, 30000); // Re-check in evevery 30s.
            }
        });
    };
};

var core = new India.Agency.Core();

$(document).ready(function () {
    core.Initialize();
});