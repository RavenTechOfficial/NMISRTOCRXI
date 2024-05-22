$(document).ready(function () {
    function returnReport(receivingId, dateInspected, status, inspectionRemarks) {
        $.ajax({
            url: '/receivingReports/return',
            type: 'POST',
            dataType: 'json',
            data: {
                receivingId: receivingId,
                dateInspected: dateInspected,
                inspectionRemarks: inspectionRemarks,
                status: status
            },
            success: function () {
            },
            error: function (error) {
                console.error('AJAX Error:', error);
            }
        });
    }
    function createMeatInspectionReport(receivingId, dateInspected, status, inspectionRemarks) {
        $.ajax({
            url: '/meatInspectionReports/create',
            type: 'POST',
            dataType: 'json',
            data: {
                receivingId: receivingId,
                dateInspected: dateInspected,
                inspectionRemarks: inspectionRemarks,
                status: status
            },
            success: function () {
            },
            error: function (error) {
                console.error('AJAX Error:', error);
            }
        });
    }

    $('#startReturn').click(function () {
        var receivingId = $('#receivingId').val();
        var dateInspected = $('#dateInspected').val();
        var status = $('#status').val();
        var inspectionRemarks = $('#inspectionRemarks').val();
        returnReport(receivingId, dateInspected, status, inspectionRemarks);
    });

    $('#startInspect').click(function () {
        document.getElementById('section2').scrollIntoView({
            behavior: 'smooth', // Smooth scroll animation
            block: 'start' // Align to the top of the element
        });
        var receivingId = $('#receivingId').val();
        var dateInspected = $('#dateInspected').val();
        var status = $('#status').val();
        var inspectionRemarks = $('#inspectionRemarks').val();
        createMeatInspectionReport(receivingId, dateInspected, status, inspectionRemarks);
    });
});
