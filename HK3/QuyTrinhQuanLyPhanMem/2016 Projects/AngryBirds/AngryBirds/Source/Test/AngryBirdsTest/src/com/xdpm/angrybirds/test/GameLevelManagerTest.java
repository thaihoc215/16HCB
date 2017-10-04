package com.xdpm.angrybirds.test;

import com.xdpm.angrybirds.manager.GameLevelManager;

import junit.framework.TestCase;

public class GameLevelManagerTest extends TestCase {

	protected void setUp() throws Exception {
		super.setUp();
	}

	public void testGetInstance() {
		assertNotNull( GameLevelManager.getInstance());
	}

}
