/* File Created: July 9, 2014 */
/* global Namespace, India, core */
'use strict';

Namespace.Register("India.Agency.Language");
India.Agency.Language = function () {
    var $this = this;
    var defaultLanguageCode = 'en-US';
    var selectedLanguage = null;

    // Get value of a value from a resource object.
    $this.GetResourceString = function (object, key) {
        var languageObject = object[selectedLanguage];
        var value = languageObject[key.toString()];

        if (!value) {
            value = languageObject[defaultLanguageCode];
        }

        if (!value) {
            value = key;
        }

        return value;
    };

    // Get language object.
    $this.GetLanguageObject = function () {
        return $this.Labels[selectedLanguage];
    };

    // Get string value of a key.
    $this.GetString = function (key) {
        if (key) {
            return $this.GetResourceString($this.Labels, key);
        } else {
            return key;
        }
    };

    // Initialize selected language.
    $this.Initialize = function (language) {
        selectedLanguage = language || defaultLanguageCode;
    };
};

var language = new India.Agency.Language();