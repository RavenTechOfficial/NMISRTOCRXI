$(document).ready(function () {
    $('#antemortemNext').click(function () {
        document.getElementById('section3').scrollIntoView({
            behavior: 'smooth', // Smooth scroll animation
            block: 'start' // Align to the top of the element
        });

        var receivingId = $('#receivingId').val();
        var passedHead = $('#passedHead').val();
        var passedWeight = $('#passedWeight').val();

        $.ajax({
            url: '/passedForSlaughters/create',
            type: 'POST',
            dataType: 'json',
            data: {

                Id: receivingId,
                passedHead: passedHead,
                passedWeight: passedWeight,

            },
            success: function () {
                $('#fitHead').val(passedHead);
            },
            error: function (error) {
                // Handle errors
                console.error('AJAX Error:', error);
                // Handle different HTTP status codes if needed
            },

        });
    });
});