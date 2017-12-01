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
}
const element = <KhoaPham2 />

//phien ban 15.4 tro len
class ComponentTmp extends React.Component {
    render() {
        return <h1 className="mauvang">Demo Reactjs</h1>;
    }
}



//demo nhiều render nhiều element
ReactDOM.render(
    <div>
        <ComponentTmp/>
        <h1 className="mauvang">HOCHNT2</h1>
        <h1 className="mauvang">HOCHNT2</h1>
        <h1 className="mauvang">HOCHNT2</h1>
        <h1 className="mauvang">HOCHNT2</h1>
    </div>
    , document.getElementById("root"));
