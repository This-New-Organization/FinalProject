import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';

export default class Counter extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Login</h1>

            <p>This is a simple example of a React component.</p>
            <button>Login</button>
            
        </div>;
    }
}