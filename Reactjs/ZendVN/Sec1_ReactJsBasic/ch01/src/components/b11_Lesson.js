import React, { Component } from 'react';

class Lesson extends Component {
  render() {
    //JSX
    // return (
    //   //<li className="list-group-item">Item 1</li>
    // );
    
    return React.createElement('li', { className: 'list-group-item' }, '123');
  }
}

export default Lesson;
