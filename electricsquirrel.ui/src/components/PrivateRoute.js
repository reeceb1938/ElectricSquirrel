import { Component } from "react";
import { Navigate, Outlet } from "react-router-dom";
import useAuth from "../hooks/useAuth";

const PrivateRoute = () => {
    let auth = useAuth();
    console.log(auth.isAuthenticated());

    return auth.isAuthenticated() ? (
        <Outlet></Outlet>
    ) : (
        <Navigate
            to={{
                pathname: '/login',
                state: { from: window.location }
            }}
        >
        </Navigate>
    )
}

export default PrivateRoute;