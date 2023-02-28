import React, {useEffect, useState} from 'react';
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import {IMessage} from "../../Util/Types";
import Message from "../Message/Message";
import "./Timeline.css";

export interface TimelineProps {
    endpoint: string;
}

function Timeline({ endpoint } : TimelineProps) {

    const [loading, setLoading] = useState(false);
    const [messages, setMessages] = useState([]);
    const fetchApi = "http://207.154.228.44:3005";

    useEffect(() => {
        fetchMessages();
    }, [])

    const fetchMessages = () => {
        setLoading(true);
        fetch(`${fetchApi}${endpoint}`, {
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

    return (
        <div className="timeline">
            {loading ? <LoadingSpinner/> :
                messages.length !== 0 ? messages.map((message: IMessage, index) => (
                        <Message
                            key={index}
                            image={"https://uploads.neatorama.com/images/posts/376/63/63376/1373756607-0.jpg"}
                            userName={message.userName}
                            text={message.text}
                            date={new Date(parseInt(message.date) * 1000).toLocaleString()}
                        />
                    )) :
                    <div className="no-message-container">
                        <p className="no-message-headline">No messages</p>
                        <p>Maybe there is an error... or maybe you don't have friends</p>
                    </div>
            }
        </div>
    );
}

export default Timeline;
