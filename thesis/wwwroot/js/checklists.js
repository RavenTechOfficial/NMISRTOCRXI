//const modal = document.getElementById("myModal");
//const approveBtn = document.getElementById("approveBtn");
//const disapproveBtn = document.getElementById("disapproveBtn");

//// Show the modal
//function showModal() {
//    modal.classList.add("show");
//}

//// Close the modal
//function closeModal() {
//    modal.classList.remove("show");
//}

//// Attach click event listeners to trigger the modal
//document.querySelectorAll("tr").forEach((row) => {
//    row.addEventListener("click", showModal);
//});

//// Attach click event listeners to buttons in the modal
//approveBtn.addEventListener("click", () => {
//    alert("Payment Approved");
//    closeModal();
//});

//disapproveBtn.addEventListener("click", () => {
//    alert("Payment Disapproved");
//    closeModal();
//});
const tableRows = document.querySelectorAll("#applications-table1 tbody tr");
const modal = document.getElementById("myModal");
const approveBtn = document.getElementById("approveBtn");
const disapproveBtn = document.getElementById("disapproveBtn");
let selectedRow = null;

tableRows.forEach((row, index) => {
    row.addEventListener("click", () => {
        selectedRow = row;
        modal.style.display = "block";
    });
});

approveBtn.addEventListener("click", () => {
    if (selectedRow) {
        const statusCell = selectedRow.querySelector(".status");
        const newStatus = document.createElement("span");
        newStatus.className = "status completed";
        newStatus.textContent = "Completed";
        statusCell.innerHTML = ''; // Clear the old content
        statusCell.appendChild(newStatus);
    }
    modal.style.display = "none";
});

disapproveBtn.addEventListener("click", () => {
    if (selectedRow) {
        const statusCell = selectedRow.querySelector(".status");
        const newStatus = document.createElement("span");
        newStatus.className = "status process";
        newStatus.textContent = "Process";
        statusCell.innerHTML = ''; // Clear the old content
        statusCell.appendChild(newStatus);
    }
    modal.style.display = "none";
});