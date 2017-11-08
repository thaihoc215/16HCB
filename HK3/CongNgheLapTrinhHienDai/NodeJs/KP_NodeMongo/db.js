//B1 require thu vien
var mongo = require('mongoose');
//B2. chon duong dan ket noi
mongo.connect('mongodb://localhost/myDatabase');
//B3. Tao schema
const userSchema = new mongo.Schema({
    name: String,
    age: Number
});
//B4. Tao model
const user = mongo.model('user', userSchema);
//B5. Tao hanh dong voi collections
// user.create({
//     name: "ha nguyen thai hoc",
//     age: 15
// })
// user.create([
//     {name: "t1", age: 21},
//     {name: "hoc", age: 25}
// ])

//Tim kiem
// user.find().exec((err,users)=>{
//     console.log(users);
// });

//Chinh sua
// user.update({name:"teo"}, {age: 34}).exec((err,rs)=>{
//     console.log(rs);
// });

//xoa
user.remove({name:"teo"}).exec((err,rs)=>{
    console.log(rs);
})