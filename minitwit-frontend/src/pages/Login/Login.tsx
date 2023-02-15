import React, {useState} from 'react';
import './Login.css';

function Login() {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit= (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        fetch("http://localhost:3005/getMessages",
            {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                mode: "cors",
                body: JSON.stringify({username, password})
            })
    }

    return (
        <div>
            <h2>Login</h2>
            <form className="login-form-container" method="post" onSubmit={handleSubmit}>
                <label htmlFor="username" className="login-label">
                    Username
                </label>
                <input id="username" className="login-input" type="text" name="username" autoFocus value={username} onChange={e => setUsername(e.target.value)}/>
                <label htmlFor="password" className="login-label">
                    Password
                </label>
                <input id="password" className="login-input" type="password" name="password" value={password} onChange={e => setPassword(e.target.value)}/>
                <input className="login-submit" type="submit" value="Login"/>
            </form>
        </div>
    );
}

export default Login;
