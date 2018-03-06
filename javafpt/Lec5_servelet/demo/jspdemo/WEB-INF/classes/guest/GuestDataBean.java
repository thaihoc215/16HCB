package guest;

// Java core packages
import java.io.*;
import java.sql.*;
import java.util.*;

public class GuestDataBean {
   private Connection connection;
   private PreparedStatement addRecord, getRecords;

   // construct TitlesBean object
   public GuestDataBean() throws Exception
   {
      Class.forName( "com.mysql.jdbc.Driver" );

      // connect to the database
      connection = DriverManager.getConnection(
         "jdbc:mysql://localhost:3306/test" );

      getRecords =
         connection.prepareStatement(
            "SELECT firstName, lastName, email FROM guests"
         );

      addRecord =
         connection.prepareStatement(
            "INSERT INTO guests ( " +
               "firstName, lastName, email ) " +
            "VALUES ( ?, ?, ? )"
         );
   }

   // return an ArrayList of GuestBeans
   public ArrayList getGuestList() throws SQLException
   {
      ArrayList guestList = new ArrayList();

      // obtain list of titles
      ResultSet results = getRecords.executeQuery();

      // get row data
      while ( results.next() ) {
         GuestBean guest = new GuestBean();

         guest.setFirstName( results.getString( 1 ) );
         guest.setLastName( results.getString( 2 ) );
         guest.setEmail( results.getString( 3 ) );

         guestList.add( guest );
      }

      return guestList;
   }

   // insert a guest in guestbook database
   public void addGuest( GuestBean guest ) throws SQLException
   {
      addRecord.setString( 1, guest.getFirstName() );
      addRecord.setString( 2, guest.getLastName() );
      addRecord.setString( 3, guest.getEmail() );

      addRecord.executeUpdate();
   }

   // close statements and terminate database connection
   protected void finalize()
   {
      // attempt to close database connection
      try {
         getRecords.close();
         addRecord.close();
         connection.close();
      }

      // process SQLException on close operation
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }
   }
}
