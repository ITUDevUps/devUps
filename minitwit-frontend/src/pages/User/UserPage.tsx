import React from 'react';
import Timeline from "../../components/Timeline/Timeline";
import {useParams} from "react-router-dom";
import "./UserPage.css";
import FollowUserButton from "../../components/FollowUserButton/FollowUserButton";

function UserPage() {

	let {userName} = useParams();
	let userNameCapitalized: string = "Incognito";
	if (userName !== undefined) {
		userNameCapitalized = userName.charAt(0).toUpperCase() + userName.slice(1);
	}

	return (
		<div className="container">
			<h1>{userNameCapitalized}</h1>
			<FollowUserButton/>
			<Timeline endpoint={`/GetMessages/${userName}`}/>
		</div>
	);
}

export default UserPage;
