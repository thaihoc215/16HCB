<html>

<head>
   <title>Forward request to another JSP</title>
</head>

<body>
   <% // begin scriptlet

      String name = request.getParameter( "firstName" );

      if ( name != null ) {

   %> <%-- end scriptlet to insert fixed template data --%>

         <jsp:forward page = "forward2.jsp">
            <jsp:param name = "date"
               value = "<%= new java.util.Date() %>" />
         </jsp:forward>

   <% // continue scriptlet

      }  // end if
      else {

   %> <%-- end scriptlet to insert fixed template data --%>

         <form action = "forward1.jsp" method = "get">
            <p>Type your first name and press Submit</p>

            <p><input type = "text" name = "firstName" />
               <input type = "submit" value = "Submit" />
            </p>
         </form>

   <%  // continue scriptlet

      }  // end else

   %> <%-- end scriptlet --%>
</body>

</html>
