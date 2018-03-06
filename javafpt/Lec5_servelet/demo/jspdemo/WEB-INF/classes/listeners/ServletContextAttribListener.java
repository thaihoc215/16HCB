package listeners;


import javax.servlet.ServletContext;
import javax.servlet.ServletContextAttributeEvent;
import javax.servlet.ServletContextAttributeListener;
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;


public class ServletContextAttribListener
    implements ServletContextAttributeListener {


  //This method is invoked when an attribute
  //is added to the ServletContext object
  public void attributeAdded (ServletContextAttributeEvent scab)
  {
    System.out.println("An attribute was added to the " +
      "ServletContext object");
  }

  //This method is invoked when an attribute
  //is removed from the ServletContext object
  public void attributeRemoved (ServletContextAttributeEvent scab)
  {
    System.out.println("An attribute was removed from " +
      "the ServletContext object");
  }

  //This method is invoked when an attribute
  //is replaced in the ServletContext object
  public void attributeReplaced (ServletContextAttributeEvent scab)
  {
    System.out.println("An attribute was replaced in the " +
      "ServletContext object");
  }

}

