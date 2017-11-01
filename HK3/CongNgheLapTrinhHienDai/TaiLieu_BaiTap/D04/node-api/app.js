var express = require('express'),
    morgan = require('morgan'),
    bodyParser = require('body-parser');

var app = express();

app.use(morgan('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));

app.get('/', (request, response) => {
    var obj = {
        msg: 'hello from api'
    };
    response.json(obj);
});

//
// GET /hello?name=...

app.get('/hello', (req, res) => {
    if (req.query.name) {
        var name = req.query.name;
        var obj = {
            name: name
        }
        res.json(obj);
    } else {
        res.statusCode = 403;
        res.json('error');
    }
});

//
// GET /hello2/abc

app.get('/hello2/:name', (req, res) => {
    if (req.params.name) {
        var name = req.params.name;
        var obj = {
            name: name
        }
        res.json(obj);
    } else {
        res.statusCode = 403;
        res.json('error');
    }
});

app.post('/add',    (req, res) => {
    var catid = req.body.catid,
        catname = req.body.catname;

    var obj = {
        CatID: catid,
        CatName: catname
    };
    res.statusCode = 201;
    res.json(obj);
});

app.listen(3000, () => {
    console.log('api run on port 3000');
});