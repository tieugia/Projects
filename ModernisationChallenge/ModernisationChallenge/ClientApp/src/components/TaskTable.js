import React, { useState } from 'react';
import 'react-toastify/dist/ReactToastify.css';
import { DataGrid } from '@mui/x-data-grid';
import { Menu, MenuItem, Fab } from '@mui/material';

import Checkbox from '@mui/material/Checkbox';
import { Add as AddIcon, Edit as EditIcon, Delete as DeleteIcon } from '@mui/icons-material';

const TaskTable = ({ tasks, handleEditModalOpen, handleDeleteModalOpen,
    handleMenuClick, handleMenuClose, handleCompleteTask, anchorEl, selectedTaskId }) => {

    const [taskId, setTaskId] = useState(selectedTaskId);

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
                        <Fab size="small" color="primary" onClick={(e) => handleMenuClick(e, params.row.id)}>
                            <AddIcon></AddIcon>
                        </Fab>
                        <Menu
                            anchorEl={anchorEl}
                            open={Boolean(anchorEl)}
                            onClose={handleMenuClose}
                        >
                            <MenuItem onClick={() => handleEditModalOpen(selectedTaskId)}>
                                <EditIcon />
                                Edit
                            </MenuItem>
                            <MenuItem onClick={() => handleDeleteModalOpen(selectedTaskId)}>
                                <DeleteIcon />
                                Delete
                            </MenuItem>
                        </Menu>
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

