package com.G6.Screen;

import java.util.ArrayList;
import java.util.List;

import com.G6.Helper.FishHookMapReader;
import com.G6.Helper.FishHookMapReader.MapInfo;
import com.G6.Helper.FishHookMapReader.ObjectInfo;
import com.G6.Helper.FishHookMapReader.ObjectName;
import com.G6.Helper.FishHookStageReader;
import com.G6.Object.Apple;
import com.G6.Object.Bubble;
import com.G6.Object.MyButton;
import com.G6.Object.MySprite;
import com.G6.Object.Player;
import com.G6.Object.Seesaw;
import com.G6.Object.Target;
import com.G6.Object.Turtle;
import com.G6.assets.Assets;
import com.G6.assets.Global;
import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef.BodyType;
import com.badlogic.gdx.physics.box2d.Contact;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.scenes.scene2d.actions.Actions;
import com.badlogic.gdx.scenes.scene2d.ui.Image;

/**
 * The hien game va cac logic trong game
 * @author Tha^n
 *
 */
public class GameScreen extends BaseScreen {
	/**
	 * doi tuong vat ly world, chua tat ca cac doi tuong vat ly con
	 */
	World world = null;
	
	/**
	 * danh sach cac qua bong bong
	 */
	List<Bubble> lstBubble;
	
	/**
	 * Danh sac cac qua tao
	 */
	ArrayList<Apple> lstApple;
	
	/**
	 * danh sach cac cau bap benh
	 */
	ArrayList<Seesaw> lstSeesaw;
	
	/**
	 * danh sach cac con rua
	 */
	ArrayList<Turtle> lstTurtle;
	
	/**
	 * nhan vat choi
	 */
	Player player;
	
	/**
	 * dich den
	 */
	Target target;
	
	/**
	 * Diem cua nhan vat
	 */
	int score = 0;
	
	/**
	 * vi tri dich den cuoi cung
	 */
	Body targetPoint;
	
	/**
	 * level cua nguoi choi
	 */
	public static int level;
	
	/**
	 * button replay trong man hinh playing
	 */
	MyButton replayButtonPlaying;
	
	/**
	 * button menu trong man hinh playing
	 */
	MyButton menuButtonPlaying;
	
	/**
	 * button replay trong man hinh win
	 */
	MyButton replayButtonWin;
	
	/**
	 * button menu trong man hinh win
	 */
	MyButton menuButtonWin;
	
	/**
	 * button next trong man hinh win
	 */
	MyButton nextButtonWin;
	
	
	/**
	 * cac trang thai trong game
	 * @author Tha^n
	 *
	 */
	enum GameState
	{
		/**
		 * Trang thai thang
		 */
		WIN,
		
		/**
		 * trang thai thua
		 */
		LOSE,
		
		/**
		 * trang thai dang choi
		 */
		PLAYING
	};
	
	/**
	 * trang thai game
	 */
	public GameState state;
	
	/**
	 * doi tuong dung de doc map
	 */
	private FishHookMapReader mapReader;
	
	/**
	 * Khoi tao game voi level cho truoc
	 * @param game doi tuong game chinh
	 * @param level level can the hien
	 */
	public GameScreen(Game game, int level) {
		super(game);
		
		mapReader = new FishHookMapReader();
		mapReader.LoadConfig("MapConfig/Config.xml");
		
		state = GameState.PLAYING;
		Gdx.input.setInputProcessor(stage);
		this.level = level;
		createWorld(this.level);
	}
	
	/**
	 * tao tat ca cac doi tuong vat ly
	 * @param level level can the hien
	 */
	public void createWorld(int level)
	{
		if(world != null)
		{
			world.dispose();
		}
		world = new World(new Vector2(0, -2f), true);
		stage.clear();
		stage.addActor(new Image(Assets.background));
		replayButtonPlaying = new MyButton(Assets.atlas.findRegion("button/smallreplay"), new Vector2(700, 30));
		stage.addActor(replayButtonPlaying);
		menuButtonPlaying = new MyButton(Assets.atlas.findRegion("button/smallmenu"), new Vector2(760, 30));
		stage.addActor(menuButtonPlaying);
		
		lstBubble = new ArrayList<Bubble>();
		lstApple = new ArrayList<Apple>();
		lstSeesaw = new ArrayList<Seesaw>();
		lstTurtle = new ArrayList<Turtle>();
		score = 0;		
		
		MapInfo mapinfo = mapReader.GetMap(level - 1);
		for(int i = 0; i < mapinfo.count; i++)
		{
			ObjectInfo obj = mapinfo.GetObject(i);
			if(obj.objName == ObjectName.Apple)
			{
				Apple apple = new Apple(Assets.atlas.findRegion("object/apple"), new Vector2(obj.cood.x, obj.cood.y), true);
				stage.addActor(apple);
				lstApple.add(apple);
			}
			else if(obj.objName == ObjectName.Seesaw)
			{
				Seesaw seesaw = new Seesaw(Assets.atlas.findRegion("object/seesaw"), new Vector2(obj.cood.x, obj.cood.y));
				seesaw.init(world);
				stage.addActor(seesaw);
				lstSeesaw.add(seesaw);
			}
			else if(obj.objName == ObjectName.Player)
			{
				player = new Player(Assets.player, new Vector2(obj.cood.x, obj.cood.y));
				player.init(world, BodyType.DynamicBody);
				stage.addActor(player);		
			}
			else if(obj.objName == ObjectName.Target)
			{
				target = new Target(Assets.target, new Vector2(obj.cood.x, obj.cood.y), -obj.angle);
				target.init(world, BodyType.StaticBody);
				stage.addActor(target);
			}
			else if(obj.objName == ObjectName.Turtle)
			{
				Turtle turtle = new Turtle(Assets.lstTurtle, new Vector2(obj.cood.x, obj.cood.y), -obj.angle, false);
				turtle.init(world, BodyType.StaticBody);
				stage.addActor(turtle);
				lstTurtle.add(turtle);
			}
			
		}
		
		targetPoint = target.getTargetPoint();
		targetPoint.setUserData("TargetPoint");
	}
	
	@Override
	public void render(float delta) {
		super.render(delta);
		
		// TODO Auto-generated method stub		
		update();
		/*
		 * Thuc thi cac hoat dong cua cac vat the trong the gioi Box2D
		 */
		world.step(Global.BOX_STEP, Global.BOX_VELOCITY_ITERATIONS, Global.BOX_POSITION_ITERATIONS);
		world.clearForces();
		
		draw(delta);
	}

	/**
	 * update lai tat ca cac doi tuong duoc goi trong ham render
	 */
	private void update() {
		// TODO Auto-generated method stub

		if(state == GameState.PLAYING)
		{
			updatePlaying();
		} else
		if(state == GameState.WIN)
		{
			updateWin();
		} else
		if(state == GameState.LOSE)
		{
			updateLose();
		}
	}
		
	/**
	 * update lai tat ca cac doi tuong o trang thai game la Playing
	 */
	private void updatePlaying() {
		if(Gdx.input.justTouched())
		{
			Vector2 touchPosition = Global.getTouchPosition();
			
			if(replayButtonPlaying.isClick(touchPosition))
			{
				createWorld(GameScreen.level);
				changeState(GameState.PLAYING);
				return;
			}
			
			if(menuButtonPlaying.isClick(touchPosition))
			{
				game.setScreen(new MainMenu(game, false));
				return;
			}
			
			boolean isBubbleClicked = false;
			for(int i = lstBubble.size() - 1; i >= 0; i--)
			{
				Bubble bubble = lstBubble.get(i);
				if(bubble.isClick(touchPosition.x, touchPosition.y))
				{
					isBubbleClicked = true;
					bubble.destroy();
					stage.getRoot().removeActor(bubble);
					lstBubble.remove(bubble);
				}
			}
			
			if(!isBubbleClicked)
			{
				if(player.isClick(touchPosition.x, touchPosition.y))
				{
					player.changState();
				}
				else
				{
					Vector2 position = new Vector2(touchPosition.x, touchPosition.y);
					Bubble bubble = new Bubble(Assets.lstBubble, position, new Vector2(100, 100));
					bubble.init(world, BodyType.DynamicBody);
					stage.addActor(bubble);
					lstBubble.add(bubble);
				}
			}
		}
		
		if(isLose())
		{
			changeState(GameState.LOSE);
		}
		
		for(int i = lstApple.size() - 1; i >= 0; i--)
		{
			if(lstApple.get(i).checCollision(player.getBound()))
			{
				stage.getRoot().removeActor(lstApple.get(i));
				score++;
				lstApple.remove(i);
			}
		}
		
		List<Contact> contacts = world.getContactList();
		
		for(Contact c : contacts)
		{
			try
			{
				
				if(player.body.equals(c.getFixtureA().getBody()) && targetPoint.equals(c.getFixtureB().getBody())
						|| player.body.equals(c.getFixtureB().getBody()) && targetPoint.equals(c.getFixtureA().getBody()))
				{
					changeState(GameState.WIN);
					saveGame();
					createWinScreen();
					break;
				}
				
				
			}
			catch(Exception ex)
			{
				
			}
			
			try
			{
				for(Turtle turtle : lstTurtle)
				{
					if(turtle.body.equals(c.getFixtureA().getBody()) || turtle.body.equals(c.getFixtureB().getBody()))
					{
						turtle.resetDeltaTime();
					}
				}
			}
			catch(Exception ex)
			{
			}
		}
		
		for(Bubble bubble : lstBubble)
		{
			bubble.update();
		}
	}

	private void saveGame()
	{
		FishHookStageReader reader=new FishHookStageReader();
		reader.LoadFile("stage.xml");
		int indexStage = (level-1)/6;
		int indexScene=(level-1)%6;
		reader.ChangeValue(indexStage, indexScene, score);
		reader.Change_nSceneUnlock(indexStage, indexScene+1);
		reader.Change_nStageUnlock(indexStage+1);
	}


	/**
	 * Tao man hinh chien thang
	 */
	private void createWinScreen() {
		stage.clear();
		stage.addActor(new Image(Assets.background));
		stage.addActor(new MySprite(Assets.atlas.findRegion("object/disk"), new Vector2(430, 250)));

		if(score >= 1)
		{
			Apple ap = new Apple(Assets.atlas.findRegion("object/apple"), new Vector2(400, 300), true, 1f);
			ap.addAction(Actions.moveTo(350, 260, 1));
			stage.addActor(ap);
		}
		if(score >= 3)
		{
			Apple ap = new Apple(Assets.atlas.findRegion("object/apple"), new Vector2(400, 500), true, 1f);
			ap.addAction(Actions.moveTo(450, 260, 3));
			stage.addActor(ap);
		}
		if(score >= 2)
		{
			Apple ap = new Apple(Assets.atlas.findRegion("object/apple"), new Vector2(400, 500), true, 1f);
			ap.addAction(Actions.moveTo(400, 240, 2));
			stage.addActor(ap);
		}
		
		replayButtonWin = new MyButton(Assets.atlas.findRegion("button/replay"), new Vector2(300, 150));
		stage.addActor(replayButtonWin);
		menuButtonWin = new MyButton(Assets.atlas.findRegion("button/menu"), new Vector2(400, 150));
		stage.addActor(menuButtonWin);
		nextButtonWin = new MyButton(Assets.atlas.findRegion("button/next"), new Vector2(500, 150));
		stage.addActor(nextButtonWin);
	}

	/**
	 * update lai tat ca cac doi tuong o trang thai game la Lose
	 */
	private void updateLose() {
		// TODO Auto-generated method stub
		createWorld(GameScreen.level);
		changeState(GameState.PLAYING);
	}

	/**
	 * update lai tat ca cac doi tuong o trang thai game la Win
	 */
	private void updateWin() {

		if(Gdx.input.justTouched())
		{
			Vector2 touchPosition = Global.getTouchPosition();
			
			if(replayButtonWin.isClick(touchPosition))
			{
				createWorld(GameScreen.level);
				changeState(GameState.PLAYING);
			}
			if(menuButtonWin.isClick(touchPosition))
			{
				game.setScreen(new MainMenu(game, false));
			}
			if(nextButtonWin.isClick(touchPosition))
			{
				if(level == 7)
					{
						game.setScreen(new MainMenu(game, false));
					}
					else
					{
						createWorld(++level);
						changeState(GameState.PLAYING);
					}
			}
		}
	}
	
	/**
	 * Thay doi trang thai game
	 * @param state trang thai can thay doi
	 */
	public void changeState(GameState state)
	{
		this.state = state;
	}
	
	/**
	 * Kiem tra nguoi choi da thua?
	 * @return nguoi choi da thua?
	 */
	public boolean isLose()
	{
		if(player.getPositionCenter().x < 0 - 100 || player.getPositionCenter().x > Gdx.graphics.getWidth() + 100
				|| player.getPositionCenter().y < 0 - 100 || player.getPositionCenter().y > Gdx.graphics.getHeight() + 100)
		{
			return true;
		}
		return false;
	}
	

	/**
	 * Ve lai tat ca cac doi tuong
	 * @param delta khoang thoi gian giua 2 lan render
	 */
	private void draw(float delta) {
		// TODO Auto-generated method stub
		for(Bubble bubble : lstBubble)
		{
			bubble.drawAnimation(delta);
		}
		for(Turtle turtle : lstTurtle)
		{
			turtle.drawAnimation(delta);
		}
		for(Seesaw seesaw : lstSeesaw)
		{
			seesaw.update();
		}
		player.update();
	}

	@Override
	public void show() {
		// TODO Auto-generated method stub
		super.show();
	}

	
}
