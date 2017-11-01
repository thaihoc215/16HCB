var express = require('express'),
    morgan = require('morgan'),
    bodyParser = require('body-parser');

var taikhoanApi = require('./api_controllers/taikhoanApiController');
var giaodichApi = require('./api_controllers/giaodichApiController');
var app = express();

app.use(morgan('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));

// di chuyen den router
app.use('/taikhoan', taikhoanApi);
app.use('/giaodich', giaodichApi);

app.get('/',(request,response) =>{
    var obj = {
        msg: 'hello'
    }
    response.json(obj);
});

// app.get('/hello',(req,res) =>{
//     if(req.query.name){
//         var name = req.query.name;
//         var obj = {
//             name : name
//         }
//         res.json(obj);
//     }else{
//         res.statusCode = 403;
//         res.json('error');
//     }
// });

//
// GET /hello2/abc

// app.get('/hello2/:name', (req, res) => {
//     if (req.params.name) {
//         var name = req.params.name;
//         var obj = {
//             name: name + '123'
//         }
//         res.json(obj);
//     } else {
//         res.statusCode = 403;
//         res.json('error');
//     }
// });

app.post('/add', (req, res) => {
    var catid = req.body.catid,
        catname = req.body.catname;

    var obj = {
        CatID: catid,
        CatName: catname
    };
    res.statusCode = 201;
    res.json(obj);
});

var PORT = 3000;
app.listen(PORT, () => {
    console.log('api run on port 3000');
})