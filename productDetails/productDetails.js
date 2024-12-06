// Get buttons and content area
const btnDescription = document.getElementById("btnDescription");
const btnDetails = document.getElementById("btnDetails");
const contentArea = document.getElementById("contentArea");

// Add click events for buttons
btnDescription.addEventListener("click", () => {
  btnDescription.classList.add("active");
  btnDetails.classList.remove("active");
  contentArea.innerHTML = `
    <p>
      Be the first to review Indri Dru Ex Bourbon Cask Strength. Write
      a review!
    </p>
  `;
});

btnDetails.addEventListener("click", () => {
  btnDetails.classList.add("active");
  btnDescription.classList.remove("active");
  contentArea.innerHTML = `
    <table class="custom-table w-100">
      <thead>
        <tr>
          <th>Attribute</th>
          <th>Value</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td><b>Brand</b></td>
          <td>Hazelwood</td>
        </tr>
        <tr>
          <td><b>Country</b></td>
          <td>Scotland</td>
        </tr>
        <tr>
          <td><b>Size</b></td>
          <td>70cl</td>
        </tr>
        <tr>
          <td><b>ABV / Strength</td>
          <td>46.4%</td>
        </tr>
        <tr>
          <td><b>Age</b></td>
          <td>37 Year Old</td>
        </tr>
        <tr>
          <td><b>Varietal</b></td>
          <td>Blended Grain</td>
        </tr>
        <tr>
          <td><b>Status</b></td>
          <td>Non-Chill Filtered</td>
        </tr>
      </tbody>
    </table>
  `;
});
