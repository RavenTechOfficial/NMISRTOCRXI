let hasStarBeenClicked = false;
let numberOfStarsClicked = 0; // Initialize with 0

// Existing star clicking logic
const stars = document.querySelectorAll(".stars i");
stars.forEach((star, index1) => {
    star.addEventListener("click", () => {
        hasStarBeenClicked = true;
        numberOfStarsClicked = index1 + 1;  // Update the number of stars clicked

        // Log the number of stars clicked to the console
        console.log(`You clicked ${numberOfStarsClicked} ${numberOfStarsClicked > 1 ? 'stars' : 'star'}`);

        stars.forEach((star, index2) => {
            index1 >= index2 ? star.classList.add("active") : star.classList.remove("active");
        });
    });
});

//document.addEventListener('DOMContentLoaded', function () {
//    var headerText = document.getElementById('header-text');
//    var submitButton = document.getElementById('submit-button');
//    var ratingBoxModal = document.getElementById('rating-box-modal');

//    // Show the rating-box modal with animation after 3 seconds
//    setTimeout(function () {
//        ratingBoxModal.classList.add('show'); // Add the 'show' class to trigger the animation
//    }, 5000);

//    submitButton.addEventListener('click', function (event) {
//        event.preventDefault();
//        if (hasStarBeenClicked) {
//            headerText.textContent = "Thank you for submitting";

//            // Log the final rating
//            console.log(`Submitted with ${numberOfStarsClicked} ${numberOfStarsClicked > 1 ? 'stars' : 'star'}`);

//            // Close the modal after 1 second
//            setTimeout(function () {
//                ratingBoxModal.classList.remove('show');
//            }, 1000);

//        } else {
//            // You could add additional logic here to remind the user to click a star
//            headerText.textContent = "Please Leave us a Feedback";
//        }
//    });
//});
