
// INPUT FORM CONFIG AND SETUP FOR QR CODE GENERATION
const form = document.querySelector('.form');
const submitBtn = document.getElementById('submitBtn');

submitBtn.addEventListener('click', function (e) {
    e.preventDefault();  // prevent default form submission

    const dealerName = form.elements[0].value;
    const farmOrigin = form.elements[1].value;
    const meatEstablishmentName = form.elements[2].value;
    const slaughterDate = form.elements[3].value;

    // Check if all form inputs are filled
    if (!dealerName || !farmOrigin || !meatEstablishmentName || !slaughterDate) {
        alert('Please fill in all form inputs.');
        return;
    }

    // Concatenate form values into a single string
    const data = `Dealer Name: ${dealerName}\nFarm Origin: ${farmOrigin}\nMeat Establishment Name: ${meatEstablishmentName}\nDate Slaughtered: ${slaughterDate}`;

    // Clear the QR code container and generate a new QR code
    const qrcodeContainer = document.getElementById('qrcode');
    qrcodeContainer.innerHTML = "";  // Clear previous QR code
    const qrcode = new QRCode(qrcodeContainer, {
        text: data,
        width: 200,
        height: 200,
    });

    $('#exampleModalCenter').modal('show');  // Show the modal
});



// QR CODE DOWNLOAD PNG FILE

document.getElementById('downloadBtn').addEventListener('click', function () {
    // Get the QR Code base64 URL
    var imgSrc = document.querySelector('#qrcode img').src;

    // Create a temporary link element
    var a = document.createElement('a');

    // Set the link's href to the QR code image src
    a.href = imgSrc;

    // Set the download attribute with a desired file name
    a.download = 'QRCode.png';

    // Trigger a click on the link to start the download
    a.click();
});


//Upload Image and scan QR Code
const selectImage = document.querySelector('#upload');
const inputFile = document.querySelector('#file');
const imgArea = document.querySelector('.img-area');
const scanButton = document.querySelector('#scan');

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
        alert("Image size more than 5MB");
    }
})


scanButton.addEventListener('click', function () {
    const imgElement = imgArea.querySelector('img');

    if (!imgElement) {
        alert("No image uploaded yet!");
        return;
    }

    const imageSrc = imgElement.src;

    const canvas = document.createElement('canvas');
    const context = canvas.getContext('2d');
    const img = new Image();
    img.src = imageSrc;

    img.onload = function () {
        canvas.width = img.width;
        canvas.height = img.height;
        context.drawImage(img, 0, 0, img.width, img.height);
        const imageData = context.getImageData(0, 0, img.width, img.height);
        const code = jsQR(imageData.data, img.width, img.height);

        if (code) {
            console.log("QR code found: ", code.data); // Debugging line
            $('#scanningModal').modal('show');
            document.getElementById('modalBody').innerText = `Found QR code:\n ${code.data}`;
        } else {
            $('#scanningModal').modal('show');
            document.getElementById('modalBody').innerText = `QR/Image Unidentified`;
            console.log("No QR code found"); // Debugging line
        }
    }
});