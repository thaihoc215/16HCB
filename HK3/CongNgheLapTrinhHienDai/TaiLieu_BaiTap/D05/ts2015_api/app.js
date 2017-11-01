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

app.use('/products', productApi);

app.get('/', (req, res) => {
    res.json('ts2015 api.');
});

var PORT = 3000;
app.listen(PORT, () => {
    console.log('ts2015 api run on port ' + PORT);
});