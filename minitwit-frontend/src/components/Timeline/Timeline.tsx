import React, {useEffect, useState} from 'react';
import {Pagination} from 'semantic-ui-react';
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import {IMessage} from "../../Util/Types";
import Message from "../../components/Message/Message";
import "./Timeline.css";

export interface TimelineProps {
    endpoint: string;
}

function Timeline({ endpoint } : TimelineProps) {

    const [loading, setLoading] = useState(false);
    const [messages, setMessages] = useState([]);
    const fetchApi = "http://207.154.228.44:3005";
    const [activePage, setActivePage] = useState(1);
    const [messagesPerPage] = useState(40);
    const totalPages = Math.ceil(messages.length / messagesPerPage);

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

    const renderMessages = () => {
        const indexOfLastMessage = activePage * messagesPerPage;
        const indexOfFirstMessage = indexOfLastMessage - messagesPerPage;
        const currentMessages = messages.slice(indexOfFirstMessage, indexOfLastMessage);

        return currentMessages.map((message: IMessage, index) => (
            <Message
                key={index}
                image={'https://uploads.neatorama.com/images/posts/376/63/63376/1373756607-0.jpg'}
                userName={message.userName}
                text={message.text}
                date={new Date(parseInt(message.date)).toLocaleString()}
            />
        ));
    };

    return (
        <div className="timeline">
            {loading ? <LoadingSpinner/> :
                messages.length !== 0 ? (
                    <>
                        {renderMessages()}
                        <Pagination
                            className="custom-pagination"
                            activePage={activePage}
                            onPageChange={(e, {activePage}) => setActivePage(activePage as number)}
                            totalPages={totalPages}
                            ellipsisItem={null}
                            boundaryRange={0}
                        />
                    </>
                ) : (
                    <div className="no-message-container">
                        <p className="no-message-headline">No messages</p>
                        <p>Maybe there is an error... or maybe you don't have friends</p>
                    </div>
                )}
        </div>
    );
}

export default Timeline;
