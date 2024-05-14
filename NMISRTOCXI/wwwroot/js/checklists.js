//date and time realtime
document.addEventListener('DOMContentLoaded', function () {
    // Your JavaScript code here

    function updateTimeAndDate() {
        var currentTime = new Date();

        // Format the date as YYYY-MM-DD
        var formattedDate = currentTime.toISOString().split('T')[0];

        // Format the time as HH:MM:SS
        var formattedTime = currentTime.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', second: '2-digit' });

        // Set the values of the date and time input fields
        document.getElementById('dateInput').value = formattedDate;
        document.getElementById('timeInput').value = formattedTime;
    }

    // Update the date and time input fields initially
    updateTimeAndDate();

    // Update the date and time input fields every second to display real-time
    setInterval(updateTimeAndDate, 1000);
});




const tableRows = document.querySelectorAll("#applications-table1 tbody tr");
const modal = document.getElementById("myModal");
const approveBtn = document.getElementById("approveBtn");
const disapproveBtn = document.getElementById("disapproveBtn");
const operatorNameInput = document.getElementById("operatorName");
const meatEstablishmentInput = document.getElementById("meatEstablishment");
const plateNumberInput = document.getElementById("plateNumber");
const accreditationNumberInput = document.getElementById("accreditationNumber");
let selectedRow = null;
//const vehicleId = row.getAttribute("data-id"); // Get the vehicleId from the data-id attribute
//document.querySelector("input[name='vehicleId']").value = vehicleId;


tableRows.forEach((row, index) => {
    row.addEventListener("click", () => {
        selectedRow = row;

        // Get data from the clicked row
        const tds = Array.from(row.getElementsByTagName("td"));
        const operatorName = tds[0].innerText;
        const applicationType = tds[1].innerText;
        const establishmentServed = tds[2].innerText;
        const plateNumber = tds[3].innerText;
        const status = tds[4].innerText;

        const vehicleId = row.getAttribute("data-id"); // Get the vehicleId from the data-id attribute

        // Populate modal inputs
        operatorNameInput.value = operatorName;
        meatEstablishmentInput.value = establishmentServed;
        plateNumberInput.value = plateNumber;

        // Populate the hidden input for vehicleId
        document.querySelectorAll("input[name='vehicleId']").forEach(input => {
            input.value = vehicleId;
        });

        // If you have more data for other fields, populate those here.

        //accreditationNumberInput.value = ???;

        // Show the modal
        modal.style.display = "block";
    });
});





//approveBtn.addEventListener("click", () => {
//    if (selectedRow) {
//        const statusCell = selectedRow.querySelector(".status");
//        const newStatus = document.createElement("span");
//        newStatus.className = "status process";
//        newStatus.textContent = "Payment";
//        statusCell.innerHTML = ''; // Clear the old content
//        statusCell.appendChild(newStatus);
//    }
//    modal.style.display = "none";
//});

//disapproveBtn.addEventListener("click", () => {
//    if (selectedRow) {
//        const statusCell = selectedRow.querySelector(".status");
//        const newStatus = document.createElement("span");
//        newStatus.className = "status process";
//        newStatus.textContent = "Process";
//        statusCell.innerHTML = ''; // Clear the old content
//        statusCell.appendChild(newStatus);
//    }
//    modal.style.display = "none";
//});
//approveBtn1.addEventListener("click", () => {
//    if (selectedRow) {
//        const statusCell = selectedRow.querySelector(".status");
//        const newStatus = document.createElement("span");
//        newStatus.className = "status completed";
//        newStatus.textContent = "Completed";
//        statusCell.innerHTML = ''; // Clear the old content
//        statusCell.appendChild(newStatus);
//    }
//    paymentModal.style.display = "none";
//});

//disapproveBtn1.addEventListener("click", () => {
//    if (selectedRow) {
//        const statusCell = selectedRow.querySelector(".status");
//        const newStatus = document.createElement("span");
//        newStatus.className = "status process";
//        newStatus.textContent = "Process";
//        statusCell.innerHTML = ''; // Clear the old content
//        statusCell.appendChild(newStatus);
//    }
//    paymentModal.style.display = "none";
//});


function closeModal() {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
}

$(document).ready(function () {
    $('#search-icon').click(function () {
        console.log('Search icon clicked');
        var searchValue = prompt('Enter a search term:');
        if (searchValue) {
            $('#applications-table tbody tr').hide();
            $('#applications-table tbody tr').each(function () {
                var rowData = $(this).find('td').text();
                if (rowData.toLowerCase().includes(searchValue.toLowerCase())) {
                    $(this).show();
                }
            });
        }
    });

    $('#filter-icon').click(function () {
        console.log('Filter icon clicked');
        var filterValue = prompt('Enter a filter term:');
        if (filterValue) {
            $('#applications-table tbody tr').hide();
            $('#applications-table tbody tr').each(function () {
                var statusValue = $(this).find('.status').text();
                if (statusValue.toLowerCase() === filterValue.toLowerCase()) {
                    $(this).show();
                }
            });
        }
    });

    $('#refresh-icon').click(function () {
        $('#applications-table tbody tr').show();
    });

    $('#search-icon1').click(function () {
        var searchValue = prompt('Enter a search term:');
        if (searchValue) {
            $('#applications-table1 tbody tr').hide();
            $('#applications-table1 tbody tr').each(function () {
                var rowData = $(this).find('td').text();
                if (rowData.toLowerCase().includes(searchValue.toLowerCase())) {
                    $(this).show();
                }
            });
        }
    });

    $('#filter-icon1').click(function () {
        var filterValue = prompt('Enter a filter term:');
        if (filterValue) {
            $('#applications-table1 tbody tr').hide();
            $('#applications-table1 tbody tr').each(function () {
                var statusValue = $(this).find('.status').text();
                if (statusValue.toLowerCase() === filterValue.toLowerCase()) {
                    $(this).show();
                }
            });
        }
    });

    $('#refresh-icon1').click(function () {
        console.log('Refresh icon clicked');
        $('#applications-table1 tbody tr').show();
    });
});


// Function to open the payment modal
function openPaymentModal() {
    var paymentModal = document.getElementById('paymentModal');
    paymentModal.style.display = 'block';
}

// Function to close the payment modal
function closePaymentModal() {
    var paymentModal = document.getElementById('paymentModal');
    paymentModal.style.display = 'none';
}

// Add an event listener to the "Check Payment Details" button to open the payment modal
document.getElementById('paymentBtn').addEventListener('click', openPaymentModal);


paymentBtn.addEventListener("click", () => {
    if (selectedRow) {

    }
    modal.style.display = "none";
});



//Upload Image sa Payment ni haa
const selectImage = document.querySelector('.select-image');
const inputFile = document.querySelector('#file');
const imgArea = document.querySelector('.img-area');

selectImage.addEventListener('click', function () {
    inputFile.click();
})

inputFile.addEventListener('change', function () {
    const image = this.files[0]
    if (image.size < 5000000) {
        const reader = new FileReader();
        reader.onload = () => {
            const allImg = imgArea.querySelectorAll('img');
            allImg.forEach(item => item.remove());
            const imgUrl = reader.result;
            const img = document.createElement('img');
            img.src = imgUrl;
            imgArea.appendChild(img);
            imgArea.classList.add('active');
            imgArea.dataset.img = image.name;
        }
        reader.readAsDataURL(image);
    } else {
        alert("Image size more than 2MB");
    }
})


