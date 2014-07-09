/* File Created: July 8, 2014 */
/* global Namespace, India, core, moment */
'use strict';

Namespace.Register("India.Agency.Layout");
India.Agency.Layout = function () {
    var $this = this;
    var mainContentLeft = 230;

    var domElements = {
        spanServerTime: null,
        spanTimezone: null,
        spanCollapse: null,
        ulTopMenus: null,
        divRightPanel: null,
        ifrMainContent: null
    };

    // Cache DOM elements.
    var cacheDomElements = function () {
        domElements.spanServerTime = $('#spanServerTime');
        domElements.spanTimezone = $('#spanTimezone');
        domElements.spanCollapse = $('#spanCollapse');
        domElements.ulTopMenus = $('#ulTopMenus');
        domElements.divRightPanel = $('#divRightPanel');
        domElements.ifrMainContent = $('#ifrMainContent');
    };

    // Initialize fields, bind event handlers if there is any.
    var intitializeFields = function () {
        var loadedUrl = domElements.ifrMainContent.attr('src');
        var $menus = domElements.ulTopMenus.children();

        // Highlight menu which has the URL is loaded to the iframe.
        $menus.each(function () {
            var isHighlighted = false;
            var $menu = $(this);

            $menu.removeClass('current');
            $menu.find('a').each(function () {
                if ($(this).attr('href') === loadedUrl) {
                    isHighlighted = true;
                }
            });

            if (isHighlighted) {
                $menu.addClass('current');
                return;
            }
        });

        // Highlight the clicked menu.
        $menus.each(function () {
            var $menu = $(this);

            $menu.find('a').on('click.india-agency', function () {
                if ($(this).attr('href') !== '#') {
                    $menus.removeClass('current');
                    $menu.addClass('current');
                }
            });
        });

        // Set server time indicator value.
        domElements.spanTimezone.text(getTimezone());
        setInterval(updateServerTimeIndicator, 250);

        // Bind event handler for Collapse/Expand button.
        domElements.spanCollapse.on('click.india-agency', function () {
            toggleLeftPanel();
        });
    };

    // Update server time indicator.
    var updateServerTimeIndicator = function () {
        var currentTime = moment().format(core.Formats.FullDateFormat);

        domElements.spanServerTime.text(currentTime);
    };

    // Get GMT timezone.
    var getTimezone = function () {
        var timezone = core.AppSettings.ServerUtcOffset;
        var prefixTimezone = '';

        if (timezone) {
            prefixTimezone = timezone[0];
            timezone = parseInt(timezone.substr(1, 2));
        }

        return prefixTimezone + timezone;
    };

    // Collapse/Expand left panel.
    var toggleLeftPanel = function () {
        var left = 0;

        if (domElements.divRightPanel.offset().left !== mainContentLeft) {
            left = mainContentLeft;
            domElements.spanCollapse.removeClass('active');
        } else {
            domElements.spanCollapse.addClass('active');
        }

        domElements.divRightPanel.animate({
            left: '{0}px'.format(left)
        }, 'fast');
    };

    // Initialize page.
    $this.Initialize = function () {
        cacheDomElements();
        intitializeFields();
    };
};

$(document).ready(function () {
    var layout = new India.Agency.Layout();

    layout.Initialize();
});