<html>
<head>
<title>JSP example 2</title>
</head>
<body>
JSP example 2<br>
<%!
	String sitename = "www.test.com";
	int counter = 0;

	private void incCounter()
	{
		counter = counter + 1;
	}
%>
Web site of the day is <%= sitename %><br>
Page accessed <%= counter %>
</body>
</html>