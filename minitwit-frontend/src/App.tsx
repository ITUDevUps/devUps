import React from 'react';
import logo from './logo.svg';
import './App.css';
import Message from "./components/message/Message";

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo"/>
                <p>
                    Edit <code>src/App.tsx</code> and save to reload.
                </p>
                <Message
                    image={"http://uploads.neatorama.com/images/posts/376/63/63376/1373756607-0.jpg"}
                    userName={"Theo"}
                    message={"fed side"}
                    date={"2020-01-01"}
                />
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>
            </header>
        </div>
    );
}

export default App;
