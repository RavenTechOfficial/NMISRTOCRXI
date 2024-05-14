//Camera Scanner
let html5QrcodeScanner;

// Add an event listener to the 'shown.bs.modal' event.
$('#cameraModal').on('shown.bs.modal', function () {
    html5QrcodeScanner = new Html5QrcodeScanner("reader", { fps: 10, qrbox: { width: 250, height: 250 } });
    html5QrcodeScanner.render(function (decodedText, decodedResult) {
        if (decodedText) {
            const urlRegex = /(https?:\/\/[^\s]+)/;
            const match = decodedText.match(urlRegex);
            if (match) {
                const url = match[0];
                window.location.href = url; // Redirect to the decoded URL
            }
        }
    }, function (errorMessage) {
        // onError Callback
        console.error(errorMessage);
    });
});


$('#cameraModal').on('hidden.bs.modal', function () {
    if (html5QrcodeScanner) {
        html5QrcodeScanner.clear();
        html5QrcodeScanner = null;
    }
});

document.getElementById('useCameraBtn').addEventListener('click', function () {
    $('#cameraModal').modal('show');
});


//Upload Image
$('#uploadBtn').on('click', function () {
    $('#uploadQrModal').modal('show');
});

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
//scan the image Uploaded
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
            window.location.href = code.data; // Redirect to the decoded link
        } else {
            $('#scanningModal').modal('show');
            document.getElementById('modalBody').innerText = `QR/Image Unidentified`;
            console.log("No QR code found"); // Debugging line
        }
    }
});