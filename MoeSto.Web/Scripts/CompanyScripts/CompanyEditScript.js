$(document).ready(function($) {
    $("#tabs").tabs();

    $('.sidebar-navigation li').click(function () {
        $(this).siblings('li').removeClass('active');
        $(this).addClass('active');
    });
});