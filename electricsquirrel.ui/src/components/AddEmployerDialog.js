import * as React from "react";
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import TextField from '@mui/material/TextField';
import useElectricSquirrelApi from "../hooks/useElectricSquirrelApi";
import { useState } from "react";

function AddEmployerDialog(props) {
    const api = useElectricSquirrelApi();
    const [newEmployerName, setNewEmployerName] = useState('');

    function handleCancel() {
        props.onClose();
    }

    async function handleAdd() {
        const result = await api.employers.createEmployerAsync({ name: newEmployerName });

        if (result) {
            props.onClose();
        } else {

        }
    }

    return (
        <Dialog open={props.isOpen}>
            <DialogTitle>Add Employer</DialogTitle>
            <DialogContent dividers>
                <TextField
                    required
                    name="name"
                    label="Name"
                    id="name"
                    value={newEmployerName}
                    onInput={e => setNewEmployerName(e.target.value)}
                ></TextField>
            </DialogContent>
            <DialogActions>
                <Button onClick={handleCancel}>Cancel</Button>
                <Button onClick={handleAdd}>Add</Button>
            </DialogActions>
        </Dialog>
    )
}

export default AddEmployerDialog;