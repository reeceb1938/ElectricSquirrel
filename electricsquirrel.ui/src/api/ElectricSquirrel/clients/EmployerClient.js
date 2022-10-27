import { bearerToken } from "../../../hooks/useAuthProvider"

export default class EmployerClient {
    async createEmployerAsync(employer) {
        const response = await fetch("api/Employer/", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${bearerToken}`
            },
            body: JSON.stringify(employer)
        });

        return response.ok;
    }

    async getEmployerAsync(id) {

    }

    async getAllEmployersAsync() {
        const response = await fetch("api/Employer/", {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${bearerToken}`
            }
        });

        if (!response.ok) {
            return []
        }
        const json = await response.json();

        console.log(json);

        return json;
    }

    async updateEmployerAsync(employer) {

    }

    async deleteEmployerAsync(id) {

    }
}