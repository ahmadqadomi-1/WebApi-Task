async function getAllCategories() {
  let url = "https://localhost:44338/api/Category/getAllCategories";


  var token=localStorage.getItem("jwtToken");
    // event.preventDefault();
    var response = await fetch(url,{
      method: "GET",
        headers: {
        'Authorization': `Bearer ${token}`
    }});
    let data = await response.json();
  let cardContainer = document.getElementById("container");

  data.forEach((category) => {
    cardContainer.innerHTML += `
            <div class="card" style="width: 18rem;">
                <img src="../Images/${category.categoryImage}" style="width:100%; height: 255.53px;" class="card-img-top" alt="${category.categoryImage} (Image not found)">
                <div class="card-body">
                    <h5 class="card-title">${category.categoryName}</h5>
                    <button class="btn btn-primary" value="${category.categoryId}" onclick="saveId(${category.categoryId})">View Products</button>
                </div>    
            </div>
            `;
  });
  console.log(data);
}
function saveId(button) {
  debugger;
  let GetId = button;
  localStorage.setItem("productId", GetId);
  window.location.href = "../Product/Product.html";
}
getAllCategories();
// saveId();
