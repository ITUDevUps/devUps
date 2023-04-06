import React from 'react';
import "./TimelinePage.css";
import MessageField from "../../components/MessageField/MessageField";
import Timeline from "../../components/Timeline/Timeline";

function TimelinePage() {

	return (
		<div className="timeline-container">
			{(localStorage.getItem("token") !== null) && (
				<MessageField/>
			)}
			<Timeline endpoint="/GetMessages"/>
		</div>
	);
}


export default TimelinePage;
