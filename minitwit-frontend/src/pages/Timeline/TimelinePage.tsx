import React, {useEffect, useState} from 'react';
import "./TimelinePage.css";
import MessageField from "../../components/MessageField/MessageField";
import Timeline from "../../components/Timeline/Timeline";

function TimelinePage() {

    const [messages, setMessages] = useState([]);
    const [loading, setLoading] = useState(false);
    const fetchApi = "http://207.154.228.44:3005";

    useEffect(() => {
        //fetchMessages();
    }, [])

    const fetchMessages = () => {
        setLoading(true);
        fetch(`${fetchApi}/getMessages`, {
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
            <Timeline endpoint="/GetMessages" />
        </div>
    );
}


export default TimelinePage;
