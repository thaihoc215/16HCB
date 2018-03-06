import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class PostGet extends HttpServlet
{
    public void doGet(HttpServletRequest req,
                      HttpServletResponse res) throws IOException, ServletException
    {
        String strName;

        res.setContentType("text/html");
        PrintWriter out = res.getWriter();

        strName = req.getParameter("txtName");

        out.println("<html>");
        out.println("<head>");
        out.println("<title>Handle POST/GET requests</title>");
        out.println("</head>");
        out.println("<body bgcolor=\"white\">");
        out.println("<h1>Handle POST/GET requests</h1>");
        out.println("<p>Hello " + strName + "!</p>");
        out.println("</body>");
        out.println("</html>");
    }
}



