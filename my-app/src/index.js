import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Link, Route } from 'react-router-dom';
import { firebaseApp } from './firebase';

// import App from './components/App';
// import SignIn from './components/SignIn';
// import SignUp from './components/SignUp';
// import { BrowserRouter, Link, Route } from 'react-router-dom';

const App = () => (
    <div>
        <Link to='signin' >Sign In</Link>
    </div>
)
const SignIn = () => (
    <div>SignIn
        <Link to='/' >App</Link>
    </div>
)

firebaseApp.auth().onAuthStateChanged(user => {
    if (user) {
        console.log('user has Signed in', user);
    } else {
        console.log('user has Signed out');
    }
})

ReactDOM.render(
    <BrowserRouter>
    <div>
        <Route path='/' component={App} />
        <Route path='signin' component={SignIn}/>
    </div>
    </BrowserRouter>, document.getElementById('root')
)