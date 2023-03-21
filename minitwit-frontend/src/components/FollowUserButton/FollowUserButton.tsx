import React from 'react';
import './FollowUserButton.css';

export interface userButtonProps {
	userName: string;
}

function FollowUserButton({userName}: userButtonProps) {

	const [following, setFollowing] = React.useState(false);
	const fetchApi = "http://207.154.228.44:3005";

	function followUserClicked() {

		fetch(`${fetchApi}/user/FollowUser`, {
			method: "POST",
			headers: {"Content-Type": "application/json"},
			mode: "cors",
			body: JSON.stringify({userName: userName})
		})
			.then((res => {
				if (res.status === 200) {
					console.log("Followed user");
					setFollowing(!following);
				} else {
					console.log("Error following user");
				}
			}))
	}

	return (
		<button className="button" onClick={followUserClicked}>
			{following ? "Following" : "Follow user"}
		</button>
	);
}

export default FollowUserButton;
