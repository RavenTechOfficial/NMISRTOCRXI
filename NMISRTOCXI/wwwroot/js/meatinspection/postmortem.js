$(document).ready(function () {
    $('#postmortemAdd').click(function () {
        var files = $('#fileInput')[0].files;
        var formData = new FormData();
        var receivingId = $('#receivingId').val();
        document.getElementById('section4').scrollIntoView({
            behavior: 'smooth', // Smooth scroll animation
            block: 'start' // Align to the top of the element
        });
        for (var i = 0; i < selectedFiles.length; i++) {
            formData.append("images", selectedFiles[i]);
            console.log('upload', selectedFiles[i]);
        }

        formData.append("Id", receivingId);
        formData.append("postPart", $('#postPart').val());
        formData.append("postCause", $('#postCause').val());
        formData.append("postWeight", $('#postWeight').val());
        formData.append("postHead", $('#postHead').val());

        const passedHead = $('#passedHead').val();
        const passedWeight = $('#passedWeight').val();

        $.ajax({
            url: '/postmortems/create',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                var imgArea = $('.img-area5');
                $('#fileInput').val('');
                imgArea.empty();
                currentImages = 0
                selectedFiles = [];
                $('#fitHead').val(passedHead - response.totalhead);

                var fileName1 = response.image1 ? response.image1.split('\\').pop() : null;
                var fileName2 = response.image2 ? response.image2.split('\\').pop() : null;
                var fileName3 = response.image3 ? response.image3.split('\\').pop() : null;

                var tableId = 'postTable';
                var newRow = '<tr>' +
                    '<td>' + response.issue + '</td>' +
                    '<td>' + response.cause + '</td>' +
                    '<td>' + response.head + '</td>' +
                    '<td>' + response.weight + '</td>' +
                    '<td>' + fileName1 + '</td>' +
                    '<td>' + fileName2 + '</td>' +
                    '<td>' + fileName3 + '</td>' +
                    '<td>' +
                    '<div class="btn-group">' +
                    //'<a class="btn btn-warning" id="postEdit" data-id="' + response.id + '">Edit</a>' +
                    '<a class="btn btn-danger" id="postDelete" data-id="' + response.id + '">Delete</a>' +
                    '</div>' +
                    '</td>' +
                    '</tr>';

                $('#' + tableId + ' tbody').append(newRow);
                document.getElementById('postWeight').value = '0';
                document.getElementById('postHead').value = '0';
                document.getElementById('postPart').selectedIndex = 0;
                document.getElementById('postCause').selectedIndex = 0;
            },
            error: function (error) {
                console.error('Error adding postmortem row:', error);
            }
        });

    });

    // IMAGE SELECT

    var selectedFiles = [];
    var currentImages = 0;
    var maxImages = 3;

    $('.select-images').click(function () {
        $('#fileInput').click();
    });

    $('#fileInput').change(function () {
        var files = $('#fileInput')[0].files;
        var imgArea = $('.img-area5');

        if (selectedFiles.length + files.length > maxImages) {
            alert('You can upload only up to 3 images.');
            return;
        }

        for (var i = 0; i < files.length; i++) {
            (function (file) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    var imgContainer = $('<div>').addClass('image-container');
                    var img = $('<img>').attr('src', e.target.result).addClass('uploaded-image');
                    var removeBtn = $('<button>').text('Remove').addClass('remove-button');

                    selectedFiles.push(file); // Store the File object in selectedFiles

                    removeBtn.click(function () {
                        // Get the index of the file to remove from selectedFiles
                        var indexToRemove = selectedFiles.indexOf(file);
                        if (indexToRemove !== -1) {
                            selectedFiles.splice(indexToRemove, 1); // Remove the file from selectedFiles array
                        }

                        $(this).parent().remove();
                    });

                    imgContainer.append(img, removeBtn);
                    imgArea.append(imgContainer);
                };

                reader.readAsDataURL(file);
            })(files[i]);
        }



        // Clear the file input to allow selecting the same files again
        $('#fileInput').val('');
    });


    var imageDelete = [];
    var rowId;
    var row;


    // Select row to edit
    $(document).ready(function () {
        $(document).on('click', '#postTable .btn-warning', function () {

            rowId = $(this).data('id');
            row = $(this).closest('tr');
            $('#postTable .btn').prop('disabled', true);

            $('#postmortemAdd').prop('hidden', true);
            $('#posteditGroup').prop('hidden', false);

            var targetDivPosition = $('#postForm').offset().top - 70;
            $('html, body').animate({
                scrollTop: targetDivPosition
            }, 500, function () {
            });

            row.addClass('selected-row');
            $('#postTable .btn').css({
                'color': 'grey',
                'cursor': 'not-allowed'
            });

            var postHead = row.find('td:eq(2)').text();
            var postWeight = row.find('td:eq(3)').text();
            document.getElementById('postWeight').value = postWeight;
            document.getElementById('postHead').value = postHead;

            document.getElementById('postPart').value = postPart;
            document.getElementById('postCause').value = postCause;

            var postPartText = row.find('td:eq(0)').text();
            var postCauseText = row.find('td:eq(1)').text();
            // Function to map text to option values
            function getTextToValueMapping(selectElement, text) {
                for (var i = 0; i < selectElement.options.length; i++) {
                    if (selectElement.options[i].text === text) {
                        return selectElement.options[i].value;
                    }
                }
                return null;
            }
            var postPart = getTextToValueMapping(document.getElementById('postPart'), postPartText);
            var postCause = getTextToValueMapping(document.getElementById('postCause'), postCauseText);


            document.getElementById('postPart').value = postPart;
            document.getElementById('postCause').value = postCause;
            if (postPart !== '1') {

                $('#postHead').prop('disabled', true);
            } else {

                $('#postHead').prop('disabled', false);
            }

            var imgArea = $('.img-area5');
            var imagePathList = [row.find('td:eq(4)').text(), row.find('td:eq(5)').text(), row.find('td:eq(6)').text()];
            imageDelete = imagePathList.map(function (path) {
                if (path !== 'null') {
                    return `wwwroot/img/PostmortemImages/${postPart}/${postCause}/${path}`;
                }
            });
            // add image to image area
            console.log('imageDelete', imageDelete);
            imageDelete.forEach(function (imagePath) {

                if (imagePath !== null || imagePath !== 'wwwroot/img/PostmortemImages/${postPart}/${postCause}/${path}\\\null') {
                    // Construct a Blob from the image path (assuming the image path is a valid URL)

                    //var formattedImagePath = 'img/PostmortemImages/${postPart}/${postCause}/' + imagePath;
                    var formattedImagePath = imagePath.replace(/\\/g, '/').replace('wwwroot', '');
                    fetch(formattedImagePath)
                        .then(response => response.blob())
                        .then(blob => {
                            // Create a File object from the Blob
                            //var formattedImagePath = imagePath.replace(/\\/g, '/').replace('wwwroot', '');
                            console.log('formatedimagepath', formattedImagePath)
                            var fileName = formattedImagePath.substring(formattedImagePath.lastIndexOf('/') + 1); // Extract filename from the path
                            var file = new File([blob], fileName, { type: blob.type });

                            // Add the File object to selectedFiles array
                            selectedFiles.push(file);

                            var imgContainer = $('<div>').addClass('image-container');
                            var img = $('<img>').attr('src', formattedImagePath).addClass('uploaded-image');
                            var removeBtn = $('<button>').text('Remove').addClass('remove-button');

                            removeBtn.click(function () {
                                // Remove the corresponding file from selectedFiles array
                                var indexToRemove = selectedFiles.indexOf(file);
                                if (indexToRemove !== -1) {
                                    selectedFiles.splice(indexToRemove, 1);
                                }


                                $(this).parent().remove();
                                console.log('removefiles', selectedFiles)
                            });

                            imgContainer.append(img, removeBtn);
                            imgArea.append(imgContainer);
                        })
                        .catch(error => {
                            console.error('Error fetching image:', error);
                        });
                }
                console.log('after', selectedFiles)
            });


        });

        // Delete postmortem Table Row
        $(document).on('click', '#postTable .btn-danger', function () {
            rowId = $(this).data('id');
            row = $(this).closest('tr');

            const passedHead = $('#passedHead').val();
            const passedWeight = $('#passedWeight').val();

            $.ajax({
                url: '/postmortems/delete/',
                type: 'POST',
                dataType: 'json',
                data: {
                    passedId: PassedForSlaughterId,
                    postRowId: rowId
                },
                success: function (response) {

                    PostMortemId = response.firstPostId;

                    $('#fitHead').val(passedHead - response.totalhead);
                    //  $('#fitWeight').val(passedWeight - response.totalweight);
                    row.remove();
                    if (postTable.rows.length <= 1) {
                        $('#postmortemNext').prop('disabled', true);
                    } else {
                        $('#postmortemNext').prop('disabled', false);
                    }

                },
                error: function (xhr, status, error) {

                }
            });
        });

        // Cancel Antemortem Row Edit
        $('#posteditCancel').click(function () {
            var imgArea = $('.img-area5');
            $('#fileInput').val('');
            imgArea.empty();

            selectedFiles = [];


            $('#postmortemAdd').prop('hidden', false);
            $('#posteditGroup').prop('hidden', true);
            $('#postHead').prop('disabled', true);
            row.removeClass('selected-row');
            $('#postTable .btn').css({
                'color': '',
                'cursor': ''
            });
            $('#postTable .btn').prop('disabled', false);

            document.getElementById('postWeight').value = '0';
            document.getElementById('postHead').value = '0';
            document.getElementById('postPart').selectedIndex = 0;
            document.getElementById('postCause').selectedIndex = 0;

        });


        // Confirm Postmortem Row Edit
        $('#posteditConfirm').click(function () {

            $('#postmortemAdd').prop('hidden', false);
            $('#posteditGroup').prop('hidden', true);

            row.removeClass('selected-row');
            $('#postTable .btn').prop('disabled', false);
            $('#postTable .btn').css({
                'color': '',
                'cursor': ''
            });
            var formData = new FormData();
            for (var i = 0; i < selectedFiles.length; i++) {
                formData.append("images", selectedFiles[i]);
                console.log('upload', selectedFiles[i]);
            }
            for (var i = 0; i < imageDelete.length; i++) {
                formData.append("imagePaths", imageDelete[i]);
                console.log('upload', imageDelete[i]);
            }

            formData.append("passedId", PassedForSlaughterId);
            formData.append("postRowId", rowId);
            formData.append("postPart", $('#postPart').val());
            formData.append("postCause", $('#postCause').val());
            formData.append("postWeight", $('#postWeight').val());
            formData.append("postHead", $('#postHead').val());

            const passedHead = $('#passedHead').val();
            const passedWeight = $('#passedWeight').val();

            var postPart = $('#postPart').val();
            var postCause = $('#postCause').val();
            var postWeight = $('#postWeight').val();
            var postHead = $('#postHead').val();

            $.ajax({
                url: '/postmortems/edit/',
                type: 'POST',
                dataType: 'json',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {

                    //update head and weight value
                    $('#fitHead').val(passedHead - response.totalhead);
                    //    $('#fitWeight').val(passedWeight - response.totalweight);


                    row.removeClass('selected-row');
                    var imgArea = $('.img-area5');
                    $('#fileInput').val('');
                    imgArea.empty();
                    currentImages = 0
                    selectedFiles = [];

                    row.find('td:eq(0)').text(response.postPart);
                    row.find('td:eq(1)').text(response.postCause);
                    row.find('td:eq(2)').text(response.postHead);
                    row.find('td:eq(3)').text(response.postWeight);

                    var fileName1 = response.image1 ? response.image1.split('\\').pop() : 'null';
                    var fileName2 = response.image2 ? response.image2.split('\\').pop() : 'null';
                    var fileName3 = response.image3 ? response.image3.split('\\').pop() : 'null';

                    row.find('td:eq(4)').text(fileName1);
                    row.find('td:eq(5)').text(fileName2);
                    row.find('td:eq(6)').text(fileName3);

                    document.getElementById('postWeight').value = '0';
                    document.getElementById('postHead').value = '0';
                    document.getElementById('postPart').selectedIndex = 0;
                    document.getElementById('postCause').selectedIndex = 0;

                    $('#postHead').prop('disabled', true);
                },
                error: function (xhr, status, error) {
                    // Handle errors
                    console.error('AJAX Error:', error);
                    // Handle different HTTP status codes if needed
                },

            });

            // here
        });
    });
});