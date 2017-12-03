//phien ban 15.4 tro len - props
class ComponentDemo1 extends React.Component {
    render() {
    return (
        <div>
        <h1 className="maudo">{this.props.ten} - {this.props.demo}</h1>
        <p>{this.props.children}</p>
        </div>
        
        );
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
        <ComponentDemo1 ten="React JS" demo="component 1.1"/>
        <ComponentDemo1 ten="Node JS" demo="component 1.2"/>
        <ComponentDemo1 ten="Props Dacbiet">Vi du props dac biet</ComponentDemo1>
        <hr/>
        {/* <ComponentDemo1/>
        <h1 className="mauvang">HOCHNT2</h1>
        <h1 className="mauvang">HOCHNT2</h1> */}
        <ComponentDemo2/>
        <hr/>
        <ComponentDemoInside1/>
    </div>
    , document.getElementById("root"));
