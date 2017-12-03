//Phieen ban truoc 15.4
//khoi tao component
// import React from 'react';
// var ComponentTmp = React.createClass({
//     render : function(){
//         return(
//             <h1>HOCHNT2</h1>
//         );
//     }
// });

//khoi tao = fuction
function ComponentTmp2 (){
    return  <h1 className="mauvang">Demo Reactjs function </h1>;    
};
const element = <ComponentTmp2/>;

//phien ban 15.4 tro len
class ComponentDemo1 extends React.Component {
    render() {
    return (<h1 className="maudo">Use component demo1</h1>);
    }
};

class ComponentDemo2 extends React.Component{
    render(){
        return(
            <h3>Use component demo2</h3>
        )
    }
};

class ComponentDemoInside1 extends React.Component {
    render() {
    return (
        <div>
        <h1 className="maudo">Use component inside</h1>
        <ComponentDemo2/>
        </div>
        );
    }
};
//demo nhiều render nhiều element
ReactDOM.render(
    <div>
        <ComponentDemo1/>
        <hr/>
        {/* <ComponentDemo1/>
        <h1 className="mauvang">HOCHNT2</h1>
        <h1 className="mauvang">HOCHNT2</h1> */}
        <ComponentDemo2/>
        <hr/>
        <ComponentDemoInside1/>
    </div>
    , document.getElementById("root"));
