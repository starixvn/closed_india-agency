/* File Created: July 9, 2014 */
/* global Namespace, India, core, language */
'use strict';

Namespace.Register("India.Agency.CustomerList");
India.Agency.CustomerList = function () {
    var $this = this;

    var domElements = {
        txtUsername: null,
        ddlStatus: null,
        dpkDate: null,
        btnSearch: null,
        divBreadcrumb: null,
        divCustomerListContainer: null,
        divCustomerList: null
    };

    // Cache DOM elements.
    var cacheDomElements = function () {
        domElements.txtUsername = $('#txtUsername');
        domElements.ddlStatus = $('#ddlStatus');
        domElements.dpkDate = $('#dpkDate');
        domElements.btnSearch = $('#btnSearch');
        domElements.divBreadcrumb = $('#divBreadcrumb');
        domElements.divCustomerListContainer = $('#divCustomerListContainer');
        domElements.divCustomerList = $('#divCustomerList');
    };

    // Initialize fields, bind event handlers if there is any.
    var intitializeFields = function () {
        // Enter on Username textbox takes the same action as clicking on Search button.
        domElements.txtUsername.on('keyup.india-agency', function () {
            domElements.btnSearch.click();
        });

        // Initialize date picker.
        domElements.dpkDate.datetimepicker({
            pickTime: false,
            language: core.AppSettings.SelectedLanguage
        });

        // Handle click event on Search button.
        domElements.btnSearch.on('click.india-agency', function () {
            renderCustomerList();
        });
    };

    // Render customer list.
    var renderCustomerList = function () {
        var gridOptions = {
            columns: [{ HeaderText: '#', Width: 70, Name: 'ColNo', HeaderAlign: 'center', CellAlign: 'center' },
                      { HeaderText: language.GetString('Action'), Width: 100, Name: 'ColAction', HeaderAlign: 'center', CellAlign: 'center' },
                      { HeaderText: language.GetString('Username'), Width: 300, Name: 'ColUsername', HeaderAlign: 'center', CellAlign: 'left' },
                      { HeaderText: language.GetString('Status'), Width: 100, Name: 'ColStatus', HeaderAlign: 'center', CellAlign: 'right' },
                      { HeaderText: language.GetString('Downlines'), Width: 100, Name: 'ColDownlines', HeaderAlign: 'center', CellAlign: 'center' },
                      { HeaderText: language.GetString('TotalOfMembers'), Width: 100, Name: 'ColTotalOfMembers', HeaderAlign: 'center', CellAlign: 'right',
                          FormatNumber: core.Formats.IntegerFormat
                      },
                      { HeaderText: language.GetString('GivenCredit'), Width: 100, Name: 'ColGivenCredit', HeaderAlign: 'center', CellAlign: 'right',
                          FormatNumber: core.Formats.DecimalFormat
                      },
                      { HeaderText: language.GetString('UsedCredit'), Width: 100, Name: 'ColUsedCredit', HeaderAlign: 'center', CellAlign: 'right',
                          FormatNumber: core.Formats.DecimalFormat
                      }],
            gridExpandHeight: 180,
            showNumberColumn: true,
            showPager: true,
            pagerOption: {
                currentPage: 0,
                itemsPerPage: core.DefaultPageSize,
                itemsPerPageArray: core.PageSizes
            }
        };
        var bodyData = [];
        var row;

        row = {
            Columns: [{ Name: 'ColNo', Value: 1 },
                      { Name: 'ColAction', Value: '<span></span>' },
                      { Name: 'ColUsername', Value: 'Test123' },
                      { Name: 'ColStatus', Value: 'Closed' },
                      { Name: 'ColDownlines', Value: '12' },
                      { Name: 'ColTotalOfMembers', Value: 1234 },
                      { Name: 'ColGivenCredit', Value: 100000000 },
                      { Name: 'ColUsedCredit', Value: 100000000}]
        };
        bodyData.push(row);

        gridOptions.bodyRows = bodyData;
        domElements.divCustomerListContainer.removeClass('hide');
        domElements.divCustomerList.fanexGrid(gridOptions);
    };

    // Initialize page.
    $this.Initialize = function () {
        cacheDomElements();
        intitializeFields();
    };
};

$(document).ready(function () {
    var customerList = new India.Agency.CustomerList();

    customerList.Initialize();
});