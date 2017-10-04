package com.G6.Object;

import com.G6.assets.Assets;
import com.G6.assets.Global;
import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.math.Circle;
import com.badlogic.gdx.math.MathUtils;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.BodyDef.BodyType;
import com.badlogic.gdx.physics.box2d.CircleShape;
import com.badlogic.gdx.physics.box2d.Fixture;
import com.badlogic.gdx.physics.box2d.FixtureDef;
import com.badlogic.gdx.physics.box2d.PolygonShape;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;

/**
 * Lop dung de the hien nhan vat choi
 * @author Tha^n
 *
 */
public class Player extends MySprite {

	/**
	 * doi tuong vat ly world
	 */
	World world;
	
	/**
	 * doi tuong vat ly body cua doi tuong
	 */
	public Body body;
	
	/**
	 * cac trang thai cua nhan vat
	 * @author Tha^n
	 *
	 */
	enum STATE
	{
		/**
		 * Trang thai bat dau cua nhan vat
		 */
		START,
		
		/**
		 * Trang thai nhan vat nam trong qua bong bong
		 */
		BUBBLE,
		
		/**
		 * Trang thai nhan vat o trang thai free
		 */
		CHARACTER
	};
	
	/**
	 * Hinh anh nhan vat o trang thai free (character)
	 */
	AtlasRegion character;
	
	/**
	 * Hinh anh nhan vat o trang thai nam trong qua bong bong (start, bubble)
	 */
	AtlasRegion character_bubble;
	
	/**
	 * Trang thai cua nhan vat
	 */
	STATE state;
	
	/**
	 * cac vectrix dung de the hien khung vat ly cua nhan vat
	 */
	private Vector2[] poly = {new Vector2(0, -43),
			  new Vector2(30, 15), 
			  new Vector2(-30, 15) };
	
//	private Vector2[] poly = {new Vector2(-20, -40),
//			  new Vector2(20, -40), 
//			  new Vector2(30, 15), 
//			  new Vector2(-30, 15) };
	
	/**
	 * FixtureDef cua nhan vat o trang thai bubble
	 */
	FixtureDef bubbleFixtureDef;
	
	/**
	 * FitureDef cua nhan vat o trang thai character
	 */
	FixtureDef characterFixtureDef;
	
	/**
	 * Fixture cua nhan vat o trang thai bubble
	 */
	Fixture bubbleFixture = null;
	
	/**
	 * Fiture cua nhan vat o trang thai character
	 */
	Fixture characterFixture = null;

	/**
	 * Khoi tao nhan vat tai mot vi tri position cho truoc
	 * @param atlasRegions hinh anh luu nhan vat
	 * @param position vi tri cua nhan vat
	 */
	public Player(AtlasRegion atlasRegions, Vector2 position) {
		super(atlasRegions, position);
		//this.setPositionCenter(position.x, position.y);
		character = atlasRegions;
		character_bubble = Assets.atlas.findRegion("object/character_bubble", 1);
		this.setDrawable(new TextureRegionDrawable(character_bubble));
//		this.addAction(Actions.forever(Actions.moveTo(3, 3, 0.5f)));
	}
	
	/**
	 * Khoi tao doi tuong vat ly cho nhan vat
	 * @param world doi tuong vat ly world
	 * @param type kieu cua nhan vat
	 */
	public void init(World world, BodyType type)
	{
		this.setName("player");
		state = STATE.START;
		
		
		for(Vector2 apoly : poly)
		{
			apoly = apoly.mul(Global.WORLD_TO_BOX);
		}
		PolygonShape characterShape = new PolygonShape();
		characterShape.set(poly);
		characterFixtureDef = new FixtureDef();
		characterFixtureDef.shape = characterShape;
		characterFixtureDef.filter.categoryBits = 0x2;// ------------
		characterFixtureDef.filter.maskBits = 0x1;
//		characterFixtureDef.filter.groupIndex = -8;
		characterFixtureDef.density = 5f;
		characterFixtureDef.friction = 0;
		characterFixtureDef.restitution = 0.1f;
		
		CircleShape bubbleShape = new CircleShape();
		bubbleShape.setRadius((getHeight() - 10)/2*Global.WORLD_TO_BOX);
		bubbleFixtureDef = new FixtureDef();
		bubbleFixtureDef.shape = bubbleShape;
		bubbleFixtureDef.filter.categoryBits = 0x0;
		bubbleFixtureDef.filter.categoryBits = 0x2;
//		bubbleFixtureDef.filter.groupIndex = -8;
		bubbleFixtureDef.density = 0.1f;
		bubbleFixtureDef.friction = 0;
		bubbleFixtureDef.restitution = 0;
		
		this.world = world;
		BodyDef def = new BodyDef();
		def.position.set(new Vector2(getPositionCenter().x*Global.WORLD_TO_BOX, getPositionCenter().y*Global.WORLD_TO_BOX));
		def.type = type;
		def.gravityScale = 0;
				
		body = world.createBody(def);
		bubbleFixture = body.createFixture(bubbleFixtureDef);
		body.setUserData(this);
		body.setFixedRotation(true);
		body.setAwake(false);
	}
	

	/**
	 * update lai vi tri nhan vat
	 */
	public void update()
	{
		if(state == STATE.START)
		{
			return;
		}
		setPositionCenter(body.getPosition().x*Global.BOX_TO_WORLD, body.getPosition().y*Global.BOX_TO_WORLD);
		this.setRotation(body.getAngle()*MathUtils.radiansToDegrees);
	}
	

	/**
	 * huy doi tuong vat ly cua nhan vat
	 */
	public void destroy()
	{
		world.destroyBody(body);
	}
	
	/**
	 * Kiem tra vi tri (x, y) co nam trong nhan vat
	 * @param x toa do x
	 * @param y toa doi y
	 * @return vi tri (x, y) co nam trong nhan vat
	 */
	public boolean isClick(float x, float y)
	{
		if(state == STATE.CHARACTER)
		{
			if(getPositionCenter().x + 13 > x && getPositionCenter().x - 13 < x)
			{
				if(getPositionCenter().y + 27 > y && getPositionCenter().y - 27 < y)
				{
					return true;
				}
			}
		}
		else if(state == STATE.BUBBLE || state == STATE.START.START)
		{
			if((new Vector2(x, y).sub(getPositionCenter())).len() < (getHeight() - 10)/2)
			{
				return true;
			}
		}
		return false;
	}
	
	/**
	 * Thay doi gia toc trong truong cua nhan vat
	 * @param value gia toc trong truong can thay doi
	 */
	public void changeGravityScale(float value)
	{
		body.setGravityScale(value);
	}
	
	/**
	 * Thay doi trang thai nhan vat
	 */
	public void changState()
	{
		if(state == STATE.START)
		{
			state = STATE.CHARACTER;
			body.setLinearVelocity(0, 0.001f);
			body.setGravityScale(1);
			body.destroyFixture(bubbleFixture);
			characterFixture = body.createFixture(characterFixtureDef);
			this.setDrawable(new TextureRegionDrawable(character));
		}
		else if(state == STATE.CHARACTER)
		{
			state = STATE.BUBBLE;
			body.setLinearVelocity(0, 0);
			body.setGravityScale(-1);
			body.destroyFixture(characterFixture);
			bubbleFixtureDef.filter.groupIndex = 8;
			bubbleFixture = body.createFixture(bubbleFixtureDef);
			this.setDrawable(new TextureRegionDrawable(character_bubble));
		}
		else if(state == STATE.BUBBLE)
		{
			state = STATE.CHARACTER;
			body.setLinearVelocity(0, 0);
			body.setGravityScale(1);
			body.destroyFixture(bubbleFixture);
			characterFixture = body.createFixture(characterFixtureDef);
			this.setDrawable(new TextureRegionDrawable(character));
		}
	}

	/**
	 * Lay khung bao quanh nhan vat
	 * @return khung bao quanh nhan vat
	 */
	public Circle getBound() {
		// TODO Auto-generated method stub
		return new Circle(getPositionCenter(), 40);
	}
}
