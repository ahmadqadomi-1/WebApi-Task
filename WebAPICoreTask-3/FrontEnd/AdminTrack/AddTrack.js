document.getElementById("addTrackForm").addEventListener("submit", async (event) => {
    event.preventDefault(); 

    const formData = new FormData(event.target); 

    try {
        const response = await fetch("https://localhost:44389/api/Track", { 
            method: "POST",
            body: formData,
        });

        if (response.ok) {
            alert("Track was added successfully");
        } else {
            alert("Failed to add track. Please try again.");
        }
    } catch (error) {
        console.error("Error:", error);
        alert("An error occurred while adding the track");
    }
});
