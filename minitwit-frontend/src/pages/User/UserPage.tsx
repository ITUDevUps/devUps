import React from 'react';
import Timeline from "../../components/Timeline/Timeline";
import {useParams} from "react-router-dom";
import "./UserPage.css";

function UserPage() {

    let {userName} = useParams();

    return (
        <div className="container">
            <h1>{userName}</h1>

            <Timeline endpoint={`GetMessages/${userName}`}/>
        </div>
    );
}

export default UserPage;
