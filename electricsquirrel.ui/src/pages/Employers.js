import * as React from "react";
import { useNavigate }  from 'react-router-dom';
import AddIcon from '@mui/icons-material/Add';
import Card from '@mui/material/Card';
import CardActionArea from '@mui/material/CardActionArea';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Grid from '@mui/material/Unstable_Grid2';
import Toolbar from '@mui/material/Toolbar';
import ToolbarIconButton from "../components/ToolbarIconButton";
import AddEmployerDialog from "../components/AddEmployerDialog";
import useElectricSquirrelApi from "../hooks/useElectricSquirrelApi";

function Employers() {
    const api = useElectricSquirrelApi();
    const navigate = useNavigate();

    const [isAddEmployerDialogOpen, setIsAddEmployerDialogOpen] = React.useState(false);
    const [employers, setEmployers] = React.useState([]);
    const [shouldReloadEmployers, setShouldReloadEmployers] = React.useState(true);

    React.useEffect(() => {
        const loadEmployers = async () => {
            if (shouldReloadEmployers) {
                setShouldReloadEmployers(false);
                const result = await api.employers.getAllEmployersAsync();
                console.log(result);
                setEmployers(result);
            }
        }
        loadEmployers();
    }, [shouldReloadEmployers])

    const handleAddEmployerOnClick = () => {
        setIsAddEmployerDialogOpen(true);
    }

    const handleAddEmployerDialogClosed = () => {
        setIsAddEmployerDialogOpen(false);
        setShouldReloadEmployers(true);
    }

    const handleEmployerOnClick = (employerId) => {
        navigate(`/employers/${employerId}`)
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
            <Grid container spacing={2} sx={{ padding: 2 }}>
                {employers.map((value, index) => (
                    <Grid key={index} xs={12} sm={6} md={3}>
                        <Card>
                            <CardActionArea onClick={() => handleEmployerOnClick(value.id)}>
                                <CardMedia
                                    component="img"
                                    height="160"
                                    img=""
                                >
                                </CardMedia>
                                <CardContent>
                                    {value.name}
                                </CardContent>
                            </CardActionArea>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </>
    )
}

export default Employers;