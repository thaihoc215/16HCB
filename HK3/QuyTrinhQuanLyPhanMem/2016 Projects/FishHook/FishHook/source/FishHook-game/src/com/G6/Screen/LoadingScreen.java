package com.G6.Screen;

import com.G6.Helper.FishHookStageReader;
import com.G6.assets.Assets;
import com.G6.assets.Audio;
import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.TextureAtlas;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Interpolation;
import com.badlogic.gdx.scenes.scene2d.Group;
import com.badlogic.gdx.scenes.scene2d.actions.Actions;
import com.badlogic.gdx.scenes.scene2d.ui.Image;

public class LoadingScreen extends BaseScreen {


	public LoadingScreen(Game game) {
		super(game);

		float w = Gdx.graphics.getWidth();
		float h = Gdx.graphics.getHeight();
		Assets.batch = new SpriteBatch();
		Assets.camera = new OrthographicCamera(1, h/w);
		Assets.atlas = new TextureAtlas(Gdx.files.internal("MyDataPacker/info.txt"));
	
		
		SpriteBatch batch = Assets.batch;
		OrthographicCamera camera = Assets.camera;
		TextureAtlas atlas = Assets.atlas;
		
		Assets.lstBubble = atlas.findRegions("Bubble/bubble");
		Assets.background = atlas.findRegion("Background/background", 1);
		Assets.player = Assets.atlas.findRegion("object/player");
		Assets.target = Assets.atlas.findRegion("object/target");
		Assets.lstTurtle = atlas.findRegions("object/turtle");
		

		//resource menu
		Assets.stringFishHooks= atlas.findRegion("Other/stringfishhooks");
		Assets.play = atlas.findRegion("Other/play");
		Assets.disney = atlas.findRegion("Other/d");
		Assets.watch = atlas.findRegion("Other/watch");
		Assets.setting = atlas.findRegion("Other/setting");
		Assets.i = atlas.findRegion("Other/i");
		Assets.rePlay = atlas.findRegion("Other/replay");
		Assets.loadingScreen = atlas.findRegion("Background/loading");
		
		Assets.a1 = atlas.findRegion("Fish/a1");
		Assets.a2 = atlas.findRegion("Fish/a2");
		Assets.a3 = atlas.findRegion("Fish/a3");
		Assets.a4 = atlas.findRegion("Fish/a4");
		Assets.a5 = atlas.findRegion("Fish/a5");
		Assets.a6 = atlas.findRegion("Fish/a6");
		Assets.a7 = atlas.findRegion("Fish/a7");
		
		Assets.back=atlas.findRegion("Other/back");
		Assets.tank1=atlas.findRegion("Other/tank1");
		Assets.listap=atlas.findRegions("Other/ap");
		
		Assets.ap0 = atlas.findRegion("AppleScore/ap0");
		Assets.ap1 = atlas.findRegion("AppleScore/ap1");
		Assets.ap2 = atlas.findRegion("AppleScore/ap2");
		Assets.ap3 = atlas.findRegion("AppleScore/ap3");
		Assets.ap4 = atlas.findRegion("AppleScore/ap4");
		Assets.ap5 = atlas.findRegion("AppleScore/ap5");
		Assets.ap6 = atlas.findRegion("AppleScore/ap6");
		Assets.ap7 = atlas.findRegion("AppleScore/ap7");
		Assets.ap8 = atlas.findRegion("AppleScore/ap8");
		Assets.ap9 = atlas.findRegion("AppleScore/ap9");
		Assets.ap10 = atlas.findRegion("AppleScore/ap10");
		Assets.ap11 = atlas.findRegion("AppleScore/ap11");
		Assets.ap12 = atlas.findRegion("AppleScore/ap12");
		Assets.ap13 = atlas.findRegion("AppleScore/ap13");
		Assets.ap14 = atlas.findRegion("AppleScore/ap14");
		Assets.ap15 = atlas.findRegion("AppleScore/ap15");
		Assets.ap16 = atlas.findRegion("AppleScore/ap16");
		Assets.ap17 = atlas.findRegion("AppleScore/ap17");
		Assets.ap18 = atlas.findRegion("AppleScore/ap18");
		
		Assets.a3k = atlas.findRegion("Fishk/a3k");
		Assets.a4k = atlas.findRegion("Fishk/a4k");
		Assets.a5k = atlas.findRegion("Fishk/a5k");
		Assets.a6k = atlas.findRegion("Fishk/a6k");
		Assets.a7k = atlas.findRegion("Fishk/a7k");
		
		Assets.table = atlas.findRegion("Other/tablefreshwater");
		Assets.pickafish = atlas.findRegion("Other/pickafish");
		
		Assets.listSelectTank = atlas.findRegions("Other/st");
		Assets.so1=atlas.findRegion("Other/so1");
		Assets.so2=atlas.findRegion("Other/so2");
		Assets.so3=atlas.findRegion("Other/so3");
		Assets.so4=atlas.findRegion("Other/so4");
		Assets.so5=atlas.findRegion("Other/so5");
		Assets.so6=atlas.findRegion("Other/so6");
		Assets.so1Clicked=atlas.findRegion("Other/so1click");
		
		Audio.musicBackground=Gdx.audio.newSound(Gdx.files.internal("Audio/musicbackground.mp3"));
		Audio.buttonClick=Gdx.audio.newSound(Gdx.files.internal("Audio/buttonclick.mp3"));
		
		Group gr = new Group();
		Image img = new Image(Assets.loadingScreen);
		img.setSize(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
		gr.addActor( img);
		gr.setPosition(0, -500);
		gr.addAction(Actions.moveTo(0,0, 0.5f, Interpolation.exp5));
		stage.addActor(gr);
    	
		
		/*
		FishHookStageReader stagereader=new FishHookStageReader();
		stagereader.LoadFile("StageInfo/stage.xml");
		stagereader.Change_nStageUnlock(5);
		stagereader.Change_nSceneUnlock(0, 9);
		stagereader.ChangeValue(2, 2, 100);
		int k=0;
		k=1;*/
	}
	

	@Override
	public void render(float delta) {
		// TODO Auto-generated method stub
		super.render(delta);
		game.setScreen(new MainMenu(game, false));
	}
}
