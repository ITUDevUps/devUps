import React, {useContext} from 'react';
import Timeline from "../../components/Timeline/Timeline";
import {useParams} from "react-router-dom";
import "./UserPage.css";
import FollowUserButton from "../../components/FollowUserButton/FollowUserButton";
import {UserContext} from "../../Util/Contexts/UserContext";

function UserPage() {

	const {user} = useContext(UserContext)
	let {userName} = useParams();
	let userNameCapitalized: string = "Incognito";
	if (userName !== undefined) {
		userNameCapitalized = userName.charAt(0).toUpperCase() + userName.slice(1);
	}

	return (
		<div className="container">
			<h2 className="user-title">{userNameCapitalized}</h2>
			{userName !== user?.userName ? (
				<FollowUserButton userName={userName as string}/>
			) : null}
			<Timeline endpoint={`/GetMessages/${userName}`}/>
		</div>
	);
}

export default UserPage;
