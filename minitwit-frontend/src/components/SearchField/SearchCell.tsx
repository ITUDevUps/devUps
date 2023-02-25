import React from 'react';
import './SearchCell.css';
import {User} from "../../Util/Types";


function SearchCell(user: User) {
    function goToUser() {
        window.location.href = "/user/" + user.userID;
    }

    return (
        <div onClick={goToUser} className="cell-container">
            <img className="avatar" alt="avatar"/>
            <p>{user.userName}</p>
        </div>
    );
}

export default SearchCell;
