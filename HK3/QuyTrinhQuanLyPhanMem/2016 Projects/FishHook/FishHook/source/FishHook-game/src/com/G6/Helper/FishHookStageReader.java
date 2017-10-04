package com.G6.Helper;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.util.ArrayList;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.files.FileHandle;
import com.badlogic.gdx.utils.XmlReader;
import com.badlogic.gdx.utils.XmlWriter;
import com.sun.xml.internal.txw2.output.XmlSerializer;

public class FishHookStageReader {
	XmlReader reader = new XmlReader();
	XmlReader.Element roofElement;

	public int numberStageUnlock;

	public ArrayList<StageInfo> listStage;

	public class Scene {
		public int index;
		public int numberApple;
	}

	public class StageInfo {

		public int index;
		public int numberSceneUnlock;
		public ArrayList<Scene> listScene;

		public StageInfo() {
			this.listScene = new ArrayList<Scene>();
		}

		public void AddScene(Scene obj) {
			this.listScene.add(obj);
		}

		public Scene GetObject(int i) {
			return listScene.get(i);
		}
	}

	public void Load(FileHandle file) {

		try {
			roofElement = reader.parse(file);
			numberStageUnlock = Integer.parseInt(GetNodeValue(roofElement,
					"nStageUnlock"));
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	public XmlReader.Element GetNode(String tagnode) {
		XmlReader.Element ret;
		ret = roofElement.getChildByName(tagnode);
		return ret;
	}

	public String GetNodeValue(XmlReader.Element element, String attribute) {
		return element.getAttribute(attribute);
	}

	/*
	 * void writeExternal(String filePath) { FileHandle fileHandle =
	 * Gdx.files.external(filePath); OutputStream out=null; try {
	 * 
	 * out=fileHandle.write(false); XmlSerializer xmlSerializer =
	 * Xml.newSerializer(); StringWriter writer = new StringWriter();
	 * xmlSerializer.setOutput(writer);
	 * xmlSerializer.startDocument("UTF-8",true); xmlSerializer.startTag(null,
	 * "userData"); xmlSerializer.startTag(null, "userName");
	 * xmlSerializer.text(username_String_Here);
	 * xmlSerializer.endTag(null,"userName");
	 * xmlSerializer.startTag(null,"password");
	 * xmlSerializer.text(password_String); xmlSerializer.endTag(null,
	 * "password"); xmlSerializer.endTag(null, "userData");
	 * xmlSerializer.endDocument(); xmlSerializer.flush(); String
	 * dataWrite=writer.toString(); fileos.write(dataWrite.getBytes());
	 * fileos.close(); } catch (FileNotFoundException e) { // TODO
	 * Auto-generated catch block e.printStackTrace(); } catch
	 * (IllegalArgumentException e) { // TODO Auto-generated catch block
	 * e.printStackTrace(); } catch (IllegalStateException e) { // TODO
	 * Auto-generated catch block e.printStackTrace(); } catch (IOException e) {
	 * // TODO Auto-generated catch block e.printStackTrace(); } }
	 */

	void saveExternal(XmlReader.Element element) {
		FileHandle fileExternal = Gdx.files.external("stage.xml");
		OutputStream out = null;
		try {
			String s = element.toString();
			out = fileExternal.write(false);
			out.write(s.getBytes());
			out.close();
		} catch (Exception ex) {
			if (out == null)
				try {
					out.close();
				} catch (Exception e) {
				}
		}
	}

	void CloneFileInExternal() {
		FileHandle fileInternal=Gdx.files.internal("StageInfo/stage.xml");
		Load(fileInternal);
		
		FileHandle fileExternal = Gdx.files.external("stage.xml");
		if (!fileExternal.exists()) {
			OutputStream out = null;
			try {
				String s = roofElement.toString();
				out = fileExternal.write(false);
				out.write(s.getBytes());
				out.close();
			} catch (Exception ex) {
				if (out == null)
					try {
						out.close();
					} catch (Exception e) {
					}
			}
		}
	}

	public void SetNodeValue(XmlReader.Element element, String nameAtt,
			String attribute) {
		element.setAttribute(nameAtt, attribute);
	}


	public void LoadFile(String path) {
		CloneFileInExternal();
		Load(Gdx.files.external(path));
		
		listStage = new ArrayList<FishHookStageReader.StageInfo>();
		//
		for (XmlReader.Element stage : roofElement
				.getChildrenByNameRecursively("stage")) {
			String sss = stage.toString();
			StageInfo st = new StageInfo();
			st.index = Integer.parseInt(GetNodeValue(stage, "index"));
			st.numberSceneUnlock = Integer.parseInt(GetNodeValue(stage,
					"nSceneUnlock"));
			for (XmlReader.Element sc : stage.getChildrenByName("scene")) {

				Scene s = new Scene();
				s.index = Integer.parseInt(GetNodeValue(sc, "index"));
				s.numberApple = Integer.parseInt(GetNodeValue(sc, "nApple"));
				st.AddScene(s);
			}
			listStage.add(st);
		}

	}

	public int Get_nStageUnlock()
	{
		int result;
		result=Integer.parseInt(GetNodeValue(roofElement, "nStageUnlock"));
		return result;
	}
	
	public int Get_nSceneUnlock(int indexStage)
	{
		int result=-1;
		for (XmlReader.Element stage : roofElement
				.getChildrenByNameRecursively("stage")) {

			int idx = Integer.parseInt(GetNodeValue(stage, "index"));

			if (idx == indexStage) {
				result=Integer.parseInt(GetNodeValue(stage,"nSceneUnlock"));
				return result;
			}
		}
		return result;
	}
	
	public int Get_NumberApple(int indexStage, int indexScene)
	{
		int result=-1;
		for (XmlReader.Element stage : roofElement
				.getChildrenByNameRecursively("stage")) {

			int idx = Integer.parseInt(GetNodeValue(stage, "index"));
			if (idx == indexStage) {
				for (XmlReader.Element sc : stage.getChildrenByName("scene")) {

					int i = Integer.parseInt(GetNodeValue(sc, "index"));
					if (i == indexScene) {
						result=Integer.parseInt(GetNodeValue(sc,"nApple"));
						return result;
					}
				}
			}
		}
		return result;
	}

	public void Change_nStageUnlock(int value) {
		SetNodeValue(roofElement, "nStageUnlock", value + "");
		saveExternal(roofElement);
	}

	public void Change_nSceneUnlock(int indexStage, int value) {
		for (XmlReader.Element stage : roofElement
				.getChildrenByNameRecursively("stage")) {

			int idx = Integer.parseInt(GetNodeValue(stage, "index"));

			if (idx == indexStage) {
				SetNodeValue(stage, "nSceneUnlock", value + "");
				saveExternal(roofElement);
				continue;
			}
		}
	}

	public void ChangeValue(int indexStage, int indexScene, int nApple) {

		for (XmlReader.Element stage : roofElement
				.getChildrenByNameRecursively("stage")) {

			int idx = Integer.parseInt(GetNodeValue(stage, "index"));
			if (idx == indexStage) {
				for (XmlReader.Element sc : stage.getChildrenByName("scene")) {

					int i = Integer.parseInt(GetNodeValue(sc, "index"));
					if (i == indexScene) {
						SetNodeValue(sc, "nApple", nApple + "");
						saveExternal(roofElement);
						return;
					}
				}
			}
		}
	}
}
