// Write your JavaScript code.

$("#grid").DataTable({
    "serverSide": true,
    "filter": true,
    "orderMulti": false,
    "ajax": {
        "url": "Home/GetCustomers",
        "type": "POST",
        "contentType": "application/json",
        "dataType": "json"
    },
    "columndefs": [{
        "targets": [0],
        "visible": false,
        "searchable": false
    }],
    "columns": [
        { "data": "Id", "name": "Id", "autoWidth": true },
        { "data": "FirstName", "name": "FirstName", "autoWidth": true },
        { "data": "LastName", "name": "LastName", "autoWidth": true },
        { "data": "Email", "name": "Email", "autoWidth": true },
        { "render": function(data, type, row) {
            return '<a class="btn btn-primary" onclick="UpdateRecord(' + row + ')">Update</a>';
        }
        },
        { "render": function(data, type, row) {
            return '<a class="btn btn-danger" onclick=DeleteRecord(' + row + ')">Delete</a>';
        }}
        ]
});

$("#submitCustomer").click(function () {
    var dataType = 'application/x-www-form-urlencoded; charset-utf-8';
    var data = $('form').serialize();

    $.ajax({
        type: 'POST',
        url: 'Home/Post',
        contentType: dataType,
        data: data
    });

    ReloadCustomerComponent();
});

function DeleteRecord(customer) {
    $.ajax({
        type: 'DELETE',
        url: 'Home/Delete',
        data: customer
    });

    ReloadCustomerComponent();
}

function UpdateRecord(customer) {
    $.ajax({
        type: 'PUT',
        url: 'Home/Put',
        data: customer
    });

    ReloadCustomerComponent();
}

function ReloadCustomerComponent() {
    $.get({
        url: 'Home/CustomerListViewComponent'
    });
}