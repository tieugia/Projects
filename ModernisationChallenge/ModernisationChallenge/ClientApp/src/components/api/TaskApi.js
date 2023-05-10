class TaskApi {
    static async getAllTasks() {
        const response = await fetch("/api/Task");
        const data = await response.json();
        return data;
    }

    static async addTask(task) {
        await fetch("/api/Task", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(task),
        });
    }

    static async updateTask(id,task) {
        await fetch(`/api/Task/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(task),
        });
    }

    static async deleteTask(id) {
        await fetch(`/api/Task/Delete/${id}`);
    }

    static async completeTask(id) {
        const response = await fetch(`/api/Task/Complete/${id}`)
        const data = await response.json();
        return data;
    }
}

export default TaskApi;
