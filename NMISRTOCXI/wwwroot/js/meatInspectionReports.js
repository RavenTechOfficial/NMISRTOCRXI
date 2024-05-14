
//View the QR Code in the modal
const viewButtons = document.querySelectorAll('.view');

viewButtons.forEach(button => {
    button.addEventListener('click', function (e) {
        const qrdata = "https://nmissmfa.site/Trace/Result?id=" + button.getAttribute('value');
        const qrcodeContainer = document.getElementById('qrcode');
        qrcodeContainer.innerHTML = "";

        const qrCode = new QRCodeStyling({
            width: 250,
            height: 250,
            type: "canvas",
            data: qrdata,
            image: "/img/logo-200h.png",
            dotsOptions: {
                color: "#000000",
                type: "rounded"
            },
            imageOptions: {
                crossOrigin: "anonymous",
                margin: 0.5,
                imageSize: 0.5
            },
            errorCorrectionLevel: "H"
        });

        qrCode.append(qrcodeContainer);

        document.getElementById('uniqueId').innerText = "UID: " + button.getAttribute('value');
        $('#viewQr').modal('show');
    });
});

//Download the QR Code in the modal
document.getElementById('downloadBtn').addEventListener('click', function () {
    var canvas = document.querySelector('#qrcode canvas');
    if (!canvas) return;

    var imgSrc = canvas.toDataURL('image/png');
    var uniqueIdText = document.getElementById('uniqueId').textContent;


    var canvas = document.createElement('canvas');
    var context = canvas.getContext('2d');
    var borderSize = 20;

    var qrCodeImage = new Image();
    qrCodeImage.onload = function () {
        var paddingBelowQR = 30;
        var textHeight = 24;

        canvas.width = qrCodeImage.width + 2 * borderSize;
        canvas.height = qrCodeImage.height + 2 * borderSize + paddingBelowQR;

        context.fillStyle = 'white';
        context.fillRect(0, 0, canvas.width, canvas.height);
        context.drawImage(qrCodeImage, borderSize, borderSize);

        context.font = textHeight + "px Arial";
        context.fillStyle = "black";
        context.textAlign = "center";
        context.fillText(uniqueIdText, canvas.width / 2, qrCodeImage.height + borderSize + textHeight);

        var modifiedImgSrc = canvas.toDataURL('image/png');

        var a = document.createElement('a');
        a.href = modifiedImgSrc;
        a.download = uniqueIdText + 'QRCode.png';
        a.click();
    };
    qrCodeImage.src = imgSrc;
});

//Qr Printing
document.getElementById('printBtn').addEventListener('click', function () {
    var numberOfSets = prompt("How many sets of QR codes do you want to print? (3 QR copies per set)");
    if (numberOfSets === null || numberOfSets <= 0) {
        alert('Invalid number of sets.');
        return;
    }

    var numberOfCopies = numberOfSets * 3;

    var printWindow = window.open('', '_blank');
    if (!printWindow) {
        alert('Unable to open print window. Please disable popup blockers.');
        return;
    }

    var canvas = document.querySelector('#qrcode canvas');
    if (!canvas) {
        alert('No canvas element found for QR code.');
        return;
    }

    var imgSrc = canvas.toDataURL('image/png');
    var uniqueIdText = document.getElementById('uniqueId').textContent;

    var htmlContent = `
        <html>
            <head>
                <title>Print QR Code</title>
                <style>
                    body {
                        text-align: center;
                        font-family: Arial, sans-serif;
                        column-count: 3;
                        column-gap: 20px;
                        margin: 0;
                        padding: 10px;
                    }
                    .qr-code {
                        break-inside: avoid-column;
                        page-break-inside: avoid;
                        margin-bottom: 20px;
                        width: 200px;
                        height: auto;
                    }
                    img {
                        width: 200px;
                        height: 200px;
                    }
                    h3 {
                        word-wrap: break-word;
                        font-size: 14px;
                    }
                </style>
            </head>
            <body onload="window.print(); window.close();">`;

    for (var i = 0; i < numberOfCopies; i++) {
        htmlContent += `<div class="qr-code">
                            <img src="${imgSrc}" alt="QR Code"/>
                            <h3>${uniqueIdText}</h3>
                        </div>`;
    }

    htmlContent += `</body></html>`;

    printWindow.document.open();
    printWindow.document.write(htmlContent);
    printWindow.document.close();
});

