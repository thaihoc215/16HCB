package com.G6.Object;

import com.G6.assets.Global;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.BodyDef.BodyType;
import com.badlogic.gdx.physics.box2d.CircleShape;
import com.badlogic.gdx.physics.box2d.FixtureDef;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.utils.Array;

/**
 * Lop dung de the hien qua bong bong duoc ke thua tu MySprite
 * @author Tha^n
 * 
 */
public class Bubble extends MySprite {
	World world;
	public Body body;
	
	/**
	 * Khoi tao mot qua bong bong voi mot toa do cho truoc
	 * @param atlasRegions danh sach nhung hinh anh dung de the hien bong bong
	 * @param position toa do cho truoc
	 */
	public Bubble(Array<AtlasRegion> atlasRegions, Vector2 position) {
		super(atlasRegions, position);
		// TODO Auto-generated constructor stub
		
	}

	/**
	 * Khoi tao mot qua bong bong voi mot toa do cho truoc va resize lai mot kich thuoc cho truoc
	 * @param atlasRegions danh sach nhung hinh anh dung de the hien bong bong
	 * @param position toa do cho truoc
	 * @param size size can resize
	 */
	public Bubble(Array<AtlasRegion> atlasRegions, Vector2 position, Vector2 size) {
		super(atlasRegions, position);
		// TODO Auto-generated constructor stub
		
		this.setSize(size.x, size.y);
	}
	
	float radius = 0;
	/**
	 * Khoi tao doi tuong vat ly cho qua bong bong
	 * @param world doi tuong world ma qua bong bong nam trong
	 * @param type loai cua doi tuong vat ly: tinh hay dong,...
	 */
	public void init(World world, BodyType type)
	{
		this.setName("bubble");
		this.world = world;
		BodyDef def = new BodyDef();
		def.position.set(new Vector2(getPositionCenter().x*Global.WORLD_TO_BOX, getPositionCenter().y*Global.WORLD_TO_BOX));
		def.type = type;
		def.gravityScale = -1;
		
		CircleShape bubbleShape = new CircleShape();
		radius = (getHeight() - 10)/2;
		bubbleShape.setRadius(radius*Global.WORLD_TO_BOX);
		
		FixtureDef fix = new FixtureDef();
		fix.filter.groupIndex = 8;
		fix.shape = bubbleShape;
		fix.filter.categoryBits = 0x3;// ----------
		fix.filter.maskBits = 0x1;
		fix.density = 5f;
		fix.friction = 0;
		fix.restitution = 0;
		
		body = world.createBody(def);
		body.createFixture(fix);
		body.setUserData(this);
	}
	

	/**
	 * Dung de update lai vi tri cua qua bong bong, can duoc goi trong mot vong lap game
	 */
	public void update()
	{
		setPositionCenter(body.getPosition().x*Global.BOX_TO_WORLD, body.getPosition().y*Global.BOX_TO_WORLD);
	}
	
	/**
	 * Kiem tra toa do (x, y) co nam trong qua bong bong hay khong
	 * @param x toa do x
	 * @param y toa do y
	 * @return toa do (x, y) co nam trong qua bong bong hay khong
	 */
	public boolean isClick(float x, float y)
	{
		Vector2 distance = new Vector2(x - getPositionCenter().x, y - getPositionCenter().y);
		if(distance.len() < radius)
		{
			return true;
		}
		return false;
	}

	/**
	 * Huy doi tuong vat ly cua qua bong bong
	 */
	public void destroy()
	{
		world.destroyBody(body);
	}
}
