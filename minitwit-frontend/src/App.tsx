import React from 'react';
import './App.css';
import {Link, Outlet} from "react-router-dom";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <div className="navigation">
                    <div>
                        <Link className="nav-link" to="/">Public Timeline</Link>
                    </div>
                    <div>
                        <Link className="nav-link" to="/login">Login</Link> |
                        <Link className="nav-link" to="/sign-up">Sign up</Link>
                    </div>
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
