//module for making api request
export async function createGarden(gardenData) {
  try {
    const response = await fetch('http://localhost:5000/api/Gardens', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(gardenData)
    });
    if (response.ok) {
      const responseData = await response.json();
      return responseData;
    } else {
      throw new Error('Failed to create garden');
    }
  } catch (error) {
    console.error('An error occurred:', error);
    throw error;
  }
}