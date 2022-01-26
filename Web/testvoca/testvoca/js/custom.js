/* global $, alert,console*/
$(function () {

    //'use strict';
    //// Adjust Header Height
    //var myheader = $('.header');

    //myheader.height($(window).height() - 150)

    //$(window).resize(function () {
    //    myheader.height($(window).height() - 150)
    //});

    // Link Add Active Class

    //$('.links li a').click(function () {

    //    $(this).parent().addClass('active').siblings().removeClass('active')

    //});

    ////Smooth Scroll To Div
    //$('.links li a').click(function () {

    //    $('html, body').animate({
    //        scrollTop: $('#' + $(this).data('value')).offset().top - 150
    //    }, 1000);
    //});

    ////Smooth Scroll To Div on login
    //$('. ').click(function () {

    //    $('html, body').animate({
    //        scrollTop: $('#' + $(this).data('value')).offset().top +250
    //}, 1000);



    //Trigger Nice Scroll
    $('html').niceScroll({
        cusrsorwidth: '50',
        cursorcolor: '#000000',
        corsorbordor: '150px solid #1abc9c'
    });

    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    //$('.links li a').click(function () {
    //    var kk = CurrentUser.UsrRlNm;
    //    if (kk.length = 0) {
    //        $(lblusr).text("dddddd")
    //    }

    //});
});