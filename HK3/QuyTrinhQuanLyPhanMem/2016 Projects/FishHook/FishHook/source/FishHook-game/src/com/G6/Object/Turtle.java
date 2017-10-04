package com.G6.Object;

import com.G6.assets.Global;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.math.MathUtils;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.BodyDef.BodyType;
import com.badlogic.gdx.physics.box2d.FixtureDef;
import com.badlogic.gdx.physics.box2d.PolygonShape;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.utils.Array;


/**
 * Lop dung de the hien doi tuong con rua
 * @author Tha^n
 *
 */
public class Turtle extends MySprite {
	
	/**
	 * cac vertrices dun de the hien doi tuong vat ly cho con rua
	 */
	private Vector2[] poly = {new Vector2(-15, -38),
			  new Vector2(-15, 19), 
			  new Vector2(-49, 2), 
			  new Vector2(-49, -38) };
	
	/**
	 * cac vertrices dun de the hien doi tuong vat ly cho con rua
	 */
	private Vector2[] poly2 = {new Vector2(15, -38), 
			  new Vector2(15, 29),
			  new Vector2(-15, 19),
			  new Vector2(-15, -38)};
	
	/**
	 * cac vertrices dun de the hien doi tuong vat ly cho con rua
	 */
	private Vector2[] poly3 = {new Vector2(44, -38), 
			  new Vector2(44, 17),
			  new Vector2(15, 29), 
			  new Vector2(15, -38)};
	
	/**
	 * doi tuong vat ly world
	 */
	private World world;
	
	/**
	 * doi tuong vat ly cua con rua
	 */
	public Body body;
	
	/**
	 * goc quay cua con rua
	 */
	float angle;
	
	/**
	 * con rua quay sang trai?
	 */
	boolean isLeft;
	
		
	/**
	 * Khoi tao con rua tai mot vi tri, goc quay co truoc
	 * @param atlasRegions danh sach cac hinh anh cua con rua
	 * @param position vi tri giua cua con rua
	 * @param rotation goc quay con rua
	 * @param isLeft true neu dau con rua duoc quay sang trai
	 */
	public Turtle(Array<AtlasRegion> atlasRegions, Vector2 position, float rotation, boolean isLeft) {
			super(atlasRegions, position);
			// TODO Auto-generated constructor stub
			this.isLeft = isLeft;
//			AtlasRegion flip = new AtlasRegion(atlasRegions);
//			flip.flip(isLeft, false);
//			this.setDrawable(new TextureRegionDrawable(flip));
			this.angle = rotation*MathUtils.degreesToRadians;
			this.setOrigin(getWidth()/2, getHeight()/2);
			this.rotate(rotation);
			m_animation = new Animation(0.03f, atlasRegions);;
	}
	
	/**
	 * Tao doi tuong vat ly cho con rua
	 * @param world doi tuong vat ly world
	 * @param type kieu cua con rua
	 */
	public void init(World world, BodyType type)
	{
		this.setName("turtle");
		this.world = world;
		BodyDef def = new BodyDef();
		def.position.set(new Vector2(getPositionCenter().x*Global.WORLD_TO_BOX, getPositionCenter().y*Global.WORLD_TO_BOX));
		def.type = type;
		def.angle = angle;
		for(Vector2 v : poly)
		{
			v.mul(Global.WORLD_TO_BOX);
		}
		for(Vector2 v : poly2)
		{
			v.mul(Global.WORLD_TO_BOX);
		}
		for(Vector2 v : poly3)
		{
			v.mul(Global.WORLD_TO_BOX);
		}
		if(isLeft)
		{
			swapAndMulMinusOneForx(poly, -1);
			swapAndMulMinusOneForx(poly2, -1);
			swapAndMulMinusOneForx(poly3, -1);
		}
		PolygonShape polyShape = new PolygonShape();
		polyShape.set(poly);
		PolygonShape polyShape2 = new PolygonShape();
		polyShape2.set(poly2);
		PolygonShape polyShape3 = new PolygonShape();
		polyShape3.set(poly3);
		
		FixtureDef fix = new FixtureDef();
		fix.shape = polyShape;
		fix.density = 0.1f;
		fix.friction = 0;
		fix.restitution = 1f;
		
		FixtureDef fix2 = new FixtureDef();
		fix2.shape = polyShape2;
		fix2.density = 0.1f;
		fix2.friction = 0;
		fix2.restitution = 1f;
		
		FixtureDef fix3 = new FixtureDef();
		fix3.shape = polyShape3;
		fix3.density = 0.1f;
		fix3.friction = 0;
		fix3.restitution = 1f;
		
		body = world.createBody(def);
		body.createFixture(fix);
		body.createFixture(fix2);
		body.createFixture(fix3);
		body.setUserData(this);
	}
	
	/**
	 * swap lai day vertrices vs va nhan no voi mot luong mul (thuong la WorldToBox)
	 * @param vs day vertrices
	 * @param mul luong can nhan
	 */
	public void swapAndMulMinusOneForx(Vector2[] vs, float mul)
	{
		for(int i = 0; i < vs.length/2; i++)
		{
			Vector2 temp = vs[i];
			vs[i] = vs[vs.length - i - 1].mul(mul, 1);
			vs[vs.length - i - 1] = temp.mul(mul, 1);
		}
	}
	
	/**
	 * t = tong cac deltatime, t ban dau bang 4 => khong ve animation cho con rua, khi nao reset lai bang 0 thi animation cua con rua se duoc ve
	 */
	float t = 4;
	@Override
	public void drawAnimation(float delta) {
		// TODO Auto-generated method stub
		//super.drawAnimation(delta);
		t += delta;
		this.setDrawable(changRegionToDrawable(m_animation.getKeyFrame(t, false)));
	}
	
	/**
	 * reset lai deltatime, dung bat dau ve animation cho con rua
	 */
	public void resetDeltaTime()
	{
		t = 0;
	}
}

