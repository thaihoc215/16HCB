<%@ page errorPage="error.jsp"%>
<html>
<head>
<title>Using JavaBeans from JSP page</title>
</head>
<body>
<jsp:useBean id="staff" class="beans.Employee"/>
<jsp:setProperty name="staff" property="name" value="Peter"/>
Welcome to the class, <jsp:getProperty name="staff" property="name"/>
<br>
<%=staff.getName()%>, please try more by yourself.
</body>
</html>