//demo nhiều render nhiều element
ReactDOM.render(
    <div>
        <h1>HOCHNT1</h1>
        <h1 className="mauvang">HOCHNT2</h1>
    </div>
    , document.getElementById("root"));

ReactDOM.render(
    <div>
        <h1 className="mauvang">HOCHNT3</h1>
        <h1 className="mauvang">HOCHNT4</h1>
    </div>
    , document.getElementById("root2"));