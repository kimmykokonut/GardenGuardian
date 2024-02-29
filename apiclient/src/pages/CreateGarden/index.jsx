//nav to seed page for details/add tags?
//nav to garden details page with all info displayed
import { h } from 'preact';
import { useState } from "preact/hooks";
import { GardenForm } from "../../components/GardenForm";
import { createGarden } from '../../services/api.js';

export function CreateGarden() {
  const [isLoading, setIsLoading] = useState(false);
  const [gardenData, setGardenData] = useState(null);

  const handleSubmitApi = async (formData) => {
    setIsLoading(true);

    try {
      const createdGarden = await createGarden(formData);
      setGardenData(createdGarden);
      console.log('Garden creation success', createdGarden);
    } catch (error) {
      console.error('fail:', error);
    }
    setIsLoading(false);
  };

  return (
    <div class="create">
      {gardenData === null && (
        <div>
          <h1>Build that bed</h1>
          <GardenForm
            onSubmit={handleSubmitApi} />
        </div>
      )}
      {isLoading && <p>submitting...</p>}
      
      {gardenData != null && (
        <div>
          <p>Garden Details</p>
          <p>Name: {gardenData.name}</p>
          <p>Size: {gardenData.size}</p>
          <p>Grids: {gardenData.gridQty}</p>
          <br />
          <button>Add grids to garden</button>
          <br />
          <button>Add seeds to grid</button>  
          <br />
          <button>Add tags to seeds</button>
          <br />
          <button>See garden details</button>
          <br />
          <button>See all created gardens</button>
        </div>
      )}
    </div>
  );
}