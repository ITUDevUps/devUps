import React from 'react';
import "./Message.css";
import {IMessage} from "../../Util/Types";

function Message(props: IMessage) {
    return (
        <div className="message-container">
            <>
                <img className="avatar" src={props.image} alt={"profile"}/>

                <a className="username" href={props.userName}>
                    {props.userName}
                </a>
                <p className="message">
                    {props.text}
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
