<!-- customTagWelcome.jsp               -->
<!-- JSP that uses a custom tag to output content. -->

<%-- taglib directive --%>
<%@ taglib uri="/WEB-INF/welcome-taglib.tld" prefix="test" %>

<!--<html xmlns = "http://www.w3.org/1999/xhtml">-->
<html>
   <head>
      <title>Simple Custom Tag Example</title>
   </head>

   <body>
      <p>The following text demonstrates a custom tag:</p>
      <h1>
         <test:welcome />
      </h1>
   </body>
</html>
