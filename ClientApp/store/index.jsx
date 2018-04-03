import React from 'react';
import { render } from 'react-dom';
import { Router, browserHistory } from 'react-router';
import { Provider } from 'react-redux';
import thunk from 'redux-thunk';
import {createStore, applyMiddleware} from 'redux';
import setAuthorizationToken from '../utilities/setAuthorizationToken';

import routes from './routes';

const store = createStore(
    (state = {}) => state, applyMiddleware(thunk)
);

setAuthorizationToken(localStorage.jwtToken);

render (
    <Provider store={store}>
    <Router history={browserHistory} routes={routes} /> 
    </Provider>, document.getElementById()
    );
