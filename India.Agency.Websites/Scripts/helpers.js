/* File Created: July 10, 2014 */
/* global Namespace, India, moment, core */
/* exported helpers */
'use strict';

Namespace.Register("India.Agency.Helpers");
India.Agency.Helpers = function () {
    var $this = this;

    $this.CreateDatePicker = function ($element, options) {
        var configOptions = {
            pickTime: false,
            useCurrent: false,
            language: core.AppSettings.SelectedLanguage
        };

        options = options || {};

        if ($element) {
            if (options.defaultDate) {
                configOptions.defaultDate = moment(options.defaultDate);
            }

            if (options.minDate) {
                configOptions.minDate = options.minDate;
            }

            if (options.maxDate) {
                configOptions.maxDate = options.maxDate;
            }

            $element.children('input').attr('disabled', true);
            $element.datetimepicker(configOptions);
        }
    };

    $this.CreateDateRangePicker = function ($fromElement, $toElement, options) {
        var configOptions = {
            pickTime: false,
            useCurrent: false,
            language: core.AppSettings.SelectedLanguage
        };

        options = options || {};

        if ($fromElement && $toElement) {
            if (options.minDate) {
                configOptions.minDate = options.minDate;
            }

            if (options.maxDate) {
                configOptions.maxDate = options.maxDate;
            }

            if (options.fromDefaultDate) {
                configOptions.defaultDate = moment(options.fromDefaultDate);
            }

            $fromElement.children('input').attr('disabled', true);
            $fromElement.datetimepicker(configOptions);

            if (options.toDefaultDate) {
                configOptions.defaultDate = moment(options.toDefaultDate);
            }

            $toElement.children('input').attr('disabled', true);
            $toElement.datetimepicker(configOptions);

            $fromElement.on("dp.change", function (e) {
                $toElement.data("DateTimePicker").setMinDate(e.date);
            });
            $toElement.on("dp.change", function (e) {
                $fromElement.data("DateTimePicker").setMaxDate(e.date);
            });
        }
    };
};

var helpers = new India.Agency.Helpers();