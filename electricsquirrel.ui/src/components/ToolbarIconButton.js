import IconButton from '@mui/material/IconButton';
import Stack from '@mui/material/Stack';
import '../App.css';

function ToolbarIconButton(props) {


    return (
        <Stack>
            <IconButton onClick={props.onClick}>
                {props.icon}
            </IconButton>
            <label className="Toolbar-button-label">{props.label}</label>
        </Stack>
    )
}

export default ToolbarIconButton;