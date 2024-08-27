var id = localStorage.getItem("rapperId");
var url = `https://localhost:44389/api/Track/GetAllTracksForOneRaper/${id}`;

async function getAllTracks() {
  try {
    let response = await fetch(url);
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    
    let data = await response.json();
    let tableBody = document.querySelector("#tracksTable tbody");
    console.log(data);

    // Clear previous rows
    tableBody.innerHTML = '';

    data.forEach(track => {
      let row = document.createElement("tr");

      row.innerHTML = `
        <td>${track.trackName}</td>
        <td>${track.description}</td>
        <td>
          <img src="../Images/${track.trackImage}" width="80" height="80" alt="${track.trackImage} (Image Not Found)" />
        </td>
        <td>${track.duration}</td>
        <td>${track.rapperId}</td>
        <td>${track.trackId}</td>
        <td>
          <button onclick="saveId(${track.trackId})" class="btn btn-primary">Add To Playlist</button>
        </td>
        <td>
          <a class="btn btn-warning" href="../AdminTrack/EditTrack.html?trackId=${track.trackId}">Edit</a>
        </td>
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
