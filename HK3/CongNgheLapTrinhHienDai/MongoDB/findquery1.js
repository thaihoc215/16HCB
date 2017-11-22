// db.users.find().count()
//Tim theo dieu kien
// db.users.find({
//     "_id": ObjectId("5a096ba61eb88c6ac4a47f61")
//     });
//Tìm và l?c d? li?u
db.users.find(
    {},
    {"username":1, "email":1 , "_id":0})
    