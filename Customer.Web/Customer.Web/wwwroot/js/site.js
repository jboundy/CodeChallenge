var grid, dialog;

function Edit(e) {
    $('#Id').val(e.data.id);
    $('#FirstName').val(e.data.record.FirstName);
    $('#LastName').val(e.data.record.LastName);
    $('#Email').val(e.data.record.Email);
    dialog.open('Edit Customer');
}

function Delete(e) {
    if (confirm('Are you sure?')) {
        $.ajax({ url: 'Home/Delete', data: { id: e.data.id }, method: 'DELETE' })
            .done(function () {
                grid.reload();
            })
            .fail(function () {
                alert('Failed to delete.');
            });
    }
}

grid = $('#grid').grid({
    primaryKey: 'id',
    dataSource: 'Home/GetCustomers',
    columns: [
        { field: 'id', title: 'Customer Id' },
        { field: 'firstName', title: 'First Name' },
        { field: 'lastName', title: 'Last Name' },
        { field: 'email', title: 'Email' },
        {
            width: 64,
            tmpl: '<span class="material-icons gj-cursor-pointer">edit</span>',
            align: 'center',
            events: { 'click': Edit }
        },
        {
            width: 64,
            tmpl: '<span class="material-icons gj-cursor-pointer">delete</span>',
            align: 'center',
            events: { 'click': Delete }
        }
    ]
});

dialog = $('#dialog').dialog({
    autoOpen: false,
    resizable: false,
    modal: true,
    width: 360
});

$('#btnUpdate').on('click', function (e) {
    console.log(e.data);
    var record = {
        Id: $('#Id').val(),
        FirstName: $('#dialog').find('#FirstName').val(),
        LastName: $('#dialog').find('#LastName').val(),
        Email: $('#dialog').find('#Email').val()
    };

    console.log(record);
    $.ajax({ url: 'Home/Update', data: record, method: 'PUT' })
        .done(function () {
            dialog.close();
            grid.reload();
        })
        .fail(function () {
            alert('Failed to save.');
            dialog.close();
        });
});

$('#btnCancel').on('click', function () {
    dialog.close();
});

$("#submitCustomer").click(function () {
    var dataType = 'application/x-www-form-urlencoded; charset-utf-8';
    var data = $('form').serialize();

    $.ajax({ url: 'Home/Post', data: data, contentType: dataType, type: 'POST' })
        .done(function () {
            grid.reload();
        });
});