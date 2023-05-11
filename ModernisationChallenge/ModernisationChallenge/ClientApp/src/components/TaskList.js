import React from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Add as AddIcon, Edit as EditIcon, Delete as DeleteIcon } from '@mui/icons-material';
import TaskApi from './api/TaskApi';
import TaskTable from './TaskTable';
import { Button, Dialog, DialogTitle, DialogContent, DialogActions, DialogContentText, Fab, TextField, Menu, MenuItem, } from '@mui/material';

export class TaskList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            tasks: [],
            anchorEl: null,
            openAddModal: false,
            openEditModal: false,
            openDeleteModal: false,
            selectedTaskId: null,
            selectedTaskDetails: '',
        };
    }

    componentDidMount() {
        this.loadTasks();
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

    loadTasks = () => {
        TaskApi.getAllTasks().then((data) => this.setState({ tasks: data }));
    };

    handleMenuClick = (event, id) => {
        this.setState({
            anchorEl: event.currentTarget,
            selectedTaskId: id
        });
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

    handleMenuClose = () => {
        this.setState({
            anchorEl: null
        });
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
                this.notify('Create task successfully');
            })
            .catch((error) => this.notify('Failed to add task', 'error'));
    };

    handleEditModalOpen = (taskId) => {
        const task = this.state.tasks.find((task) => task.id === taskId);
        if (task) {
            this.setState({ selectedTaskId: task.id, selectedTaskDetails: task.details, openEditModal: true });
        }
    };

    handleEditModalClose = () => {
        this.setState({ selectedTaskId: null, selectedTaskDetails: '', openEditModal: false });
        this.handleMenuClose();
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
        this.setState({ openDeleteModal: false });
    };

    handleDeleteModalConfirm = (id) => {
        TaskApi.deleteTask(id)
            .then(() => {
                this.loadTasks();
                this.handleDeleteModalClose();
                this.notify('Delete task successfully');
            })
            .catch((error) => this.notify('Failed to delete task', 'error'));
    };

    render() {
        const { tasks, anchorEl, openAddModal, openEditModal, openDeleteModal, selectedTaskDetails, selectedTaskId } = this.state;

        return (
            <div>
                <h1>Tasks</h1>
                <Fab variant="extended" onClick={this.handleAddModalOpen}>
                    <AddIcon>
                    </AddIcon>
                    Add Task
                </Fab>

                <TaskTable
                    tasks={tasks}
                    handleEditModalOpen={this.handleEditModalOpen}
                    handleDeleteModalOpen={this.handleDeleteModalOpen}
                    handleMenuClick={this.handleMenuClick}
                    handleMenuClose={this.handleMenuClose}
                    handleCompleteTask={this.handleCompleteTask}
                    selectedTaskId={selectedTaskId}
                    anchorEl={anchorEl}
                />

                <Dialog fullWidth={true} className="paper" open={openAddModal} onClose={this.handleAddModalClose}>
                    <DialogTitle>Add Task</DialogTitle>
                    <DialogContent>
                        <TextField sx={{ width: 550 }} autoFocus margin="dense" variant="standard" label="Details" onChange={this.handleTaskDetailsChange} />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleAddModalClose}>Cancel</Button>
                        <Button variant="contained" color="primary" onClick={this.handleAddModalSave}>Save</Button>
                    </DialogActions>
                </Dialog>

                <Dialog fullWidth={true} className="paper" open={openEditModal} onClose={this.handleEditModalClose}>
                    <DialogTitle>Edit Task</DialogTitle>
                    <DialogContent>
                        <TextField sx={{ width: 550 }} autoFocus margin="dense" variant="standard" label="Details" defaultValue={selectedTaskDetails} onChange={this.handleTaskDetailsChange} />
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleEditModalClose}>Cancel</Button>
                        <Button variant="contained" color="primary" onClick={this.handleEditModalSave}>Save</Button>
                    </DialogActions>
                </Dialog>

                <Dialog fullWidth={true} className="paper" open={openDeleteModal} onClose={this.handleDeleteModalClose}>
                    <DialogTitle>Delete Task</DialogTitle>
                    <DialogContent>
                        <DialogContentText>Are you sure you want to delete this task?</DialogContentText>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleDeleteModalClose}>Cancel</Button>
                        <Button variant="contained" color="primary" onClick={() => this.handleDeleteModalConfirm(selectedTaskId)}>OK</Button>
                    </DialogActions>
                </Dialog>

                <ToastContainer />
            </div>
        );
    }
}

