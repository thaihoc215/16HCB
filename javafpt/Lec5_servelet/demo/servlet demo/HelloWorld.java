import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

/**
 * The simplest possible servlet.
 *
 * @author Kien NGUYEN TRUNG
 */

public class HelloWorld extends HttpServlet
{
    String m_sMsg;
    String m_sTitle;

    public void init(ServletConfig config)
    {
        m_sMsg = config.getInitParameter("msg");
        m_sTitle = config.getInitParameter("title");
    }

    public void doGet(HttpServletRequest request,
                      HttpServletResponse response) throws IOException, ServletException
    {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();

        out.println("<html>");
        out.println("<head>");
        out.println("<title>" + m_sTitle + "</title>");
        out.println("</head>");
        out.println("<body bgcolor=\"white\">");
        out.println("<h1>" + m_sTitle + "</h1>");
        out.println("<p>" + m_sMsg + "</p>");
        out.println("</body>");
        out.println("</html>");
    }
}



