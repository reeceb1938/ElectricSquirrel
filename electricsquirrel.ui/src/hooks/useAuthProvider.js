import { useState } from "react";

const useAuthProvider = () => {
    const [user, setUser] = useState(null);

    const login = () => {
        localStorage.setItem('user_state', true);
    };

    const logout = () => {
        localStorage.setItem('user_state', false);
    };

    const isAuthenticated = () => {
        return localStorage.getItem('user_state') === 'true';
    }

    return {
        login,
        logout,
        isAuthenticated
    };
}

export default useAuthProvider;