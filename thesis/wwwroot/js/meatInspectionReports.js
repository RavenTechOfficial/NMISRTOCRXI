//show QR Code in the modal
const viewButtons = document.querySelectorAll('.view');

viewButtons.forEach(button => {
    button.addEventListener('click', function (e) {
        const qrdata = "https://localhost:7116/Trace/Result?id=" + button.getAttribute('value');;
        const qrcodeContainer = document.getElementById('qrcode');
        qrcodeContainer.innerHTML = "";  // Clear previous QR code
        const qrcode = new QRCode(qrcodeContainer, {
            text: qrdata,
            width: 200,
            height: 200,
        });

        document.getElementById('uniqueId').innerText = "UID: " + button.getAttribute('value');
        $('#viewQr').modal('show');
    });
});

//Download the QR Code in the modal
document.getElementById('downloadBtn').addEventListener('click', function () {
    var imgSrc = document.querySelector('#qrcode img').src;
    var uniqueIdText = document.getElementById('uniqueId').textContent;

    var canvas = document.createElement('canvas');
    var context = canvas.getContext('2d');
    var borderSize = 20;

    var qrCodeImage = new Image();
    qrCodeImage.onload = function () {  // Ensure the image is loaded before drawing on canvas
        var paddingBelowQR = 30;  // Space for the Unique ID text below the QR code
        var textHeight = 24;  // Font size for Unique ID

        canvas.width = qrCodeImage.width + 2 * borderSize;
        canvas.height = qrCodeImage.height + 2 * borderSize + paddingBelowQR;

        context.fillStyle = 'white';
        context.fillRect(0, 0, canvas.width, canvas.height);
        context.drawImage(qrCodeImage, borderSize, borderSize);

        // Drawing the Unique ID text
        context.font = textHeight + "px Arial";
        context.fillStyle = "black";
        context.textAlign = "center";
        context.fillText(uniqueIdText, canvas.width / 2, qrCodeImage.height + borderSize + textHeight);

        var modifiedImgSrc = canvas.toDataURL('image/png');

        var a = document.createElement('a');
        a.href = modifiedImgSrc;
        a.download = 'ModifiedQRCode.png';
        a.click();
    };
    qrCodeImage.src = imgSrc;
});


//print QR code
document.getElementById('printBtn').addEventListener('click', function () {
    var printWindow = window.open('', '_blank');

    var imgSrc = document.querySelector('#qrcode img').src;
    var uniqueIdText = document.getElementById('uniqueId').textContent;

    // Create elements
    var body = printWindow.document.body;

    var style = printWindow.document.createElement('style');
    style.innerHTML = `
                    body {
                        width: 105mm;
                        height: 148mm;
                        margin: 0;
                        font-family: Arial, sans-serif;
                        text-align: center;
                    }
                    img {
                        width: 100%;
                    }
                `;

    var img = printWindow.document.createElement('img');
    img.src = imgSrc;
    img.alt = "QR Code";

    var h3 = printWindow.document.createElement('h3');
    h3.textContent = uniqueIdText;

    // Append elements to the new window's body
    body.appendChild(style);
    body.appendChild(img);
    body.appendChild(h3);

    printWindow.print();
    printWindow.onfocus = function () { setTimeout(function () { printWindow.close(); }, 500); }; // Close after printing
});
