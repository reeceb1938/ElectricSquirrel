import { useState } from "react";
import useElectricSquirrelApi from "./useElectricSquirrelApi";

export var bearerToken = null;
export function setBearerToken(newValue) {
    bearerToken = newValue;
}

const useAuthProvider = () => {
    const [user, setUser] = useState(null);
    const api = useElectricSquirrelApi();

    async function loginAsync(username, password) {
        const result = await api.accessControl.loginAsync(username, password);

        if (result !== null) {
            setBearerToken(result.token);
            setUser(result);
            return true;
        }

        return false;
    };

    async function logoutAsync() {
        await api.accessControl.logoutAsync();
        setUser(null);
        setBearerToken(null);
        localStorage.setItem('user_state', false);
    };

    const isAuthenticated = () => {
        return user !== null;
    }

    const getBearerToken = () => {
        return bearerToken;
    }

    return {
        getBearerToken,
        loginAsync,
        logoutAsync,
        isAuthenticated
    };
}

export default useAuthProvider;