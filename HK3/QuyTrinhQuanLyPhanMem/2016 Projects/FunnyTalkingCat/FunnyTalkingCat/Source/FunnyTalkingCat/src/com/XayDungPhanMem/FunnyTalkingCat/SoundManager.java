package com.XayDungPhanMem.FunnyTalkingCat;

import java.io.IOException;

import org.andengine.audio.sound.Sound;
import org.andengine.audio.sound.SoundFactory;
import org.andengine.engine.Engine;
import org.andengine.engine.camera.Camera;
import org.andengine.opengl.vbo.VertexBufferObjectManager;

/*
 * SoundManager class. Manage sound and music in game
 */
public class SoundManager 
{
	/*
	 * Important Variables
	 */
	private static SoundManager INSTANCE = null;
	public Engine engine;
	public MainActivity activity;
	public Camera camera;
	public VertexBufferObjectManager vbom;
	
	/*
	 * Variables
	 */
	public Sound[] angry = new Sound[4];
	public Sound[] beat = new Sound[12];
	public Sound[] drink = new Sound[2];
	public Sound[] pour = new Sound[2];
	public Sound[] foot = new Sound[4];
	public Sound[] happy = new Sound[2];
	public Sound[] fall = new Sound[2];
	public Sound[] star = new Sound[2];
	public Sound[] scratch = new Sound[2];
	public Sound[] sneeze = new Sound[2];
	public Sound[] stomach = new Sound[4];
	public Sound[] zeh = new Sound[4];
	public Sound curSound = null;
	
	/*
	 * Singleton Design Pattern
	 */
	private SoundManager() {};
	
	public static SoundManager getInstance()
	{
		return INSTANCE;
	}
	
	public static void prepareManager(Engine engine, MainActivity activity, Camera camera, VertexBufferObjectManager vbom)
	{
		INSTANCE = new SoundManager();
		getInstance().engine = engine;
		getInstance().activity = activity;
		getInstance().camera = camera;
		getInstance().vbom = vbom;
	}
	
	/*
	 * Load Resources
	 */
	public void loadSound()
	{
		loadGameSound();
		loadSplashScreenSound();
	}
	
	private void loadSoundByName(Sound[] s, String name)
	{
		for (int i=0; i<s.length; i++)
		{
			try {
				s[i] = SoundFactory.createSoundFromAsset(engine.getSoundManager(), activity, "mfx/" + name + String.format("/%04d.wav", i));
			} catch (IllegalStateException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
	
	private void loadGameSound()
	{
		loadSoundByName(angry, "angry");
		loadSoundByName(beat, "beat");
		loadSoundByName(drink, "drink");
		loadSoundByName(fall, "fall");
		loadSoundByName(foot, "foot");
		loadSoundByName(happy, "happy");
		loadSoundByName(pour, "pour");
		loadSoundByName(scratch, "scratch");
		loadSoundByName(sneeze, "sneeze");
		loadSoundByName(star, "star");
		loadSoundByName(stomach, "stomach");
		loadSoundByName(zeh, "zeh");
	}
	
	private void loadSplashScreenSound()
	{
		
	}
	
	/*
	 * Unload Resources
	 */
	private void unloadSoundByName(Sound[] s)
	{
		for (int i=0; i<s.length; i++)
		{
			s[i].release();
		}
	}
	
	public void unloadGameSound()
	{
		unloadSoundByName(angry);
		unloadSoundByName(beat);
		unloadSoundByName(drink);
		unloadSoundByName(fall);
		unloadSoundByName(foot);
		unloadSoundByName(happy);
		unloadSoundByName(pour);
		unloadSoundByName(scratch);
		unloadSoundByName(sneeze);
		unloadSoundByName(star);
		unloadSoundByName(stomach);
		unloadSoundByName(zeh);
	}	
}
