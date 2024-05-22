$(document).ready(function () {
	$.ajax({
		url: '/receivingReports/notification',
		type: 'GET',
		dataType: 'json',
		success: function (response) {
			$('notificationCount').val(notificationCount);
		},
		error: function (xhr, status, error) {

		}
});