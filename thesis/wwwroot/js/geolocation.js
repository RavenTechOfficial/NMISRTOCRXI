const selectBtn = document.querySelector(".select-btn"),
    items = document.querySelectorAll(".item");

selectBtn.addEventListener("click", () => {
    selectBtn.classList.toggle("open");
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

