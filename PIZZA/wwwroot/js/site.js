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

document.body.onload = function () {
    setTimeout(function () {
        var preloader = document.getElementById('page_preloader');
        if (!preloader.classList.contains('done')) {
            preloader.classList.add('done');
        }
    }, 5000);
}






