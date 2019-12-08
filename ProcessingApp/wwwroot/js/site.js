// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#button").click(function () {
    $("#ajax").load("/ajax/getPartial");
})

$(function () {
    $('#query').autocomplete({
        source: "searchajax/autocomplete",
        minLength: 2,
        autoFocus: true
    });
});

