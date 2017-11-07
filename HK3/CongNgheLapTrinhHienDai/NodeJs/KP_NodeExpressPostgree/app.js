var express = require('express'),
    bodyParser = require('body-parser'),
    ejs = require('ejs');

var app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));

//cau hinh ejs
// app.engine('ejs',ejs.renderFile);
app.set('view engine','ejs');
app.set('views',__dirname + '/views');

app.get('/thaihoc',(req,res)=>{
    res.render('thaihoc');
});

app.get('/', (req, res) => {
    res.send('route succesfull');
});

app.post('/hello',(req,res)=>{
    let name = req.body.name;
    res.send('hello ' + name);
});

var PORT = 3000;
app.listen(PORT, () => {
    console.log('connect successful');
});