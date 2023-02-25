import React from 'react';
import './App.css';
import {Link, Outlet} from "react-router-dom";
import {ReactComponent as SearchIcon} from "./assets/icons/search-icon.svg";

function App() {

    const [searchQuery, setSearchQuery] = React.useState("");
    const [searchbarActive, setSearchbarActive] = React.useState(false);

    const logout = () => {
        localStorage.removeItem("token");
        window.location.href = "/";
    }

    return (
        <div className="App">
            <header className="App-header">
                <div className="navigation">
                    <div className="left-side-nav">
                        <Link className="nav-link" to="/">Timeline</Link>
                        <SearchIcon className="search-icon" onClick={() => setSearchbarActive(!searchbarActive)}/>
                        {searchbarActive && (
                            <input className="search-input" type="text" placeholder="Search..." value={searchQuery}
                                   onChange={e => setSearchQuery(e.target.value)}/>
                        )}
                    </div>
                    {(localStorage.getItem("token") === null) && (
                        <div>
                            <Link className="nav-link" to="/login">Login</Link> |
                            <Link className="nav-link" to="/sign-up">Sign up</Link>
                        </div>
                    )}
                    {(localStorage.getItem("token") !== null) && (
                        <div>
                            <p className="nav-link logout-button" onClick={logout}>Logout</p>
                        </div>
                    )}
                </div>
                <h1>MiniTwit</h1>
                <Outlet/>
            </header>
            <footer className="App-footer">
                <p>MiniTwit - A DevUps Application</p>
            </footer>
        </div>
    );
}

export default App;
