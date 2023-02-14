import React from 'react';
import './Login.css';

function Login() {
    return (
        <div>
            <h1>Login</h1>
            <form className="login-form-container">
                <label htmlFor="username">
                    Username:
                </label>
                <input id="username" className="login-input" type="text" name="username"/>
                <label htmlFor="password">
                    Password:
                </label>
                <input id="password" className="login-input" type="password" name="password"/>
                <input className="login-submit" type="submit" value="Login"/>
            </form>
        </div>
    );
}

export default Login;
