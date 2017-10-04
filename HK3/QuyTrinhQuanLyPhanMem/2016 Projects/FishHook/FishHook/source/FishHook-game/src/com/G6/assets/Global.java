package com.G6.assets;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.math.Vector2;

/**
 * Lop chua nhung hang so Global
 * @author Tha^n
 *
 */
public class Global {
	public static final float BOX_STEP = 1 / 45f;
	public static final int BOX_VELOCITY_ITERATIONS = 6;
	public static final int BOX_POSITION_ITERATIONS = 2;
	private static final int VIEWPORT_WIDTH = 800;
	private static final int VIEWPORT_HEIGHT = 480;
	
//	public static final float BOX_STEP = 1 / 120f;
//	public static final int BOX_VELOCITY_ITERATIONS = 8;
//	public static final int BOX_POSITION_ITERATIONS = 3;
	
	/**
	 * lay toa do cua chuot, ngon tay
	 * @return toa do chuot, ngon tay
	 */
	public static Vector2 getTouchPosition()
    {
    	Vector2 ret = new Vector2(Gdx.input.getX()*VIEWPORT_WIDTH/Gdx.graphics.getWidth(), 
    			VIEWPORT_HEIGHT - Gdx.input.getY()*VIEWPORT_HEIGHT/Gdx.graphics.getHeight());
    	return ret;
    }
	
	/**
	 * "ty le" doi tu don vi game sang box2d
	 */
	public static final float WORLD_TO_BOX = 0.01f;
	
	/**
	 * "ty le" doi tu don vi box2d sang game
	 */
	public static final float BOX_TO_WORLD = 100f; 
}
