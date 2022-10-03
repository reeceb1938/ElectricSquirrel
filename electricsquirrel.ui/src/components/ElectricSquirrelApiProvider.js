import { createContext } from "react"
import useElectricSquirrelApiProvider from "../hooks/useElectricSquirrelApiProvider";

export const electricSquirrelApiContext = createContext();

function ElectricSquirrelApiProvider({ children }) {
    const api = useElectricSquirrelApiProvider();
    return <electricSquirrelApiContext.Provider value={api}>{children}</electricSquirrelApiContext.Provider>
}

export default ElectricSquirrelApiProvider;