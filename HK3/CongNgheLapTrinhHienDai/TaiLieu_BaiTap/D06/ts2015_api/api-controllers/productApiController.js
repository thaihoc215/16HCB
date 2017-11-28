var express = require('express'),
    db = require('../fn/mysql-db');

var router = express.Router();

router.get('/', (req, res) => {
    // productModel.LoadAll().then(rows => {
    //     res.json(rows);
    // })

    var sql = 'select * from products';
    db.load(sql).then(rows => {
        res.json(rows);
    });
});

router.get('/:id', (req, res) => {
    var id = req.params.id;
    var sql = `select * from products where id = ${id}`;
    db.load(sql).then(rows => {
        res.json(rows[0]);
    });
});

router.post('/', (req, res) => {
    var code = req.body.code;
    var name = req.body.name;
    var price = req.body.price;
    var sql = `insert into products(code, name, imagePath, price) values('${code}', '${name}', 'logo.jpg', ${price})`;
    db.insert(sql).then(id => {
        res.statusCode = 201;
        res.json(id);
    });
});

// router.get('/', (req, res) => {
//     var sql = 'select * from products';
//     db.load(sql, (results) => {
//         res.json(results);
//     });
// });

// router.get('/:id', (req, res) => {
//     var id = req.params.id;
//     var sql = `select * from products where id = ${id}`;
//     db.load(sql, (results) => {
//         res.json(results[0]);
//     });
// });

module.exports = router;