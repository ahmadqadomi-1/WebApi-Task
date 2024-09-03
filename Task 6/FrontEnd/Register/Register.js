const url = "https://localhost:44338/api/User/Register";
let form = document.getElementById("form");
event.preventDefault();
async function register() {
    let formData = new FormData (form);

    let repeatPass=document.getElementById("repeatPass").value;
    let password=document.getElementById("password").value
    if(repeatPass!=password){
        alert("the password doesn't match")
        return;
    }

    let response = await fetch(url, 
        {
            method: "POST",
            body:formData,
        }
    );
    if(!response.ok){
        alert("this email is already exist");
            }
            let data=await response.json();

            location.href = "../Log/LogIn.html";

            alert("you are register ");
}

register();