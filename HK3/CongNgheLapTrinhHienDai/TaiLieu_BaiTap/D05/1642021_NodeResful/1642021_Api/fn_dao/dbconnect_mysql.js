var mySql = require('mysql'),
    q = require('q');

exports.load = (sql) => {
    var d = q.defer();

    var connection = mySql.createConnection({
        host: '127.0.0.1',
        user: 'root',
        password: 'th2151994',
        database: 'rest_atm'
    });
    connection.connect();
    connection.query(sql,function (err, rs, fields) {
        if (err) {
            d.reject(err);
        } else {
            d.resolve(rs);
        }
        connection.end();
    });
    return d.promise;
}