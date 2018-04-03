import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';


export default class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        // Body will go on the <div></div> tag
        return <div>
            <h1>Hello, world!</h1>
            <p>Welcome to your new single-page application, built with:</p>
        </div>;
    }
}
