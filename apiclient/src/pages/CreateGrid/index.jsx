//build out garden here?
//create garden bed api call
//add grid to garden bed id
//add seed to grid by id

//nav to seed page for details/add tags?
//nav to garden details page with all info displayed
import { h } from 'preact';
import { useState } from "preact/hooks";
import { createGarden } from '../../services/api.js';

export function CreateGrid() {
  // const [isLoading, setIsLoading] = useState(false);

  // const handleSubmitApi = async (formData) => {
  //   setIsLoading(true);

  //   try {
  //     const createdGarden = await createGarden(formData);
  //     console.log('Garden creation success', createdGarden);
  //   } catch (error) {
  //     console.error('fail:', error);
  //   }
  //   setIsLoading(false);
  // };

  return (
    <div class="gDeets">
      
      <p>display garden info? </p>
      <section>
        <button>Add grids to this garden bed?</button>
      </section>
      <section>
        <button>Add seeds to this grid?</button>
      </section>
    </div>
  );
}