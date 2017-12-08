package jp.co.enecom.model;

public class ProjectModelResponse {

	/**
	 * 作業番号
	 */
	private String work_number;
	
	/**
	 * 作業内容
	 */
	private String work_content;
	
	/**
	 * 分類
	 */
	private String classification;
	
	/**
	 * 担当者ID
	 */
	private String person_id;
	
	/**
	 * 計画工数
	 */
	private int planning_man_hours;
	
	/**
	 * 出来高（予定）
	 */
	private int planning_volume;
	
	/**
	 * 開始日（予定）
	 */
	private String planning_start_date;
	
	/**
	 * 終了日（予定）
	 */
	private String planning_end_date;
	
	/**
	 * 進捗率
	 */
	private int progress_rate;
	
	/**
	 * 出来高（実績）
	 */
	private int actual_volumn;
	
	/**
	 * 開始日（実績）
	 */
	private String actual_start_date;
	
	/**
	 * 終了日（実績）
	 */
	private String actual_end_date;
	
	/**
	 * 実績工数
	 */
	private int actual_man_hours;
	
	/**
	 * 累積工数
	 */
	private int cumulative_man_hours;
	
	/**
	 * 備考
	 */
	private String remarks;
	
	/**
	 * シーケンス番号
	 */
	private int sequence_number;

	/**
	 * プロジェクトID
	 */
	private String project_id;
	
	/**
	 * 階層番号
	 */
	private int hierarchy_number;
	
	/**
	 * 区分
	 */
	private String kbn;
	
	
	
	/**
	 * @return the kbn
	 */
	public String getKbn() {
		return kbn;
	}

	/**
	 * @param kbn the kbn to set
	 */
	public void setKbn(String kbn) {
		this.kbn = kbn;
	}

	/**
	 * @return the hierarchy_number
	 */
	public int getHierarchy_number() {
		return hierarchy_number;
	}

	/**
	 * @param hierarchy_number the hierarchy_number to set
	 */
	public void setHierarchy_number(int hierarchy_number) {
		this.hierarchy_number = hierarchy_number;
	}

	/**
	 * @return the project_id
	 */
	public String getProject_id() {
		return project_id;
	}

	/**
	 * @param project_id the project_id to set
	 */
	public void setProject_id(String project_id) {
		this.project_id = project_id;
	}

	/**
	 * @return the work_number
	 */
	public String getWork_number() {
		return work_number;
	}

	/**
	 * @param work_number the work_number to set
	 */
	public void setWork_number(String work_number) {
		this.work_number = work_number;
	}

	/**
	 * @return the work_content
	 */
	public String getWork_content() {
		return work_content;
	}

	/**
	 * @return the sequence_number
	 */
	public int getSequence_number() {
		return sequence_number;
	}

	/**
	 * @param sequence_number the sequence_number to set
	 */
	public void setSequence_number(int sequence_number) {
		this.sequence_number = sequence_number;
	}

	/**
	 * @param work_content the work_content to set
	 */
	public void setWork_content(String work_content) {
		this.work_content = work_content;
	}

	/**
	 * @return the classification
	 */
	public String getClassification() {
		return classification;
	}

	/**
	 * @param classification the classification to set
	 */
	public void setClassification(String classification) {
		this.classification = classification;
	}
	
	/**
	 * @return the person_id
	 */
	public String getPerson_id() {
		return person_id;
	}

	/**
	 * @param person_id the person_id to set
	 */
	public void setPerson_id(String person_id) {
		this.person_id = person_id;
	}

	/**
	 * @return the planning_man_hours
	 */
	public int getPlanning_man_hours() {
		return planning_man_hours;
	}

	/**
	 * @param planning_man_hours the planning_man_hours to set
	 */
	public void setPlanning_man_hours(int planning_man_hours) {
		this.planning_man_hours = planning_man_hours;
	}

	/**
	 * @return the planning_volume
	 */
	public int getPlanning_volume() {
		return planning_volume;
	}

	/**
	 * @param planning_volume the planning_volume to set
	 */
	public void setPlanning_volume(int planning_volume) {
		this.planning_volume = planning_volume;
	}

	/**
	 * @return the planning_start_date
	 */
	public String getPlanning_start_date() {
		return planning_start_date;
	}

	/**
	 * @param planning_start_date the planning_start_date to set
	 */
	public void setPlanning_start_date(String planning_start_date) {
		this.planning_start_date = planning_start_date;
	}

	/**
	 * @return the planning_end_date
	 */
	public String getPlanning_end_date() {
		return planning_end_date;
	}

	/**
	 * @param planning_end_date the planning_end_date to set
	 */
	public void setPlanning_end_date(String planning_end_date) {
		this.planning_end_date = planning_end_date;
	}

	/**
	 * @return the progress_rate
	 */
	public int getProgress_rate() {
		return progress_rate;
	}

	/**
	 * @param progress_rate the progress_rate to set
	 */
	public void setProgress_rate(int progress_rate) {
		this.progress_rate = progress_rate;
	}

	/**
	 * @return the actual_volumn
	 */
	public int getActual_volumn() {
		return actual_volumn;
	}

	/**
	 * @param actual_volumn the actual_volumn to set
	 */
	public void setActual_volumn(int actual_volumn) {
		this.actual_volumn = actual_volumn;
	}

	/**
	 * @return the actual_start_date
	 */
	public String getActual_start_date() {
		return actual_start_date;
	}

	/**
	 * @param actual_start_date the actual_start_date to set
	 */
	public void setActual_start_date(String actual_start_date) {
		this.actual_start_date = actual_start_date;
	}

	/**
	 * @return the actual_end_date
	 */
	public String getActual_end_date() {
		return actual_end_date;
	}

	/**
	 * @param actual_end_date the actual_end_date to set
	 */
	public void setActual_end_date(String actual_end_date) {
		this.actual_end_date = actual_end_date;
	}

	/**
	 * @return the actual_man_hours
	 */
	public int getActual_man_hours() {
		return actual_man_hours;
	}

	/**
	 * @param actual_man_hours the actual_man_hours to set
	 */
	public void setActual_man_hours(int actual_man_hours) {
		this.actual_man_hours = actual_man_hours;
	}

	/**
	 * @return the cumulative_man_hours
	 */
	public int getCumulative_man_hours() {
		return cumulative_man_hours;
	}

	/**
	 * @param cumulative_man_hours the cumulative_man_hours to set
	 */
	public void setCumulative_man_hours(int cumulative_man_hours) {
		this.cumulative_man_hours = cumulative_man_hours;
	}

	/**
	 * @return the remarks
	 */
	public String getRemarks() {
		return remarks;
	}

	/**
	 * @param remarks the remarks to set
	 */
	public void setRemarks(String remarks) {
		this.remarks = remarks;
	}
	
}
