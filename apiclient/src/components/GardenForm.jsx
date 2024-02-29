import { h } from 'preact';
import { useState } from 'preact/hooks';

export function GardenForm({ onSubmit }) {
  const [gardenName, setGardenName] = useState('');
  const [gardenSize, setGardenSize] = useState('');
  const [gridQty, setGridQty] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit({ gardenName, gardenSize, gridQty });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Name:</label>
        <input type="text" value={gardenName} onChange={(e) => setGardenName(e.target.value)} />
      </div>
      <div>
        <label>Size:</label>
        <input type="text" value={gardenSize} onChange={(e) => setGardenSize(e.target.value)} />
      </div>
      <div>
        <label>Grid Quantity:</label>
        <input type="text" value={gridQty} onChange={(e) => setGridQty(e.target.value)} />
      </div>
      <button type="submit">Create Garden</button>
    </form>
  );
}