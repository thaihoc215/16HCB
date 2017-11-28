var express = require('express'),
    morgan = require('morgan'),
    bodyParser = require('body-parser');

var productApi = require('./api-controllers/productApiController');

var app = express();

app.use(morgan('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));

//
// cors middle-ware

app.use((req, res, next) => {
    res.header('Access-Control-Allow-Credentials', true);
    res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
    res.header('Access-Control-Allow-Origin', '*');
    res.header('Access-Control-Allow-Headers', 'Origin, X-Requested-With, Content-Type, Accept');
    next();
});

app.use('/products', productApi);

app.get('/', (req, res) => {
    res.json('ts2015 api.');
});

var PORT = 3000;
app.listen(PORT, () => {
    console.log(`ts2015 api run on port ${PORT}`);
});