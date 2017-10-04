package com.xdpm.angrybirds.test;

import com.xdpm.angrybirds.utils.GameUtils;

import junit.framework.TestCase;

public class TestGameUtils extends TestCase {

	public void testConvertDpToPixel() {
	
	GameUtils gameUtils = new GameUtils();
	String expected = "20";
	String actual = Float.toString(gameUtils.convertDpToPixel(10, null));
	
	assertEquals(expected, actual);
		
	}

	public void testConvertPixelsToDp() {
		GameUtils gameUtils = new GameUtils();
		String expected = "10";
		String actual = Float.toString(gameUtils.convertPixelsToDp(20, null));
		
		assertEquals(expected, actual);
	}

}
