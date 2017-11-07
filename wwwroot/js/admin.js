//image upload
$('#file').on('change', function () {
    var formData = new FormData();
    formData.append('file', $('#file')[0].files[0]);

    $.ajax({
        url: '/admingames/upload',
        type: 'POST',
        data: formData,
        processData: false,  // tell jQuery not to process the data
        contentType: false,  // tell jQuery not to set contentType
        success: function (data) {
            $('#uploaded').css('display', 'block');
            $('#uploaded').css('color', 'green');
            $('#img').attr('src', data.uri);
            $('#ImageURL').val(data.uri);
        },
        error: function (jqXHR, status, err) {
            $('#uploaded').text("Upload unsuccessful.");
            $('#uploaded').css('display', 'block');
            $('#uploaded').css('color', 'red');
            console.log("Error uploading image:" + err);
        }
    });
});