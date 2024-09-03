async function getAllProducts() {
    var id = localStorage.getItem("productId");
    let url = `https://localhost:44338/api/Products/GetAllProductsForOneCategory/${id}`;




    let response = await fetch (url);


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
                <td><button onclick="Cart(${Product.productId})" class="btn btn-primary">Add To Cart</button></td>
            `;

        tableBody.appendChild(row);
    });
    

// function Details(id) {
//     localStorage.setItem("productId", id);
//     window.location.href = "../Details/Details.html";
// }

function Cart(button) {
    let GetId = button.value;
    localStorage.setItem("productId", GetId);
    window.location.href = "../Cart/Cart.html";
}
}
getAllProducts();
