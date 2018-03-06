<%-- taglib directive --%>
<%@ taglib uri = "/WEB-INF/welcome2-taglib.tld" prefix = "test" %>

<html xmlns = "http://www.w3.org/1999/xhtml">

   <head>
      <title>Specifying Custom Tag Attributes</title>
   </head>

   <body>
      <p>Demonstrating an attribute with a string value</p>
      <h1>
         <test:welcome2 firstName = "Paul" />
      </h1>

      <p>Demonstrating an attribute with an expression value</p>
      <h1>
         <%-- scriptlet to obtain "name" request parameter --%>
         <%
            String name = request.getParameter( "name" );
         %>

         <test:welcome2 firstName = "<%= name %>" />
      </h1>
   </body>

</html>