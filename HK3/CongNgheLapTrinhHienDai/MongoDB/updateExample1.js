db.users.update(
   {"username" : "thaihoc"},
   {$set: {password: "abcde"}},
   {
     upsert: false,
     multi: false
   }
)