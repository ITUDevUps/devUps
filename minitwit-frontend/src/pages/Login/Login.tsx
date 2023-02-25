import React, {useState} from 'react';
import './Login.css';

function Login() {

    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit= (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        fetch("http://157.245.27.152:3005/user/login",
            {
                method: "POST",
                headers: {"Content-Type": "application/json"},
                mode: "cors",
                body: JSON.stringify({username: userName, password})
            }).then(res => res.json())
            .then((res) => {
                if(res.message !== -1) {
                    window.location.href = "/";
                    localStorage.setItem("token", "coolToken");
                } else {
                    alert(res.message);
                }
            })
    }

    return (
        <div>
            <h2>Login</h2>
            <form className="login-form-container" method="post" onSubmit={handleSubmit}>
                <label htmlFor="username" className="login-label">
                    Username
                </label>
                <input id="username" className="login-input" type="text" name="username" autoFocus value={userName} onChange={e => setUserName(e.target.value)}/>
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
