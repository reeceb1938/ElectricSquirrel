import * as React from 'react';
import PropTypes from 'prop-types';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import { Link as RouterLink, Outlet } from 'react-router-dom';
import { useMediaQuery } from '@mui/material';

function BaseLayout() {
    const userPrefersDarkMode = useMediaQuery('(prefers-color-scheme: dark)');

    const LinkBehavior = React.forwardRef((props, ref) => {
        const { href, ...other } = props;
        // Map href (MUI) -> to (react-router)
        return <RouterLink ref={ref} to={href} {...other}></RouterLink>
    });

    LinkBehavior.propTypes = {
        href: PropTypes.oneOfType([
            PropTypes.shape({
                hash: PropTypes.string,
                pathname: PropTypes.string,
                search: PropTypes.string,
            }),
            PropTypes.string,
        ]).isRequired,
    };

    const theme = React.useMemo(
        () =>
            createTheme({
                palette: {
                    mode: userPrefersDarkMode ? 'dark' : 'light',
                    //primary: {
                    //    main: '#EE02EE',
                    //},
                },
                components: {
                    MuiLink: {
                        defaultProps: {
                            component: LinkBehavior
                        },
                    }
                },
                MuiButtonBase: {
                    defaultProps: {
                        LinkComponent: LinkBehavior
                    }
                }
            }),
        [userPrefersDarkMode],
    );

    return (
        <ThemeProvider theme={theme}>
            <CssBaseline />
            <Outlet></Outlet>
        </ThemeProvider>
    )
}

export default BaseLayout;