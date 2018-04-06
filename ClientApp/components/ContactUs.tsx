import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class ContactUs extends React.Component<RouteComponentProps<{}>, {}> {
  constructor(){
    super();
    this.state = {email: null, name: null, message: null};
  }
   submitHandler() {
    fetch("http://localhost:5000/api/ContactUs/")
    .then()
      return (Response);
  }


  private updateEmail(event: any){
    this.setState({
      ...this.state, email: event.target.value
    });
  }

  public render() {
    return (
      <div>
        <h1>Contact us</h1>
        <input type='email' onChange={this.updateEmail}/>
        <input type='textbox' />
        <textarea/>
        <form action="/ContactUs">
        First name:<br/>
        <input type="text" name="firstname" value="First name"/>
      <br/>
       Last name: <br/>
      <input type="text" name="lastname" value="Last name"/>
      <br/>
        <button onClick={this.submitHandler}></button>
        <input type="submit" value="Submit"/>
       </form>
      </div>
    );
  }
 }