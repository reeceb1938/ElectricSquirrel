export default class AccessControlClient {
    async loginAsync(username, password) {
        const response = await fetch("api/AccessControl/Login", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'username': username,
                'password': password
            })
        });

        const data = await response.json();

        if (response.status) {
            if (data.isAuthenticated) {
                return data;
            }

            return null;
        }

        return null;
    }

    async logoutAsync() {
        await fetch("api/AccessControl/Logout");
    }
}