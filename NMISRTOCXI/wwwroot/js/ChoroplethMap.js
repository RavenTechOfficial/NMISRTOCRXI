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
document.addEventListener('DOMContentLoaded', function () {
    const heatmapCheckboxes = document.querySelectorAll(".heatmap .item input[type='checkbox']");

    // Set the initial state for the checkboxes
    setInitialCheckboxState(heatmapCheckboxes);

    heatmapCheckboxes.forEach(checkbox => {
        checkbox.addEventListener('change', function () {
            // Uncheck all other checkboxes if this one is checked
            if (checkbox.checked) {
                uncheckOtherCheckboxes(checkbox, heatmapCheckboxes);
            }
            updateHeatmapBtnText();
        });
    });
});

function setInitialCheckboxState(checkboxes) {
    let isCheckedFound = false;
    for (const checkbox of checkboxes) {
        if (checkbox.checked) {
            isCheckedFound = true;
            break;
        }
    }
    if (!isCheckedFound && checkboxes.length > 0) {
        checkboxes[0].checked = true; // Check the first checkbox by default
    }
}

function uncheckOtherCheckboxes(selectedCheckbox, checkboxes) {
    checkboxes.forEach(otherCheckbox => {
        if (otherCheckbox !== selectedCheckbox) {
            otherCheckbox.checked = false;
        }
    });
}

function updateHeatmapBtnText() {
    const heatmapBtnText = document.querySelector(".heatmap .btn-text");
    const checkedHeatmapItems = Array.from(document.querySelectorAll(".heatmap .item input[type='checkbox']")).filter(checkbox => checkbox.checked);

    if (checkedHeatmapItems.length === 1) {
        const text = checkedHeatmapItems[0].nextElementSibling.querySelector('.item-text').innerText;
        heatmapBtnText.innerText = text;
    } else {
        heatmapBtnText.innerText = 'Select an Option';
    }
}

// SPECIES DROPDOWN
//let firstUpdate = true; 

//function updateSpeciesBtnText() {
//    const checkedSpeciesItems = document.querySelectorAll(".species .item.checked");
//    const speciesBtnText = document.querySelector(".species .btn-text");

//    if (firstUpdate) {
//        speciesBtnText.innerText = "Filter Species";
//        firstUpdate = false; 
//    } else {
//        speciesBtnText.innerText = checkedSpeciesItems.length > 0 ? `${checkedSpeciesItems.length} Selected` : "Select Species";
//    }
//}

//const speciesItems = document.querySelectorAll(".species .item");
//speciesItems.forEach(item => item.classList.add("checked"));

//updateSpeciesBtnText();

//speciesItems.forEach(item => {
//    item.addEventListener("click", () => {
//        if (item.classList.contains("checked") && document.querySelectorAll(".species .item.checked").length === 1) {
//            return;
//        }

//        item.classList.toggle("checked");
//        updateSpeciesBtnText();
//    });
//});



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

