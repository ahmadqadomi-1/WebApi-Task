document.getElementById("addRapperForm").addEventListener("submit", async (event) => {
    event.preventDefault(); // Prevent default form submission

    const formData = new FormData(event.target); // Collect form data

    try {
        const response = await fetch("https://localhost:44389/api/Rapper", {
            method: "POST",
            body: formData,
        });

        if (response.ok) {
            alert("Rapper was added successfully");
        } else {
            alert("Failed to add rapper. Please try again.");
        }
    } catch (error) {
        console.error("Error:", error);
        alert("An error occurred while adding the rapper");
    }
});
