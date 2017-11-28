var mysql = require('mysql'),
    q = require('q');

exports.load = (sql) => {

    var d = q.defer();

    var connection = mysql.createConnection({  
        host: '127.0.0.1',
        user: 'root',
        password: 'th2151994',
        database: 'ts2015'
    }); 
    connection.connect();
    connection.query(sql, function(error, results, fields) {  
        if (error)  {
            d.reject(error);
        } else {
            d.resolve(results);
        }

        connection.end();
    }); 

    return d.promise;
};

exports.insert = (sql) => {

    var d = q.defer();

    var connection = mysql.createConnection({  
        host: '127.0.0.1',
        user: 'root',
        password: '',
        database: 'ts2015'
    }); 
    connection.connect();
    connection.query(sql, function(error, value) {  
        if (error)  {
            d.reject(error);
        } else {
            d.resolve(value.insertId);
        }

        connection.end();
    }); 

    return d.promise;
};

// exports.load = (sql, fn) => {
//     var connection  = mysql.createConnection({  
//         host: '127.0.0.1',
//         user: 'root',
//         password: '',
//         database: 'ts2015'
//     }); 
//     connection.connect();
//     connection.query(sql, function(error, results, fields) {  
//         if (error) 
//             throw error;  

//         // console.log(results);
//         connection.end();

//         fn(results);
//     }); 
// };