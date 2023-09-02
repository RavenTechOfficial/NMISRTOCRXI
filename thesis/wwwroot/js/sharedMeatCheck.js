//Side Navigation Bar
//Side Navigation Bar
const allSideMenu = document.querySelectorAll('#sidebar .side-menu.top li a');
const currentPage = window.location.href;

allSideMenu.forEach(item => {
	const li = item.parentElement;

	// Compare item href with current page
	if (item.href === currentPage) {
		li.classList.add('active');
	} else {
		li.classList.remove('active');
	}

	item.addEventListener('click', function () {
		allSideMenu.forEach(i => {
			i.parentElement.classList.remove('active');
		})
		li.classList.add('active');
	})
});

// TOGGLE SIDEBAR Hide SideNav Starts
const menuBar = document.querySelector('#meatcheck #navbar  nav .bx.bx-menu');
const sidebar = document.getElementById('sidebar');

menuBar.addEventListener('click', function () {
	console.log("Menu bar clicked"); // Add this line
	sidebar.classList.toggle('hide');
});


window.addEventListener('load', function () {
	if (window.innerWidth <= 768) {
		sidebar.classList.add('hide');
	}
});

window.addEventListener('resize', function () {
	console.log("Window resized"); // Add this line
	if (window.innerWidth <= 768 && !sidebar.classList.contains('hide')) {
		sidebar.classList.add('hide');
	} else if (window.innerWidth > 768 && sidebar.classList.contains('hide')) {
		sidebar.classList.remove('hide');
	}
});


// TOGGLE SIDEBAR Hide SideNav Ends

//const searchButton = document.querySelector('#navbar nav form .form-input button');
//const searchButtonIcon = document.querySelector('#navbar nav form .form-input button .bx');
//const searchForm = document.querySelector('#navbar nav form');

//searchButton.addEventListener('click', function (e) {
//	if (window.innerWidth < 576) {
//		e.preventDefault();
//		searchForm.classList.toggle('show');
//		if (searchForm.classList.contains('show')) {
//			searchButtonIcon.classList.replace('bx-search', 'bx-x');
//		} else {
//			searchButtonIcon.classList.replace('bx-x', 'bx-search');
//		}
//	}
//})





//if (window.innerWidth < 768) {
//	sidebar.classList.add('hide');
//} else if (window.innerWidth > 576) {
//	searchButtonIcon.classList.replace('bx-x', 'bx-search');
//	searchForm.classList.remove('show');
//}


//window.addEventListener('resize', function () {
//	if (this.innerWidth > 576) {
//		searchButtonIcon.classList.replace('bx-x', 'bx-search');
//		searchForm.classList.remove('show');
//	}
//})


// //light-mode to dark-mode and vice-versa
const switchMode = document.getElementById('switch-mode');

// Load previously saved mode from localStorage
const currentMode = localStorage.getItem('mode');

if (currentMode === 'dark') {
	document.body.classList.add('dark');
	switchMode.checked = true;
} else {
	document.body.classList.remove('dark');
	switchMode.checked = false;
}

switchMode.addEventListener('change', function () {
	if (this.checked) {
		document.body.classList.add('dark');
		localStorage.setItem('mode', 'dark'); // Save mode to localStorage
	} else {
		document.body.classList.remove('dark');
		localStorage.setItem('mode', 'light'); // Save mode to localStorage
	}
});
