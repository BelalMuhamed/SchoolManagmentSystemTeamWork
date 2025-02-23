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
