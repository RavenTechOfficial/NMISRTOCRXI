document.addEventListener("DOMContentLoaded", function () {
	const form = document.querySelector(".logout-form");

	form.addEventListener("submit", function (event) {
		event.preventDefault();

		Swal.fire({
			title: 'Logout',
			text: 'Are you sure you want to logout?',
			icon: 'question',
			showCancelButton: true,
			confirmButtonColor: '#3085d6',
			cancelButtonColor: '#d33',
			confirmButtonText: 'Yes, logout!'
		}).then((result) => {
			if (result.isConfirmed) {
				form.submit();
			}
		});
	});
});
document.addEventListener("DOMContentLoaded", function () {
	const form = document.querySelector(".logout-form");

	form.addEventListener("submit", function (event) {
		event.preventDefault();

		Swal.fire({
			title: 'Logout',
			text: 'Are you sure you want to logout?',
			icon: 'question',
			showCancelButton: true,
			confirmButtonColor: '#3085d6',
			cancelButtonColor: '#d33',
			confirmButtonText: 'Yes, logout!'
		}).then((result) => {
			if (result.isConfirmed) {
				form.submit();
			}
		});
	});
});