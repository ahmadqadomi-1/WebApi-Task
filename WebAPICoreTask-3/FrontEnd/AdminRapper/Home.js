async function getAllRappers() {
    let url = "https://localhost:44389/api/Rapper/GetAllRappers";

    try {
        let response = await fetch(url);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        let data = await response.json();
        let tableBody = document.querySelector("#table tbody");

        tableBody.innerHTML = '';

        data.forEach(rapper => {
            let row = document.createElement("tr");

            row.innerHTML = `
                <td>${rapper.rapperName}</td>
                <td>
                    <img src="../Images/${rapper.rapperImage}" alt="${rapper.rapperImage} (Image not found)" />
                </td>
                <td>
                    <button class="btn btn-primary" value="${rapper.rapperId}" onclick="saveId(this)">View Tracks</button>
                </td>
                <td>
                    <a class="btn btn-warning" href="../AdminRapper/EditRapper.html?rapperId=${rapper.rapperId}">Edit</a>
                </td>
            `;

            tableBody.appendChild(row);
        });

    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

function saveId(button) {
    let GetId = button.value;
    localStorage.setItem("rapperId", GetId);
    window.location.href = "../AdminTrack/Home.html"; 
}

getAllRappers();
