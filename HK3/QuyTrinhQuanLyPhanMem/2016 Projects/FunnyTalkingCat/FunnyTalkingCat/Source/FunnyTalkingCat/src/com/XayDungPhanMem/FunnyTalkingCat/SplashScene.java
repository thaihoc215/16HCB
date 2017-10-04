package com.XayDungPhanMem.FunnyTalkingCat;


import org.andengine.engine.camera.Camera;
import org.andengine.entity.sprite.Sprite;
import org.andengine.opengl.util.GLState;

import com.XayDungPhanMem.FunnyTalkingCat.SceneManager.SceneType;


/*
 * SplashScene class. Represent a splashscene in game
 */
public class SplashScene extends BaseScene
{
	
	/*
	 * Variables
	 */
	private Sprite splashSprite;
	
	/*
	 * Methods
	 */
	@Override
	public void createScene() 
	{
		splashSprite = new Sprite(0, 0, graphicsManager.splash_region, vertexBufferObjectManager)
		{
		    @Override
		    protected void preDraw(GLState pGLState, Camera pCamera) 
		    {
		       super.preDraw(pGLState, pCamera);
		       pGLState.enableDither();
		    }
		};
		
		splashSprite.setPosition(MainActivity.CAMERA_WIDTH / 8, MainActivity.CAMERA_HEIGHT / 8);
		splashSprite.setWidth(MainActivity.CAMERA_WIDTH * 3 / 4);
		splashSprite.setHeight(MainActivity.CAMERA_HEIGHT * 3 / 4);
		attachChild(splashSprite);
	}

	@Override
	public void onBackKeyPressed() 
	{
		return;
	}

	@Override
	public SceneType getSceneType() 
	{
		return SceneType.SCENE_SPLASH;
	}

	@Override
	public void disposeScene() 
	{
		splashSprite.detachSelf();
		splashSprite.dispose();
		this.detachSelf();
		this.dispose();
	}

}
