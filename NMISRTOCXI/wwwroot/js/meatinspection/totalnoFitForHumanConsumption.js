$(document).ready(function () {
    $('#postmortemNext').click(function () {
        var receivingId = $('#receivingId').val();
        var totalHead = $('#fitHead').val();
        var totalWeight = $('#fitWeight').val();
        var ofals = $('#ofals').val();

        $.ajax({
            url: '/totalNoFitForHumanConsumptions/create',
            type: 'POST',
            dataType: 'json',
            data: {

                Id: receivingId,
                totalHead: totalHead,
                totalWeight: totalWeight,
                ofals: ofals,

            },
            success: function (response) {
                document.getElementById('postWeight').value = '0';
                document.getElementById('postHead').value = '0';
                document.getElementById('postPart').selectedIndex = 0;
                document.getElementById('postCause').selectedIndex = 0;

                window.location.href = response.redirectUrl;
            },
            error: function (xhr, status, error) {
                // Handle errors
                console.error('AJAX Error:', error);

            },
        });
    });
});