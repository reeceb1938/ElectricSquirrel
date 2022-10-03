import * as React from 'react';
import { Avatar, Badge, IconButton, ListItemIcon, Menu, MenuItem } from '@mui/material';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import useAuth from '../hooks/useAuth';
import { useNavigate } from 'react-router-dom';

const UserAccountActionsMenu = () => {
    const [accountActionsMenuAnchorEl, setAccountActionsMenuAnchorEl] = React.useState(null);
    const accountActionsMenuOpen = Boolean(accountActionsMenuAnchorEl);
    const auth = useAuth();
    const navigate = useNavigate();

    const handleAccountActionsButtonClick = (event) => {
        setAccountActionsMenuAnchorEl(event.currentTarget);
    }

    const handleMenuClose = () => {
        setAccountActionsMenuAnchorEl(null);
    }

    async function handleLogoutClick() {
        await auth.logoutAsync();
        navigate('/login');
    }

    return (
        <>
            <IconButton
                id='account-actions-button'
                aria-controls={accountActionsMenuOpen ? 'account-actions-menu' : undefined}
                aria-haspopup='true'
                aria-expanded={accountActionsMenuOpen ? 'true' : undefined}
                onClick={handleAccountActionsButtonClick}
                color='inherit'
            >
                <Badge badgeContent={4} color='secondary'>
                    <AccountCircleIcon></AccountCircleIcon>
                </Badge>
            </IconButton>
            <Menu
                id='account-actions-menu'
                anchorEl={accountActionsMenuAnchorEl}
                open={accountActionsMenuOpen}
                onClose={handleMenuClose}
                onClick={handleMenuClose}
            >
                <MenuItem>
                    My Account
                </MenuItem>
                <MenuItem>
                    Settings
                </MenuItem>
                <MenuItem
                    onClick={handleLogoutClick}
                >
                    Logout
                </MenuItem>
            </Menu>
        </>
    )
}

export default UserAccountActionsMenu;