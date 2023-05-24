import React, {useEffect, useState} from 'react';
import './SearchBar.css';
import {ReactComponent as SearchIcon} from "../../assets/icons/search-icon.svg";
import {User} from "../../Util/Types";
import SearchCell from "./SearchCell";

function SearchBar() {
	const [searchbarActive, setSearchbarActive] = useState(false);
	const [searchQuery, setSearchQuery] = useState("");
	const [users, setUsers] = useState([]);
	const [foundUsers, setFoundUsers] = useState([]);
	const [showSearch, setShowSearch] = useState(false);
	const {REACT_APP_API_URL} = process.env;


	useEffect(() => {
		fetch(`${REACT_APP_API_URL}/user/GetUsers`, {
			method: "GET",
			headers: {"Content-Type": "application/json"},
			mode: "cors",
		})
			.then((res) => res.json())
			.then((res) => {
				setUsers(res);
			})
	}, [REACT_APP_API_URL]);

	const searchUsers = (e: React.ChangeEvent<HTMLInputElement>) => {
		const query = e.currentTarget.value.toLowerCase();

		if (query === "") {
			setFoundUsers(users);
			setShowSearch(false);
		} else {
			setShowSearch(true);
			const res = users.filter((user: User) => user.userName.toLowerCase().startsWith(query));
			setFoundUsers(res);
		}
		setSearchQuery(query);
	}

	return (
		<div className="search-container">
			<SearchIcon className="search-icon" onClick={() => setSearchbarActive(!searchbarActive)}/>
			{searchbarActive && (
				<input className="search-input" type="text" placeholder="Search..." value={searchQuery}
					   onChange={searchUsers}/>
			)}
			<div className="searchCell-container">
				{showSearch && foundUsers.length !== 0 ? (
					foundUsers.map((user: User, index) => (
						<SearchCell key={index} userName={user.userName} userID={user.userID}/>
					))
				) : (
					<></>
				)}
			</div>
		</div>
	);
}

export default SearchBar;
