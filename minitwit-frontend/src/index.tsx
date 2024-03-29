import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import {createBrowserRouter, RouterProvider,} from "react-router-dom";
import ErrorPage from "./pages/Error/ErrorPage";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import TimelinePage from "./pages/Timeline/TimelinePage";
import UserPage from "./pages/User/UserPage";

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

const router = createBrowserRouter([
    {
        path: '/',
        element: <App/>,
        errorElement: <ErrorPage/>,
        children: [
            {
                path: "",
                element: <TimelinePage/>,
            },
            {
                path: "login",
                element: <Login/>,
            },
            {
                path: "sign-up",
                element: <Register/>,
            },
            {
                path: "user/:userName",
                element: <UserPage/>,
            }
        ],
    }
]);

root.render(
    <React.StrictMode>
        <RouterProvider router={router}/>
    </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
