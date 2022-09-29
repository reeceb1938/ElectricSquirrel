import React, { Component } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import BaseLayout from './layouts/BaseLayout';
import NavigationLayout from './layouts/NavigationLayout'
import Calendar from './pages/Calendar';
import Employers from './pages/Employers';
import Home from './pages/Home';
import Login from './pages/Login';
import PageNotFound from './pages/PageNotFound';
import AuthenticationProvider from './components/AuthenticationProvider';
import PrivateRoute from './components/PrivateRoute';
// import EsApiProvider from './components/EsApiProvider';
// import ViewStateProvider from './components/ViewStateProvider';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { loading: true };
    }

    componentDidMount() {
        // this.populateWeatherData();
    }

    render() {
        return (
            <AuthenticationProvider>
                <BrowserRouter>
                    <Routes>
                        <Route path='/' element={<BaseLayout></BaseLayout>}>
                            <Route path='login' element={<Login></Login>}></Route>

                            <Route path='' element={<PrivateRoute></PrivateRoute>}>
                                <Route path='' element={<NavigationLayout></NavigationLayout>}>
                                    <Route index element={<Home></Home>}></Route>
                                    <Route path='calendar' element={<Calendar></Calendar>}></Route>
                                    <Route path='employers' element={<Employers></Employers>}></Route>
                                </Route>
                            </Route>

                            <Route path='*' element={<PageNotFound></PageNotFound>}></Route>
                        </Route>
                    </Routes>
                </BrowserRouter>
            </AuthenticationProvider>
        );
    }
}
