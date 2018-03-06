<%@ page errorPage="error.jsp"%>
<html>
<head>
</head>
<body>
<%
Integer totalvisits = (Integer)session.getValue("visitcounter");
if (totalvisits == null)
{
	totalvisits = new Integer(0);
	session.putValue("visitcounter", totalvisits);
	out.print("Welcome visitor");
}
else
{
	totalvisits = new Integer(totalvisits.intValue()+1);
	session.putValue("visitcounter", totalvisits);
	out.print("You have visited this page " + totalvisits.intValue() + " times!");
}
%>
</body>
</html>