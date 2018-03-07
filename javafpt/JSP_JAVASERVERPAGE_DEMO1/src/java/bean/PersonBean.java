package java.bean;

import java.io.Serializable;

public class PersonBean implements Serializable
{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String _firstName = null;
	private String _lastName = null;
	private int age = 0;
	/**
	 * @return the _firstName
	 */
	public String get_firstName() {
		return _firstName;
	}
	/**
	 * @param _firstName the _firstName to set
	 */
	public void set_firstName(String _firstName) {
		this._firstName = _firstName;
	}
	/**
	 * @return the _lastName
	 */
	public String get_lastName() {
		return _lastName;
	}
	/**
	 * @param _lastName the _lastName to set
	 */
	public void set_lastName(String _lastName) {
		this._lastName = _lastName;
	}
	/**
	 * @return the age
	 */
	public int getAge() {
		return age;
	}
	/**
	 * @param age the age to set
	 */
	public void setAge(int age) {
		this.age = age;
	}
}