async function getAllTracks() {
    let url = "https://localhost:44389/api/Track/GetAllTracks";
    
    try {
        let response = await fetch(url);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        
        let data = await response.json();
        let cardContainer = document.getElementById("Container");
        console.log(data);


        data.forEach(track => {
            cardContainer.innerHTML += `
            <div class="card mb-4" style="width: 18rem;">
                <img src="../Images/${track.trackImage}" class="card-img-top" alt="${track.trackImage} (Image Not Found)">
                <div class="card-body">
                    <h5 class="card-title">${track.trackName}</h5>
                    <p class="card-text">${track.description}</p>
                </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">${track.duration}</li>
                    <li class="list-group-item">${track.rapperId}</li>
                    <li class="list-group-item">${track.trackId}</li>
                </ul>
                <div class="card-body">
                    <button value="${track.trackId}" onclick="saveId(this)" class="btn btn-primary">Add To Playlist</button>
                </div>
            </div>
            `;
        });

    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

function saveId(button) {
    let trackId = button.value;
    localStorage.setItem("trackId", trackId);
}


getAllTracks();
saveId();