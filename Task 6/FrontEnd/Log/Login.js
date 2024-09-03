const url = "https://localhost:44338/api/User/Login";

let form = document.getElementById("form");

form.addEventListener("submit", async function(event) {
    event.preventDefault();

    


    let data = {
        username: document.getElementById("username").value,
        password: document.getElementById("password").value
    };

    let response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Content-Type": "application/json",
        },
        
    });
    var result = await response.json();
    localStorage.setItem('jwtToken', result.token);
    
    if (response.ok) {
        alert("Done");
        window.location.href = "../Category/Category.html";
    } else {
        alert("Invalid username or password");
    }
});
