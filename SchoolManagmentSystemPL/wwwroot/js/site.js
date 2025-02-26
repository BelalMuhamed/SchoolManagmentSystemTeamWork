// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script src="~/lib/jquery/dist/jquery.js"></script>

$(document).ready(function () {
    $("#searchinput").keyup(function () {
        var searchValue = $(this).val().trim();

        if (searchValue.length > 0) {
            $.ajax({
                url: "/Student/Index",
                type: "GET",
                data: { searchitem: searchValue },
                success: function (data) {
                    $("#result").html(data);
                },
                error: function () {
                    $("#result").html("<tr><td colspan='10' class='text-danger text-center'>Cannot get data</td></tr>");
                }
            });
        } else {
            location.reload();
        }
    });
});

//function confirmDelete(userId) {
//    Swal.fire({
//        title: "Are you sure?",
//        text: "You won't be able to revert this!",
//        icon: "warning",
//        showCancelButton: true,
//        confirmButtonColor: "#d33",
//        cancelButtonColor: "#3085d6",
//        confirmButtonText: "Yes, delete it!"
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: '/Student/Delete?UserId=' + userId, 
//                type: 'DELETE', 
//                success: function (response) {
//                    if (response.success) {
//                        Swal.fire("Deleted!", response.message, "success").then(() => {
//                            $("#row-" + userId).remove(); 
//                        });
//                    } else {
//                        Swal.fire("Error!", response.message, "error");
//                    }
//                },
//                error: function () {
//                    Swal.fire("Error!", "Something went wrong.", "error");
//                }
//            });
//        }
//    });
//}
