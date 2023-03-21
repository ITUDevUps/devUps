import React from 'react';
import "./Message.css";
import {IMessage} from "../../Util/Types";

function Message(props: IMessage) {
    return (
        <div className="message-container">
            <>
                <img className="avatar" src={props.image} alt={"profile"}/>

                <a className="username" href={`/user/${props.userName}`}>
                    {props.userName}
                </a>
                <p className="message">
                    {props.message}
                </p>
                <p className="date">
                    <>
                        &mdash; {props.date}
                    </>
                </p>
            </>
        </div>
    );
}

export default Message;
