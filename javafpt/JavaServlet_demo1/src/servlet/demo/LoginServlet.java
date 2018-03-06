package servlet.demo;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletConfig;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class LoginServlet
 */
public class LoginServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private static String USER_NAME;
	private static String PASSWORD;
    /**
     * Default constructor. 
     */
    public LoginServlet() {
    }

	/**
	 * @see Servlet#init(ServletConfig)
	 */
	public void init(ServletConfig config) throws ServletException {
		System.out.println("Login Servlet::BEGIN");
		ServletContext context = config.getServletContext();
		USER_NAME = context.getInitParameter("USER_NAME");
		PASSWORD = context.getInitParameter("PASSWORD");
		System.out.println(USER_NAME + ": " + PASSWORD);
		System.out.println("Login Servlet::END");
	}

	/**
	 * @see Servlet#destroy()
	 */
	public void destroy() {
		// TODO Auto-generated method stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
//		response.getWriter().append("Served at: ").append(request.getContextPath());
		response.setContentType( "text/html" );
	      PrintWriter out = response.getWriter();
	      
	      // send XHTML page to client

	      // start XHTML document
	      out.println( "<?xml version = \"1.0\"?>" );

	      out.println( "<!DOCTYPE html PUBLIC \"-//W3C//DTD " +
	         "XHTML 1.0 Strict//EN\" \"http://www.w3.org" +
	         "/TR/xhtml1/DTD/xhtml1-strict.dtd\">" );

	      out.println(
	         "<html xmlns = \"http://www.w3.org/1999/xhtml\">" );

	      // head section of document
	      out.println( "<head>" );
	      out.println( "<title>A Simple Servlet Example</title>" );
	      out.println( "</head>" );

	      // body section of document
	      out.println( "<body>" );
	      out.println( "<h1>Welcome to Servlets!</h1>" );
	      //login form
	      out.println("<form action='" + request.getContextPath() + "/Login' method = 'POST'" );
		out.println("<table>");
		out.println("<tr>");
		out.println("<td>Username:</td>");
		out.println("<td><input type='text' name='userName'></td>");
		out.println("</tr>");
		out.println("<tr>");
		out.println("<td>Password:</td>");
		out.println("<td><input type='password' name='password'></td>");
		out.println("</tr>");
		out.println("</table>");
		out.println("<tr>");
		out.println("<td></td>");
		out.println("<td><input type='submit' value='Login'></td>");
		out.println("</tr>");
		out.println("</body>");

	      // end XHTML document
	      out.println( "</html>" );
	      out.close();  // close stream to complete the page
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
//		doGet(request, response);
		String userName = request.getParameter( "userName" );
		String password = request.getParameter( "password" );

	      response.setContentType( "text/html" );
	      PrintWriter out = response.getWriter();

	      // send XHTML document to client

	      // start XHTML document
	      out.println( "<?xml version = \"1.0\"?>" );

	      out.println( "<!DOCTYPE html PUBLIC \"-//W3C//DTD " +
	         "XHTML 1.0 Strict//EN\" \"http://www.w3.org" +
	         "/TR/xhtml1/DTD/xhtml1-strict.dtd\">" );

	      out.println(
	         "<html xmlns = \"http://www.w3.org/1999/xhtml\">" );

	      // head section of document
	      out.println( "<head>" );
	      out.println(
	         "<title>Processing get requests with data</title>" );
	      out.println( "</head>" );

	      // body section of document
	      out.println( "<body>" );
	      out.println( "<h1>Hello " + userName + "- Password is " + password + ",<br />" );
	      out.println( "Welcome to Servlets!</h1>" );
	      out.println( "</body>" );

	      // end XHTML document
	      out.println( "</html>" );
	      out.close();  // close stream to complete the page
	}

}
