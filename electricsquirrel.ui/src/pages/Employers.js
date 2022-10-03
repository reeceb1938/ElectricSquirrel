import * as React from "react";
import AddIcon from '@mui/icons-material/Add';
import Toolbar from '@mui/material/Toolbar';
import ToolbarIconButton from "../components/ToolbarIconButton";
import AddEmployerDialog from "../components/AddEmployerDialog";

function Employers() {
    const [isAddEmployerDialogOpen, setIsAddEmployerDialogOpen] = React.useState(false);

    const handleAddEmployerOnClick = () => {
        setIsAddEmployerDialogOpen(true);
    }

    const handleAddEmployerDialogClosed = () => {
        setIsAddEmployerDialogOpen(false);
    }

    return (
        <>
            <Toolbar
                sx={{
                    bgcolor: 'grey.600'
                }}
            >
                <ToolbarIconButton icon={<AddIcon></AddIcon>} label="Add" onClick={handleAddEmployerOnClick}></ToolbarIconButton>
            </Toolbar>
            <AddEmployerDialog isOpen={isAddEmployerDialogOpen} onClose={handleAddEmployerDialogClosed}></AddEmployerDialog>
        </>
    )
}

export default Employers;