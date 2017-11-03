var express = require('express'),
    morgan = require('morgan'),
    bodyParser = require('body-parser');

var taikhoanApi = require('./api_controllers/taikhoanApiController');
var giaodichApi = require('./api_controllers/giaodichApiController');
var nganHangApi = require('./api_controllers/nganhangApiController');
var app = express();

app.use(morgan('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));

// di chuyen den router
app.use('/taikhoan', taikhoanApi);
app.use('/giaodich', giaodichApi);
app.use('/nganhang', nganHangApi);

var PORT = 3000;
app.listen(PORT, () => {
    console.log('api run on port 3000');
})