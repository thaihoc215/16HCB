<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
	<table>
			<tr>
			<td colspan="2"><jsp:include page="Banner.jsp"></jsp:include></td>
		</tr>
		<tr valign="top">
			<td valign="top" width="20%"><jsp:include page="Menu.jsp"></jsp:include></td>
			<td align="center" width="80%">
				<div>
					<form action="ListMember.jsp" method="post">
						<table
							style="border: 1px solid #cccccc; width: 20%; margin: 10px;"
							align="center">
							<tr>
								<td>FullName:</td>
								<td><input type="text" name="fullName"></td>
							</tr>
							<tr>
								<td>Email:</td>
								<td><input type="text" name="email"></td>
							</tr>
							<tr>
								<td>Phone:</td>
								<td><input type="text" name="phone"></td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" value="Register"></td>
							</tr>
						</table>
					</form>
				</div>
			</td>
		</tr>
	</table>

</body>
</html>