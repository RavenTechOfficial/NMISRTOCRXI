
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
