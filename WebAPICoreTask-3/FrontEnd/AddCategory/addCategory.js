async function addRapp(){
    var data = document.getElementById("form");
    var deta = new FormData (data);
    event.preventDefault();
    let url = "https://localhost:44389/api/Rapper"
    let request = await fetch (url, {method: "POST", body:deta });
    alert("Done");
}