package com.XayDungPhanMem.FunnyTalkingCat;

import java.util.Random;

import org.andengine.entity.sprite.Sprite;
import org.andengine.opengl.texture.region.ITextureRegion;
import org.andengine.opengl.vbo.VertexBufferObjectManager;

/*
 * TomCatAction class. A state of Tom Cat - main character.
 */
public class TomCatState extends Sprite 
{

	/*
	 * Enumerator
	 */
	public enum StateType
	{
		ANGRY, BEAT, BLINK, DRINK, FOOT_LEFT, FOOT_RIGHT,
		HAPPY, HAPPY_SMILE, KNOCKOUT, LISTEN, SCRATCH,
		SNEEZE, STOMACH, TALK, ZEH, NORMAL
	}
	
	/*
	 * Variables
	 */
	private ITextureRegion[] bmp;
	private int iBmp = 0;
	private float delay;
	private float totalTime = 0;
	private boolean isCurrent;
	public StateType type;
	
	/*
	 * Methods
	 */
	public TomCatState(float pX, float pY, ITextureRegion pTextureRegion, VertexBufferObjectManager vbom, float delay, StateType type) 
	{
		super(pX, pY, pTextureRegion, vbom);
		this.delay = delay;
		this.type = type;
		this.isCurrent = false;
		setPosition(pX, pY);
		setWidth(MainActivity.CAMERA_WIDTH);
		setHeight(MainActivity.CAMERA_HEIGHT);
	}
	
	public void createState()
	{
		GraphicsManager.getInstance().loadTomCatState(this);
		setTextureRegion(bmp[0]);
	}
	
	public void setBMP(ITextureRegion[] other)
	{
		bmp = other.clone();
	}
	
	@Override
    protected void onManagedUpdate(float pSecondsElapsed) 
    {
        super.onManagedUpdate(pSecondsElapsed);
        // while action running
        if (isCurrent && !endAction())
        {
        	if (pSecondsElapsed < 1)
        		totalTime += pSecondsElapsed * 1000;
	        if (totalTime > delay)
	        {
	        	totalTime -= delay;
	        	setTextureRegion(bmp[iBmp]);
	        	playSound();
	        	if (type != StateType.LISTEN || !(VoiceHandler.getInstance().listening) || iBmp != 5)
	        		iBmp = iBmp + 1;
	        }
	        if (endAction() && type == StateType.TALK)
	        	iBmp = 0;
	        
	        if (type == StateType.BEAT && iBmp >= 9)
	        	if (TomCat.getInstance().getPreviousState() != null && TomCat.getInstance().getPreviousState().type == StateType.BEAT)
	        		changeTo(StateType.KNOCKOUT);		    
        }
        // action end
        if (isCurrent && endAction())
        {
        	if (type == StateType.NORMAL)
        	{
        		if (TomCat.getInstance().timesOfBlink < TomCat.getInstance().maxTimesOfBlink)
        			changeTo(StateType.BLINK);
        		else
        		{
        			Random r = new Random();
        			int t = r.nextInt(4);
        			if (t == 1)
        				changeTo(StateType.SNEEZE);
        			else
        				changeTo(StateType.ZEH);
        			TomCat.getInstance().timesOfBlink = 0;
        		}
        	}
        	else
        	{
        		if (type != StateType.LISTEN && type != StateType.TALK)
        		{	
        			if (type == StateType.BLINK)
	            		TomCat.getInstance().timesOfBlink++;
	        		changeTo(StateType.NORMAL);   
	        	}
        		else
        		{
        			if (type == StateType.LISTEN)
        			{
        				changeTo(StateType.TALK);
        				VoiceHandler.getInstance().playback();
        			}
        		}
        	}     	 		
        }
    }
	
	private void playSound() {
		if (iBmp == 0 && SoundManager.getInstance().curSound != null)
			SoundManager.getInstance().curSound.stop();
		Random r = new Random();
		switch (type)
		{
		case ANGRY:
			if (iBmp == 8)
			{
				int t = r.nextInt(SoundManager.getInstance().angry.length);
				SoundManager.getInstance().angry[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().angry[t];
			}
			break;
		case BEAT:
			if (iBmp == 0)
			{
				int t = r.nextInt(SoundManager.getInstance().beat.length);
				SoundManager.getInstance().beat[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().beat[t];
			}
			break;
		case DRINK:
			if (iBmp == 15)
			{
				int t = r.nextInt(SoundManager.getInstance().pour.length);
				SoundManager.getInstance().pour[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().pour[t];
			}
			if (iBmp == 36)
			{
				int t = r.nextInt(SoundManager.getInstance().drink.length);
				SoundManager.getInstance().drink[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().drink[t];
			}
			break;
		case FOOT_LEFT:
		case FOOT_RIGHT:
			if (iBmp == 3)
			{
				int t = r.nextInt(SoundManager.getInstance().foot.length);
				SoundManager.getInstance().foot[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().foot[t];
			}
			break;
		case HAPPY:			
		case HAPPY_SMILE:
			if (iBmp == 2)
			{
				int t = r.nextInt(SoundManager.getInstance().happy.length);
				SoundManager.getInstance().happy[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().happy[t];
			}
			break;
		case KNOCKOUT:
			if (iBmp == 15)
			{
				int t = r.nextInt(SoundManager.getInstance().fall.length);
				SoundManager.getInstance().fall[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().fall[t];
			}
			if (iBmp == 19)
			{
				int t = r.nextInt(SoundManager.getInstance().star.length);
				SoundManager.getInstance().star[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().star[t];
			}
			break;
		case SCRATCH:
			if (iBmp == 21)
			{
				int t = r.nextInt(SoundManager.getInstance().scratch.length);			
				SoundManager.getInstance().scratch[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().scratch[t];
			}
			break;
		case SNEEZE:
			if (iBmp == 2)
			{
				int t = r.nextInt(SoundManager.getInstance().sneeze.length);
				SoundManager.getInstance().sneeze[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().sneeze[t];
			}
			break;
		case STOMACH:
			if (iBmp == 2)
			{
				int t = r.nextInt(SoundManager.getInstance().stomach.length);
				SoundManager.getInstance().stomach[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().stomach[t];
			}
			break;
		case ZEH:
			if (iBmp == 5)
			{
				int t = r.nextInt(SoundManager.getInstance().zeh.length);
				SoundManager.getInstance().zeh[t].play();
				SoundManager.getInstance().curSound = SoundManager.getInstance().zeh[t];
			}
			break;
		default:
			break;
		}
	}

	public boolean endAction()
	{
		return iBmp >= bmp.length;
	}
	
	public void setDefault()
	{
		iBmp = 0;
		totalTime = 0;
		setTextureRegion(bmp[iBmp]);
	}
	
	public void setCurrent(boolean value)
	{
		isCurrent = value;
	}
	
	public void changeTo(TomCatState other)
	{
		if ((type == StateType.TALK || type == StateType.LISTEN) && other.type != StateType.TALK && other.type != StateType.LISTEN)
			VoiceHandler.getInstance().nextPos = 0;
		TomCat.getInstance().setState(other);
		this.setCurrent(false);
		other.setCurrent(true);
		this.setDefault();
		other.setDefault();
		this.detachSelf();
		SceneManager.getInstance().engine.getScene().attachChild(other);
	}
	
	public void changeTo(StateType type)
	{
		changeTo(TomCat.getInstance().pickAction(type));
	}	
}
