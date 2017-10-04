package com.XayDungPhanMem.FunnyTalkingCat;

import com.XayDungPhanMem.FunnyTalkingCat.TomCatState.StateType;

/*
 * TomCat class. Container of TomCatActions
 */
public class TomCat 
{
	
	/*
	 * Singleton Design Pattern
	 */
	private static TomCat INSTANCE = new TomCat();
	
	public static TomCat getInstance()
	{
		return INSTANCE;
	}
	
	/*
	 * Variables
	 */
	private TomCatState[] states;
	private TomCatState currentState;
	private TomCatState previousState;
	private float pX, pY;
	
	/*
	 * Constants
	 */
	public int timesOfBlink = 0;
	public final int maxTimesOfBlink = 5;
	
	/*
	 * Methods
	 */
	public void init()
	{
		states = new TomCatState[16];
		pX = 0;
		pY = 0;
		states[0] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.ANGRY);
		states[1] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.BEAT);
		states[2] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.BLINK);
		states[3] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.DRINK);
		states[4] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.FOOT_LEFT);
		states[5] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.FOOT_RIGHT);
		states[6] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.HAPPY);
		states[7] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.HAPPY_SMILE);
		states[8] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.KNOCKOUT);
		states[9] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.LISTEN);
		states[10] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 500, StateType.NORMAL);
		states[11] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.SCRATCH);
		states[12] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.SNEEZE);
		states[13] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.STOMACH);
		states[14] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 75, StateType.TALK);
		states[15] = new TomCatState(pX, pY, GraphicsManager.getInstance().dummy_tomcat_region, GraphicsManager.getInstance().vertexBufferObjectManager, 100, StateType.ZEH);
		for (int i=0; i<16; i++)
			states[i].createState();
		currentState = pickAction(StateType.NORMAL);
		currentState.setCurrent(true);
		previousState = null;
	}
	
	public TomCatState pickAction(StateType type)
	{
		for (int i=0; i<states.length; i++)
			if (states[i].type == type)
				return states[i];
		return null;
	}
	
	public TomCatState pickAction(int index)
	{
		StateType[] at = StateType.values();
		return pickAction(at[index]);
	}
	
	public void setState(TomCatState action)
	{
		if (action.type ==  StateType.BEAT)
			previousState = currentState;
		else
			previousState = null;
		currentState = action;
	}
	
	public TomCatState getCurrentState()
	{
		return currentState;
	}
	
	public TomCatState getPreviousState()
	{
		return previousState;
	}
	
	public void disposeSelf()
	{
		currentState.detachSelf();
		for (int i=0; i<16; i++)
			states[i].dispose();
	}
}
