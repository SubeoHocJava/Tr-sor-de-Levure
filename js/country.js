// country.js

// Function to load countries and populate the country dropdown
function loadCountries() {
    const countrySelect = document.getElementById('country'); // Get the country select element

    // Clear any existing options
    countrySelect.innerHTML = '';

    console.log("Loading countries...");

    // Fetch countries from the API
    fetch('https://restcountries.com/v3.1/all')
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to fetch countries');
            }
            return response.json();
        })
        .then(countries => {
            console.log("Countries fetched:", countries);

            // Add a default option at the top
            let defaultOption = document.createElement('option');
            defaultOption.textContent = 'Select a Country';
            defaultOption.value = '';
            countrySelect.appendChild(defaultOption);

            // Loop through countries and add each as an option
            countries.forEach(country => {
                let option = document.createElement('option');
                option.value = country.cca2; // Using the country code (e.g., "US" for United States)
                option.textContent = country.name.common; // Country name (e.g., "United States")
                countrySelect.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error fetching country data:', error);
            let defaultOption = document.createElement('option');
            defaultOption.textContent = 'Failed to load countries';
            countrySelect.appendChild(defaultOption);
        });
}

// Call the function to load countries when the page loads
window.onload = loadCountries;
