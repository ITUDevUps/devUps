import React from 'react';
import './ErrorPage.css';

function ErrorPage() {
    return (
        <div className="error-page">
            <h1>404</h1>
            <p>Page not found</p>

            <a className="back-link" href="/">Go back to home</a>
        </div>
    );
}

export default ErrorPage;
