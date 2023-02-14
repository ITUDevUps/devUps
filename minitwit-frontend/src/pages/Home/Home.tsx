import React, {useEffect, useState} from 'react';
import Message, {IMessage} from "../../components/message/Message";
import "./Home.css";

function Home() {

    const [messages, setMessages] = useState([]);

    useEffect(() => {
        fetch("http://localhost:3005/getMessages", {
            method: "GET",
            headers: { "Content-Type": "application/json" },
            mode: "cors",
        })
            .then((response) => response.json())
            .then((json) => {
                setMessages(json);
            })
    }, [])

    // @ts-ignore
    return (
        <div className="home-container">
            <div className="timeline">
                {messages ? messages.map((message: IMessage, index) => (
                    <Message
                        key={index}
                        image={"http://uploads.neatorama.com/images/posts/376/63/63376/1373756607-0.jpg"}
                        userName={message.userName}
                        message={message.message}
                        date={new Date(parseInt(message.date) * 1000).toLocaleString()}
                    />
                )) : undefined}
            </div>
        </div>
    );
}


export default Home;
