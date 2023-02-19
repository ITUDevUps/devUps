import React, {useEffect, useState} from 'react';
import Message, {IMessage} from "../../components/message/Message";
import "./Timeline.css";
import LoadingSpinner from "../../components/LoadingSpinner/LoadingSpinner";

function Timeline() {

    const [messages, setMessages] = useState([]);
    const [twit, setTwit] = useState("");
    const [loading, setLoading] = useState(false);
    const [token, setToken] = useState(true);

    useEffect(() => {
        fetchMessages();
    }, [])

    const fetchMessages = () => {
        setLoading(true);
        fetch("http://localhost:3005/getMessages", {
            method: "GET",
            headers: {"Content-Type": "application/json"},
            mode: "cors",
        })
            .then((response) => response.json())
            .then((json) => {
                setMessages(json);
                setLoading(false);
            })
    }


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
                fetchMessages();
            })
    }

// @ts-ignore
    return (
        <div className="timeline-container">
            {token && (
            <div>
                <form className="post-message-form" onSubmit={handleSubmit}>
                <textarea id="message" className="post-message-input" name="message" value={twit}
                          onChange={e => setTwit(e.target.value)} placeholder="What's on your mind?" required/>
                    <input className="post-message-submit" type="submit" value="Post"/>
                </form>
            </div>
            )}
            <div className="timeline">
                {loading ? <LoadingSpinner/> :
                    messages.length !== 0 ? messages.map((message: IMessage, index) => (
                            <Message
                                key={index}
                                image={"https://uploads.neatorama.com/images/posts/376/63/63376/1373756607-0.jpg"}
                                userName={message.userName}
                                message={message.message}
                                date={new Date(parseInt(message.date) * 1000).toLocaleString()}
                            />
                        )) :
                        <div>
                            <p className="no-message-headline">No messages</p>
                            <p>Maybe there is an error... or maybe you don't have friends</p>
                        </div>
                }
            </div>
        </div>
    );
}


export default Timeline;
