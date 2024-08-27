async function getAllTracks() {
    var id = localStorage.getItem("rapperId");
    let url = `https://localhost:44389/api/Track/GetAllTracksForOneRaper/${id}`;

    try {
        let response = await fetch(url);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        
        let data = await response.json();
        let tableBody = document.getElementById("trackTableBody");

        data.forEach(track => {
            let row = document.createElement("tr");

            row.innerHTML = `
                <td><img src="../Images/${track.trackImage}" alt="${track.trackImage}" style="width: 100px; height: auto;"></td>
                <td>${track.trackName}</td>
                <td>${track.description}</td>
                <td>${track.duration}</td>
                <td>${track.rapperId}</td>
                <td>${track.trackId}</td>
                <td><button onclick="saveId(${track.trackId})" class="btn btn-primary">Add To Playlist</button></td>
            `;

            tableBody.appendChild(row);
        });

    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

function saveId(id) {
    localStorage.setItem("trackId", id);
}

getAllTracks();
