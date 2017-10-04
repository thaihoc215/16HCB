package com.xdpm.angrybirds.test;

import junit.framework.TestCase;

import com.xdpm.angrybirds.MainActivity;
import com.xdpm.angrybirds.gamelevel.GameLevel;
import com.xdpm.angrybirds.manager.ResourceManager;
import com.xdpm.angrybirds.utils.XMLLevelLoader;

public class XMLLevelLoaderTest extends TestCase {

	protected void setUp() throws Exception {
		super.setUp();
		MainActivity m = new MainActivity();
	}

	public void testXMLLevelLoader() {
		GameLevel gl = new GameLevel(1,1,1);
		XMLLevelLoader xml = new XMLLevelLoader(gl);
		assertNotNull(xml);
	}


}
