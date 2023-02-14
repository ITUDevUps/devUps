import React from 'react';
import './Register.css';

function Register() {
    return (
        <div>
            <h1>Sign Up</h1>
            <form className="register-form-container">
                <label htmlFor="username">
                    Username:
                </label>
                <input id="username" className="register-input" type="text" name="username"/>
                <label htmlFor="email">
                    E-mail:
                </label>
                <input id="email" className="register-input" type="email" name="email"/>
                <label htmlFor="password">
                    Password:
                </label>
                <input id="password" className="register-input" type="password" name="password"/>
                <label htmlFor="repeatPassword">
                    Password (repeat):
                </label>
                <input id="repeatPassword" className="register-submit" type="password" name="password"/>
                <input className="register-submit" type="submit" value="Sign Up"/>
            </form>
        </div>
    );
}

export default Register;
