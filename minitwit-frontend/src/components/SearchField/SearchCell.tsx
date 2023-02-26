import React from 'react';
import './SearchCell.css';
import {User} from "../../Util/Types";


function SearchCell(user: User) {
    function goToUser() {
        window.location.href = "/user/" + user.userID;
    }

    return (
        <div onClick={goToUser} className="cell-container">
            <img className="avatar" alt="avatar" src={"https://uploads.neatorama.com/images/posts/376/63/63376/1373756607-0.jpg"}/>
            <p className="search-username">{user.userName}</p>
        </div>
    );
}

export default SearchCell;
