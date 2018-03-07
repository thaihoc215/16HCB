<%@page import="java.util.ArrayList"%>
<%@page import="java.util.List"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
	<%
	//luu tru hien thi danh sach thanh vien
	//su dung doi tuong session luu trong listmember
		List listMembers = (ArrayList)session.getAttribute("LIST_MEMBER");
	//su dung doi tuong request do register gui den
		String fullName = request.getParameter("fullName");
		String email = request.getParameter("email");
		String phone = request.getParameter("phone");
		
		String result = fullName + " : " + email + " : " + phone;
		if(listMembers == null){
			listMembers = new ArrayList();
		}else{
			listMembers = (ArrayList)session.getAttribute("LIST_MEMBER");
		}
		
		if(fullName!=null && !"".equals(null)){
			listMembers.add(result);
		}
		
		session.setAttribute("LIST_MEMBER", listMembers);
	%>
</body>
</html>