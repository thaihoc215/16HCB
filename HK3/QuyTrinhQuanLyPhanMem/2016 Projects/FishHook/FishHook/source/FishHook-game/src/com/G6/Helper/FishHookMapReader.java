package com.G6.Helper;

import java.io.IOException;
import java.util.ArrayList;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.files.FileHandle;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Array;
import com.badlogic.gdx.utils.XmlReader;

/**
 * Lop dung de doc map
 * @author Tha^n
 *
 */
public class FishHookMapReader {

	/**
	 * doi tuong reader
	 */
	XmlReader reader = new XmlReader();
	
	/**
	 * element goc trong file xml
	 */
	XmlReader.Element roofElement;
    
	/**
	 * Danh sach cac map
	 */
    public ArrayList<MapInfo> listMap;

    /**
     * Lop luu nhung thong tin cua map
     * @author Tha^n
     *
     */
    public class MapInfo {

    	/**
    	 * level cua map
    	 */
        public String level;
        
        /**
         * so luong object
         */
        public int count;
        
        /**
         * tat ca cac object cua map
         */
        public ArrayList<ObjectInfo> listObject;

        /**
         * Ham khoi tao mapInfo
         */
        public MapInfo() {
            this.listObject = new ArrayList<FishHookMapReader.ObjectInfo>();
            count = 0;
        }

        /**
         * Add 1 object vao listObject
         * @param obj
         */
        public void AddObject(ObjectInfo obj) {
            this.listObject.add(obj);
            count = listObject.size();
        }

        /**
         * lay ra 1 object
         * @param i object co index i
         * @return objectinfo
         */
        public ObjectInfo GetObject(int i) {
            return listObject.get(i);
        }
    }

    /**
     * ten cua cac object
     * @author Tha^n
     *
     */
    public enum ObjectName {

        Apple,
        Turtle,
        Seesaw,
        Target,
        Player,
        Bubble
    }

    /**
     * Thong tin cua object
     * @author Tha^n
     *
     */
    public class ObjectInfo {

        public String name;
        public Vector2 cood;
        public int angle;
        public ObjectName objName;
    }


    /**
     * Load file map (xml)
     * @param file file map
     */
    public void Load(FileHandle file) {
    	
    	try {
			roofElement = reader.parse(file);
		} catch (IOException e) {
			e.printStackTrace();
		}
    }

    /**
     * lay 1 node dua vao tagnode
     * @param tagnode tagnode can lay
     * @return node muon lay
     */
    public XmlReader.Element GetNode(String tagnode) {
    	XmlReader.Element ret;
    	ret = roofElement.getChildByName(tagnode);
    	return ret;
    }

    /**
     * Lay danh sach nhung node dua vao tagnode
     * @param tagnode
     * @return
     */
    public Array<XmlReader.Element> GetNodeList(String tagnode) {
    	Array<XmlReader.Element> nodeList;
    	nodeList = roofElement.getChildrenByNameRecursively(tagnode);
    	return nodeList;
    }

    /**
     * lay abtribute cua node
     * @param element node
     * @param attribute abtribute
     * @return
     */
    public String GetNodeValue(XmlReader.Element element, String attribute) {
    	return element.getAttribute(attribute);
    }

    /**
     * Load file config va load map
     * @param path
     */
    public void LoadConfig(String path) {
    	 Load(Gdx.files.internal(path));
    	 String mapPath = GetNodeValue(roofElement, "mappath");
    	 FileHandle file = Gdx.files.internal(mapPath);
    	 listMap = new ArrayList<FishHookMapReader.MapInfo>();
    	 for(FileHandle f : file.list())
    	 {
    		 Load(f);
    		 MapInfo map = new MapInfo();
    		 map.level = GetNodeValue(roofElement, "MapName");
    		 Array<XmlReader.Element> listobj = GetNodeList("Object");
    		 for(int i = 0; i < listobj.size; i++)
    		 {
    			   XmlReader.Element e = listobj.get(i);
	               ObjectInfo objinfo = new ObjectInfo();
	               objinfo.name = GetNodeValue(e, "name");
	               objinfo.cood = new Vector2(Integer.parseInt(GetNodeValue(e, "cood").split(",")[0]), 480 - Integer.parseInt(GetNodeValue(e, "cood").split(",")[1]));
	               objinfo.angle = Integer.parseInt(GetNodeValue(e, "angle"));
	               
	               if(objinfo.name.equals("character_bubble_1-1.png"))
	               {
	               	objinfo.objName = ObjectName.Player;
	               } else if(objinfo.name.equals("apple-1.png"))
	               {
	               	objinfo.objName = ObjectName.Apple;
	               } else if(objinfo.name.equals("seesaw-1.png"))
	               {
	               	objinfo.objName = ObjectName.Seesaw;
	               } else if(objinfo.name.equals("target-1.png"))
	               {
	               	objinfo.objName = ObjectName.Target;
	               } else if(objinfo.name.equals("turtle-1.png"))
	               {
	               	objinfo.objName = ObjectName.Turtle;
	               } else if(objinfo.name.equals("bubble-1.png"))
	               {
	            	   objinfo.objName = ObjectName.Bubble;
	               }
	               map.AddObject(objinfo);
    		 }
    		 listMap.add(map);
    	 }
    }
    
    /**
     * them mot map
     * @param map
     */
    public void AddMap(MapInfo map)
    {
        listMap.add(map);
        
    }
    
    /**
     * Lay mot map
     * @param i
     * @return
     */
    public MapInfo GetMap(int i)
    {
        return listMap.get(i);
    }
}
