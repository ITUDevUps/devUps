import React, {useEffect} from 'react';
import './SearchBar.css';
import {ReactComponent as SearchIcon} from "../../assets/icons/search-icon.svg";
import {User} from "../../Util/Types";
import SearchCell from "./SearchCell";

function SearchBar() {
    const [searchbarActive, setSearchbarActive] = React.useState(false);
    const [searchQuery, setSearchQuery] = React.useState("");
    const [users, setUsers] = React.useState([]);
    const [foundUsers, setFoundUsers] = React.useState([]);

    useEffect(() => {
        fetchUsers();
    });

    const searchUsers = (e: React.ChangeEvent<HTMLInputElement>) => {
        const query = e.currentTarget.value;

        if(query === "") {
            setFoundUsers(users);
            return;
        } else {
            const res = users.filter((user: User) => user.userName.includes(query));
            setFoundUsers(res);
        }

        setSearchQuery(query);
    }

    const fetchUsers = () => {
        fetch("http://207.154.228.44:3005/GetUsers", {
            method: "GET",
            headers: {"Content-Type": "application/json"},
            mode: "cors",
        })
            .then((response) => response.json())
            .then((json) => {
                setUsers(json);
            })
    }

    return (
        <div className="search-container">
            <SearchIcon className="search-icon" onClick={() => setSearchbarActive(!searchbarActive)}/>
            {searchbarActive && (
                <input className="search-input" type="text" placeholder="Search..." value={searchQuery}
                       onChange={searchUsers}/>
            )}
            {foundUsers && foundUsers.length !== 0 ? (
                foundUsers.map((user: User, index) => (
                <SearchCell key={index} userName={user.userName} userID={user.userID} />
                    ))
                ) : (
                 <></>
                )}
        </div>
    );
}

export default SearchBar;
