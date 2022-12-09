// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const checkInput = () => {
    var value = document.getElementById("weightInput").value
    if (value > 39) {
        document.getElementById("weightInput").value = 39;
        alert("The specified value have to be below 40")
    }
}