<%@ page import="java.util.Date"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<%@ page errorPage="ErrorPage.jsp"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Welcome JSP</title>
</head>
<body>
	<!-- lay thong tin username tu login va hien thi
su dung 2 thanh phan import va request -->
	<table style="border: 1px solid;">

		<tr>
			<td colspan="2"><jsp:include page="Banner.jsp"></jsp:include></td>
		</tr>

		<%
			String username = request.getParameter("userName"); //servlet
		%>

		<tr valign="top">
			<td valign="top" width="20%"><jsp:include page="Menu.jsp"></jsp:include></td>
			<td valign="top" width="80%">
				<div style="border: 1px solid #cccccc; width: 100%; height: 400px;">
					<table>
						<tr>
							<td><h3>Today: <%=new Date() %></h3></td>
						</tr>
						<tr>
							<td><h3>Welcome to: <%=username %></h3></td>
						</tr>
					</table>

				</div>
			</td>
		</tr>
	</table>
</body>
</html>