package com.XayDungPhanMem.FunnyTalkingCat;

import org.andengine.engine.Engine;
import org.andengine.ui.IGameInterface.OnCreateSceneCallback;

/*
 * SceneManager class. Manage scenes
 */
public class SceneManager 
{
	
	/*
	 * Enumerator
	 */
	public enum SceneType
	{
		SCENE_SPLASH,		
		SCENE_GAME,
	}
	
	/*
	 * Singleton Design Pattern
	 */
	private static final SceneManager INSTANCE = new SceneManager();
	
	public static SceneManager getInstance() 
	{
		return INSTANCE;
	}
	
	/*
	 * Samples of BaseScene
	 */
	private BaseScene splashScene;
	private BaseScene gameScene;
	
	/*
	 * Variables
	 */
	private SceneType currentSceneType = SceneType.SCENE_SPLASH;
	private BaseScene currentScene;
	public Engine engine = GraphicsManager.getInstance().engine;
	
	/*
	 * Important Methods
	 */
	public void SetScene(BaseScene scene) 
	{
		engine.setScene(scene);
		currentScene = scene;
		currentSceneType = scene.getSceneType();
		switch (currentSceneType) 
		{
		case SCENE_GAME:
			break;
		default:
			break;
		}
	}
	
	public void SetScene(SceneType sceneType) 
	{
		switch (sceneType)
		{
		case SCENE_SPLASH:
			SetScene(splashScene);
			break;
		case SCENE_GAME:
			SetScene(gameScene);			
			break;
		default:
			break;
		}
	}
	
	public SceneType getCurrentSceneType() 
	{
		return currentSceneType;
	}
	
	public BaseScene getCurrentScene() 
	{
		return currentScene;
	}
	
	/*
	 * Methods
	 */
	public void createSplashScene(OnCreateSceneCallback pOnCreateSceneCallback)
	{
	    this.splashScene = new SplashScene();
	    this.splashScene.createScene();
	    this.currentScene = this.splashScene;
	    pOnCreateSceneCallback.onCreateSceneFinished(this.splashScene);
	}
	
	private void disposeSplashScene()
	{
	    GraphicsManager.getInstance().unloadSplashScreen();
	    this.splashScene.disposeScene();
	    this.splashScene = null;
	}
	
	public void disposeGameScene()
	{
		GraphicsManager.getInstance().unloadGameGraphics();
		SoundManager.getInstance().unloadGameSound();
		this.gameScene.disposeScene();
		this.gameScene = null;
	}
	
	public void createGameScene()
	{
		this.gameScene = new GameScene();
		this.gameScene.createScene();
		SetScene(this.gameScene);
		this.disposeSplashScene();
	}
}
