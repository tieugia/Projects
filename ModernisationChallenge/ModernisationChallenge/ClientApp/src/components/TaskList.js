import React from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { DataGrid } from '@mui/x-data-grid';
import {
    Button,
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    DialogContentText,
    Menu,
    MenuItem,
    Fab,
    IconButton,
} from '@mui/material';
import Checkbox from '@mui/material/Checkbox';
import { Add as AddIcon, Edit as EditIcon, Delete as DeleteIcon } from '@mui/icons-material';

import TaskApi from './api/TaskApi';

const TaskTable = ({ tasks, handleEditModalOpen, handleDeleteModalOpen,
    handleMenuClick, handleMenuClose, handleCompleteTask, anchorEl,
    openAddModal, handleAddModalClose, selectedTaskDetails, handleAddModalSave,
    handleTaskDetailsChange, openEditModal, handleEditModalClose,
    handleEditModalSave, openDeleteModal, handleDeleteModalClose, handleDeleteModalConfirm }) => {
    const columns = [
        {
            field: 'completed',
            headerName: 'Completed',
            width: 200,
            align: 'center',
            renderCell: (params) => {
                return (
                    <Checkbox checked={params.row.completed} onClick={() => handleCompleteTask(params.row.id)}></Checkbox>
                )
            }
        },
        { field: 'details', headerName: 'Details', width: 700, align: 'center' },
        {
            field: 'actions',
            headerName: 'Actions',
            width: 200,
            align: 'center',
            sortable: true,
            filterable: true,
            disableColumnMenu: false,
            renderCell: (params) => {
                return (
                    <>
                        <Fab size="small" color="primary" onClick={(e) => handleMenuClick(e, params.row)}>
                            <AddIcon></AddIcon>
                        </Fab>
                        <Menu
                            anchorEl={anchorEl}
                            open={Boolean(anchorEl)}
                            onClose={handleMenuClose}
                        >
                            <MenuItem onClick={() => handleEditModalOpen(params.row.id)}>
                                <EditIcon />
                                Edit
                            </MenuItem>
                            <MenuItem onClick={() => handleDeleteModalOpen(params.row.id)}>
                                <DeleteIcon />
                                Delete
                            </MenuItem>
                        </Menu>

                        <Dialog className="paper" open={openAddModal} onClose={handleAddModalClose}>
                            <DialogTitle>Add Task</DialogTitle>
                            <DialogContent>
                                <textarea required label="Details" value={selectedTaskDetails} onChange={handleTaskDetailsChange} />
                            </DialogContent>
                            <DialogActions>
                                <Button onClick={handleAddModalClose}>Cancel</Button>
                                <Button variant="contained" color="primary" onClick={handleAddModalSave}>Save</Button>
                            </DialogActions>
                        </Dialog>

                        <Dialog className="paper" open={openEditModal} onClose={handleEditModalClose}>
                            <DialogTitle>Edit Task</DialogTitle>
                            <DialogContent>
                                <textarea required label="Details" value={selectedTaskDetails} onChange={handleTaskDetailsChange} />
                            </DialogContent>
                            <DialogActions>
                                <Button onClick={handleEditModalClose}>Cancel</Button>
                                <Button variant="contained" color="primary" onClick={handleEditModalSave}>Save</Button>
                            </DialogActions>
                        </Dialog>

                        <Dialog className="paper" open={openDeleteModal} onClose={handleDeleteModalClose}>
                            <DialogTitle>Delete Task</DialogTitle>
                            <DialogContent>
                                <DialogContentText>Are you sure you want to delete this task?</DialogContentText>
                            </DialogContent>
                            <DialogActions>
                                <Button onClick={handleDeleteModalClose}>Cancel</Button>
                                <Button variant="contained" color="primary" onClick={handleDeleteModalConfirm}>OK</Button>
                            </DialogActions>
                        </Dialog>
                    </>
                );
            },
        },
    ];

    return (
        <div style={{ height: 370, width: '100%' }}>
            <DataGrid rows={tasks} columns={columns} pageSize={5} />
        </div>
    );
};

export default TaskTable;


export class TaskList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            tasks: [],
            anchorEl: null,
            selectedItem: null,
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

    loadTasks = () => {
        TaskApi.getAllTasks().then((data) => this.setState({ tasks: data }));
    };

    handleMenuClick = (event, task) => {
        this.setState({
            anchorEl: event.currentTarget,
            selectedItem: task,
        });
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
            anchorEl: null,
            selectedItem: null,
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
        this.setState({ selectedTaskId: taskId, isDeleteModalOpen: true });
    };

    handleDeleteModalClose = () => {
        this.setState({ isDeleteModalOpen: false });
    };

    handleDeleteModalConfirm = () => {
        const { selectedTaskId } = this.state;
        TaskApi.deleteTask(selectedTaskId)
            .then(() => {
                this.loadTasks();
                this.handleDeleteModalClose();
                this.notify('Delete task successfully');
            })
            .catch((error) => this.notify('Failed to delete task', 'error'));
    };

    render() {
        //const { tasks, handleEditModalOpen, handleDeleteModalOpen,
        //    handleMenuClick, handleMenuClose, handleCompleteTask, anchorEl,
        //    openAddModal,  openEditModal, openDeleteModal} = this.state;
        const { tasks } = this.state;

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
                    anchorEl={this.state.anchorEl}
                    openAddModal={this.state.openAddModal}
                    handleAddModalClose={this.handleAddModalClose}
                    selectedTaskDetails={this.selectedTaskDetails}
                    handleAddModalSave={this.handleAddModalSave}
                    handleTaskDetailsChange={this.handleTaskDetailsChange}
                    openEditModal={this.state.openEditModal}
                    handleEditModalClose={this.handleEditModalClose}
                    handleTaskDetailsChange={this.handleTaskDetailsChange}
                    handleEditModalSave={this.handleEditModalSave}
                    openDeleteModal={this.state.openDeleteModal}
                    handleDeleteModalClose={this.handleDeleteModalClose}
                    handleDeleteModalConfirm={this.handleDeleteModalConfirm}
                />

                <ToastContainer />
            </div>
        );
    }
}

