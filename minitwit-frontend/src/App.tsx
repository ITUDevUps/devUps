import React, {useState} from 'react';
import './App.css';
import {Link, Outlet} from "react-router-dom";
import SearchBar from "./components/SearchField/SearchBar";
import {UserContext} from "./Util/Contexts/UserContext";
import {User} from "./Util/Types";

function App() {

	const [user, setUser] = useState<User | null>(null);

	const logout = () => {
		localStorage.removeItem("token");
		window.location.href = "/";
	}

	return (
		<div className="App">
			<header className="App-header">
				<div className="navigation">
					<div className="nav-links">
						<Link className="nav-link" to="/">Timeline</Link>
						<SearchBar/>
					</div>
					<div className="nav-links title">
						<h3>MiniTwit</h3>
					</div>
					{(localStorage.getItem("token") === null) && (
						<div className="nav-links">
							<Link className="nav-link" to="/login">Login</Link> |
							<Link className="nav-link" to="/sign-up">Sign up</Link>
						</div>
					)}
					{(localStorage.getItem("token") !== null) && (
						<>
							<div className="nav-links">
								<Link className="nav-link" to="/user/">Profile</Link>
								<p className="nav-link logout-button" onClick={logout}>Logout</p>
							</div>
						</>
					)}
				</div>
				<div className="App-content">
					<UserContext.Provider value={{user, setUser}}>
						<Outlet/>
					</UserContext.Provider>
				</div>
			</header>
			<footer className="App-footer">
				<p>MiniTwit - A DevUps Application</p>
			</footer>
		</div>
	);
}

export default App;
