<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>JavaBean Example</title>
</head>
<body>
	<jsp:useBean id="person" class="java.bean.PersonBean">
		<jsp:setProperty name = "person" property="firstName" value="Zara"></jsp:setProperty>
		<jsp:setProperty name = "person" property="lastName" value="Ali"></jsp:setProperty>
		<jsp:setProperty name = "person" property="age" value="10"></jsp:setProperty>
	</jsp:useBean>
	
	<p>
		Student First Name: 
		<jsp:getProperty property="firstName" name="person"/>
	</p>
	<p>
		Student Last Name: 
		<jsp:getProperty property="lastName" name="person"/>
	</p>
	<p>
		Student Age: 
		<jsp:getProperty property="age" name="person"/>
	</p>
</body>
</html>