import React from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import {
    Button,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    DialogContentText
} from '@mui/material';

import Checkbox from '@mui/material/Checkbox';

import {
    Add as AddIcon,
    Edit as EditIcon,
    Delete as DeleteIcon
} from '@material-ui/icons';
import TaskApi from './api/TaskApi';

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
        debugger;
        const { selectedTaskDetails } = this.state;
        const newTask = { details: selectedTaskDetails };
        TaskApi.addTask(newTask)
            .then(() => {
                this.loadTasks();
                this.handleAddModalClose();
                this.notify('Create task successfully');
            })
            .catch((error) => this.notify('Failed to add task', 'error'));
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
                this.notify('Edit task successfully');
            })
            .catch((error) => this.notify('Failed to edit task', 'error'));
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
                this.notify('Delete successfully');
            })
            .catch((error) => this.notify('Failed to delete', 'error'))
    };

    handleTaskDetailsChange = (event) => {
        this.setState({ selectedTaskDetails: event.target.value });
    };

    handleCompleteTask = (id) => {
        TaskApi.completeTask(id)
            .then(() => {
                this.loadTasks();
            })
            .catch((error) => this.notify('Failed to complete task', 'error'))
    }

    notify = (message, type = 'success') => {
        const toastConfig = {
            position: 'bottom-right',
            autoClose: 5000,
            closeOnClick: true,
            pauseOnHover: true
        };
        switch (type) {
            case 'success':
                toast.success(message, toastConfig);
                break;
            case 'error':
                toast.error(message, toastConfig);
                break;
            default:
                toast(message, toastConfig);
        }
    }

    render() {
        const { tasks, openAddModal, openEditModal, openDeleteModal, selectedTaskId, selectedTaskDetails } = this.state;
        return (
            <div>
                <h1>Tasks</h1>

                <Button>
                    <AddIcon variant="contained" color="primary" onClick={this.handleAddModalOpen}>
                        Add Task
                    </AddIcon>
                </Button>

                <TableContainer component={Paper}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Completed</TableCell>
                                <TableCell>Details</TableCell>
                                <TableCell>Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {tasks.map((task) => (
                                <TableRow key={task.id}>
                                    <Checkbox checked={task.completed} onClick={() => this.handleCompleteTask(task.id)}></Checkbox>
                                    <TableCell>{task.details}</TableCell>
                                    <TableCell>
                                        <Button>
                                            <EditIcon variant="contained" color="primary" onClick={() => this.handleEditModalOpen(task.id, task.details)}>
                                                Edit
                                            </EditIcon>
                                        </Button>
                                        <Button>
                                            <DeleteIcon variant="contained" color="secondary" onClick={() => this.handleDeleteModalOpen(task.id)}>
                                                Delete
                                            </DeleteIcon>
                                        </Button>
                                    </TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>

                <Dialog className="paper" open={openAddModal} onClose={this.handleAddModalClose}>
                    <DialogTitle>Add Task</DialogTitle>
                    <DialogContent>
                        <textarea required label="Details" fullWidth value={selectedTaskDetails} onChange={this.handleTaskDetailsChange} />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleAddModalClose}>Cancel</Button>
                        <Button variant="contained" color="primary" onClick={this.handleAddModalSave}>Save</Button>
                    </DialogActions>
                </Dialog>

                <Dialog className="paper" open={openEditModal} onClose={this.handleEditModalClose}>
                    <DialogTitle>Edit Task</DialogTitle>
                    <DialogContent>
                        <textarea required label="Details" fullWidth value={selectedTaskDetails} onChange={this.handleTaskDetailsChange} />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleEditModalClose}>Cancel</Button>
                        <Button variant="contained" color="primary" onClick={this.handleEditModalSave}>Save</Button>
                    </DialogActions>
                </Dialog>

                <Dialog className="paper" open={openDeleteModal} onClose={this.handleDeleteModalClose}>
                    <DialogTitle>Delete Task</DialogTitle>
                    <DialogContent>
                        <DialogContentText>Are you sure you want to delete this task?</DialogContentText>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleDeleteModalClose}>Cancel</Button>
                        <Button variant="contained" color="primary" onClick={this.handleDeleteModalConfirm}>OK</Button>
                    </DialogActions>
                </Dialog>  
                <ToastContainer />
            </div>

        );
    }
}
export default TaskList;