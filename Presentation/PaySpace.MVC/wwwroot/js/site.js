$(document).ready(function () {
    $('#btn-calc').on('click', function () {
        calc();
    });
});

var formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
});

function calc() {
    const apiUrl = 'https://localhost:44355/api/calc';
    const success = 'success';

    let postalCode = $('#postal-code').val();
    let income = parseFloat($('#anual-income').val());
    let payLoad = { postalCode: postalCode, income: income };

    $.ajax({
        type: "POST",
        url: apiUrl,
        data: JSON.stringify(payLoad),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).done(function (data, status) {
        cleanInputs();
        showData(data);
    }).fail(function (jqXHR) {
        cleanCalcData();
        alert(jqXHR.responseJSON.Message);
    });
}

function showData(data) {
    $('#label-date-time').text(new Date(data.date).toLocaleString('en-US'));
    $('#label-postal-code').text(data.postalCode);
    $('#label-income').text(formatter.format(data.income));
    $('#label-tax-value').text(formatter.format(data.taxValue));
}

function cleanCalcData() {
    $('#label-date-time').text("");
    $('#label-postal-code').text("");
    $('#label-income').text("");
    $('#label-tax-value').text("");
}

function cleanInputs() {
    $('#postal-code').val("");
    $('#anual-income').val("");
}