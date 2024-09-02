async function getAllProducts() {
    var id = localStorage.getItem("productId");
    let url = `https://localhost:44338/api/Products/GetAllProductsForOneCategory/${id}`;

    try {
    let response = await fetch(url);
    if (!response.ok) {
        throw new Error("Network response was not ok");
    }

    let data = await response.json();
    let tableBody = document.getElementById("ProductTableBody");

    data.forEach((Product) => {
        let row = document.createElement("tr");

    row.innerHTML = `
                <td><img src="../Images/${Product.productImage}" alt="${Product.productImage}" style="width: 100px; height: auto;"></td>
                <td>${Product.productName}</td>
                <td>${Product.description}</td>
                <td>${Product.price}</td>
                <td>${Product.categoryId}</td>
                <td>${Product.productId}</td>
                <td><button onclick="Details(${Product.productId})" class="btn btn-primary" >Details</button></td>
                <td><button onclick="PlayList(${Product.productId})" class="btn btn-primary">Add To Playlist</button></td>
            `;

        tableBody.appendChild(row);
    });
    } catch (error) {
    console.error("Error fetching data:", error);
    }
}

function Details(id) {
    localStorage.setItem("trackId", id);
    window.location.href = "../Details/Details.html";
}

  // function PlayList(button) {
  //   let GetId = button.value;
  //   localStorage.setItem("trackId", GetId);
  //   window.location.href = "../PlayList/PlayList.html";
  // }

getAllProducts();
