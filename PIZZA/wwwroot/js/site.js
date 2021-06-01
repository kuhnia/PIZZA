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

var count = 1;
var ClasicPiza = 4;
var FirmPiza = 4;
var SeeFoodPiza = 4;
var VeganPiza = 4;



$(function () {
    $(".row").children().hide();
    let f = $('.row > :nth-child(' + count + '), .row > :nth-child(' + (count + 1) + '), .row > :nth-child(' + (count + 2) + ')');
    f.show();
    let b = $(".LoadMore");
    b.show();

    document.getElementById("look").onclick = function () {
        let f = $('.clasic > :nth-child(' + ClasicPiza + ') , .clasic > :nth-child(' + (ClasicPiza + 1) + ') , .clasic > :nth-child(' + (ClasicPiza + 2) +')');
        f.show();
        if (ClasicPiza > 8) { $("#look").fadeOut("slow"); }
        ClasicPiza += 3;
       
    };  

    document.getElementById("look2").onclick = function () {
        let f = $('.firm > :nth-child(' + FirmPiza + ') , .firm > :nth-child(' + (FirmPiza + 1) + ') , .firm > :nth-child(' + (FirmPiza+2) + ')');
        f.show();
        if (FirmPiza > 6) { $("#look2").fadeOut("slow"); }
        FirmPiza += 3;
       
    };  

    document.getElementById("look3").onclick = function () {
        let f = $('.seeFood > :nth-child(' + SeeFoodPiza + '), .seeFood > :nth-child(' + (SeeFoodPiza + 1) + ') , .seeFood > :nth-child(' + (SeeFoodPiza + 2) + ') ');
        f.show();
        if (SeeFoodPiza > 6) { $("#look3").fadeOut("slow"); }
        SeeFoodPiza += 3;
    }; 

    document.getElementById("look4").onclick = function () {
        let f = $('.vegan > :nth-child(' + VeganPiza + ') , .vegan > :nth-child(' + (VeganPiza + 1) + '), .vegan > :nth-child(' + (VeganPiza + 2) + ')');
        f.show();
        if (SeeFoodPiza > 4) { $("#look4").fadeOut("slow"); }
        VeganPiza += 3;
    };  
   
})



function loadData() {
    return new Promise((resolve, reject) => {
        setTimeout(resolve, 2000);
    })
}

loadData()
    .then(() => {
        let preloaderEl = document.getElementById('preloader');
        preloaderEl.classList.add('hidden');
        preloaderEl.classList.remove('visible');

    });


function AddPizzaToCast(id) {
    $.post("Home/AddPizzaToCast", {num: id})
}

function AddDrinkToCast(id) {
    $.post("Home/AddDrinkToCast", { num: id })
}

function AddSushiToCast(id) {
    $.post("Home/AddSushiToCast", { num: id })
}

function RemovePizzaFromCast(id) {
    $.post("Home/RemovePizzaFromCast", { num: id })
}

function RemoveDrinkFromCast(id) {
    $.post("Home/RemoveDrinkFromCast", { num: id })
}

function RemoveSushiFromCast(id) {
    $.post("Home/RemoveSushiFromCast", { num: id })
}

