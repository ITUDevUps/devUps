import React, {useState} from 'react';
import './Message-field.css';

type Props = { fetchMessages: () => void }
function MessageField(props: Props) {

    const [twit, setTwit] = useState("");
    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        fetch("http://localhost:3005/postMessage", {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            mode: "cors",
            body: JSON.stringify({message: twit})
        })
            .then((response) => response.json())
            .then(() => {
                setTwit("");
                props.fetchMessages();
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
