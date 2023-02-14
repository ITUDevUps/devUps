import React from 'react';
import './App.css';
import {Link, Outlet} from "react-router-dom";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <h1>MiniTwit</h1>
                <div className="navigation">
                    <Link className="nav-link" to="/">Public Timeline</Link> |
                    <Link className="nav-link" to="/login">Login</Link> |
                    <Link className="nav-link" to="/sign-up">Sign up</Link>
                </div>
                <Outlet/>
            </header>
        </div>
    );
}

export default App;
