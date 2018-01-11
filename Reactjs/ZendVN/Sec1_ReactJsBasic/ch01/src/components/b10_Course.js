import React, { Component } from 'react';
import Lesson from './b11_Lesson';

class Course extends Component {
  // JSX
  // formatName(user) {
  //   return user.firstName + ' ' + user.lastName;
  // }
  ShowButtonFree() {
    const isFree = this.props.free;
    if (isFree) {
      return <div className="panel-footer">
      <button type="button" className="btn btn-warning">Register</button>
    </div>;
    }
  }
  
  render() {
    const user = {
      firstName: 'Harper',
      lastName: 'Perez'
    };
    return (
      <div className="col-xs-4 col-sm-4 col-md-4 col-lg-4">

        <div className="panel panel-info">
          <div className="panel-heading">
            <h3 className="panel-title">{this.props.name}</h3>
          </div>
          <div className="panel-body">
            {/* {this.formatName(user)}
            {user.firstName} */}
            <p>{this.props.time}</p>
            <p>{this.props.children}</p>
            <ul className="list-group">
              <Lesson />
              <Lesson />
              <Lesson />
            </ul>
          </div>
          {this.ShowButtonFree()};
          
        </div>
        <button type="button" className="btn btn-default">register</button>
      </div>
      
    );
  }
}

export default Course;
