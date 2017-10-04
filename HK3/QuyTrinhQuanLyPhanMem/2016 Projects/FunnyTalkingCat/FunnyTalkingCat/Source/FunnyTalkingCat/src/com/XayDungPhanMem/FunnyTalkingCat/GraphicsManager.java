package com.XayDungPhanMem.FunnyTalkingCat;

import org.andengine.engine.Engine;
import org.andengine.engine.camera.Camera;
import org.andengine.opengl.texture.TextureOptions;
import org.andengine.opengl.texture.atlas.bitmap.BitmapTextureAtlas;
import org.andengine.opengl.texture.atlas.bitmap.BitmapTextureAtlasTextureRegionFactory;
import org.andengine.opengl.texture.atlas.bitmap.BuildableBitmapTextureAtlas;
import org.andengine.opengl.texture.atlas.bitmap.source.IBitmapTextureAtlasSource;
import org.andengine.opengl.texture.atlas.buildable.builder.BlackPawnTextureAtlasBuilder;
import org.andengine.opengl.texture.atlas.buildable.builder.ITextureAtlasBuilder.TextureAtlasBuilderException;
import org.andengine.opengl.texture.region.ITextureRegion;
import org.andengine.opengl.vbo.VertexBufferObjectManager;
import org.andengine.util.debug.Debug;

/*
 * GraphicsManager class. Manage graphics resources
 */
public class GraphicsManager 
{
	/*
	 * Important Variables
	 */
	private static GraphicsManager INSTANCE = null;
	public Engine engine;
	public MainActivity activity;
	public Camera camera;
	public VertexBufferObjectManager vertexBufferObjectManager;
	
	/*
	 * Variables
	 */
	private BitmapTextureAtlas splash_texture_atlas;
	public ITextureRegion splash_region;
	
	private BuildableBitmapTextureAtlas game_texture_atlas;
	public ITextureRegion background_region;
	
	private BitmapTextureAtlas btnScratch_atlas, btnMilk_atlas;
	public ITextureRegion btnScratch_region, btnMilk_region;
	
	private BitmapTextureAtlas dummy_tomcat_atlas;
	public ITextureRegion dummy_tomcat_region;
	
	/*
	 * Singleton Design Pattern
	 */
	private GraphicsManager() {};
	
	public static GraphicsManager getInstance()
	{
		return INSTANCE;
	}
	
	public static void prepareManager(Engine engine, MainActivity activity, Camera camera, VertexBufferObjectManager vbom)
	{
		INSTANCE = new GraphicsManager();
		getInstance().engine = engine;
		getInstance().activity = activity;
		getInstance().camera = camera;
		getInstance().vertexBufferObjectManager = vbom;
	}
	
	/*
	 * Load Resources
	 */
	public void loadGraphics()
	{
		this.loadGameGraphics();
		this.loadDummyTomCat();
		this.loadSplashScreen();
		this.loadButton();
	}
	
	private void loadGameGraphics()
	{
		BitmapTextureAtlasTextureRegionFactory.setAssetBasePath("gfx/");
		game_texture_atlas = new BuildableBitmapTextureAtlas(activity.getTextureManager(), 1024, 1024, TextureOptions.BILINEAR);    
		background_region = BitmapTextureAtlasTextureRegionFactory.createFromAsset(game_texture_atlas, activity, "drawable/bg.png");
			
		try 
	    {
	        this.game_texture_atlas.build(new BlackPawnTextureAtlasBuilder<IBitmapTextureAtlasSource, BitmapTextureAtlas>(0, 1, 0));
	        this.game_texture_atlas.load();
	    } 
	    catch (final TextureAtlasBuilderException e)
	    {
	        Debug.e(e);
	    }
	}
	
	private void loadButton()
	{
		BitmapTextureAtlasTextureRegionFactory.setAssetBasePath("gfx/");
		btnScratch_atlas = new BitmapTextureAtlas(activity.getTextureManager(), 60, 60, TextureOptions.BILINEAR);
		btnScratch_region = BitmapTextureAtlasTextureRegionFactory.createFromAsset(btnScratch_atlas, 
				activity.getAssets(), "drawable/btnprint.png", 0, 0);
		btnScratch_atlas.load();
		
		btnMilk_atlas = new BitmapTextureAtlas(activity.getTextureManager(), 60, 60, TextureOptions.BILINEAR);
		btnMilk_region = BitmapTextureAtlasTextureRegionFactory.createFromAsset(btnMilk_atlas, 
				activity.getAssets(), "drawable/button_milk.png", 0, 0);
		btnMilk_atlas.load();
	}
	
	private void loadDummyTomCat()
	{
		BitmapTextureAtlasTextureRegionFactory.setAssetBasePath("gfx/");
		dummy_tomcat_atlas = new BitmapTextureAtlas(activity.getTextureManager(), 
				240, 360, TextureOptions.BILINEAR);
		dummy_tomcat_region = BitmapTextureAtlasTextureRegionFactory.createFromAsset(dummy_tomcat_atlas, 
				activity.getAssets(), "normal/0000.png", 0, 0);		
		dummy_tomcat_atlas.load();
	}
	
	public void loadTomCatState(TomCatState action)
	{
		BitmapTextureAtlasTextureRegionFactory.setAssetBasePath("gfx/");
		int nBMP = 0;
		ITextureRegion[] source;
		switch (action.type)
		{
		case ANGRY:
			nBMP = 26;
			break;
		case BEAT:
			nBMP = 19;
			break;
		case BLINK:
			nBMP = 3;
			break;
		case DRINK:
			nBMP = 81;
			break;
		case FOOT_LEFT:
			nBMP = 30;
			break;
		case FOOT_RIGHT:
			nBMP = 30;
			break;
		case HAPPY:
			nBMP = 29;
			break;
		case HAPPY_SMILE:
			nBMP = 25;
			break;
		case KNOCKOUT:
			nBMP = 80;
			break;
		case LISTEN:
			nBMP = 12;
			break;
		case NORMAL:
			nBMP = 2;
			break;
		case SCRATCH:
			nBMP = 56;
			break;
		case SNEEZE:
			nBMP = 14;
			break;
		case STOMACH:
			nBMP = 34;
			break;
		case TALK:
			nBMP = 12;
			break;
		case ZEH:
			nBMP = 31;
			break;
		}
		source = new ITextureRegion[nBMP];
		for (int i=0; i<nBMP; i++)
		{
			BitmapTextureAtlas bta = new BitmapTextureAtlas(activity.getTextureManager(),
					240, 360, TextureOptions.BILINEAR);
			source[i] = BitmapTextureAtlasTextureRegionFactory.createFromAsset(bta, activity.getAssets(), 
					action.type.toString().toLowerCase() + "/" + String.format("%04d.png", i), 0, 0);
			bta.load();
		}
		action.setBMP(source);
	}
	
	public void loadSplashScreen()
	{
		BitmapTextureAtlasTextureRegionFactory.setAssetBasePath("gfx/");
		splash_texture_atlas = new BitmapTextureAtlas(activity.getTextureManager(), 
				MainActivity.CAMERA_WIDTH_STANDARD / 2, MainActivity.CAMERA_HEIGHT_STANDARD / 2, TextureOptions.BILINEAR);
		splash_region = BitmapTextureAtlasTextureRegionFactory.createFromAsset(splash_texture_atlas, 
				activity.getAssets(), "drawable/first.png", 0, 0);		
		splash_texture_atlas.load(); 
	}
	
	/*
	 * Unload Resources
	 */	
	public void unloadGameGraphics()
	{
		game_texture_atlas.unload();
		background_region = null;
		btnMilk_atlas.unload();
		btnMilk_region = null;
		btnScratch_atlas.unload();
		btnScratch_region = null;
		dummy_tomcat_atlas.unload();
		dummy_tomcat_region = null;
	}
	
	public void unloadSplashScreen()
	{
		splash_texture_atlas.unload();
		splash_region = null;
	}
}
