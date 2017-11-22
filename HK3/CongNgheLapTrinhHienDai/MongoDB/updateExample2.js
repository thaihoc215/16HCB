db.users.update(
    //tim kiem tat ca nhung record chua co gia tri va set gia tri
   {"email": {$exists: false}},
   {$set: {passwordee: "12345"}},
   {
     upsert: true,
     multi: false
   }
)