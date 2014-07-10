/* File Created: July 10, 2014 */
/* global Namespace, India */
'use strict';

Namespace.Register("India.Agency.Login");
India.Agency.Login = function () {
    var $this = this;

    // Initialize login page.
    $this.Initialize = function () {
    };
};

$(document).ready(function () {
    var login = new India.Agency.Login();

    login.Initialize();
});