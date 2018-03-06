<html>

   <head>
      <title>Using the include directive</title>

      <style type = "text/css">
         body {
            font-family: tahoma, helvetica, arial, sans-serif;
         }

         table, tr, td {
            font-size: .9em;
            border: 3px groove;
            padding: 5px;
            background-color: #dddddd;
         }
      </style>
   </head>

   <body>
      <table>
         <tr>
            <td style = "width: 160px; text-align: center">
               <img src = "images/logotiny.png"
                  width = "140" height = "93"
                  alt = "Deitel & Associates, Inc. Logo" />
            </td>

            <td>

               <%-- include banner.html in this JSP --%>
               <%@ include file = "banner.html" %>

            </td>
         </tr>

         <tr>
            <td style = "width: 160px">

               <%-- include toc.html in this JSP --%>
               <%@ include file = "toc.html" %>

            </td>

            <td style = "vertical-align: top">

               <%-- include clock2.jsp in this JSP --%>
               <%@ include file = "clock2.jsp" %>

            </td>
         </tr>
      </table>
   </body>
</html>
