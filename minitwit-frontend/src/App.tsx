import React from 'react';
import './App.css';
import Home from "./pages/Home/Home";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";

function App() {

    const showHome = window.location.pathname === "/";
    const showLogin = window.location.pathname === "/login";
    const showRegister = window.location.pathname === "/sign-up";

    return (
        <div className="App">
            <header className="App-header">
                <h1>MiniTwit</h1>
                <div className="navigation">
                    <a className="nav-link" href="/">Public Timeline</a> |
                    <a className="nav-link" href="/login">Login</a> |
                    <a className="nav-link" href="/sign-up">Sign up</a>
                </div>
                {showHome ? <Home/> : undefined}
                {showLogin ? <Login/> : undefined}
                {showRegister ? <Register/> : undefined}

            </header>
        </div>
    );
}

export default App;
