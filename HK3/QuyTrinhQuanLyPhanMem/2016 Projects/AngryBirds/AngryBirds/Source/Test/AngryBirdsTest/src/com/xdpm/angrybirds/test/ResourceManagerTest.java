package com.xdpm.angrybirds.test;

import com.xdpm.angrybirds.MainActivity;
import com.xdpm.angrybirds.manager.ResourceManager;

import junit.framework.TestCase;

public class ResourceManagerTest extends TestCase {

	protected void setUp() throws Exception {
		super.setUp();

		MainActivity m = new MainActivity();
		ResourceManager.getInstance().setBaseGameActivity(m);
	}

	public void testGetInstance() {
		assertNotNull(ResourceManager.getInstance());
	}
	
	public void testGetBaseGameActivity()
	{
		assertNotNull(ResourceManager.getInstance().getBaseGameActivity());
	}
}
