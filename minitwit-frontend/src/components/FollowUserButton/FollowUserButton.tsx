import React from 'react';
import './FollowUserButton.css';

function FollowUserButton() {

	const [following, setFollowing] = React.useState(false);

	function followUserClicked() {
		setFollowing(!following);
	}

	return (
		<button className="button" onClick={followUserClicked}>
			{following ? "Following" : "Follow user"}
		</button>
	);
}

export default FollowUserButton;
