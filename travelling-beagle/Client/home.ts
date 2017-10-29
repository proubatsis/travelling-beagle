function filterChange(event: Event) {
    const element = <HTMLInputElement>event.target;
    const text = element.value.trim().toLowerCase();

    const countryLinks = <HTMLCollectionOf<HTMLAnchorElement>>document.getElementsByClassName('country-link');
    for (let i = 0; i < countryLinks.length; i++) {
        const link = countryLinks.item(i);
        link.classList.remove('hidden');

        if (text.length > 0 && link.innerText.toLowerCase().indexOf(text) < 0) {
            console.log(link.innerText);
            link.classList.add('hidden');
        }
    }
}

const countryFilter = document.getElementById('countryFilter');
countryFilter.onkeyup = filterChange;
countryFilter.classList.remove('hidden');
