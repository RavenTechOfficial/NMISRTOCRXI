//Upload Image
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


//integration of Philippines Address JSON
fetch('philippine_provinces_cities_municipalities_and_barangays_2019v2.json')
    .then(response => response.json())
    .then(data => {
        const regionSelect = document.getElementById('regionSelect');
        const provinceSelect = document.getElementById('provinceSelect');
        const citySelect = document.getElementById('citySelect');
        const barangaySelect = document.getElementById('barangaySelect');

        // Define the desired order of regions
        const regionOrder = [
            { regionCode: "NCR", regionName: "National Capital Region" },
            { regionCode: "CAR", regionName: "Cordillera Administrative Region" },
            { regionCode: "01", regionName: "Region I" },
            { regionCode: "02", regionName: "Region II" },
            { regionCode: "03", regionName: "Region III" },
            { regionCode: "04A", regionName: "Region IV-A" },
            { regionCode: "04B", regionName: "Region IV-B" },
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

            if (selectedRegion !== "") {
                const regionData = data[selectedRegion];
                const provinceList = regionData.province_list;

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

            if (selectedRegion !== "" && selectedProvince !== "") {
                const regionData = data[selectedRegion];
                const provinceData = regionData.province_list[selectedProvince];
                const municipalityList = provinceData.municipality_list;

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

            if (selectedRegion !== "" && selectedProvince !== "" && selectedCity !== "") {
                const regionData = data[selectedRegion];
                const provinceData = regionData.province_list[selectedProvince];
                const municipalityData = provinceData.municipality_list[selectedCity];
                const barangayList = municipalityData.barangay_list;

                for (const barangay of barangayList) {
                    const option = document.createElement('option');
                    option.value = barangay;
                    option.textContent = barangay;
                    barangaySelect.appendChild(option);
                }
            }
        }

        // Add event listeners to call the populate functions on change
        regionSelect.addEventListener('change', populateProvinces);
        provinceSelect.addEventListener('change', populateCities);
        citySelect.addEventListener('change', populateBarangays);
    })
    .catch(error => console.error('Error fetching JSON:', error));


DataTable
new DataTable('#admin-accounts');