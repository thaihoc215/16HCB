<html>
<head>
<title>Request-Response Example</title>
</head>
<body>
<%
	String name = request.getParameter( "firstName" );
	if ( name != null ) 
	{
%>
	<h1>
	Hello <%= name %>, <br />
	Welcome to JavaServer Pages!
	</h1>
<%
	}	
	else
	{
%>
	<form action = "welcome.jsp" method = "get">
	<p>Type your first name and press Submit</p>

	<p><input type = "text" name = "firstName" />
	<input type = "submit" value = "Submit" />
	</p>
</form>
<%
	}
%>

</body>
</html>