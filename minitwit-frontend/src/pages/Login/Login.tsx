import React, {useState} from 'react';
import './Login.css';

function Login() {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    return (
        <div>
            <h1>Login</h1>
            <form className="login-form-container">
                <label htmlFor="username">
                    Username:
                </label>
                <input id="username" className="login-input" type="text" name="username" autoFocus value={username} onChange={e => setUsername(e.target.value)}/>
                <label htmlFor="password">
                    Password:
                </label>
                <input id="password" className="login-input" type="password" name="password" value={password} onChange={e => setPassword(e.target.value)}/>
                <input className="login-submit" type="submit" value="Login"/>
            </form>
        </div>
    );
}

export default Login;
