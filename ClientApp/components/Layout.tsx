import * as React from 'react';
import { NavMenu } from './NavMenu';
import Footer from "./Footer";
import Header from "./Header";

export class Layout extends React.Component<{}, {}> {
    public render() {
        return <div className='container-fluid'>
            <div className='row'>
                <div className='col-sm-3'>
                {/* Navmenu and Header placement to be dicussed */}
                    <NavMenu />
                    <Header />
                </div>
                <div className='col-sm-9'>
                    { this.props.children }
                </div>
                <Footer />
            </div>
        </div>;
    }
}
