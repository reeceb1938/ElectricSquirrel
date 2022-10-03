import AccessControlClient from "../api/ElectricSquirrel/clients/AccessControlClient";
import EmployerClient from "../api/ElectricSquirrel/clients/EmployerClient";

function useElectricSquirrelApiProvider() {

    const accessControl = new AccessControlClient();
    const employers = new EmployerClient();

    return {
        accessControl,
        employers
    };
}

export default useElectricSquirrelApiProvider;