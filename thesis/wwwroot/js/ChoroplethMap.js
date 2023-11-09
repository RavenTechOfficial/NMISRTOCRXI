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



//Search Bar Configurations
//Search Suggestions Delay
var currentMarker = null;
var inputElement = document.querySelector('.Search-Input');
var suggestionsElement = document.querySelector('.suggestions');

function debounce(func, wait) {
    let timeout;
    return function () {
        const context = this;
        const args = arguments;
        clearTimeout(timeout);
        timeout = setTimeout(function () {
            func.apply(context, args);
        }, wait);
    };
}
//Search Bar Function
function performSearch(e) {
    e.preventDefault();

    var locationName = document.querySelector(".Search-Input").value;
    performGeocoding(locationName);
}

function performGeocoding(locationName) {
    if (locationName) {
        var geocoder = L.Control.Geocoder.nominatim();
        geocoder.geocode(locationName, function (results) {
            if (results && results.length > 0) {
                var latlng = results[0].center;
                map.setView(latlng, 9);

                if (currentMarker) {
                    map.removeLayer(currentMarker);
                }

                currentMarker = L.marker(latlng).addTo(map).bindPopup(results[0].name).openPopup();
            } else {
                alert("Location not found!");
            }
        });
    } else {
        alert("Please enter a location!");
    }
}
//Search Suggestions Function
function getSuggestions() {
    var query = inputElement.value;
    if (query) {
        var geocoder = L.Control.Geocoder.nominatim();
        geocoder.geocode(query, function (results) {
            if (results && results.length > 0) {
                var suggestions = results.map(function (result) {
                    return result.name;
                });
                suggestionsElement.innerHTML = suggestions.map(s => `<div class="suggestion">${s}</div>`).join('');
                suggestionsElement.style.display = 'block';
            } else {
                suggestionsElement.style.display = 'none';
            }
        });
    } else {
        suggestionsElement.style.display = 'none';
    }
}

inputElement.addEventListener('input', debounce(getSuggestions, 1000));

suggestionsElement.addEventListener('click', function (e) {
    if (e.target.classList.contains('suggestion')) {
        inputElement.value = e.target.innerText;
        performGeocoding(e.target.innerText);
        suggestionsElement.style.display = 'none';
    }
});

document.querySelector(".search-form").addEventListener('submit', performSearch);

