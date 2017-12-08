package jp.co.enecom.sql;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.List;
import java.util.Properties;

import org.apache.commons.dbutils.DbUtils;
import org.apache.commons.dbutils.QueryRunner;
import org.apache.commons.dbutils.handlers.BeanListHandler;

import jp.co.enecom.ma_tanaka.io.ResourceLoadUtils;
import jp.co.enecom.model.DivisionModel;
import jp.co.enecom.model.PersonModel;
import jp.co.enecom.model.ProjectModel;
import jp.co.enecom.model.ProjectModelResponse;
import jp.co.enecom.ws.ProjectManagementWs;

public class ProjectSql {
	
   private String url;
   private String usr;
   private String pwd;    
   private final String DIVISION_KIND_CODE = "1";
   private QueryRunner run = new QueryRunner();  
   
   private final String SQL_SCHEDULE_SELECT = 
		   "SELECT "
                + "sch.work_number, sch.work_content, div.division_name, sch.classification, per.person_id, sch.planning_man_hours, " 
		        + "sch.planning_volume, sch.planning_start_date, sch.planning_end_date, sch.progress_rate, sch.actual_volume, sch.actual_start_date, sch.actual_end_date"
		        + ", sch.actual_man_hours, sch.cumulative_man_hours, sch.remarks, sch.sequence_number, sch.project_id, sch.hierarchy_number "
		   + "FROM "
          	    + "r_schedule as sch " 
		   + "LEFT JOIN " 
          	    + "tb_division div ON div.division_kind_code = '" + DIVISION_KIND_CODE + "' AND div.division_code = sch.kbn " 
		   + "LEFT JOIN "
          	    + "r_person per ON per.person_id = sch.person_id " 
		   + "WHERE " 
          	    + "sch.project_id = ? "
           + "ORDER BY "
           		+ "sch.work_number"
		   ;
   
   private final String SQL_PROJECTS = 
		   "SELECT "
                + "project_id, project_name "
           + "FROM "
                + "r_project "
           ;
   
   private final String SQL_SCHEDULE_INSERT = 
		   "INSERT INTO "
				+ "r_schedule "
				+ "(project_id, work_number, hierarchy_number, work_content, classification, person_id, planning_man_hours, planning_volume, "
		   		+ "planning_start_date, planning_end_date, progress_rate, actual_volume, actual_start_date, actual_end_date, actual_man_hours, "
		   		+ "cumulative_man_hours, remarks, kbn) "
		   + "VALUES ( "
		   		+ "?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,? " //21 parameter
		   + ") "
		   ;
   
   private final String SQL_SCHEDULE_UPDATE =
		   "UPDATE "
				+ "r_schedule "
			+ "SET "
				+ "project_id = ? AND work_number = ? AND hierarchy_number = ? AND work_content = ? AND classification = ?"
				+ "AND person_id = ? AND planning_man_hours = ? AND planning_volume = ? AND planning_start_date = ? AND planning_end_date = ? "
				+ "AND progress_rate = ? AND actual_volume = ? AND actual_start_date = ? AND actual_end_date = ? AND actual_man_hours = ? "
				+ "AND cumulative_man_hours = ? AND remarks = ? AND kbn = ? "
			+ "WHERE "
				+ "sequence_number = ?"
				+ "AND project_id = ?"
			;
		   
   private final String SQL_SCHEDULE_DELETE =
		   "DELETE FROM "
		   		+ "r_schedule "
		   + "WHERE "
				+ "sequence_number = ?"
				+ "AND project_id = ?"
			;
   
   private final String SQL_DIVISION_SELECT =
		   "SELECT "
				+ "division_kind_code, "
				+ "division_code, "
				+ "division_name "
		   + "FROM "
		   		+ "tb_division "
		   + "WHERE "
		   		+ "division_kind_code = ?"
		   ;
   
   private final String SQL_PERSON_SELECT =
		   "SELECT "
				+ "person_id, "
				+ "person_name "
		   + "FROM "
		   		+ "r_person "
		   ;
   
   public ProjectSql() {
	   try {
		   Properties props = ResourceLoadUtils.loadProperties(ProjectSql.class, "/dbcp.properties");
		   DbUtils.loadDriver(props.getProperty("driverClassName"));
		   url = props.getProperty("url");
		   usr = props.getProperty("username");
		   pwd = props.getProperty("password");
	   }catch(Exception e) {		   
		   ProjectManagementWs._log.info("Exception: " + e.getMessage());
	   }
   }

   /**
    * Get data of schedule table
    * @param projectId
    * @return data of schedule table
    * @throws SQLException
    */
   public List<ProjectModelResponse> getDataOfProjectId(String projectId) throws SQLException {
	   Connection conn = null;    	   
	   try {
    	   conn = getConnection();
    	   return run.query(conn, SQL_SCHEDULE_SELECT,
    			   new BeanListHandler<ProjectModelResponse>(ProjectModelResponse.class), projectId);
	   }finally {
		   DbUtils.close(conn);
	   }
   }
   
   /**
    * Get data of division table
    * @param divisionKindCode
    * @return data of division table
    * @throws SQLException
    */
   public List<DivisionModel> getDivisions(String divisionKindCode) throws SQLException {
	   Connection conn = null;    	   
	   try {
    	   conn = getConnection();
    	   return run.query(conn, SQL_DIVISION_SELECT,
    			   new BeanListHandler<DivisionModel>(DivisionModel.class), divisionKindCode);
	   }finally {
		   DbUtils.close(conn);
	   }
   }
   
   /**
    * Get data of person table
    * @return data of person table
    * @throws SQLException
    */
   public List<PersonModel> getPersons() throws SQLException {
	   Connection conn = null;    	   
	   try {
    	   conn = getConnection();
    	   return run.query(conn, SQL_PERSON_SELECT,
    			   new BeanListHandler<PersonModel>(PersonModel.class));
	   }finally {
		   DbUtils.close(conn);
	   }
   }
   
   /**
    * Get all data of project table
    * @return All data of project table
    * @throws SQLException
    */
   public List<ProjectModel> getProjects() throws SQLException {
	   Connection conn = null;    	   
	   try {
    	   conn = getConnection();
    	   return run.query(conn, SQL_PROJECTS,
    			   new BeanListHandler<ProjectModel>(ProjectModel.class));
	   }finally {
		   DbUtils.close(conn);
	   }
   }

   /**
    * Insert record into schedule table
    * @param model ProjectResultModel
    * @return number inserted record
    * @throws SQLException
    */
   public int insert(ProjectModelResponse model) throws SQLException {
	   Connection conn = null;    	   
	   try {
    	   conn = getConnection();
    	   return run.update(conn, SQL_SCHEDULE_INSERT, model.getProject_id(), model.getWork_number(), model.getHierarchy_number(), model.getWork_content()
    			   ,model.getClassification(), model.getPerson_id(), model.getPlanning_man_hours(), model.getPlanning_volume(), model.getPlanning_start_date()
    			   , model.getPlanning_end_date(), model.getProgress_rate(), model.getActual_volumn(), model.getActual_start_date(), model.getActual_end_date()
    			   , model.getActual_man_hours(), model.getCumulative_man_hours(), model.getRemarks(), model.getKbn()
    			   );
    	  
	   }finally {
		   DbUtils.close(conn);
	   }
	}
   
   /**
    * Update record of schedule table
    * @param model ProjectResultModel
    * @return number updated record
    * @throws SQLException
    */
   public int update(ProjectModelResponse model) throws SQLException {
	   Connection conn = null;    	   
	   try {
    	   conn = getConnection();
    	   return run.update(conn, SQL_SCHEDULE_UPDATE, model.getWork_number(), model.getHierarchy_number(), model.getWork_content()
    			   ,model.getClassification(), model.getPerson_id(), model.getPlanning_man_hours(), model.getPlanning_volume(), model.getPlanning_start_date()
    			   , model.getPlanning_end_date(), model.getProgress_rate(), model.getActual_volumn(), model.getActual_start_date(), model.getActual_end_date()
    			   , model.getActual_man_hours(), model.getCumulative_man_hours(), model.getRemarks(), model.getKbn()
    			   , model.getSequence_number(), model.getProject_id());
    	  
	   }finally {
		   DbUtils.close(conn);
	   }
	}
   
   /**
    * Delete record of schedule table
    * @param model ProjectResultModel
    * @return number deleted record
    * @throws SQLException
    */
   public int delete(ProjectModelResponse model) throws SQLException {
	   Connection conn = null;    	   
	   try {
    	   conn = getConnection();
    	   return run.update(conn, SQL_SCHEDULE_DELETE, model.getSequence_number(), model.getProject_id());	    	  
	   }finally {
		   DbUtils.close(conn);
	   }
	}
   
   private Connection getConnection() throws SQLException {	
	   return DriverManager.getConnection(url, usr, pwd);
   }
   
}
