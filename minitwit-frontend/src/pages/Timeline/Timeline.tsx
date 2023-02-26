import React, {useEffect, useState} from 'react';
import Message, {IMessage} from "../../components/message/Message";
import "./Timeline.css";
import LoadingSpinner from "../../components/LoadingSpinner/LoadingSpinner";
import MessageField from "../../components/Message-field/MessageField";

function Timeline() {

    const [messages, setMessages] = useState([]);
    const [loading, setLoading] = useState(false);
    const fetchApi = "http://207.154.228.44:3005/getMessages";

    useEffect(() => {
        fetchMessages();
    }, [])

    const fetchMessages = () => {
        setLoading(true);
        fetch(fetchApi, {
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

// @ts-ignore
    return (
        <div className="timeline-container">
            {(localStorage.getItem("token") !== null) && (
                <MessageField fetchMessages={fetchMessages}/>
            )}
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
