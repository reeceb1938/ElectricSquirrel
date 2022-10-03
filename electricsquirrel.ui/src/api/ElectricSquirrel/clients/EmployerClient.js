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

    }

    async updateEmployerAsync(employer) {

    }

    async deleteEmployerAsync(id) {

    }
}