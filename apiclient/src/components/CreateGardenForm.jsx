import { useLocation } from 'preact-iso';
import { useEffect } from 'preact/hooks';

export function CreateGarden() {
  const { url } = useLocation();

  //useeffect ehre for api call

  return (
    <>
      <button>add grid to garden</button>
      <button>add seed to grid</button>
      <p>nav to seed page to add tag</p>
      <p>nav to see garden bed details page</p>
    </>
  );
}
