package jp.co.enecom.ws;

import java.io.File;
import java.util.List;
import java.util.Properties;
import java.util.logging.Logger;

import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import org.apache.commons.io.FilenameUtils;

import jp.co.enecom.ma_tanaka.io.ResourceLoadUtils;
import jp.co.enecom.ma_tanaka.util.LoggerFactory;
import jp.co.enecom.model.DivisionModel;
import jp.co.enecom.model.PersonModel;
import jp.co.enecom.model.ProjectModel;
import jp.co.enecom.model.ProjectModelRequest;
import jp.co.enecom.model.ProjectModelResponse;
import jp.co.enecom.sql.ProjectSql;

@Path("/ws")
public class ProjectManagementWs {

	public static Logger _log = getLogger();
	
	@GET
	@Path("/projects")
	@Produces(MediaType.APPLICATION_JSON)
    public Response projects() throws Exception
    {		
		_log.info("Thuc hien lay danh sach project");
		List<ProjectModel> result =null;
		
		try {
			ProjectSql projectSql = new ProjectSql();			
			result = projectSql.getProjects();			
			
		} catch (Exception e) {
			_log.info("Exception: " + e.getMessage());
		}
		return Response.ok(result).header("Access-Control-Allow-Origin", "*").build();
    }	
	
	@GET
	@Path("/persons")
	@Produces(MediaType.APPLICATION_JSON)
    public Response persons() throws Exception
    {		
		_log.info("Thuc hien lay danh sach nguoi phu trach");
		List<PersonModel> result =null;
		
		try {
			ProjectSql projectSql = new ProjectSql();			
			result = projectSql.getPersons();			
			
		} catch (Exception e) {
			_log.info("Exception: " + e.getMessage());
		}
		return Response.ok(result).header("Access-Control-Allow-Origin", "*").build();
    }	
	
	@GET
	@Path("/divisions")
	@Produces(MediaType.APPLICATION_JSON)
    public Response division(@QueryParam("divisionKindCode") String divisionKindCode) throws Exception
    {		
		_log.info("Thuc hien lay danh sach 区分");
		List<DivisionModel> result =null;	
		
		try {
			ProjectSql projectSql = new ProjectSql();			
			result = projectSql.getDivisions(divisionKindCode);			
			
		} catch (Exception e) {
			_log.info("Exception: " + e.getMessage());
		}
		return Response.ok(result).header("Access-Control-Allow-Origin", "*").build();
    }	
	
	@GET
	@Path("/schedules")
	@Produces(MediaType.APPLICATION_JSON)
    public Response schedules(@QueryParam("projectId") String projectId) throws Exception
    {		
		_log.info("Thuc hien lay danh sach スケジュール");
		List<ProjectModelResponse> result = null;
		
		try {
			ProjectSql projectSql = new ProjectSql();
			result = projectSql.getDataOfProjectId(projectId);
		} catch (Exception e) {
			_log.info("Exception: " + e.getMessage());
		}
		return Response.ok(result).header("Access-Control-Allow-Origin", "*").build();
    }
	
	@POST
	@Path("/save")
	@Consumes(MediaType.APPLICATION_JSON)
	public Response save(ProjectModelRequest[][] recordArrGroup)
	{			
		_log.info("----------------------Bat dau xu ly luu du lieu-------------------");
		ProjectSql projectSql = new ProjectSql();
		boolean errorFlg = false;
		
		for (ProjectModelRequest[] recordArr : recordArrGroup) {
			for (ProjectModelRequest record : recordArr) {
				try {		
					switch (record.status) {
					case "UPDATE":
						if(projectSql.update(record.row) <= 0) {
							errorFlg = true;
							_log.info("Doi tuong project_id: [" + record.row.getProject_id() + "] va sequence_number ["+ record.row.getSequence_number() +"] cap nhat that bai" );
						}else
							_log.info("Doi tuong project_id: [" + record.row.getProject_id() + "] va sequence_number ["+ record.row.getSequence_number() +"] cap nhat thanh cong" );
						break;
					case "INSERT":
						if(projectSql.insert(record.row) <= 0) {
							errorFlg = true;
							_log.info("Doi tuong project_id: [" + record.row.getProject_id() + "] va sequence_number ["+ record.row.getSequence_number() +"] them moi that bai" );
						}else
							_log.info("Doi tuong project_id: [" + record.row.getProject_id() + "] va sequence_number ["+ record.row.getSequence_number() +"] them moi thanh cong" );
						break;
					case "DELETE":
						if(projectSql.delete(record.row) <= 0) {
							errorFlg = true;
							_log.info("Doi tuong project_id: [" + record.row.getProject_id() + "] va sequence_number ["+ record.row.getSequence_number() +"] xoa that bai" );
						}else
							_log.info("Doi tuong project_id: [" + record.row.getProject_id() + "] va sequence_number ["+ record.row.getSequence_number() +"] xoa thanh cong" );
						break;
					default:
						break;
					}
				} catch (Exception e) {
					_log.info("Exception: " + e.getMessage());
					errorFlg = true;
					continue;
				}
			}
		}
		_log.info("----------------------Ket thuc xu ly luu du lieu-------------------");
		if(errorFlg)
			return Response.status(Status.INTERNAL_SERVER_ERROR).header("Access-Control-Allow-Origin", "*").build();
		else {
			return Response.status(Status.OK).header("Access-Control-Allow-Origin", "*").build();
		}
	}	
	
	private static Logger getLogger(){		
		try {
			if(_log != null)
				return _log;
			
			Properties props = ResourceLoadUtils.loadProperties(ProjectManagementWs.class, "/javalog.properties");    		
			String filePath = FilenameUtils
					.getPathNoEndSeparator(props.getProperty("java.util.logging.FileHandler.pattern"));
			filePath = filePath.replace("%h", System.getProperty("user.home"));
			filePath = filePath.replace("%t", System.getProperty("java.io.tmpdir"));	
			File dir = new File(filePath);
			
	        if (!dir.exists() ) {
	        	dir.mkdirs();
	        }	        
	        
	        return LoggerFactory.getLogger("logger");
	       
		}catch(Exception e) {
			e.printStackTrace();
		}
		return null;
	}		
	
}
