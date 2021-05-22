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


//$(window).on("load", function () {
//    $(".preload").fadeOut(1000);
//});


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

$(function () {
/* $(".DesignerComponent").parents(".row").show();*/
    let count = 0;
    $(".row").children().hide();
    let f = $(".row > :nth-child(2), .row > :nth-child(1)");
    f.show();
    let b = $(".LoadMore");
    b.show();

    document.getElementById("look").addEventListener("click", myFunction);
    document.getElementById("look2").addEventListener("click", myFunction01);
    document.getElementById("look3").addEventListener("click", myFunction02);
    document.getElementById("look4").addEventListener("click", myFunction03);
})

function myFunction() {
    f = $("#row01 > :nth-child(2), #row01 > :nth-child(1) , #row01 > :nth-child(3), #row01 > :nth-child(4)");
    f.show();
}
function myFunction01() {
    f = $("#row02 > :nth-child(2), #row02 > :nth-child(1) , #row02 > :nth-child(3), #row02 > :nth-child(4)");
    f.show();
}
function myFunction02() {
    f = $("#row03 > :nth-child(2), #row03 > :nth-child(1) , #row03 > :nth-child(3), #row03 > :nth-child(4)");
    f.show();
}
function myFunction03() {
    f = $("#row04 > :nth-child(2), #row04 > :nth-child(1) , #row04 > :nth-child(3), #row04 > :nth-child(4)");
    f.show();
}



function loadData() {
    return new Promise((resolve, reject) => {
        // setTimeout не является частью решения
        // Код ниже должен быть заменен на логику подходящую для решения вашей задачи
        setTimeout(resolve, 2000);
    })
}

loadData()
    .then(() => {
        let preloaderEl = document.getElementById('preloader');
        preloaderEl.classList.add('hidden');
        preloaderEl.classList.remove('visible');
    });












