import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;
import java.util.*;
import java.net.*;

public class BannedAccessFilter implements Filter
{
  private HashSet bannedSiteTable;

  /** Deny access if the request comes from a banned site
   *  or is referred here by a banned site.
   */

  public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
                 throws ServletException, IOException {

    HttpServletRequest req = (HttpServletRequest)request;
    String requestingHost = req.getRemoteHost();
    String referringHost = getReferringHost(req.getHeader("Referer"));
    String bannedSite = null;
    boolean isBanned = false;

    if (bannedSiteTable.contains(requestingHost))
    {
      bannedSite = requestingHost;
      isBanned = true;
    }
    else if (bannedSiteTable.contains(referringHost))
    {
      bannedSite = referringHost;
      isBanned = true;
    }

    if (isBanned)
    {
      showWarning(response, bannedSite);
    }
    else
    {
      chain.doFilter(request,response);
    }
  }

  /** Create a table of banned sites based on initialization
   *  parameters . Remember that version 2.3 of the servlet
   *  API mandates the use of the Java 2 Platform. Thus,
   *  it is safe to use HashSet (which determines whether
   *  a given key exists) rather than the clumsier
   *  Hashtable (which has a value for each key).
   */

  public void init(FilterConfig config) throws ServletException
  {
    bannedSiteTable = new HashSet();
    String bannedSites = config.getInitParameter("bannedSites");

    // Default token set: white space.
    StringTokenizer tok = new StringTokenizer(bannedSites);
    while(tok.hasMoreTokens())
    {
      String bannedSite = tok.nextToken();
      bannedSiteTable.add(bannedSite);
      System.out.println("Banned " + bannedSite);
    }
  }

  public void destroy() {}

  private String getReferringHost(String refererringURLString)
  {
    try
    {
      URL referringURL = new URL(refererringURLString);
      return(referringURL.getHost());
      //return referringURL.toString();
    }
    catch(MalformedURLException mue) { // Malformed or null
      return(null);
    }
  }

  // Replacement response that is returned to users
  // who are from or referred here by a banned site.

  private void showWarning(ServletResponse response,String bannedSite)
                    throws ServletException, IOException
  {
    response.setContentType("text/html");
    PrintWriter out = response.getWriter();
    String docType = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 "
                     + "Transitional//EN\">\n";
    out.println
      (docType +
       "<HTML>\n" +
       "<HEAD><TITLE>Access Prohibited</TITLE></HEAD>\n" +
       "<BODY BGCOLOR=\"WHITE\">\n" +
       "<H1>Access Prohibited</H1>\n" +
       "Sorry, access from or via " + bannedSite + "\n" +
       "is not allowed.\n" +
       "</BODY></HTML>");
  }
}
