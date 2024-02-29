import './style.css';

export function Home() {
	
	const handleCreateGarden = () => {
		window.location.href = ('/create-garden');
	}

	const handleSignIn = () => {
		window.location.href = '/Signin';
	}

	return (
		<div className="home">
			<h1>Garden Tracker</h1>
			<h3>Get Started</h3>
			<p>Create a garden bed, add grids, plant a seed in each grid, optional tags for seeds</p>

			<button onClick={handleCreateGarden}>Create garden bed</button>
			<hr />
			
			<button onClick={handleSignIn} className="button">User Login</button>
			
		</div>
	);
}