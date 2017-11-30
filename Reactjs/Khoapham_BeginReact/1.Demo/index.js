var express = require("express");

var app = express();

var x = 10 + 5;
console.log(x);
//yeu cau gui len server tim o public
app.use(express.static("public"));
app.set("view engine", "ejs");
app.set("views",__dirname + "/views");

var PORT = 3000;
app.listen(PORT,()=>{
    console.log("connect server: " + PORT);
})

app.get("/",(req,res)=>{
    res.render("trangchu");
});