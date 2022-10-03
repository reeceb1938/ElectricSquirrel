import { useContext } from "react";
import { electricSquirrelApiContext } from "../components/ElectricSquirrelApiProvider";

function useElectricSquirrelApi() {
    return useContext(electricSquirrelApiContext);
}

export default useElectricSquirrelApi;