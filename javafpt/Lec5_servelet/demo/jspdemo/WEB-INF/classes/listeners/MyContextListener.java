package listeners;

import javax.servlet.ServletContext;
import javax.servlet.ServletContextAttributeEvent;
import javax.servlet.ServletContextAttributeListener;
import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

public final class MyContextListener implements ServletContextListener {

  private ServletContext context = null;

  public MyContextListener() {}

  //This method is invoked when the Web Application
  //has been removed and is no longer able to accept
  //requests

  public void contextDestroyed(ServletContextEvent event)
  {

    //Output a simple message to the server's console
    System.out.println("The Simple Web App. Has Been Removed");
    this.context = null;

  }


  //This method is invoked when the Web Application
  //is ready to service requests

  public void contextInitialized(ServletContextEvent event)
  {
    this.context = event.getServletContext();

    //Output a simple message to the server's console
    System.out.println("The Simple Web App. Is Ready");

  }
}

