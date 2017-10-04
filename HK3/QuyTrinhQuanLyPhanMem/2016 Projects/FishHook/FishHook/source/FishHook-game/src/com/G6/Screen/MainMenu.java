package com.G6.Screen;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import com.G6.Helper.FishHookStageReader;
import com.G6.Object.Bubble;
import com.G6.Object.MySprite;
import com.G6.Object.ObjectAnimation;
import com.G6.Object.PlayButton;
import com.G6.assets.Assets;
import com.G6.assets.Audio;
import com.G6.assets.Global;
import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Interpolation;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.BodyDef.BodyType;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.scenes.scene2d.Group;
import com.badlogic.gdx.scenes.scene2d.actions.Actions;
import com.badlogic.gdx.scenes.scene2d.ui.Image;

public class MainMenu extends BaseScreen {

	/*
	 * public class MyGestureListener implements GestureListener {
	 * 
	 * @Override public boolean touchDown(float x, float y, int pointer, int
	 * button) { // TODO Auto-generated method stub
	 * Gdx.app.log("GestureDetectorTest", "long press at " + x + ", " + y);
	 * isMainMenu = true; isSelectMenu = false;
	 * mainGroup.addAction(Actions.moveTo(0, 0, 0.5f, Interpolation.swingOut));
	 * 
	 * selectGroup.addAction(Actions.moveTo(-800, 0, 0.5f,
	 * Interpolation.swingOut)); return false; }
	 * 
	 * @Override public boolean tap(float x, float y, int count, int button) {
	 * // TODO Auto-generated method stub Gdx.app.log("GestureDetectorTest",
	 * "long press at " + x + ", " + y); return false; }
	 * 
	 * @Override public boolean longPress(float x, float y) { // TODO
	 * Auto-generated method stub Gdx.app.log("GestureDetectorTest",
	 * "long press at " + x + ", " + y); return false; }
	 * 
	 * @Override public boolean fling(float velocityX, float velocityY, int
	 * button) { Gdx.app.log("GestureDetectorTest", "long press at "); // TODO
	 * Auto-generated method stub return false; }
	 * 
	 * @Override public boolean pan(float x, float y, float deltaX, float
	 * deltaY) { Gdx.app.log("GestureDetectorTest", "long press at " + x + ", "
	 * + y); // TODO Auto-generated method stub return false; }
	 * 
	 * @Override public boolean zoom(float initialDistance, float distance) {
	 * Gdx.app.log("GestureDetectorTest", "long press at "); // TODO
	 * Auto-generated method stub return false; }
	 * 
	 * @Override public boolean pinch(Vector2 initialPointer1, Vector2
	 * initialPointer2, Vector2 pointer1, Vector2 pointer2) {
	 * Gdx.app.log("GestureDetectorTest", "long press at "); // TODO
	 * Auto-generated method stub return false; }
	 * 
	 * }
	 * 
	 * GestureDetector gestureDetector;
	 */
	FishHookStageReader stageReader;
	// menu
	PlayButton btnPlay, btnReplay, btnSetting, btnDisney, btnI;// menu so 1

	PlayButton btnBackSelectMenu, btnSelectTank1, btnSelectTank2,
			btnSelectTank3, btnApple;// menu so 2
	List<TextureRegion> listApple;
	
	int indexStageChoosed = -1;
	List<PlayButton> listButtonStage;
	List<Float> listKC;

	PlayButton btnFishA1, btnFishA4, btnFishA5, btnFishA6, btnFishA3,// menu so
																		// 3
			btnFishA7, btnBackTankMenu;
	List<ObjectAnimation> listFishCharacter;

	PlayButton btnScene1, btnScene2, btnScene3, btnScene4, btnScene5,
			btnScene6;
	List<PlayButton> listButtonScene;// button choose scene

	List<PlayButton> listButtonMenuItem;// button choose stage
	//
	Group mainGroup;
	Group selectGroup, itemGroup;
	Group Tank1Group;

	ObjectAnimation a1;
	float time = 0;

	List<ObjectAnimation> listAnimation;

	List<Bubble> listBubble;
	World world;

	// Image imgSelectATank;
	Vector2 sizeSelectAtank;

	boolean GotoMenuSelectStage=false;
	public MainMenu(Game game, boolean gotoMenuSelectStage) {
		super(game);

		GotoMenuSelectStage=gotoMenuSelectStage;
		mainGroup = new Group();
		Image img = new Image(Assets.background);
		img.setSize(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
		mainGroup.addActor(img);

		selectGroup = new Group();
		img = new Image(Assets.background);
		img.setSize(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
		selectGroup.setPosition(VIEWPORT_WIDTH, 0);
		selectGroup.addActor(img);

		Tank1Group = new Group();
		img = new Image(Assets.background);
		img.setSize(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
		Tank1Group.addActor(img);
		Tank1Group.setPosition(VIEWPORT_WIDTH, 0);

		listAnimation = new ArrayList<ObjectAnimation>();
		listBubble = new ArrayList<Bubble>();
		world = new World(new Vector2(0, -0.5f), true);

		stageReader = new FishHookStageReader();
		stageReader.LoadFile("stage.xml");
		// TODO Auto-generated constructor stub
		Audio.musicBackground.play(0.4f);
		Audio.musicBackground.loop();

	}

	void addBubble() {
		Random r = new Random();
		Vector2 position = new Vector2(r.nextInt() % VIEWPORT_WIDTH, 0);
		int h = r.nextInt() % 20;
		Bubble bubble = new Bubble(Assets.lstBubble, position,
				new Vector2(h, h));
		bubble.init(world, BodyType.DynamicBody);
		Color c = bubble.getColor();
		bubble.setColor(c.r, c.g, c.b, 0.5f);
		stage.addActor(bubble);
		listBubble.add(bubble);
	}

	void removeBubble(Bubble bubble) {
		bubble.destroy();
		stage.getRoot().removeActor(bubble);
		listBubble.remove(bubble);
	}

	void addImageNoAnimation() {
		// play
		btnPlay = new PlayButton(Assets.play, new Vector2(
				VIEWPORT_WIDTH / 7.5f * 3, VIEWPORT_HEIGHT / 6), new Vector2(
				VIEWPORT_WIDTH / 4.2f, VIEWPORT_WIDTH / 4.9f), new Vector2(
				VIEWPORT_WIDTH, VIEWPORT_HEIGHT));

		// replay
		btnReplay = new PlayButton(Assets.rePlay, new Vector2(0,
				VIEWPORT_HEIGHT / 13f * 10), new Vector2(VIEWPORT_WIDTH / 13,
				VIEWPORT_HEIGHT / 13f * 3), new Vector2(VIEWPORT_WIDTH,
				VIEWPORT_HEIGHT));

		// setting
		btnSetting = new PlayButton(Assets.setting, new Vector2(0, 0),
				new Vector2(VIEWPORT_WIDTH / 15, VIEWPORT_WIDTH / 15),
				new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));

		// Watch fish hooks on
		Image imgWatch = new Image(Assets.watch);
		imgWatch.setSize(VIEWPORT_WIDTH / 12f * 5, VIEWPORT_WIDTH / 13);
		imgWatch.setPosition(VIEWPORT_WIDTH / 24f * 7, 0);

		// disney
		btnDisney = new PlayButton(Assets.disney, new Vector2(
				VIEWPORT_WIDTH / 13f * 12, 0), new Vector2(VIEWPORT_WIDTH / 15,
				VIEWPORT_WIDTH / 15), new Vector2(VIEWPORT_WIDTH,
				VIEWPORT_HEIGHT));
		// stage.addActor(btnDisney);
		// i
		btnI = new PlayButton(Assets.i, new Vector2(VIEWPORT_WIDTH / 15f * 14,
				VIEWPORT_HEIGHT - VIEWPORT_WIDTH / 15f), new Vector2(
				VIEWPORT_WIDTH / 15, VIEWPORT_WIDTH / 15), new Vector2(
				VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		// stage.addActor(btnI);

		mainGroup.addActor(btnPlay);
		mainGroup.addActor(btnReplay);
		mainGroup.addActor(btnSetting);
		mainGroup.addActor(imgWatch);
		mainGroup.addActor(btnDisney);
		mainGroup.addActor(btnI);
	}

	void addImageAnimation() {

		Group gr1;
		// string fish hooks
		Image imgFishHooks = new Image(Assets.stringFishHooks);
		imgFishHooks
				.setSize(VIEWPORT_WIDTH / 3.5f, VIEWPORT_HEIGHT / 11.5f * 5);
		gr1 = new Group();
		gr1.addActor(imgFishHooks);
		gr1.setPosition(VIEWPORT_WIDTH / 4, VIEWPORT_HEIGHT);
		gr1.addAction(Actions.moveTo(VIEWPORT_WIDTH / 8 * 3,
				VIEWPORT_HEIGHT / 20 * 11, 0.5f, Interpolation.pow4));
		// stage.addActor(gr1);
		mainGroup.addActor(gr1);

		List<Vector2> list;
		// a1
		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 6.2f,
				VIEWPORT_HEIGHT / 23.8f * 14));
		list.add(new Vector2(VIEWPORT_WIDTH / 7, VIEWPORT_HEIGHT / 24 * 14));
		a1 = new ObjectAnimation(Assets.a1, new Vector2((-1) * VIEWPORT_WIDTH
				/ 6, VIEWPORT_HEIGHT + 50), new Vector2(VIEWPORT_WIDTH / 8,
				VIEWPORT_HEIGHT / 3), new Vector2(VIEWPORT_WIDTH / 7,
				VIEWPORT_HEIGHT / 24 * 14), Interpolation.pow4, list, 1f);
		listAnimation.add(a1);
		mainGroup.addActor(a1);
		// a2

		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 7.3f * 5,
				VIEWPORT_HEIGHT / 8.4f * 5));
		list.add(new Vector2(VIEWPORT_WIDTH / 6.8f * 5,
				VIEWPORT_HEIGHT / 7.8f * 5));
		list.add(new Vector2(VIEWPORT_WIDTH / 7 * 5, VIEWPORT_HEIGHT / 8 * 5));
		a1 = new ObjectAnimation(Assets.a2, new Vector2(VIEWPORT_WIDTH,
				VIEWPORT_HEIGHT), new Vector2(VIEWPORT_WIDTH / 4f,
				VIEWPORT_HEIGHT / 3.6f), new Vector2(VIEWPORT_WIDTH / 7 * 5,
				VIEWPORT_HEIGHT / 8 * 5), Interpolation.pow4, list, 1f);
		listAnimation.add(a1);
		mainGroup.addActor(a1);

		// a3

		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 9.2f * 7,
				VIEWPORT_HEIGHT / 6.2f * 2));
		list.add(new Vector2(VIEWPORT_WIDTH / 9 * 7, VIEWPORT_HEIGHT / 6 * 2));
		a1 = new ObjectAnimation(Assets.a3, new Vector2(VIEWPORT_WIDTH,
				VIEWPORT_HEIGHT / 5 * 2), new Vector2(VIEWPORT_WIDTH / 10,
				VIEWPORT_HEIGHT / 4f), new Vector2(VIEWPORT_WIDTH / 9 * 7,
				VIEWPORT_HEIGHT / 6 * 2), Interpolation.pow4, list, 1f);
		listAnimation.add(a1);
		mainGroup.addActor(a1);

		// a4

		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 10.3f * 7,
				VIEWPORT_HEIGHT / 11.5f * 3));
		list.add(new Vector2(VIEWPORT_WIDTH / 10f * 7,
				VIEWPORT_HEIGHT / 11f * 3));
		a1 = new ObjectAnimation(Assets.a4, new Vector2(VIEWPORT_WIDTH,
				VIEWPORT_HEIGHT / 10 * 4), new Vector2(VIEWPORT_WIDTH / 9,
				VIEWPORT_HEIGHT / 9.5f), new Vector2(VIEWPORT_WIDTH / 10f * 7,
				VIEWPORT_HEIGHT / 11f * 3), Interpolation.pow4, list, 1f);
		listAnimation.add(a1);
		mainGroup.addActor(a1);

		// a5

		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 11.3f * 3,
				VIEWPORT_HEIGHT / 7.8f * 2));
		list.add(new Vector2(VIEWPORT_WIDTH / 12 * 3, VIEWPORT_HEIGHT / 7 * 2));
		a1 = new ObjectAnimation(Assets.a5, new Vector2(0,
				VIEWPORT_HEIGHT / 7 * 2), new Vector2(VIEWPORT_WIDTH / 12.5f,
				VIEWPORT_HEIGHT / 4.5f), new Vector2(VIEWPORT_WIDTH / 12 * 3,
				VIEWPORT_HEIGHT / 7 * 2), Interpolation.pow4, list, 1f);
		listAnimation.add(a1);
		mainGroup.addActor(a1);

		// a6

		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 12.3f * 2, VIEWPORT_HEIGHT / 5));
		list.add(new Vector2(VIEWPORT_WIDTH / 13f * 2, VIEWPORT_HEIGHT / 5));
		a1 = new ObjectAnimation(Assets.a6,
				new Vector2(0, VIEWPORT_HEIGHT / 4), new Vector2(
						VIEWPORT_WIDTH / 13f, VIEWPORT_HEIGHT / 4.5f),
				new Vector2(VIEWPORT_WIDTH / 13f * 2, VIEWPORT_HEIGHT / 5),
				Interpolation.pow4, list, 1f);
		listAnimation.add(a1);
		mainGroup.addActor(a1);

		// a7

		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 13.3f, VIEWPORT_HEIGHT / 6.8f * 2));
		list.add(new Vector2(VIEWPORT_WIDTH / 14, VIEWPORT_HEIGHT / 6 * 2));
		a1 = new ObjectAnimation(Assets.a7, new Vector2(0,
				VIEWPORT_HEIGHT / 5 * 2), new Vector2(VIEWPORT_WIDTH / 12,
				VIEWPORT_HEIGHT / 4), new Vector2(VIEWPORT_WIDTH / 14,
				VIEWPORT_HEIGHT / 6 * 2), Interpolation.pow4, list, 1f);
		listAnimation.add(a1);
		mainGroup.addActor(a1);

	}

	void initMainMenu() {
		// image no animation: anh ko chuyen dong
		addImageNoAnimation();

		// image animation: anh co chuyen dong
		addImageAnimation();
		//
	}

	void initTankMenu() {
		Image img;
		img = new Image(Assets.table);
		img.setSize(VIEWPORT_WIDTH, VIEWPORT_HEIGHT / 3 * 2);
		img.setPosition(0, VIEWPORT_HEIGHT / 3);
		Tank1Group.addActor(img);

		// btn scene
		btnScene1 = new PlayButton(Assets.so1, new Vector2(
				VIEWPORT_WIDTH / 13.2f, VIEWPORT_HEIGHT / 12 * 7.8f),
				new Vector2(VIEWPORT_WIDTH / 7, VIEWPORT_HEIGHT / 4.4f),
				new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		btnScene1.imgClicked = Assets.so1Clicked;
		btnScene1.show = false;

		btnScene2 = new PlayButton(Assets.so2, new Vector2(
				VIEWPORT_WIDTH / 3.9f, VIEWPORT_HEIGHT / 12 * 7.8f),
				new Vector2(VIEWPORT_WIDTH / 7, VIEWPORT_HEIGHT / 4.4f),
				new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		btnScene2.imgClicked = Assets.so1Clicked;
		btnScene2.show = false;

		btnScene3 = new PlayButton(Assets.so3, new Vector2(
				VIEWPORT_WIDTH / 2.22f, VIEWPORT_HEIGHT / 12 * 7.8f),
				new Vector2(VIEWPORT_WIDTH / 7, VIEWPORT_HEIGHT / 4.4f),
				new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		btnScene3.imgClicked = Assets.so1Clicked;
		btnScene3.show = false;

		btnScene4 = new PlayButton(Assets.so4, new Vector2(VIEWPORT_WIDTH / 8f,
				VIEWPORT_HEIGHT / 2.4f), new Vector2(VIEWPORT_WIDTH / 7,
				VIEWPORT_HEIGHT / 4.4f), new Vector2(VIEWPORT_WIDTH,
				VIEWPORT_HEIGHT));
		btnScene4.imgClicked = Assets.so1Clicked;
		btnScene4.show = false;

		btnScene5 = new PlayButton(Assets.so5, new Vector2(
				VIEWPORT_WIDTH / 3.25f, VIEWPORT_HEIGHT / 2.4f), new Vector2(
				VIEWPORT_WIDTH / 7, VIEWPORT_HEIGHT / 4.4f), new Vector2(
				VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		btnScene5.imgClicked = Assets.so1Clicked;
		btnScene5.show = false;

		btnScene6 = new PlayButton(Assets.so6, new Vector2(
				VIEWPORT_WIDTH / 2.0f, VIEWPORT_HEIGHT / 2.4f), new Vector2(
				VIEWPORT_WIDTH / 7, VIEWPORT_HEIGHT / 4.4f), new Vector2(
				VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		btnScene6.imgClicked = Assets.so1Clicked;
		btnScene6.show = false;

		listButtonScene = new ArrayList<PlayButton>();
		listButtonScene.add(btnScene1);
		listButtonScene.add(btnScene2);
		listButtonScene.add(btnScene3);
		listButtonScene.add(btnScene4);
		listButtonScene.add(btnScene5);
		listButtonScene.add(btnScene6);
		//

		listFishCharacter = new ArrayList<ObjectAnimation>();
		// a4
		addFishCharacter(Assets.a4, new Vector2(VIEWPORT_WIDTH / 6,
				VIEWPORT_HEIGHT / 17), new Vector2(VIEWPORT_WIDTH / 6,
				VIEWPORT_HEIGHT / 5));
		// a5
		addFishCharacter(Assets.a5, new Vector2(VIEWPORT_WIDTH / 3,
				VIEWPORT_HEIGHT / 17), new Vector2(VIEWPORT_WIDTH / 10,
				VIEWPORT_HEIGHT / 4));
		// a1
		addFishCharacter(Assets.a1, new Vector2(VIEWPORT_WIDTH / 16 * 7,
				VIEWPORT_HEIGHT / 17), new Vector2(VIEWPORT_WIDTH / 10,
				VIEWPORT_HEIGHT / 4));

		List<Vector2> list;
		ObjectAnimation pickImg;
		list = new ArrayList<Vector2>();
		list.add(new Vector2(VIEWPORT_WIDTH / 32 * 28.2f, VIEWPORT_HEIGHT / 17));
		list.add(new Vector2(VIEWPORT_WIDTH / 32 * 27.9f, VIEWPORT_HEIGHT / 17));
		pickImg = new ObjectAnimation(Assets.pickafish, new Vector2(
				VIEWPORT_WIDTH / 32 * 28, VIEWPORT_HEIGHT / 17), new Vector2(
				VIEWPORT_WIDTH / 9, VIEWPORT_HEIGHT / 4), new Vector2(
				VIEWPORT_WIDTH / 32 * 27.9f, VIEWPORT_HEIGHT / 17),
				Interpolation.pow4, list, 0.8f);
		pickImg.delta = 0.3f;
		listAnimation.add(pickImg);
		// a7
		addFishCharacter(Assets.a7, new Vector2(VIEWPORT_WIDTH / 16 * 9,
				VIEWPORT_HEIGHT / 17), new Vector2(VIEWPORT_WIDTH / 10,
				VIEWPORT_HEIGHT / 4));
		// a6
		addFishCharacter(Assets.a6, new Vector2(VIEWPORT_WIDTH / 32 * 21,
				VIEWPORT_HEIGHT / 17), new Vector2(VIEWPORT_WIDTH / 11,
				VIEWPORT_HEIGHT / 5));
		// a3
		addFishCharacter(Assets.a3, new Vector2(VIEWPORT_WIDTH / 32 * 24,
				VIEWPORT_HEIGHT / 17), new Vector2(VIEWPORT_WIDTH / 10,
				VIEWPORT_HEIGHT / 4));

		btnBackTankMenu = new PlayButton(Assets.back, new Vector2(
				VIEWPORT_WIDTH / 20, VIEWPORT_HEIGHT / 17), new Vector2(
				VIEWPORT_HEIGHT / 5, VIEWPORT_HEIGHT / 5), new Vector2(
				VIEWPORT_WIDTH, VIEWPORT_HEIGHT));

		//Tank1Group.addActor(a1);
		//Tank1Group.addActor(btnFishA3);
		//Tank1Group.addActor(btnFishA4);
		Tank1Group.addActor(pickImg);
		//Tank1Group.addActor(btnFishA7);
		//Tank1Group.addActor(btnFishA5);
		//Tank1Group.addActor(btnFishA6);
		Tank1Group.addActor(btnBackTankMenu);
		Tank1Group.addActor(btnScene1);
		Tank1Group.addActor(btnScene2);
		Tank1Group.addActor(btnScene3);
		Tank1Group.addActor(btnScene4);
		Tank1Group.addActor(btnScene5);
		Tank1Group.addActor(btnScene6);
	}

	void addFishCharacter(TextureRegion img, Vector2 pos, Vector2 size) {
		ObjectAnimation fish;
		List<Vector2> list;
		// a4
		list = new ArrayList<Vector2>();
		list.add(new Vector2(pos.x, VIEWPORT_HEIGHT / 12));
		list.add(new Vector2(pos.x, VIEWPORT_HEIGHT / 30));
		fish = new ObjectAnimation(img, pos, size, new Vector2(pos.x,
				VIEWPORT_HEIGHT / 30), Interpolation.pow4, list, 0.5f);
		fish.delta = 0.7f;
		fish.EnableChoose = true;
		fish.sizeScreen = new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT);
		listFishCharacter.add(fish);
		fish.DisableAnimation();
		Tank1Group.addActor(fish);
	}

	MySprite imgselect;
	//MySprite apsc;
	float kc_btnStage1, kc_btnStage2, kc_btnStage3;

	void initListApple()
	{
		listApple=new ArrayList<TextureRegion>();
		listApple.add(Assets.ap0);
		listApple.add(Assets.ap1);
		listApple.add(Assets.ap2);
		listApple.add(Assets.ap3);
		listApple.add(Assets.ap4);
		listApple.add(Assets.ap5);
		listApple.add(Assets.ap6);
		listApple.add(Assets.ap7);
		listApple.add(Assets.ap8);
		listApple.add(Assets.ap9);
		listApple.add(Assets.ap10);
		listApple.add(Assets.ap11);
		listApple.add(Assets.ap12);
		listApple.add(Assets.ap13);
		listApple.add(Assets.ap14);
		listApple.add(Assets.ap15);
		listApple.add(Assets.ap16);
		listApple.add(Assets.ap17);
		listApple.add(Assets.ap18);
	}
	void initSelectMenu() {
		btnBackSelectMenu = new PlayButton(Assets.back, new Vector2(
				VIEWPORT_WIDTH / 20, VIEWPORT_HEIGHT / 17), new Vector2(
				VIEWPORT_HEIGHT / 5, VIEWPORT_HEIGHT / 5), new Vector2(
				VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		selectGroup.addActor(btnBackSelectMenu);

		/*apsc = new MySprite(Assets.listap, new Vector2(VIEWPORT_WIDTH
				- VIEWPORT_HEIGHT / 4, VIEWPORT_HEIGHT / 8));
		apsc.setSize(VIEWPORT_HEIGHT / 5, VIEWPORT_HEIGHT / 5);
		selectGroup.addActor(apsc);*/
		
		btnApple = new PlayButton(Assets.ap0, new Vector2(VIEWPORT_WIDTH- VIEWPORT_HEIGHT / 2.5f, VIEWPORT_HEIGHT / 10f),
				new Vector2(VIEWPORT_HEIGHT / 4.8f, VIEWPORT_HEIGHT / 4.8f), new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));
		selectGroup.addActor(btnApple);
		initListApple();
		
		imgselect = new MySprite(Assets.listSelectTank, new Vector2(
				VIEWPORT_WIDTH / 2, VIEWPORT_HEIGHT / 5 * 4.3f));
		imgselect.setSize(VIEWPORT_WIDTH / 16f * 7, VIEWPORT_HEIGHT / 6);
		selectGroup.addActor(imgselect);

		itemGroup = new Group();
		itemGroup.setPosition(VIEWPORT_WIDTH, 0);
		// itemGroup.setPosition(selectGroup.getX(), selectGroup.getY());
		listButtonMenuItem = new ArrayList<PlayButton>();

		btnSelectTank1 = new PlayButton(Assets.tank1, new Vector2(
				VIEWPORT_WIDTH / 3.5f, VIEWPORT_HEIGHT / 17), new Vector2(
				VIEWPORT_WIDTH / 16 * 6, VIEWPORT_HEIGHT / 4.2f * 3),
				new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));

		btnSelectTank2 = new PlayButton(Assets.tank1, new Vector2(
				VIEWPORT_WIDTH / 1.2f, VIEWPORT_HEIGHT / 17), new Vector2(
				VIEWPORT_WIDTH / 16 * 6, VIEWPORT_HEIGHT / 4.2f * 3),
				new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));

		btnSelectTank3 = new PlayButton(
				Assets.tank1,
				new Vector2(VIEWPORT_WIDTH * (1 / 3.5f + 1),
						VIEWPORT_HEIGHT / 17),
				new Vector2(VIEWPORT_WIDTH / 16 * 6, VIEWPORT_HEIGHT / 4.2f * 3),
				new Vector2(VIEWPORT_WIDTH, VIEWPORT_HEIGHT));

		listButtonStage = new ArrayList<PlayButton>();
		listButtonStage.add(btnSelectTank1);
		listButtonStage.add(btnSelectTank2);
		listButtonStage.add(btnSelectTank3);

		itemGroup.addActor(btnSelectTank1);
		itemGroup.addActor(btnSelectTank2);
		itemGroup.addActor(btnSelectTank3);
		selectGroup.addActor(itemGroup);

		listKC = new ArrayList<Float>();
		listKC.add(btnSelectTank1.position.x);
		listKC.add(btnSelectTank2.position.x);
		listKC.add(btnSelectTank3.position.x);
		
	}

	Vector2 toaDoCu = Vector2.Zero, toaDoMoi;
	boolean touchUp = true;
	boolean canNext = true, canPrev = false;
	int indexMn = 0;
	float posMN_X = 0;
	int t = 0;
	boolean r = false;

	void detectDragOnMenuItem() {
		// drag
		if (Gdx.input.isTouched() && isSelectMenu && r == false) {
			if (!touchUp) {
				toaDoMoi = new Vector2(Gdx.input.getX(), Gdx.input.getY());
				if ((toaDoCu.x - toaDoMoi.x) > 0 && canNext) {
					posMN_X -= (VIEWPORT_WIDTH / 2);

					UpdateItemGroup(posMN_X);

					indexMn++;
					canPrev = true;
					if (indexMn >= 2) {
						indexMn = 2;
						canNext = false;
					}
					r = true;
				}

				if ((toaDoCu.x - toaDoMoi.x) < 0 && canPrev) {
					posMN_X += (VIEWPORT_WIDTH / 2);
					UpdateItemGroup(posMN_X);

					indexMn--;
					canNext = true;
					if (indexMn <= 0) {
						indexMn = 0;
						canPrev = false;
					}
					r = true;
				}

			}
			touchUp = false;
			toaDoCu = new Vector2(Gdx.input.getX(), Gdx.input.getY());
		} else
			touchUp = true;
		// end drag
		if (isSelectMenu == false) {
			canNext = true;
			indexMn = 0;
			canPrev = false;
			posMN_X = 0;
		}
		// khoang thoi gian giua 2 lan click
		if (r) {
			t++;
			if (t > 20) {
				t = 0;
				r = false;
			}
		}
	}

	void detectInput() {
		// btnScene1.Update();

		detectDragOnMenuItem();

		if(GotoMenuSelectStage)
		{
			isMainMenu = false;
			isSelectMenu = true;
			mainGroup.addAction(Actions.moveTo(-800, 0, 0.5f,
					Interpolation.swingOut));

			selectGroup.addAction(Actions.moveTo(0, 0, 0.5f,
					Interpolation.swingOut));
			UpdateItemGroup(0);
			GotoMenuSelectStage=false;
		}
		if (Gdx.input.justTouched()) {

			Vector2 pos = new Vector2(Gdx.input.getX(), Gdx.input.getY());

			if (btnPlay.IsClicked(pos) && isMainMenu) {
				Audio.buttonClick.play(0.8f);
				isMainMenu = false;
				isSelectMenu = true;
				mainGroup.addAction(Actions.moveTo(-800, 0, 0.5f,
						Interpolation.swingOut));

				selectGroup.addAction(Actions.moveTo(0, 0, 0.5f,
						Interpolation.swingOut));
				UpdateItemGroup(0);
			} else if (btnBackSelectMenu.IsClicked(pos) && isSelectMenu) {
				Audio.buttonClick.play(0.8f);
				isMainMenu = true;
				isSelectMenu = false;
				mainGroup.addAction(Actions.moveTo(0, 0, 0.5f,
						Interpolation.swingOut));

				UpdateItemGroup(VIEWPORT_WIDTH);
				selectGroup.addAction(Actions.moveTo(VIEWPORT_WIDTH, 0, 0.5f,
						Interpolation.swingOut));

			} else

			if (buttonItemIsCliked(pos)) {
			}

			else if (btnBackTankMenu.IsClicked(pos) && isTankMenu) {
				Audio.buttonClick.play(0.8f);
				isTankMenu = false;
				isSelectMenu = true;
				Tank1Group.addAction(Actions.moveTo(-VIEWPORT_WIDTH, 0, 0.5f,
						Interpolation.swingOut));

				selectGroup.addAction(Actions.moveTo(0, 0, 0.5f,
						Interpolation.swingOut));
				UpdateItemGroup(0);
				
				showButtonScene=false;
				dem=0;
				
			}/*
			 * else if (btnScene1.IsClicked(pos) && isTankMenu) {
			 * Audio.buttonClick.play(0.8f); game.setScreen(new GameScreen(game,
			 * 1)); }
			 */

			checkClickScene(pos);
			checkFishClicked(pos);
			
		}
		showButtonScene();
	}

	void checkFishClicked(Vector2 pos) {
		if (isTankMenu) {
			int idxClick=-2;
			for (int i = 0; i < listFishCharacter.size(); i++) {
				if (listFishCharacter.get(i).IsClicked(pos)) {
					idxClick=i;
					///do something
				}
			}
			
			if(idxClick!=-2)
			{
				for (int i = 0; i < listFishCharacter.size(); i++) {
					if (i!=idxClick) {
						listFishCharacter.get(i).DisableAnimation();
						///do something
					}
				}
			}
		}
	}

	void checkClickScene(Vector2 pos) {
		if (isTankMenu) {
			for (int i = 0; i < listButtonScene.size(); i++) {
				if (listButtonScene.get(i).IsClicked(pos)
						&& listButtonScene.get(i).show) {
					Audio.buttonClick.play(0.8f);
					game.setScreen(new GameScreen(game, i + 1 + 6
							* indexStageChoosed));
				}
			}
		} else
		{
			
			for (PlayButton btn : listButtonScene) {
				btn.hideButton();
			}
		}
	}

	int dem=0;
	void showButtonScene() 
	{
		boolean showBTN = false;
		if(showButtonScene)
		{
			
			if(++dem ==10)
				showBTN=true;
			
		}	
		if(showBTN)
		{
		int n = stageReader.Get_nSceneUnlock(indexStageChoosed);
		for (int i = 0; i < n; i++)
			listButtonScene.get(i).showButton();
		}
	}

	void UpdatePositionListButtonStage(float pos_itemGroupX) {
		for (int i = 0; i < listButtonStage.size(); i++) {
			listButtonStage.get(i).position.x = pos_itemGroupX + listKC.get(i);
		}
	}

	void UpdateItemGroup(float moveto_X) {
		itemGroup.addAction(Actions.moveTo(moveto_X, 0, 1.5f,
				Interpolation.swingOut));
		UpdatePositionListButtonStage(moveto_X);
	}

	boolean showButtonScene=false;
	boolean buttonItemIsCliked(Vector2 pos) {
		boolean check = false;
		for (int idx = 0; idx < listButtonStage.size(); idx++) {
			if (listButtonStage.get(idx).IsClicked(pos) && isSelectMenu) {
				Audio.buttonClick.play(0.8f);
				isTankMenu = true;
				isSelectMenu = false;
				indexStageChoosed = idx;
				

				Tank1Group.addAction(Actions.moveTo(0, 0, 0.5f,
						Interpolation.swingOut));

				selectGroup.addAction(Actions.moveTo(VIEWPORT_WIDTH, 0, 0.5f,
						Interpolation.swingOut));
				UpdateItemGroup(VIEWPORT_WIDTH);

				check = true;
				showButtonScene=true;
				
			}
		}
		return check;
	}

	@Override
	public void show() {
		// main menu
		initMainMenu();
		stage.addActor(mainGroup);

		// select menu
		initSelectMenu();
		stage.addActor(selectGroup);

		initTankMenu();
		// hide button scene, show it in load file xml
		for (PlayButton btn : listButtonScene) {
			btn.hideButton();
		}
		//listFishCharacter.get(2).EnableAnimation();
		stage.addActor(Tank1Group);

		super.show();
	}

	float scaleDelta = 1.5f;

	boolean isMainMenu = true, isSelectMenu = false, isTankMenu = false;

	@Override
	public void render(float delta) {

		// TODO Auto-generated method stub

		imgselect.drawAnimation(delta / 2.5f);
		//apsc.drawAnimation(delta / 8);

		for (int i = 0; i < listAnimation.size(); i++)
			listAnimation.get(i).Update();

		for (int i = 0; i < listFishCharacter.size(); i++) {
			listFishCharacter.get(i).Update();
		}

		detectInput();

		world.step(Global.BOX_STEP, Global.BOX_VELOCITY_ITERATIONS,
				Global.BOX_POSITION_ITERATIONS);
		world.clearForces();
		addBubble();
		for (Bubble bubble : listBubble) {
			bubble.update();
			bubble.drawAnimation(delta / 5);
		}

		if (listBubble.size() > 300) {
			for (int i = 50; i > 1; i--)
				listBubble.remove(i);
		}

		
		int indexStage = stageReader.Get_nStageUnlock()-1;
		int sl = stageReader.Get_nSceneUnlock(indexStage)+6*indexStage-1;
		if(sl<=18)
		{
			btnApple.SetImage(listApple.get(sl));
		}
		/*//
		SpriteBatch spriteBatch;
        BitmapFont font = new BitmapFont();
        CharSequence str = "Hello World!";
        spriteBatch = new SpriteBatch();

        Gdx.graphics.getGL10().glClearColor(0, 0, 0, 0);
		Gdx.graphics.getGL10().glClear(Gdx.gl10.GL_COLOR_BUFFER_BIT);
        spriteBatch.begin();
        font.setColor(1.0f, 1.0f, 1.0f, 1.0f);
        font.draw(spriteBatch, str, 10, 400);
        spriteBatch.end();
		//*/
		super.render(delta);
	}

}
