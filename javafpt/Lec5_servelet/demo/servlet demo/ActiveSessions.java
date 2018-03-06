import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class ActiveSessions extends HttpServlet
{
    public void doGet(HttpServletRequest request,
                      HttpServletResponse response)
                  throws IOException, ServletException
    {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();

        out.println("<html>");
        out.println("<head>");
        out.println("<title>Active Sessions</title>");
        out.println("</head>");
        out.println("<body bgcolor=\"white\">");
        out.println("<p>Number of sessions currently in the memory: "
        			+ SessionCounter.getActiveSessions() + "</p>");
        out.println("</body>");
        out.println("</html>");
    }
}



