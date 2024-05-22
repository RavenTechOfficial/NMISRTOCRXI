//script for adding row to antermotem table
$(document).ready(function () {
    $('#antemortemAdd').click(function () {

        var receivingId = $('#receivingId').val();
        var conductHead = $('#conductHead').val();
        var conductWeight = $('#conductWeight').val();
        var conductIssue = $('#conductIssue').val();
        var conductCause = $('#conductCause').val();
        var conductRemarks = $('#conductRemarks').val();
        var others = $('#others').val();
        var causeOthers = "";
        const passedHead = $('#receivingHead').val();
        const passedWeight = $('#receivingWeight').val();

        $.ajax({
            url: '/antemortem/create',
            type: 'POST',
            dataType: 'json',
            data: {
                Id: receivingId,
                conductHead: conductHead,
                conductWeight: conductWeight,
                issue: conductIssue,
                cause: conductCause,
                remarks: conductRemarks,
                others: others,
            },
            success: function (response) {

                $('#passedHead').val(passedHead - response.totalhead);
                $('#passedWeight').val(passedWeight - response.totalweight);

                if (response.cause === 'Others') {
                    causeOthers = response.cause + '(' + response.other + ')';
                }
                else {
                    causeOthers = response.cause
                }

                var tableId = 'anteTable';
                var newRow = '<tr>' +
                    '<td>' + response.issue + '</td>' +
                    '<td>' + causeOthers + '</td>' +
                    '<td>' + response.head + '</td>' +
                    '<td>' + response.weight + '</td>' +
                    '<td>' + response.remarks + '</td>' +
                    '<td>' +
                    '<div class="btn-group">' +
                    /*'<a class="btn btn-warning" id="anteEdit"  data-id="' + response.id + '">Edit</a>' +*/
                    '<a class="btn btn-danger" id="anteDelete" data-id="' + response.id + '">Delete</a>' +
                    '</div>' +
                    '</td>' +
                    '</tr>';

                // Append new row to table
                $('#' + tableId + ' tbody').append(newRow);

                document.getElementById('conductWeight').value = '0';
                document.getElementById('conductHead').value = '0';
                document.getElementById('conductIssue').selectedIndex = 0;
                document.getElementById('conductCause').selectedIndex = 0;
                document.getElementById('conductRemarks').value = '';
                document.getElementById('others').value = '';


            },
            error: function (xhr, status, error) {
                // Handle error response
                console.error('AJAX Error:', xhr + status +error);
                // Handle different HTTP status codes if needed
            }
        });
    });

});

var rowId;
var row;


// Select row to edit
$(document).ready(function () {
    $(document).on('click', '#anteTable .btn-warning', function () {

        rowId = $(this).data('id');
        row = $(this).closest('tr');
        $('#anteTable .btn').prop('disabled', true);


        var targetDivPosition = $('#anteForm').offset().top - 70;
        $('html, body').animate({
            scrollTop: targetDivPosition
        }, 500, function () {
        });

        row.addClass('selected-row');
        $('#anteTable .btn').css({
            'color': 'grey',
            'cursor': 'not-allowed'
        });

        $('#antemortemAdd').prop('hidden', true);
        $('#editGroup').prop('hidden', false);


        var conductHead = row.find('td:eq(2)').text();
        var conductWeight = row.find('td:eq(3)').text();
        var conductRemarks = row.find('td:eq(4)').text();

        document.getElementById('conductWeight').value = conductWeight;
        document.getElementById('conductHead').value = conductHead;

        document.getElementById('conductIssue').value = conductIssue;
        document.getElementById('conductCause').value = conductCause;

        document.getElementById('conductRemarks').value = conductRemarks;
        document.getElementById('others').value = others;

        var conductIssueText = row.find('td:eq(0)').text();
        var conductCauseText = row.find('td:eq(1)').text();

        // Function to map text to option values
        function getTextToValueMapping(selectElement, text) {
            for (var i = 0; i < selectElement.options.length; i++) {
                if (selectElement.options[i].text === text) {
                    return selectElement.options[i].value;
                }
            }
            return null; // If the text doesn't match any option, handle it accordingly
        }

        var conductIssue = getTextToValueMapping(document.getElementById('conductIssue'), conductIssueText);
        var conductCause = getTextToValueMapping(document.getElementById('conductCause'), conductCauseText);

        // Set values for the select elements
        document.getElementById('conductIssue').value = conductIssue;
        document.getElementById('conductCause').value = conductCause;

    });

    // Delete Antermortem Table Row
    $(document).on('click', '#anteTable .btn-danger', function () {
        rowId = $(this).data('id');
        row = $(this).closest('tr');

        const passedHead = $('#receivingHead').val();
        const passedWeight = $('#receivingWeight').val();
        const receivingId = $('#receivingId').val();

        $.ajax({
            url: '/antemortem/delete',
            type: 'POST',
            dataType: 'json',
            data: {
                Id: receivingId,
                anteRowId: rowId
            },
            success: function (response) {

                $('#passedHead').val(passedHead - response.totalhead);
                $('#passedWeight').val(passedWeight - response.totalweight);
                row.remove();
            },
            error: function (xhr, status, error) {
                consol.error("Delete Antemortem: ", error);
            }
        });
    });

    // Cancel Antemortem Row Edit
    $('#editCancel').click(function () {

        $('#antemortemAdd').prop('hidden', false);
        $('#editGroup').prop('hidden', true);
        row.removeClass('selected-row');
        $('#anteTable .btn').css({
            'color': '',
            'cursor': ''
        });
        $('#anteTable .btn').prop('disabled', false);
        document.getElementById('conductWeight').value = '0';
        document.getElementById('conductHead').value = '0';
        document.getElementById('conductIssue').selectedIndex = 0;
        document.getElementById('conductCause').selectedIndex = 0;
        document.getElementById('conductRemarks').value = '';
        document.getElementById('others').value = '';

    });


    // Confirm Antemortem Row Edit
    $('#editConfirm').click(function () {

        $('#antemortemAdd').prop('hidden', false);
        $('#editGroup').prop('hidden', true);
        row.removeClass('selected-row');
        $('#anteTable .btn').prop('disabled', false);
        $('#anteTable .btn').css({
            'color': '',
            'cursor': ''
        });
        var conductHead = $('#conductHead').val();
        var conductWeight = $('#conductWeight').val();
        var conductIssue = $('#conductIssue').val();
        var conductCause = $('#conductCause').val();
        var conductRemarks = $('#conductRemarks').val();
        var others = $('#others').val();

        const passedHead = $('#receivingHead').val();
        const passedWeight = $('#receivingWeight').val();
        const receivingId = $('#receivingId').val();

        $.ajax({
            url: '/antemortem/edit/',
            type: 'POST',
            dataType: 'json',
            data: {
                Id: receivingId,
                anteRowId: rowId,
                conductHead: conductHead,
                conductWeight: conductWeight,
                issue: conductIssue,
                cause: conductCause,
                conductRemarks: conductRemarks,
                others: others,
            },
            success: function (response) {

                console.log(response.totalhead);

                $('#passedHead').val(passedHead - response.totalhead);
                $('#passedWeight').val(passedWeight - response.totalweight);


                row.removeClass('selected-row');
                row.find('td:eq(0)').text(response.issue);
                row.find('td:eq(1)').text(response.cause);
                row.find('td:eq(2)').text(response.head);
                row.find('td:eq(3)').text(response.weight);
                row.find('td:eq(4)').text(response.remarks);
                //existingRow.replaceWith(updatedRow);
                document.getElementById('conductWeight').value = '0';
                document.getElementById('conductHead').value = '0';
                document.getElementById('conductRemarks').value = '';
                document.getElementById('others').value = '';
                document.getElementById('conductIssue').selectedIndex = 0;
                document.getElementById('conductCause').selectedIndex = 0;
            },
            error: function (xhr, status, error) {
                // Handle errors
                console.error('AJAX Error:', error);
                // Handle different HTTP status codes if needed
            },

        });
    });
});