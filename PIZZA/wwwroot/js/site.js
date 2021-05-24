// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

jQuery(($) => {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 780) $('.to-up').fadeIn();
        else $('.to-up').fadeOut();
    });
    $('.to-up').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 566);
        return false;
    });
});


$(window).on("load", function () {
    $(".preload").fadeOut(1000);
});


function getName(str) {
    if (str.lastIndexOf('\\')) {
        var i = str.lastIndexOf('\\') + 1;
    }
    else {
        var i = str.lastIndexOf('/') + 1;
    }
    var filename = str.slice(i);
    var uploaded = document.getElementById("fileformlabel");
    uploaded.innerHTML = filename;
}

function AddPizzaToCast(id) {
    $.post("Home/AddPizzaToCast", {num: "10"})
};








