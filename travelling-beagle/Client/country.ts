const countryImages = document.getElementsByClassName('country-image-src');
const overlay = <HTMLDivElement>document.getElementById("overlay");
const overlayImage = <HTMLImageElement>document.getElementById("overlayImage");

for (let i = 0; i < countryImages.length; i++) {
    const img = <HTMLImageElement>countryImages.item(i);
    img.onclick = () => {
        overlayImage.src = img.src;
        overlay.style.display = 'block';
        overlayImage.style.left = `${window.innerWidth / 2 - img.width}px`;
    };
}

overlay.onclick = () => overlay.style.display = 'none';
