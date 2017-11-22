db.users.update(
   {},
   {$unset: {password: ""}},
   {
     upsert: true,
     multi: false
   }
)