function getCountryLinks(): HTMLCollectionOf<HTMLAnchorElement> {
    return <HTMLCollectionOf<HTMLAnchorElement>>document.getElementsByClassName('country-link');
}

function getCodeFromCountryLink(link: HTMLAnchorElement): string {
    return link.attributes.getNamedItem('data-code').value.trim().toUpperCase();
}

function focusCountriesOnMap(countryCodes: string[], dataMap: any) {
    let updated: { [c: string]: any } = null;

    if (countryCodes.length > 0) {
        updated = {};
        for (let i = 0; i < countryCodes.length; i++) {
            const code = countryCodes[i];
            updated[code] = { fillKey: 'FOCUSED' };
        }
    }

    dataMap.updateChoropleth(updated, { reset: true });
}

function filterChange(dataMap: any) {
    return (event: Event) => {
        const element = <HTMLInputElement>event.target;
        const text = element.value.trim().toLowerCase();
        const visibleCountryCodes: string[] = [];

        const countryLinks = getCountryLinks();
        for (let i = 0; i < countryLinks.length; i++) {
            const link = countryLinks.item(i);
            link.classList.remove('hidden');

            if (text.length > 0 && link.innerText.toLowerCase().indexOf(text) < 0) {
                link.classList.add('hidden');
            } else {
                // country should be displayed
                visibleCountryCodes.push(getCodeFromCountryLink(link));
            }
        }

        focusCountriesOnMap(visibleCountryCodes, dataMap);
    };
}

function countryLinkHover(dataMap: any, isEnter: boolean) {
    return (event: Event) => {
        const element = <HTMLAnchorElement>event.target;
        const code = getCodeFromCountryLink(element);

        if (isEnter) {
            focusCountriesOnMap([code], dataMap);
        } else {
            focusCountriesOnMap([], dataMap);
        }
    };
}

const mapContainer = document.getElementById('mapContainer');
mapContainer.classList.remove('hidden');

declare var Datamap: any;
const dataMap = new Datamap({
    element: mapContainer,
    responsive: true,
    fills: {
        defaultFill: '#c7c7c7',
        FOCUSED: '#e4e65e'
    },
    geographyConfig: {
        highlightFillColor: '#e4e65e'
    }
});

const countryFilter = document.getElementById('countryFilter');
countryFilter.onkeyup = filterChange(dataMap);
countryFilter.classList.remove('hidden');

const mainContainer = document.getElementById('mainContainer');
mainContainer.classList.remove('twelve');
mainContainer.classList.add('six');

const countryLinks = getCountryLinks();
for (let i = 0; i < countryLinks.length; i++) {
    const link = countryLinks.item(i);
    link.onmouseenter = countryLinkHover(dataMap, true);
    link.onmouseleave = countryLinkHover(dataMap, false);
}
