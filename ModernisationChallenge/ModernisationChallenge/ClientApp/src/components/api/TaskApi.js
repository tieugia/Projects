class TaskApi {
    static async getAllTasks() {
        const response = await fetch("/api/Task");
        const data = await response.json();
        return data;
    }

    static async createTask(task) {
        const response = await fetch("/api/Customer/CreateCustomerAsync", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(task),
        });
        const data = await response.json();
        return data;
    }
}

export default TaskApi;
