import React, {useState} from 'react';
import './MessageField.css';

function MessageField() {

    const [twit, setTwit] = useState("");
    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        fetch("http://157.245.27.152:3005/postMessage", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            mode: "cors",
            body: JSON.stringify({message: twit})
        })
            .then((response) => response.json())
            .then(() => {
                setTwit("");
            })
    }

    return (
        <form className="post-message-form" onSubmit={handleSubmit}>
                <textarea id="message" className="post-message-input" name="message" value={twit}
                          onChange={e => setTwit(e.target.value)} placeholder="What's on your mind?" required/>
            <input className="post-message-submit" type="submit" value="Post"/>
        </form>
    );
}

export default MessageField;
