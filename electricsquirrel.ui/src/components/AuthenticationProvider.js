import { createContext } from "react";
import useAuthProvider from "../hooks/useAuthProvider";

export const authContext = createContext();

const AuthenticationProvider = ({ children }) => {
    const auth = useAuthProvider();
    return <authContext.Provider value={auth}>{children}</authContext.Provider>
}

export default AuthenticationProvider;