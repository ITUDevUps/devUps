import React, {useEffect, useState} from 'react';
import Message, {IMessage} from "../../components/message/Message";
function Home() {

    const [messages, setMessages] = useState([]);

    useEffect(() => {
        fetch("http://localhost/3005")
            .then((response) => response.json())
            .then((json) => {
                console.log(json);
                setMessages(json);
            })
    }, [])

        return (
            <div>
                <div className="header">
                    <h1>MiniTwit</h1>
                </div>
                <div className="navigation">

                </div>
                <div className="timeline">
                    {messages ? messages.map((message: IMessage) => (
                        <Message
                            image={"http://uploads.neatorama.com/images/posts/376/63/63376/1373756607-0.jpg"}
                            userName={message.userName}
                            message={message.message}
                            date={message.date}
                        />
                    )) : undefined}
                </div>

            </div>
        );
}
