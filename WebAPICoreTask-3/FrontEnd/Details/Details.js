async function ShowDetails() {
    debugger;
    let n = localStorage.getItem("trackId");
    let url = `https://localhost:44389/api/PlayListTracks/GetTrack/${n}`;
    let response = await fetch(url);

    let data = await response.json();
    console.log("API response:", data);

    // Check if data is an object
    if (typeof data !== 'object' || Array.isArray(data)) {
        console.error("Expected an object but got:", typeof data);
        return; // Exit if data is not an object
    }

    let cardContainer = document.getElementById("Container");

    // Clear previous content
    cardContainer.innerHTML = '';

    // Handle the single object case
    let track = data;
    cardContainer.innerHTML = `
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">${track.playListId}</h5>
                <p class="card-text">${track.trackId}</p>
                <p class="card-text">${track.quantity}</p>
                <form id="addToCart">
                        <div>
                            <label>Enter Quantity:</label>
                            <input type="number" name="quantity" id="EnterNumber" />
                        </div>
                        <div>
                            <button type="submit" onclick="addToCart()"class="btn btn-primary">Add To Cart</button>
                        </div>
                    </form>
            </div>
        </div>
    `;
}


ShowDetails();
function addToCart() {
    event.preventDefault();
    const formRef = document.querySelector("form");
    let Q = document.getElementById("EnterNumber");
    fetch("https://localhost:44389/api/PlayList", {
    method: "POST",
    headers: {
        "Content-Type": "application/json",
    },
    body: JSON.stringify({
        cartId: localStorage.getItem("CartId"),
        productId: localStorage.getItem("productId"),
        quantity: Q.value,
    }),
    });
}