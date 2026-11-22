
function togglePasswordVisibility(fieldId) {
    var field = document.getElementById(fieldId);
    if (field.type === "password") {
        field.type = "text";
    } else {
        field.type = "password";
    }
}


$(document).ready(function () {
    
    setTimeout(function () {
        $("#alertMessage").fadeOut("slow");
    }, 4000);

    
    $("#registerForm").on("submit", function (e) {
        var pwd = $("#Password").val();
        var confirmPwd = $("#ConfirmPassword").val();

        if (pwd !== confirmPwd) {
            e.preventDefault();
            alert("Error: Password and Confirm Password do not match.");
        }
    });
});