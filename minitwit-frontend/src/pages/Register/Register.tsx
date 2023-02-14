import React, {useState} from 'react';
import './Register.css';

function Register() {

    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    return (
        <div>
            <h1>Sign Up</h1>
            <form className="register-form-container">
                <label htmlFor="username">
                    Username:
                </label>
                <input id="username" className="register-input" type="text" name="username" value={username} onChange={e => setUsername(e.target.value)} autoFocus required/>
                <label htmlFor="email">
                    E-mail:
                </label>
                <input id="email" className="register-input" type="email" name="email" value={email} onChange={e => setEmail(e.target.value)} required/>
                <label htmlFor="password">
                    Password:
                </label>
                <input id="password" className="register-input" type="password" name="password" minLength={8} value={password} onChange={e => setPassword(e.target.value)} required/>
                <label htmlFor="repeatPassword">
                    Password (repeat):
                </label>
                <input id="repeatPassword" className="register-submit" type="password" name="password" minLength={8} required/>
                <input className="register-submit" type="submit" value="Sign Up"/>
            </form>
        </div>
    );
}

export default Register;
