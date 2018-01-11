import React, { Component } from 'react';
import Course from './components/b10_Course';
// import logo from './logo.svg';
import './App.css';

class App extends Component {
  render() {
    //array thong tin khoa hoc
    const items = [
      {
        name: 'React Js',
        time : '30h',
        free: false,
        desc: 'Very Simple!'
      },
      {
        name: 'Angular',
        time : '55',
        free: false,
        desc: ''
      },
      {
        name: 'Node Js',
        time : '35',
        free: true,
        desc: 'Very Simple!'
      }
    ];

    const elementCours = items.map((item,index) =>
      <Course key={index} name = {item.name} time={item.time} free={item.free}>{item.desc}</Course>
    );
    return (
      <div className="row">
        {/* <Course /> */}
        {/* <Course name = "React JS" time="30h" free={true}>Very Simple</Course>
        <Course name = "Angular" time="55h" free={false}></Course>
        <Course name = "Node JS" time="35h" free={true}></Course> */}
        {elementCours}
      </div>
    );
  }
}

export default App;
