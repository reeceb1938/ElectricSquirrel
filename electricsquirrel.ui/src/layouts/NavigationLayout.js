import * as React from 'react';
import { Outlet, useNavigate } from 'react-router-dom';
import { AppBar, Box, Divider, Drawer, IconButton, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Toolbar, Typography, useMediaQuery } from '@mui/material';
import { useTheme } from '@mui/material/styles';
import BadgeIcon from '@mui/icons-material/Badge';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import DashboardIcon from '@mui/icons-material/Dashboard';
import MenuIcon from '@mui/icons-material/Menu';
import UserAccountActionsMenu from '../components/UserAccountActionsMenu';

export default function NavigationLayout(props) {
    const { window } = props;
    const [isMobileDrawerOpen, setIsMobileDrawerOpen] = React.useState(false);
    const [selectedIndex, setSelectedIndex] = React.useState(0);
    const navigate = useNavigate();
    const theme = useTheme();
    const isFixedNavMenu = useMediaQuery(theme.breakpoints.up('md'));

    const drawerWidth = 250;

    const container = window !== undefined ? () => window().document.body : undefined;

    const handleDrawerToggle = () => {
        setIsMobileDrawerOpen(!isMobileDrawerOpen);
    }

    const handleListItemClick = (event, index) => {
        setSelectedIndex(index);
        navigate(navListItems[index].link);
    }

    const navListItemToJSX = (listItem, index) => {
        if (listItem.type === 'link') {
            return <ListItem key={index} disablePadding>
                <ListItemButton
                    selected={selectedIndex === index}
                    onClick={(event) => handleListItemClick(event, index)}
                >
                    <ListItemIcon>
                        {listItem.icon}
                    </ListItemIcon>
                    <ListItemText primary={listItem.displayText}></ListItemText>
                </ListItemButton>
            </ListItem>
        } else if (listItem.type === 'divider') {
            return <Divider key={index} sx={{ my: 1 }}></Divider>
        }
    }

    const navListItems = [
        {
            type: 'link',
            displayText: 'Dashboard',
            link: '/',
            icon: (<DashboardIcon></DashboardIcon>)
        },
        {
            type: 'link',
            displayText: 'Calendar',
            link: '/calendar',
            icon: (<CalendarMonthIcon></CalendarMonthIcon>)
        },
        {
            type: 'divider'
        },
        {
            type: 'link',
            displayText: 'My Employers',
            link: '/employers',
            icon: (<BadgeIcon></BadgeIcon>)
        },
    ];

    const drawerContent = (
        <>
            <Toolbar>
            </Toolbar>
            <Divider></Divider>
            <List>
                {navListItems.map((listItem, index) => navListItemToJSX(listItem, index))}
            </List>
        </>
    )

    return (
        <Box sx={{ display: 'flex', height: '100vh' }}>
            <AppBar
                position='fixed'
                sx={{
                    width: { md: `calc(100% - ${drawerWidth}px)` },
                    ml: { md: `${drawerWidth}px` }
                }}
            >
                <Toolbar>
                    <IconButton
                        aria-label='open drawer'
                        edge='start'
                        color='inherit'
                        onClick={handleDrawerToggle}
                        sx={{ mr: 2, display: { md: 'none' } }}
                    >
                        <MenuIcon></MenuIcon>
                    </IconButton>

                    <Typography
                        component='h1'
                        variant='h6'
                        noWrap
                        sx={{ flexGrow: 1 }}
                    >
                        Electric Squirrel
                    </Typography>
                    <UserAccountActionsMenu></UserAccountActionsMenu>
                </Toolbar>
            </AppBar>

            <Box
                component='nav'
                sx={{ width: { md: drawerWidth }, flexShrink: { md: 0 } }}
                aria-label=''
            >
                <Drawer
                    container={container}
                    variant={isFixedNavMenu ? 'permanent' : 'temporary'}
                    open={isMobileDrawerOpen}
                    onClose={handleDrawerToggle}
                    ModalProps={{
                        keepMounted: true
                    }}
                    sx={{
                        // display: { xs: 'block', md: 'none' },
                        '& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth }
                    }}
                >
                    {drawerContent}
                </Drawer>
            </Box>

            <Box
                component='main'
                sx={{
                    mt: 8,
                    flexGrow: 1,
                    width: { md: `calc(100% - ${drawerWidth}px)` },
                    overflowX: 'hidden',
                    overflowY: 'hidden'
                }}
            >
                <Box
                    sx={{
                        flexGrow: 1,
                        // p: 3,
                        width: '100%',
                        overflowX: 'hidden',
                        overflowY: 'auto',
                        height: { md: `calc(100vh - 112px)` }
                    }}
                >
                    <Outlet></Outlet>
                </Box>
            </Box>
        </Box>
    );
}