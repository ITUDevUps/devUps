import React, {useState} from 'react';
import './Register.css';

function Register() {
	const {REACT_APP_API_URL} = process.env;
	const [userName, setUserName] = useState('');
	const [email, setEmail] = useState('');
	const [password, setPassword] = useState('');
	const [repeatPassword, setRepeatPassword] = useState('');

	const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
		e.preventDefault();

		if (password !== repeatPassword) {
			alert("Passwords don't match");
			return;
		}

		if (!email.includes(".") || !email.includes("@")) {
			alert("Invalid email");
			return;
		}

		fetch(`${REACT_APP_API_URL}/user/register`,
			{
				method: "POST",
				headers: {"Content-Type": "application/json"},
				mode: "cors",
				body: JSON.stringify({username: userName, password, email})
			})
			.then((res) => {
				if (res.status === 200) {
					window.location.href = "/login";
				} else {
					alert("An error has occurred");
				}
			}).catch((err) => {
			alert(err);
		})
	}

	return (
		<div>
			<h2>Sign Up</h2>
			<form className="register-form-container" onSubmit={handleSubmit}>
				<label htmlFor="username" className="register-label">
					Username
				</label>
				<input id="username" className="register-input" type="text" name="username" value={userName}
					   onChange={e => setUserName(e.target.value)} autoFocus required/>
				<label htmlFor="email" className="register-label">
					E-mail
				</label>
				<input id="email" className="register-input" type="email" name="email" value={email}
					   onChange={e => setEmail(e.target.value)} required/>
				<label htmlFor="password" className="register-label">
					Password
				</label>
				<input id="password" className="register-input" type="password" name="password" minLength={8}
					   value={password} onChange={e => setPassword(e.target.value)} required/>
				<label htmlFor="repeatPassword" className="register-label">
					Password (repeat)
				</label>
				<input id="repeatPassword" className="register-input" type="password" name="password" minLength={8}
					   value={repeatPassword} onChange={e => setRepeatPassword(e.target.value)} required/>
				<input className="register-submit" type="submit" value="Sign Up"/>
			</form>
		</div>
	);
}

export default Register;
