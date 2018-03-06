// WelcomeTagHandler.java
// Custom tag handler that handles a simple tag.
package taglibs;

// Java core packages
import java.io.*;

// Java extension packages
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class WelcomeTagHandler extends TagSupport
{

   // Method called to begin tag processing
   public int doStartTag() throws JspException
   {
      // attempt tag processing
      try
      {
         // obtain JspWriter to output content
         JspWriter out = pageContext.getOut();

         // output content
         out.print( "Welcome to JSP Tag Libraries!" );
      }

      // rethrow IOException to JSP container as JspException
      catch( IOException ioException )
      {
         throw new JspException( ioException.getMessage() );
      }

      return SKIP_BODY;  // ignore the tag's body
   }
}
