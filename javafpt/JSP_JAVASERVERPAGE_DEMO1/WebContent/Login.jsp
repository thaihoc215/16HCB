<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
	<table style="border: 1px solid ;">
		<tr>
			<td colspan="2"><jsp:include page="Banner.jsp"></jsp:include></td>
		</tr>

		<tr valign="top">
			<td align="center" width="100%">
				<div style="border: 1px solid #cccccc; width: 100%; height: 400px">
					<form action="Welcome.jsp" method="post">
						<table
							style="border: 1px solid #cccccc; width: 20%; margin: 10px;"
							align="center">
							<tr>
								<td>Username:</td>
								<td><input type="text" name="userName"></td>
							</tr>
							<tr>
								<td>Password:</td>
								<td><input type="text" name="password"></td>
							</tr>
							<tr>
								<td></td>
								<td><input type="submit" value="Login"></td>
							</tr>
						</table>
					</form>
				</div>
			</td>
		</tr>
		<tr>
			<td colspan="2"><jsp:include page="Footer.jsp"></jsp:include></td>
		</tr>
	</table>
</body>
</html>