var url = "https://localhost:44389/api/PlayList";
debugger;
var input = document.getElementById("User").value;
var data = {
  userId: 4,
};



async function Add() {
  event.preventDefault();
  debugger;
  var response = await fetch(url, {
    method: "POST",
    body: JSON.stringify(data),
    headers: {
      "Content-Type": "application/json",
    },
  });
}
