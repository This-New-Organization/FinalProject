import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import ContactUs from './components/ContactUs';
import Login from './components/Login';
//import Register from './components/Register';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/Login' component={ Login } />
    <Route path='/ContactUs' component={ ContactUs } />
    {/* <Route path='/Register' component={ Register } /> */}
</Layout>;
