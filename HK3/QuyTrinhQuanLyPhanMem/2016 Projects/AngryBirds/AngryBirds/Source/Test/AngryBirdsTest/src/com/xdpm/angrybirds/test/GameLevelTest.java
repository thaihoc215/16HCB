package com.xdpm.angrybirds.test;

import junit.framework.TestCase;

import com.xdpm.angrybirds.gamelevel.GameLevel;

public class GameLevelTest extends TestCase {

	protected void setUp() throws Exception {
		super.setUp();
	}

	public void testGameLevel() {
		GameLevel gl = new GameLevel(1,1,1);
		assertNotNull(gl);
	}

}
