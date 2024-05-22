$(document).ready(function () {
    var routeId = window.location.pathname.split('/').pop();
    $.ajax({
        url: '/receivingReports/inspect', // Updated URL to match the correct route
        type: 'GET',
        dataType: 'json',
        data: {
            Id: routeId,
            jsonResponse : true
        },
        success: function (response) {
            var data = response.data;
            if (data.meatInspectionReport.id !== 0) {
                document.getElementById('section2').scrollIntoView({
                    behavior: 'smooth', // Smooth scroll animation
                    block: 'start' // Align to the top of the element
                });
                var date = new Date(data.meatInspectionReport.repDate);
                var formattedDateTime = date.toLocaleString('en-PH', {
                    day: '2-digit',
                    month: '2-digit',
                    year: 'numeric',
                    hour: '2-digit',
                    minute: '2-digit',
                    second: '2-digit',
                    hour12: true // Set to false if you want 24-hour format
                });
                $('#dateInspected').val(data.meatInspectionReport.repDate);
                $('#inspectionRemarks').val(data.meatInspectionReport.remarks);
                $('#inspector').val(data.inspector);
                $('#passedHead').val($('#receivingHead').val());
                $('#passedWeight').val($('#receivingWeight').val());
            }
            else {
                var defaultDateTime = moment().format('YYYY-MM-DDTHH:mm');
                $('#dateInspected').val(defaultDateTime);
            }

            if (data.antemortems && data.antemortems.length > 0) {
                $('#passedHead').val($('#receivingHead').val() - response.totalNoOfHeads);
                $('#passedWeight').val($('#receivingWeight').val() - response.totalWeight);
                data.antemortems.forEach(function (item) {

                    if (item.cause === 'Others') {
                        causeOthers = item.cause + '(' + item.other + ')';
                    }
                    else {
                        causeOthers = item.cause
                    }

                    var newRow = `<tr>
                            <td>${item.issue}</td>
                            <td>${causeOthers}</td>
                            <td>${item.noOfHeads}</td>
                            <td>${item.weight}</td>
                            <td>${item.remarks}</td>
                            <td>
                                <div class="btn-group">
                                    <a class="btn btn-warning anteEdit" data-id="${item.id}">Edit</a>
                                    <a class="btn btn-danger anteDelete" data-id="${item.id}">Delete</a>
                                </div>
                            </td>
                        </tr>`;
                    $('#anteTable tbody').append(newRow);
                });
            }
            if (data.passedForSlaughter.id !== 0) {
                document.getElementById('section3').scrollIntoView({
                    behavior: 'smooth', // Smooth scroll animation
                    block: 'start' // Align to the top of the element
                });
                $('#fitHead').val($('#passedHead').val());

                document.getElementById('section3').scrollIntoView({
                    behavior: 'smooth', // Smooth scroll animation
                    block: 'start' // Align to the top of the element
                });
            }
            if (data.postmortems && data.postmortems.length > 0) {
                $('#fitHead').val($('#passedHead').val() - response.totalNoOfHeads);
                document.getElementById('section4').scrollIntoView({
                    behavior: 'smooth', // Smooth scroll animation
                    block: 'start' // Align to the top of the element
                });
                data.postmortems.forEach(function (item) {
                    var fileName1 = item.image1 ? item.image1.split('\\').pop() : null;
                    var fileName2 = item.image2 ? item.image2.split('\\').pop() : null;
                    var fileName3 = item.image3 ? item.image3.split('\\').pop() : null;

                    var newRow = `<tr>
                            <td>${item.animalPart}</td>
                            <td>${item.cause}</td>
                            <td>${item.noOfHeads}</td>
                            <td>${item.weight}</td>
                            <td>${fileName1}</td>
                            <td>${fileName2}</td>
                            <td>${fileName3}</td>
                            <td>
                                <div class="btn-group">
                                    <a class="btn btn-warning postEdit" data-id="${item.id}">Edit</a>
                                    <a class="btn btn-danger postDelete" data-id="${item.id}">Delete</a>
                                </div>
                            </td>
                        </tr>`;
                    $('#postTable tbody').append(newRow);
                });
            }

            if ( data.totalNoFitForHumanConsumption?.id !== null) {
                $('#fitWeight').val(data.totalNoFitForHumanConsumption.dressedWeight);
                $('#ofals').val(data.totalNoFitForHumanConsumption.ofals);
            }
        },
        error: function (xhr, status, error) {
            console.error('Error fetching IDs:', error);
        }
    });
});
