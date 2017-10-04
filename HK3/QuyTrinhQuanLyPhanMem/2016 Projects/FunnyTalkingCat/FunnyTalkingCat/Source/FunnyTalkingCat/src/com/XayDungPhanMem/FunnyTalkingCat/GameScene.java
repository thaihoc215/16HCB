package com.XayDungPhanMem.FunnyTalkingCat;


import org.andengine.entity.primitive.Rectangle;
import org.andengine.entity.sprite.Sprite;
import org.andengine.input.touch.TouchEvent;
import org.andengine.util.color.Color;

import com.XayDungPhanMem.FunnyTalkingCat.SceneManager.SceneType;
import com.XayDungPhanMem.FunnyTalkingCat.TomCatState.StateType;


/*
 * Scene class
 */
public class GameScene extends BaseScene
{
	
	/*
	 * Variables
	 */
	Rectangle headArea;
	Rectangle tailArea;
	Rectangle stomachArea;
	Rectangle footLeftArea;
	Rectangle footRightArea;
	float xTouch, yTouch;
	Sprite btnScratch, btnMilk;
	
	/*
	 * Methods
	 */
	@Override
	public void createScene() 
	{
		createBackground();
		TomCat.getInstance().init();
		attachChild(TomCat.getInstance().getCurrentState());
		
		// head area
		headArea = new Rectangle(110 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD, 
				173 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD,
				258 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD, 
				254 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, vertexBufferObjectManager)
		{
            @Override
            public boolean onAreaTouched(final TouchEvent pSceneTouchEvent, final float pTouchAreaLocalX, final float pTouchAreaLocalY) 
            {                 
            	StateType type = TomCat.getInstance().getCurrentState().type;
            	if (pSceneTouchEvent.isActionDown())
            	{
            		xTouch = pSceneTouchEvent.getX();
            		yTouch = pSceneTouchEvent.getY();
            	}
            	if (type != StateType.SCRATCH && type != StateType.KNOCKOUT)
            	{
            		if (pSceneTouchEvent.isActionMove() && type != StateType.HAPPY && type != StateType.HAPPY_SMILE)
            		{
            			TomCat.getInstance().getCurrentState().changeTo(StateType.HAPPY);
            		}
            		if (pSceneTouchEvent.isActionUp())
            		{
            			float x = pSceneTouchEvent.getX();
            			float y = pSceneTouchEvent.getY();
            			double distance = Math.sqrt(Math.pow(xTouch - x, 2) + Math.pow(yTouch - y, 2));
            			if (distance < 4)
            				TomCat.getInstance().getCurrentState().changeTo(StateType.BEAT);
            		}      		
            	}
                return true;
            }
	    };
	    headArea.setColor(Color.TRANSPARENT);
	    this.registerTouchArea(headArea);
	    
	    // tail area
	    tailArea = new Rectangle(313 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD,
	    		601 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, 
	    		41 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD, 
	    		124 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, vertexBufferObjectManager)
		{
            @Override
            public boolean onAreaTouched(final TouchEvent pSceneTouchEvent, final float pTouchAreaLocalX, final float pTouchAreaLocalY) 
            {
            	StateType type = TomCat.getInstance().getCurrentState().type;
            	if (pSceneTouchEvent.isActionDown() && type != StateType.ANGRY &&
            			type != StateType.SCRATCH && type != StateType.KNOCKOUT)
            		TomCat.getInstance().getCurrentState().changeTo(StateType.ANGRY);    
                return true;
            }
	    };
	    tailArea.setColor(Color.TRANSPARENT);
	    this.registerTouchArea(tailArea);
	    
	    // stomach area
	    stomachArea = new Rectangle(160 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD,
	    		435 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD,
	    		148 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD,
	    		282 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, vertexBufferObjectManager)
		{
            @Override
            public boolean onAreaTouched(final TouchEvent pSceneTouchEvent, final float pTouchAreaLocalX, final float pTouchAreaLocalY) 
            {
            	StateType type = TomCat.getInstance().getCurrentState().type;
            	if (pSceneTouchEvent.isActionDown())
            	{
            		xTouch = pSceneTouchEvent.getX();
            		yTouch = pSceneTouchEvent.getY();
            	}
            	if (type != StateType.SCRATCH && type != StateType.KNOCKOUT)
            	{
            		if (pSceneTouchEvent.isActionMove() && type != StateType.HAPPY && type != StateType.HAPPY_SMILE)
            		{
            			TomCat.getInstance().getCurrentState().changeTo(StateType.HAPPY_SMILE);           		
            		}
            		if (pSceneTouchEvent.isActionUp())
            		{
            			float x = pSceneTouchEvent.getX();
            			float y = pSceneTouchEvent.getY();
            			double distance = Math.sqrt(Math.pow(xTouch - x, 2) + Math.pow(yTouch - y, 2));
            			if (distance < 4)
            				TomCat.getInstance().getCurrentState().changeTo(StateType.STOMACH);
            		}
            	}
                return true;
            }
	    };
	    stomachArea.setColor(Color.TRANSPARENT);
	    this.registerTouchArea(stomachArea);
	    
	    // foot left area
	    footLeftArea = new Rectangle(241 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD,
	    		720 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD,
	    		51 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD,
	    		50 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, vertexBufferObjectManager)
		{
            @Override
            public boolean onAreaTouched(final TouchEvent pSceneTouchEvent, final float pTouchAreaLocalX, final float pTouchAreaLocalY) 
            {
            	StateType type = TomCat.getInstance().getCurrentState().type;
            	if (pSceneTouchEvent.isActionDown() && type != StateType.SCRATCH && type != StateType.KNOCKOUT)
            		TomCat.getInstance().getCurrentState().changeTo(StateType.FOOT_LEFT);    
                return true;
            }
	    };
	    footLeftArea.setColor(Color.TRANSPARENT);
	    this.registerTouchArea(footLeftArea);
	    
	    // foot right area
	    footRightArea = new Rectangle(180 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD,
	    		720 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD,
	    		56 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD,
	    		50 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, vertexBufferObjectManager)
		{
            @Override
            public boolean onAreaTouched(final TouchEvent pSceneTouchEvent, final float pTouchAreaLocalX, final float pTouchAreaLocalY) 
            {
            	StateType type = TomCat.getInstance().getCurrentState().type;
            	if (pSceneTouchEvent.isActionDown() && type != StateType.SCRATCH && type != StateType.KNOCKOUT)
            		TomCat.getInstance().getCurrentState().changeTo(StateType.FOOT_RIGHT);    
                return true;
            }
	    };
	    footRightArea.setColor(Color.TRANSPARENT);
	    this.registerTouchArea(footRightArea);
	    
	    // two buttons
	    btnScratch = new Sprite(0, 
	    		MainActivity.CAMERA_HEIGHT - 60 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, 
	    		60 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD, 
	    		60 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, 
	    		graphicsManager.btnScratch_region, vertexBufferObjectManager)
	    {
	    	@Override
	    	public boolean onAreaTouched(final TouchEvent pSceneTouchEvent, final float pTouchAreaLocalX, final float pTouchAreaLocalY)
	    	{
	    		StateType type = TomCat.getInstance().getCurrentState().type;
            	if (pSceneTouchEvent.isActionDown() && type != StateType.KNOCKOUT)
            		TomCat.getInstance().getCurrentState().changeTo(StateType.SCRATCH);
	    		return true;
	    	}
	    };
	    this.registerTouchArea(btnScratch);
	    
	    btnMilk = new Sprite(0, 
	    		MainActivity.CAMERA_HEIGHT - 150 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD, 
	    		60 * MainActivity.CAMERA_WIDTH / MainActivity.CAMERA_WIDTH_STANDARD, 
	    		60 * MainActivity.CAMERA_HEIGHT / MainActivity.CAMERA_HEIGHT_STANDARD,
	    		graphicsManager.btnMilk_region, vertexBufferObjectManager)
	    {
	    	@Override
	    	public boolean onAreaTouched(final TouchEvent pSceneTouchEvent, final float pTouchAreaLocalX, final float pTouchAreaLocalY)
	    	{
	    		StateType type = TomCat.getInstance().getCurrentState().type;
            	if (pSceneTouchEvent.isActionDown() && type != StateType.SCRATCH && type != StateType.KNOCKOUT)
            		TomCat.getInstance().getCurrentState().changeTo(StateType.DRINK);
	    		return true;
	    	}
	    };
	    
	    this.registerTouchArea(btnMilk);
	    
	    attachChild(headArea);
		attachChild(tailArea);
		attachChild(stomachArea);
		attachChild(footLeftArea);
		attachChild(footRightArea);
		attachChild(btnMilk);
		attachChild(btnScratch);
		
		VoiceHandler.getInstance().init();		
	}

	@Override
	public void onBackKeyPressed() 
	{
		// TODO Auto-generated method stub
		SceneManager.getInstance().disposeGameScene();
		activity.finish();
		System.exit(0);
	}

	@Override
	public SceneType getSceneType() 
	{
		return SceneType.SCENE_GAME;
	}

	@Override
	public void disposeScene() 
	{
		VoiceHandler.getInstance().release();
		headArea.detachSelf();
		headArea.dispose();
		tailArea.detachSelf();
		tailArea.dispose();
		stomachArea.detachSelf();
		stomachArea.dispose();
		footLeftArea.detachSelf();
		footLeftArea.dispose();
		footRightArea.detachSelf();
		footRightArea.dispose();
		btnMilk.detachSelf();
		btnMilk.dispose();
		btnScratch.detachSelf();
		btnScratch.dispose();
		TomCat.getInstance().disposeSelf();
		this.detachSelf();
		this.dispose();
	}
	
	private void createBackground()
	{
		Sprite wall = new Sprite(0, 0, graphicsManager.background_region, vertexBufferObjectManager);	
		wall.setPosition(0, 0);
		wall.setWidth(MainActivity.CAMERA_WIDTH);
		wall.setHeight(MainActivity.CAMERA_HEIGHT);
		attachChild(wall);
	}
}
