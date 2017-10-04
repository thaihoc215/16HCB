package com.XayDungPhanMem.FunnyTalkingCat;

import org.andengine.engine.Engine;
import org.andengine.engine.LimitedFPSEngine;
import org.andengine.engine.camera.Camera;
import org.andengine.engine.handler.timer.ITimerCallback;
import org.andengine.engine.handler.timer.TimerHandler;
import org.andengine.engine.options.EngineOptions;
import org.andengine.engine.options.ScreenOrientation;
import org.andengine.engine.options.WakeLockOptions;
import org.andengine.engine.options.resolutionpolicy.RatioResolutionPolicy;
import org.andengine.entity.scene.Scene;
import org.andengine.opengl.view.RenderSurfaceView;
import org.andengine.ui.activity.BaseGameActivity;

import android.annotation.SuppressLint;
import android.util.DisplayMetrics;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.ViewGroup;
import android.widget.FrameLayout;

/*
 * Main Activity
 */
public class MainActivity extends BaseGameActivity 
{
	/*
	 * Variables
	 */
	public static final int CAMERA_WIDTH_STANDARD = 480;
	public static final int CAMERA_HEIGHT_STANDARD = 800;
	public static final int AD_BANNER_HEIGHT = 50;
	public static int CAMERA_WIDTH;
	public static int CAMERA_HEIGHT;
	private SoundManager soundManager;
	private GraphicsManager graphicsManager;
	private Camera camera;
	
	/*
	 * Methods
	 */
	@Override
	public EngineOptions onCreateEngineOptions() 
	{
		final DisplayMetrics displayMetrics = new DisplayMetrics();
		this.getWindowManager().getDefaultDisplay().getMetrics(displayMetrics);
		CAMERA_HEIGHT = displayMetrics.heightPixels;
		CAMERA_WIDTH = (int)((float)CAMERA_HEIGHT * CAMERA_WIDTH_STANDARD / CAMERA_HEIGHT_STANDARD);
		camera = new Camera(0, 0, CAMERA_WIDTH, CAMERA_HEIGHT);
		camera.setCenter(CAMERA_WIDTH / 2, CAMERA_HEIGHT / 2);
		EngineOptions option = new EngineOptions(true, ScreenOrientation.PORTRAIT_FIXED,
				new RatioResolutionPolicy(CAMERA_WIDTH, CAMERA_HEIGHT - AD_BANNER_HEIGHT), camera);
		option.getAudioOptions().setNeedsMusic(true).setNeedsSound(true);
		option.setWakeLockOptions(WakeLockOptions.SCREEN_ON);
		return option;
	}
	
	@Override
	public Engine onCreateEngine(EngineOptions pEngineOptions) 
	{
		return new LimitedFPSEngine(pEngineOptions, 60);
	}

	@Override
	public void onCreateResources(
			OnCreateResourcesCallback pOnCreateResourcesCallback)
			throws Exception 
	{
		GraphicsManager.prepareManager(mEngine, this, camera, this.getVertexBufferObjectManager());
		graphicsManager = GraphicsManager.getInstance();
		graphicsManager.loadGraphics();
		SoundManager.prepareManager(mEngine, this, camera, this.getVertexBufferObjectManager());
		soundManager = SoundManager.getInstance();
		soundManager.loadSound();
		pOnCreateResourcesCallback.onCreateResourcesFinished();
	}

	@Override
	public void onCreateScene(OnCreateSceneCallback pOnCreateSceneCallback)
			throws Exception 
	{
		SceneManager.getInstance().createSplashScene(pOnCreateSceneCallback);
	}

	@Override
	public void onPopulateScene(Scene pScene,
			OnPopulateSceneCallback pOnPopulateSceneCallback) throws Exception 
	{
		mEngine.registerUpdateHandler(new TimerHandler(3f, new ITimerCallback() 
	    {
	            public void onTimePassed(final TimerHandler pTimerHandler) 
	            {
	                mEngine.unregisterUpdateHandler(pTimerHandler);
	                SceneManager.getInstance().createGameScene();
	            }
	    }));
		
	    pOnPopulateSceneCallback.onPopulateSceneFinished();
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		if (keyCode == KeyEvent.KEYCODE_BACK)
			SceneManager.getInstance().getCurrentScene().onBackKeyPressed();
		return false;
	}
}