async function getAllRappers() {
    let url = "https://localhost:44389/api/Rapper/GetAllRappers";

        let response = await fetch(url);

        let data = await response.json();
        
        let cardContainer = document.getElementById("Container");
        
        data.forEach(rapper => {
            cardContainer.innerHTML += `
            <div class="card" style="width: 18rem;">
                <img src="../Images/${rapper.rapperImage}" style="width:100%; height: 255.53px;" class="card-img-top" alt="${rapper.rapperImage} (Image not found)">
                <div class="card-body">
                    <h5 class="card-title">${rapper.rapperName}</h5>
                    <button class="btn btn-primary" value="${rapper.rapperId}" onclick="saveId(this)">View Tracks</button>
                </div>    
            </div>
            `;
        });

        console.log(data);

}
function saveId(button) {
    let GetId = button.value;
    localStorage.setItem("rapperId", GetId);
    window.location.href = "../Tracks/track.html"; 
}
getAllRappers();
saveId();
