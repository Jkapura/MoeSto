var uploadedPictureTemplate = function (reader) {
    return "<div class='col-md-4 col-sm-4'>"
        + "<div class='property'>"
        + "<a href='property-detail.html'>"
        + "<div class='property-image'>"
        + "<img src="+ reader +">"
        + "</div>"
        + "<div class='overlay'>"
        + "<div class='info'>"
        + "<div class='tag price'>Сделать главной</div>"
        + "<h3>3398 Lodgeville Road</h3>"
        + "<figure>Golden Valley, MN 55427</figure>"
        + "</div>"
        + "<ul class='additional-info'>"
        + "<li>"
        + "<header>Area:</header>"
        + "<figure>240m<sup>2</sup></figure>"
        + "</li>"
        + "<li>"
        + "<header>Beds:</header>"
        + "<figure>2</figure>"
        + "</li>"
        + "<li>"
        + "<header>Baths:</header>"
        + "<figure>2</figure>"
        + "</li>"
        + "<li>"
        + "<header>Garages:</header>"
        + "<figure>0</figure>"
        + " </li>"
        + " </ul>"
        + "</div>"
        + "</a>"
        + "</div>"
        + "</div>";
}

$(document).ready(function ($) {

    //activate tabs
    $("#tabs").tabs();
    //active class on tabs
    $('.sidebar-navigation li').click(function () {
        $(this).siblings('li').removeClass('active');
        $(this).addClass('active');
    });

    $("#upload-imgs").click(function () {
        //$("#upload-imgs span").text("Закрыть");
        $("#gallery").toggle();
    });


    $("#input-711").fileinput({
        uploadUrl: "/Company/UploadImgs", // server upload action
        uploadAsync: true,
        maxFileCount: 10,
        showBrowse: false,
        browseOnZoneClick: true,
        allowedFileExtensions: ["jpg", "png", "gif"],

    });
    // CATCH RESPONSE


    $('#input-711').on('fileuploaded', function (event, data) {
        var reader = data.reader,
            files = data.files,
            response = data.response,
            form = data.form;
        $('#input-711').fileinput('refresh');
        $('#input-711').fileinput('enable');
        $('#input-711').fileinput('clear');
        
        $("#agent-properties").prepend(uploadedPictureTemplate(reader.result));
    });

    $('#input-711').on('fileuploaderror', function (event, data, previewId, index) {
        var form = data.form, files = data.files, extra = data.extra,
            response = data.response, reader = data.reader;
    });

    $('#input-711').on('filebatchuploadsuccess', function (event, data, previewId, index) {
        alert(data.text);
    });
});
