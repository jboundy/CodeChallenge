$(window).load(function() {
    $("#grid").dataTable({
        "processing": false,
        "serverSide": true,
        "filter": false,
        "orderMulti": false,
        "ajax": {
            "url": "Home/GetCustomers",
            "type": "POST"
        },
        "columndefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "id", "autoWidth": true },
            { "data": "firstName", "autoWidth": true },
            { "data": "lastName", "autoWidth": true },
            { "data": "email", "autoWidth": true },
            {
                "render": function (data, type, row) {
                    return "<a class='btn btn-primary' onclick=UpdateRecord('" + row + "');>Update</a>";
                }
            },
            {
                "render": function (data, type, row) {
                    return "<a class='btn btn-danger' onclick=DeleteRecord('" + row.id + "');>Delete</a>";
                }
            }
        ]
    });

    $('#grid').DataTable();
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

    ReloadTableComponent();
});

function DeleteRecord(row) {

    var customer = {Id: row}

    $.ajax({
        type: 'DELETE',
        url: 'Home/Delete',
        data: customer
    });

    ReloadTableComponent();
}

function UpdateRecord(row) {

    var customer = Object.values(row);
    console.log(customer);

    $.ajax({
        type: 'PUT',
        url: 'Home/Put',
        data: customer
    });

    ReloadTableComponent();
}

function ReloadTableComponent() {
    $('#grid').DataTable().ajax.reload();
}

function serializeCustomer(customer) {
    var customerObj = { Id: customer.id, FirstName: customer.fistName, LastName: customer.lastName, Email: customer.email }
    return customerObj;
}