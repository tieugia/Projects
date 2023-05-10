//import React, { Component } from "react";
//import TaskApi from './api/TaskApi';

//export class TaskList extends Component {
//    state = {
//        tasks: [], // array of tasks
//        isCreatingTask: false, // whether the "create task" dialogue is open
//        taskToEdit: null, // the task being edited
//    };

//    componentDidMount() {
//        // fetch tasks from API and update state
//        TaskApi.getAllTasks()
//            .then((data) => {
//                this.setState({ tasks: data });
//            })
//            .catch((error) => {
//                console.error('Error fetching tasks: ', error);
//            });
//    }

//    // handle click on "create task" button
//    handleCreateTaskClick = () => {
//        this.setState({
//            isCreatingTask: true,
//            taskToEdit: null,
//        });
//    };

//    // handle click on "edit" button
//    handleTaskDetailsChange = (task) => {
//        this.setState({
//            isCreatingTask: true,
//            taskToEdit: task,
//        });
//    };

//    // handle click on "cancel" button
//    handleCancelClick = () => {
//        this.setState({
//            isCreatingTask: false,
//            taskToEdit: null,
//        });
//    };

//    // handle click on "save" button
//    handleSaveClick = () => {
//        // update tasks state with new/updated task
//        // and close "create/edit task" dialogue
//        this.setState({
//            isCreatingTask: false,
//            taskToEdit: null,
//        });
//    };

//    // handle click on "delete" button
//    handleDeleteTaskClick = (taskId) => {
//        // delete task from API and update state
//    };

//    render() {
//        const { tasks, isCreatingTask, editingTask } = this.state;

//        return (
//            <div>
//                <h1>Tasks</h1>

//                <div className="table">
//                    <table>
//                        <thead>
//                            <tr>
//                                <th style={{ width: "1px" }}>Completed</th>
//                                <th>Details</th>
//                                <th style={{ width: "1px" }}></th>
//                            </tr>
//                        </thead>
//                        <tbody>
//                            {tasks.map((task) => (
//                                <tr key={task.id}>
//                                    <td style={{ textAlign: "center", width: "1px" }}>
//                                        <input
//                                            type="checkbox"
//                                            checked={task.completed}
//                                            onChange={(event) =>
//                                                this.handleTaskCompletionChange(task, event.target.checked)
//                                            }
//                                        />
//                                    </td>
//                                    <td>{task.details}</td>
//                                    <td style={{ width: "1px" }}>
//                                        <div className="popup_menu">
//                                            <span
//                                                className="popup_menu_button"
//                                                onClick={() => this.handleTaskEdit(task)}
//                                            >
//                                                Edit
//                                            </span>
//                                            <span
//                                                className="popup_menu_button"
//                                                onClick={() => this.handleTaskDeletion(task)}
//                                            >
//                                                Delete
//                                            </span>
//                                        </div>
//                                    </td>
//                                </tr>
//                            ))}
//                            {isCreatingTask && (
//                                <div className="dialogue">
//                                    <div style={{ width: "750px" }}>
//                                        <div className="header">
//                                            <button
//                                                className="close"
//                                                onClick={this.handleCancelTaskCreation}
//                                            >
//                                                Close
//                                            </button>
//                                            <h2>Create a new task</h2>
//                                        </div>

//                                        <div className="body">
//                                            <fieldset className="required">
//                                                <label>Details</label>
//                                                <textarea
//                                                    className="text"
//                                                    value={editingTask ? editingTask.details : ""}
//                                                    onChange={(event) =>
//                                                        this.handleTaskDetailsChange(event.target.value)
//                                                    }
//                                                />
//                                            </fieldset>
//                                        </div>

//                                        <div className="footer">
//                                            <p className="commands">
//                                                <span className="grow"></span>
//                                                <button
//                                                    className="button hollow"
//                                                    onClick={this.handleCancelTaskCreation}
//                                                >
//                                                    Cancel
//                                                </button>
//                                                <button
//                                                    className="button"
//                                                    onClick={this.handleSaveTask}
//                                                >
//                                                    Save
//                                                </button>
//                                            </p>
//                                        </div>
//                                    </div>
//                                </div>
//                            )}
//                        </tbody>
//                    </table>
//                </div>

//                {!isCreatingTask && (
//                    <div className="info">
//                        <button onClick={this.handleCreateTask}>
//                            + Create a new task
//                        </button>
//                    </div>
//                )}
//            </div>
//        );
//    }
//}

//export default TaskList;

import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Button,
    Modal,
    TextField,
    FormControlLabel,
    Checkbox
} from '@material-ui/core';
import {
    Add as AddIcon,
    Edit as EditIcon,
    Delete as DeleteIcon
} from '@material-ui/icons';
import TaskApi from './api/TaskApi';

const modalStyle = makeStyles(() => ({
    paper: {
        position: 'absolute',
        width: 400,
        backgroundColor: '#fff',
        border: '2px solid #000',
        boxShadow: '10px 10px 5px -5px rgba(0,0,0,0.75)',
        padding: '16px',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
    },
}));

const styles = {
    root: {
        marginTop: '20px',
        overflowX: 'auto'
    },
    addButton: {
        marginBottom: '10px'
    }
};

export class TaskList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            tasks: [],
            openAddModal: false,
            openEditModal: false,
            openDeleteModal: false,
            selectedTaskId: null,
            selectedTaskDetails: ''
        };
    }

    componentDidMount() {
        this.loadTasks();
    }

    loadTasks = () => {
        TaskApi.getAllTasks()
            .then((data) => this.setState({ tasks: data }));
    };

    handleAddModalOpen = () => {
        this.setState({ openAddModal: true });
    };

    handleAddModalClose = () => {
        this.setState({ openAddModal: false });
    };

    handleAddModalSave = () => {
        const { selectedTaskDetails } = this.state;
        const newTask = { details: selectedTaskDetails };
        TaskApi.addTask(newTask)
            .then(() => {
                this.loadTasks();
                this.handleAddModalClose();
            })
            .catch((error) => console.error(error));
    };

    handleEditModalOpen = (taskId, taskDetails) => {
        this.setState({ selectedTaskId: taskId, selectedTaskDetails: taskDetails, openEditModal: true });
    };

    handleEditModalClose = () => {
        this.setState({ selectedTaskId: null, selectedTaskDetails: '', openEditModal: false });
    };

    handleEditModalSave = () => {
        const { selectedTaskId, selectedTaskDetails } = this.state;
        const updatedTask = { id: selectedTaskId, details: selectedTaskDetails };
        TaskApi.updateTask(selectedTaskId, updatedTask)
            .then(() => {
                this.loadTasks();
                this.handleEditModalClose();
            })
            .catch((error) => console.error(error));
    };

    handleDeleteModalOpen = (taskId) => {
        this.setState({ selectedTaskId: taskId, openDeleteModal: true });
    };

    handleDeleteModalClose = () => {
        this.setState({ selectedTaskId: null, openDeleteModal: false });
    };

    handleDeleteModalConfirm = () => {
        const { selectedTaskId } = this.state;
        TaskApi.deleteTask(selectedTaskId)
            .then(() => {
                this.loadTasks();
                this.handleDeleteModalClose();
            })
            .catch((error) => console.error(error));
    };

    handleTaskDetailsChange = (event) => {
        this.setState({ selectedTaskDetails: event.target.value });
    };


    render() {
        const { tasks, addModalOpen, editModalOpen, deleteModalOpen, selectedTask } = this.state;

        return (
            <div>
                <h1>Tasks</h1>

                <Button variant="contained" color="primary" onClick={this.handleAddModalOpen}>Add Task</Button>

                <TableContainer component={Paper}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Details</TableCell>
                                <TableCell>Completed</TableCell>
                                <TableCell>Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {tasks.map((task) => (
                                <TableRow key={task.id}>
                                    <TableCell>{task.details}</TableCell>
                                    <TableCell>{task.completed ? 'Yes' : 'No'}</TableCell>
                                    <TableCell>
                                        <Button variant="contained" color="primary" onClick={() => this.handleEditModalOpen(task)}>Edit</Button>
                                        <Button variant="contained" color="secondary" onClick={() => this.handleDeleteModalOpen(task)}>Delete</Button>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>

                <Modal open={addModalOpen} onClose={this.handleAddModalClose}>
                    <div style={modalStyle} className={styles.modal}>
                        <h2>Add Task</h2>
                        <form onSubmit={this.handleAddTask}>
                            <TextField label="Details" fullWidth value={this.state.newTaskDetails} onChange={this.handleNewTaskDetailsChange} />
                            <Button variant="contained" color="primary" type="submit">Add</Button>
                        </form>
                    </div>
                </Modal>

                <Modal open={editModalOpen} onClose={this.handleEditModalClose}>
                    <div style={modalStyle} className={styles.modal}>
                        <h2>Edit Task</h2>
                        <form onSubmit={this.handleEditTask}>
                            <TextField label="Details" fullWidth value={selectedTask.details} onChange={this.handleSelectedTaskDetailsChange} />
                            <FormControlLabel
                                control={<Checkbox checked={selectedTask.completed} onChange={this.handleSelectedTaskCompletedChange} />}
                                label="Completed"
                            />
                            <Button variant="contained" color="primary" type="submit">Save</Button>
                        </form>
                    </div>
                </Modal>

                <Modal open={deleteModalOpen} onClose={this.handleDeleteModalClose}>
                    <div style={modalStyle} className={styles.modal}>
                        <h2>Delete Task</h2>
                        <p>Are you sure you want to delete this task?</p>
                        <p><strong>{selectedTask.details}</strong></p>
                        <Button variant="contained" color="secondary" onClick={this.handleDeleteTask}>Delete</Button>
                    </div>
                </Modal>

            </div>
        );
    }
}
export default TaskList;