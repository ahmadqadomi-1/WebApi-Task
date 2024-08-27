document.addEventListener("DOMContentLoaded", async () => {
    const trackId = localStorage.getItem("trackId"); 

    if (trackId) {
        try {
            const response = await fetch(`https://localhost:44389/api/Track/UpdateTheTrackByID/${trackId}`);
            if (!response.ok) throw new Error('Failed to fetch track data');

            const data = await response.json();

            document.getElementById("TrackName").value = data.trackName;
            document.getElementById("Description").value = data.description;
            document.getElementById("Duration").value = data.duration;
            document.getElementById("RapperId").value = data.rapperId;
        } catch (error) {
            console.error("Error fetching track data:", error);
        }
    } else {
        alert("No track ID found. Please select a track to edit.");
    }
});

document.getElementById("addTrackForm").addEventListener("submit", async (event) => {
    event.preventDefault(); 

    const formData = new FormData(event.target); 
    const trackId = localStorage.getItem("trackId"); 

    if (trackId) {
        try {
            const response = await fetch(`https://localhost:44389/api/Track/UpdateTheTrackByID/${trackId}`, {
                method: "PUT", 
                body: formData,
            });

            if (response.ok) {
                alert("Track details updated successfully");
            } else {
                const errorText = await response.text();
                console.error("Error response:", errorText);
                alert("Failed to update track details. Please try again.");
            }
        } catch (error) {
            console.error("Error updating track data:", error);
            alert("An error occurred while updating the track details");
        }
    } else {
        alert("No track ID found. Please select a track to edit.");
    }
});
