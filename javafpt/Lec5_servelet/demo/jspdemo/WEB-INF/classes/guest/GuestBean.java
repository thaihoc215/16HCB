package guest;

public class GuestBean {
   private String firstName, lastName, email;

   // set the guest's first name
   public void setFirstName( String name )
   {
      firstName = name;
   }

   // get the guest's first name
   public String getFirstName()
   {
      return firstName;
   }

   // set the guest's last name
   public void setLastName( String name )
   {
      lastName = name;
   }

   // get the guest's last name
   public String getLastName()
   {
      return lastName;
   }

   // set the guest's email address
   public void setEmail( String address )
   {
      email = address;
   }

   // get the guest's email address
   public String getEmail()
   {
      return email;
   }
}
