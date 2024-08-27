document.addEventListener("DOMContentLoaded", async () => {
    const rapperId = localStorage.getItem("rapperId"); 

    if (rapperId) {
        try {
            const response = await fetch(`https://localhost:44389/api/Rapper/UpdateTheRapperByID/${rapperId}`);
            if (!response.ok) throw new Error('Failed to fetch rapper data');

            const data = await response.json();

            document.getElementById("RapperName").value = data.name;
        } catch (error) {
            console.error("Error fetching rapper data:", error);
        }
    } else {
        alert("No rapper ID found. Please select a rapper to edit.");
    }
});

document.getElementById("updateRapperForm").addEventListener("submit", async (event) => {
    event.preventDefault(); 

    const formData = new FormData(event.target); 
    const rapperId = localStorage.getItem("rapperId"); 

    if (rapperId) {
        try {
            const response = await fetch(`https://localhost:44389/api/Rapper/UpdateTheRapperByID/${rapperId}`, {
                method: "PUT", 
                body: formData,
            });

            if (response.ok) {
                alert("Rapper details updated successfully");
            } else {
                alert("Failed to update rapper details. Please try again.");
            }
        } catch (error) {
            console.error("Error updating rapper data:", error);
            alert("An error occurred while updating the rapper details");
        }
    } else {
        alert("No rapper ID found. Please select a rapper to edit.");
    }
});
