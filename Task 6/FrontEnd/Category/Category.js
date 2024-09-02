async function getAllCategories() {
    let url = "https://localhost:44338/api/Category/getAllCategories";
        let response = await fetch(url);
        let data = await response.json();
        
        let cardContainer = document.getElementById("container");
        
        data.forEach(category => {
            cardContainer.innerHTML += `
            <div class="card" style="width: 18rem;">
                <img src="../Images/${category.categoryImage}" style="width:100%; height: 255.53px;" class="card-img-top" alt="${category.categoryImage} (Image not found)">
                <div class="card-body">
                    <h5 class="card-title">${category.categoryName}</h5>
                    <button class="btn btn-primary" value="${category.productId}" onclick="saveId(this)">View Products</button>
                </div>    
            </div>
            `;
        });
        console.log(data);
}
function saveId(button) {
    let GetId = button.value;
    localStorage.setItem("productId", GetId);
    window.location.href = "../Product/Product.html"; 
}
getAllCategories();
saveId();