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

// router.get('/', (req, res) => {
//     var sql = 'select * from products';
//     db.load(sql, (results) => {
//         res.json(results);
//     });
// });

router.get('/:id', (req, res) => {
    var id = req.params.id;
    var sql = `select * from products where id = ${id}`;
    db.load(sql, (results) => {
        res.json(results[0]);
    });
});

module.exports = router;