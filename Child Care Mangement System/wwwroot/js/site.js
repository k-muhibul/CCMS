// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function selfClockIn(userId) {
    $.ajax({
        url: "/Carer/SelfClockIn",
        type: "POST",
        data: { UserId: userId },
        dataType: "json",
        success: function (response) {
            console.log(response)
            if (response.success == true) {
                alertify.success(response.message);
            }
            else {
                alertify.error(response.message)
            }
        },
        error: function (error) {
            console.error("Error:", error);
        }
    });

}