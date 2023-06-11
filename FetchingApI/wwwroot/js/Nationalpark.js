var dataTable;

$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "NationalPark/GetAll"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "state", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                      <div class="text-center">
                      <a href="NationalPark/Upsert/${data}" class="btn btn-success">
                      <i class="fas fa-edit"></i>
                      </a>
                      <a class="btn btn-success" onclick=Delete("NationalPark/Delete/${data}")>
                      <i class="fas fa-trash-alt"></i>
                      </a>
                      </div>
                    `;
                }
            }
        ]
    })
}
function Delete(url) {
    swal({
        title: "Want To Delete Data ?",
        text: "Delete Information !!!",
        buttons: true,
        icon: "warning",
        dangerModel: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}
