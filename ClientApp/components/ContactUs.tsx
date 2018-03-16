import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class ContactUs extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Contact us</h1>
            <p>This will be a page with our contacts information</p>
        </div>;
    }
}
