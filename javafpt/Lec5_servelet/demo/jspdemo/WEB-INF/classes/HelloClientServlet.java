import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class HelloClientServlet extends HttpServlet
{
  protected void doGet(HttpServletRequest req,
                       HttpServletResponse res)
            throws ServletException, IOException
  {
    res.setContentType("text/html");
    PrintWriter out = res.getWriter();
    out.println("<HTML><HEAD><TITLE>Hello Kien Client!</TITLE>"+
		"</HEAD><BODY>Hello Client!</BODY></HTML>");
    out.close();
  }

  public String getServletInfo()
  {
    return "HelloClientServlet 1.0 by Stefan Zeiger";
  }
}
