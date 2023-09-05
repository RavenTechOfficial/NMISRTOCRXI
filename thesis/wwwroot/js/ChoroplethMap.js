// Dropdown toggling
const selectBtns = document.querySelectorAll(".select-btn");
selectBtns.forEach(selectBtn => {
    selectBtn.addEventListener("click", () => {
        // Close all other open dropdowns
        selectBtns.forEach(otherSelectBtn => {
            if (otherSelectBtn !== selectBtn) {
                otherSelectBtn.classList.remove("open");
            }
        });

        selectBtn.classList.toggle("open");
    });
});

// HEATMAP DROPDOWN
function updateHeatmapBtnText() {
    const checkedHeatmapItems = document.querySelectorAll(".heatmap .item.checked");
    const heatmapBtnText = document.querySelector(".heatmap .btn-text");

    if (checkedHeatmapItems.length > 1) {
        heatmapBtnText.innerText = `${checkedHeatmapItems.length} Selected`;
    } else if (checkedHeatmapItems.length === 1) { // If only one item is selected
        const text = checkedHeatmapItems[0].querySelector('.item-text').innerText;
        heatmapBtnText.innerText = text;
    }
}

const heatmapItems = document.querySelectorAll(".heatmap .item");

heatmapItems[0].classList.add("checked");
updateHeatmapBtnText();

heatmapItems.forEach(item => {
    item.addEventListener("click", () => {
        if (item.classList.contains("checked") && document.querySelectorAll(".heatmap .item.checked").length === 1) {
            return;
        }

        heatmapItems.forEach(heatmapItem => heatmapItem.classList.remove("checked"));


        item.classList.add("checked");

        updateHeatmapBtnText();
    });
});


// SPECIES DROPDOWN
let firstUpdate = true; // Flag to indicate the first time the function is run

function updateSpeciesBtnText() {
    const checkedSpeciesItems = document.querySelectorAll(".species .item.checked");
    const speciesBtnText = document.querySelector(".species .btn-text");

    if (firstUpdate) {
        speciesBtnText.innerText = "Filter Species"; // Initial placeholder text
        firstUpdate = false; // Update the flag
    } else {
        speciesBtnText.innerText = checkedSpeciesItems.length > 0 ? `${checkedSpeciesItems.length} Selected` : "Select Species";
    }
}

// Species item toggling
const speciesItems = document.querySelectorAll(".species .item");

// Default all items to checked
speciesItems.forEach(item => item.classList.add("checked"));

// Update the button text initially
updateSpeciesBtnText();

speciesItems.forEach(item => {
    item.addEventListener("click", () => {
        // If it's the only checked item, prevent unchecking
        if (item.classList.contains("checked") && document.querySelectorAll(".species .item.checked").length === 1) {
            return;
        }

        // Toggle the checked state
        item.classList.toggle("checked");
        updateSpeciesBtnText();
    });
});


