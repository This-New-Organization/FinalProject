import React from 'react';


class RegisterForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            nameFirst: '',
            nameLast: '',
            email: '',
            password:'',
            passwordConfirmation: ''
        }
        this.onChange = this.onChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onChange(e) {
        this.setState({ [e.target.name]: e.target.value});
    }

    onSubmit(e) {
        e.preventDefault();
        //using Axios instead of fetch
        this.props.userRegisterRequest(this.state)
    }

    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <h1>Join</h1>
                <div className="form-group">
                    <label className="control-label">UserName</label>
                    <input 
                        onChange={this.onChange}
                        value={this.state.username}
                        type="text"
                        name="username"
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label className="control-label">UserName</label>
                    <input 
                        onChange={this.onChange}
                        value={this.state.nameFirst}
                        type="text"
                        name="nameFirst"
                        className="form-control"
                    />
                </div>   
                <div className="form-group">
                    <label className="control-label">UserName</label>
                    <input 
                        onChange={this.onChange}
                        value={this.state.nameLast}
                        type="text"
                        name="nameLast"
                        className="form-control"
                    />
                </div>   
                <div className="form-group">
                    <label className="control-label">UserName</label>
                    <input 
                        onChange={this.onChange}
                        value={this.state.email}
                        type="text"
                        name="email"
                        className="form-control"
                    />
                </div>   
                <div className="form-group">
                    <label className="control-label">UserName</label>
                    <input 
                        onChange={this.onChange}
                        value={this.state.password}
                        type="password"
                        name="password"
                        className="form-control"
                    />
                </div>      
                <div className="form-group">
                    <label className="control-label">UserName</label>
                    <input 
                        onChange={this.onChange}
                        value={this.state.passwordConfirmation}
                        type="password"
                        name="passwordConfirmation"
                        className="form-control"
                    />
                </div>   

                <div className="form-group">
                    <button className="btn btn-primary btn-lg">
                        Sign Up
                    </button>
                </div>         
            </form>
        );
    }
}

RegisterForm.propTypes = {
    userRegisterRequest: React.PropTypes.func.isRequired
}

export default RegisterForm;