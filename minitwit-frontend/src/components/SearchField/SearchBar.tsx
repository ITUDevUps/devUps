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

    const fetchApi = "http://207.154.228.44:3005/user/GetUsers";

    useEffect(() => {
        fetchUsers();
    });

    const searchUsers = (e: React.ChangeEvent<HTMLInputElement>) => {
        const query = e.currentTarget.value;

        if(query === "") {
            setFoundUsers(users);
            setShowSearch(false);
        } else {
            setShowSearch(true);
            const res = users.filter((user: User) => user.userName.startsWith(query));
            setFoundUsers(res);
        }
        setSearchQuery(query);
    }

    const fetchUsers = () => {
        fetch(fetchApi, {
            method: "GET",
            headers: {"Content-Type": "application/json"},
            mode: "cors",
        })
            .then((res) => res.json())
            .then((res) => {
                setUsers(res);
            })
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
                <SearchCell key={index} userName={user.userName} userID={user.userID} />
                    ))
                ) : (
                 <></>
                )}
            </div>
        </div>
    );
}

export default SearchBar;
