
const selectImageButtons = document.querySelectorAll('.select-image');
const fileInputs = document.querySelectorAll('.file-input');
const imgAreas = document.querySelectorAll('.img-area');

selectImageButtons.forEach((button, index) => {
    button.addEventListener('click', function () {
        fileInputs[index].click();
    });

    fileInputs[index].addEventListener('change', function () {
        const image = this.files[0];
        if (image.size < 5000000) {
            const reader = new FileReader();
            reader.onload = () => {
                const allImg = imgAreas[index].querySelectorAll('img');
                allImg.forEach(item => item.remove());
                const imgUrl = reader.result;
                const img = document.createElement('img');
                img.src = imgUrl;
                imgAreas[index].appendChild(img);
                imgAreas[index].classList.add('active');
                imgAreas[index].dataset.img = image.name;
            };
            reader.readAsDataURL(image);
        } else {
            alert("Image size more than 5MB");
        }
    });
});

fetch('@Url.Content("~/philippine_provinces_cities_municipalities_and_barangays_2019v2.json")')
    .then(response => response.json())
    .then(data => {
        const sets = ['Owner', 'Driver', 'Helper'];

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

        sets.forEach(set => {
            const regionSelect = document.getElementById(`regionSelect${set}`);
            regionOrder.forEach(region => {
                const option = document.createElement('option');
                option.value = region.regionCode;
                option.textContent = region.regionName;
                regionSelect.appendChild(option);
            });

            regionSelect.addEventListener('change', () => populateProvinces(set));
            document.getElementById(`provinceSelect${set}`).addEventListener('change', () => populateCities(set));
            document.getElementById(`citySelect${set}`).addEventListener('change', () => populateBarangays(set));
        });

        function populateProvinces(set) {
            const selectedRegion = document.getElementById(`regionSelect${set}`).value;
            const provinceSelect = document.getElementById(`provinceSelect${set}`);
            provinceSelect.innerHTML = "<option hidden>Select Province</option>";
            document.getElementById(`citySelect${set}`).innerHTML = "<option hidden>Select City/Municipality</option>";
            document.getElementById(`barangaySelect${set}`).innerHTML = "<option hidden>Select Barangay</option>";

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

        function populateCities(set) {
            const selectedRegion = document.getElementById(`regionSelect${set}`).value;
            const selectedProvince = document.getElementById(`provinceSelect${set}`).value;
            const citySelect = document.getElementById(`citySelect${set}`);
            citySelect.innerHTML = "<option hidden>Select City/Municipality</option>";
            document.getElementById(`barangaySelect${set}`).innerHTML = "<option hidden>Select Barangay</option>";

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

        function populateBarangays(set) {
            const selectedRegion = document.getElementById(`regionSelect${set}`).value;
            const selectedProvince = document.getElementById(`provinceSelect${set}`).value;
            const selectedCity = document.getElementById(`citySelect${set}`).value;
            const barangaySelect = document.getElementById(`barangaySelect${set}`);
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
    })
    .catch(error => console.error('Error fetching JSON:', error));