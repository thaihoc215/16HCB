package com.XayDungPhanMem.FunnyTalkingCat;


import org.andengine.engine.Engine;
import org.andengine.engine.camera.Camera;
import org.andengine.entity.scene.Scene;
import org.andengine.opengl.vbo.VertexBufferObjectManager;

import com.XayDungPhanMem.FunnyTalkingCat.SceneManager.SceneType;


/*
 * Super class of all Scene class
 */
public abstract class BaseScene extends Scene 
{
	/*
	 * Variables
	 */
	protected Engine engine;
	protected Camera camera;
	protected MainActivity activity;
	protected VertexBufferObjectManager vertexBufferObjectManager;
	protected GraphicsManager graphicsManager;
	
	/*
	 * Constructors
	 */
	public BaseScene() {
		graphicsManager = GraphicsManager.getInstance();
		engine = graphicsManager.engine;
		camera = graphicsManager.camera;
		vertexBufferObjectManager = graphicsManager.vertexBufferObjectManager;
		activity = graphicsManager.activity;
	}
	
	/*
	 * Abstract Methods
	 */
	public abstract void createScene();
	public abstract void onBackKeyPressed();
	public abstract SceneType getSceneType();
	public abstract void disposeScene();
}
