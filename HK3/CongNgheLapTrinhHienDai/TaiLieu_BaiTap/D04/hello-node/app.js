// var m = require('mustache');
var nb = require('./fn/number'),
    constant = require('./fn/const');


// console.log('hello-node');

// function sum(a, b) {
//     return a + b;
// }

// var sum = (a, b) => {
//     return a + b;
// }

// var s = sum(9, 6);
// console.log(s);

// var obj = {
//     x: 9,
//     y: 6,
//     s: s
// }

// var str = m.render('{{x}} + {{y}} = {{s}}', obj);
// console.log(str);

var x = 9,
    y = 6;

var s = nb.sum(x, y) + constant.PI;

var str2 = `${x} + ${y} = ${s}`;
console.log(str2);