class Ajax {
    Get<T>(url: string, callback: (err: Event, res: T) => void) {
        const xhr = new XMLHttpRequest();
        xhr.open('GET', url);
        xhr.send();

        xhr.addEventListener('load', () => {
            try {
                const parsed = JSON.parse(xhr.responseText);
                callback(null, parsed);
            } catch (err) {
                callback(err, null);
            }
        });

        xhr.addEventListener('error', (e) => {
            callback(e, null);
        });
    }
}

const ajax = new Ajax();

interface Country {
    name: string,
    isoCode: string
};

function sideMenuFilterCountries(event: Event) {
    const countryLinks = <HTMLCollectionOf<HTMLAnchorElement>>document.getElementsByClassName('country-link');
    for (let i = 0; i < countryLinks.length; i++) {
        const link = countryLinks.item(i);
        const element = <HTMLInputElement>event.target;
        const text = element.value.trim().toLowerCase();
        link.classList.remove('hidden');

        if (text.length > 0 && link.innerText.toLowerCase().indexOf(text) < 0) {
            link.classList.add('hidden');
        }
    }
}

function loadNavMenu() {
    const countryFilter = document.getElementById('countryFilter');
    const menu = document.getElementById('navMenuButton');

    if (!countryFilter) {
        // Not on a page with a country list displayed by default
        menu.style.display = 'inline';
        const sideMenuCountryFilter = document.getElementById('sideMenuCountryFilter');
        sideMenuCountryFilter.onkeyup = sideMenuFilterCountries;

        ajax.Get<[Country]>('/country/all.json', (err, res) => {
            if (res) {
                // Display countries in side menu
                const entryContainer = document.getElementById('sideMenuEntries');
                const views = res.forEach(c => {
                    const row = document.createElement('div');
                    row.classList.add('row');
                    const link = document.createElement('a');
                    link.href = `/country/${c.isoCode}`;
                    link.classList.add('country-link');
                    link.appendChild(document.createTextNode(c.name));
                    row.appendChild(link);

                    entryContainer.appendChild(row);
                });
            }
        });
    }
}

const sideMenu = document.getElementById('sideMenu');

document.getElementById('navMenuButton').onclick = () => {
    sideMenu.style.left = '0px';
};
document.getElementById('closeSideMenu').onclick = () => {
    sideMenu.style.left = '-100%';
};

loadNavMenu();
