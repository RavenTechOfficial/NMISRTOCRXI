// address.js

// Integration of Philippines Address JSON
fetch('/data/philippine_provinces_cities_municipalities_and_barangays_2019v2.json')
    .then(response => response.json())
    .then(data => {
        const regionSelect = document.getElementById('regionSelect');
        const provinceSelect = document.getElementById('provinceSelect');
        const citySelect = document.getElementById('citySelect');
        const barangaySelect = document.getElementById('barangaySelect');
        const addressInput = document.getElementById('addressInput');

        // Desired order of regions
        const regionOrder = [
            { regionCode: "NCR", regionName: "National Capital Region" },
            { regionCode: "CAR", regionName: "Cordillera Administrative Region" },
            { regionCode: "01", regionName: "Region I" },
            { regionCode: "02", regionName: "Region II" },
            { regionCode: "03", regionName: "Region III" },
            { regionCode: "4A", regionName: "Region IV-A" },
            { regionCode: "4B", regionName: "Region IV-B" },
            { regionCode: "05", regionName: "Region V" },
            { regionCode: "06", regionName: "Region VI" },
            { regionCode: "07", regionName: "Region VII" },
            { regionCode: "08", regionName: "Region VIII" },
            { regionCode: "09", regionName: "Region IX" },
            { regionCode: "10", regionName: "Region X" },
            { regionCode: "11", regionName: "Region XI" },
            { regionCode: "12", regionName: "Region XII" },
            { regionCode: "13", regionName: "Region XIII" },
            { regionCode: "BARMM", regionName: "Bangsamoro Autonomous Region in Muslim Mindanao" }
        ];

        // Populate regions dropdown
        regionOrder.forEach(region => {
            const option = document.createElement('option');
            option.value = region.regionCode;
            option.textContent = region.regionName;
            regionSelect.appendChild(option);
        });

        // Function to populate provinces based on the selected region
        function populateProvinces() {
            const selectedRegion = regionSelect.value;
            provinceSelect.innerHTML = "<option hidden>Select Province</option>";
            citySelect.innerHTML = "<option hidden>Select City/Municipality</option>";
            barangaySelect.innerHTML = "<option hidden>Select Barangay</option>";

            if (selectedRegion) {
                const provinceList = data[selectedRegion].province_list;
                for (const [provinceCode, province] of Object.entries(provinceList)) {
                    const option = document.createElement('option');
                    option.value = provinceCode;
                    option.textContent = provinceCode;
                    provinceSelect.appendChild(option);
                }
            }
        }

        // Function to populate cities/municipalities based on the selected province
        function populateCities() {
            const selectedRegion = regionSelect.value;
            const selectedProvince = provinceSelect.value;
            citySelect.innerHTML = "<option hidden>Select City/Municipality</option>";
            barangaySelect.innerHTML = "<option hidden>Select Barangay</option>";

            if (selectedRegion && selectedProvince) {
                const municipalityList = data[selectedRegion].province_list[selectedProvince].municipality_list;
                for (const [municipalityCode, municipality] of Object.entries(municipalityList)) {
                    const option = document.createElement('option');
                    option.value = municipalityCode;
                    option.textContent = municipalityCode;
                    citySelect.appendChild(option);
                }
            }
        }

        // Function to populate barangays based on the selected city/municipality
        function populateBarangays() {
            const selectedRegion = regionSelect.value;
            const selectedProvince = provinceSelect.value;
            const selectedCity = citySelect.value;
            barangaySelect.innerHTML = "<option hidden>Select Barangay</option>";

            if (selectedRegion && selectedProvince && selectedCity) {
                const barangayList = data[selectedRegion].province_list[selectedProvince].municipality_list[selectedCity].barangay_list;
                for (const barangay of barangayList) {
                    const option = document.createElement('option');
                    option.value = barangay;
                    option.textContent = barangay;
                    barangaySelect.appendChild(option);
                }
            }
        }

        // Function to update address input
        function updateAddress() {
            const region = regionSelect.selectedOptions[0] ? regionSelect.selectedOptions[0].textContent : '';
            const province = provinceSelect.value || '';
            const city = citySelect.value || '';
            const barangay = barangaySelect.value || '';
            addressInput.value = `${region}, ${province}, ${city}, ${barangay}`;
        }

        // Event listeners to populate dropdowns and update address
        regionSelect.addEventListener('change', () => {
            populateProvinces();
            updateAddress();
        });
        provinceSelect.addEventListener('change', () => {
            populateCities();
            updateAddress();
        });
        citySelect.addEventListener('change', () => {
            populateBarangays();
            updateAddress();
        });
        barangaySelect.addEventListener('change', updateAddress);
    })
    .catch(error => console.error('Error fetching JSON:', error));
