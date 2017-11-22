//xoa 1 record
/*db.users.remove(
   {username: "thaihoc"},
   {
     justOne: true
   }
)*/
//xoa theo dieu kien
db.users.remove(
   {username: {$eq: "thaihoc"}},
   {
     justOne: true
   }
)