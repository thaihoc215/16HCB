package com.G6.Object;

import com.G6.assets.Global;
import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.math.MathUtils;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.BodyDef.BodyType;
import com.badlogic.gdx.physics.box2d.PolygonShape;
import com.badlogic.gdx.physics.box2d.World;

/**
 * Lop the hien dich can den cua nhan vat (cai lu)
 * @author Tha^n
 *
 */
public class Target extends MySprite {

	/**
	 * Doi tuong vat ly world
	 */
	World world = null;
	
	/**
	 * Doi tuong vat ly cua target
	 */
	public Body body = null;

	/**
	 * danh sach cac vertices dung de the hien canh cua cai lu ben trai
	 */
	Vector2 vertices[] = {new Vector2(-52, 0),
			   new Vector2(-52, 85),
			   new Vector2(-76, 94),
			   new Vector2(-76, 0)};
	
	/**
	 * danh sach cac vertices dung de the hien canh cua cai lu ben phai
	 */
	Vector2 vertices2[] = {new Vector2(72, 0),
			   new Vector2(72, 106),
			   new Vector2(50, 95),
			   new Vector2(50, 0)};
	
	/**
	 * Vi tri giua duoi cua cai lu
	 */
	private Vector2 positionBottonCenter;
	
	/**
	 * Goc quay ban dau cua cai lu
	 */
	private float angle;
	
	/**
	 * Tao mot cai lu o vi tri position la vi tri giua duoi cua cai lu, voi mot luong goc quay la rotation
	 * @param atlasRegions hinh anh cai lu
	 * @param position vi tri giua duoi cua cai lu
	 * @param rotation luong goc quay ban dau (tinh bang do)
	 */
	public Target(AtlasRegion atlasRegions, Vector2 position, float rotation) {
		super(atlasRegions, position);
		this.angle = rotation*MathUtils.degreesToRadians;
		this.setOrigin(getWidth()/2, 0);
		this.rotate(rotation);
		setPositionBottonCenter(position.x, position.y);
		// TODO Auto-generated constructor stub
	}
	
	/**
	 * Set lai vi tri giua duoi cua cai lu
	 * @param x toa do x
	 * @param y toa do y
	 */
	public void setPositionBottonCenter(float x, float y) {
		// TODO Auto-generated method stub
		super.setPosition(x - getWidth()/2, y);
		positionBottonCenter = new Vector2(x, y);
	}
	
	/**
	 * Lay vi tri giua duoi cua cai lu
	 * @return Lay vi tri giua duoi cua cai lu
	 */
	public Vector2 getPositionBottonCenter() {
		// TODO Auto-generated method stub
		//return super.getPosition();
		return positionBottonCenter;
	}
	
	/**
	 * Khoi tao doi tuong vat ly cho cai lu
	 * @param world doi tuong vat ly world
	 * @param type kieu cua cai lu
	 */
	public void init(World world, BodyType type)
	{
		this.setName("target");
		this.world = world;
		BodyDef def = new BodyDef();
		def.type = type;
		def.position.set(this.getPositionBottonCenter().x*Global.WORLD_TO_BOX, this.getPositionBottonCenter().y*Global.WORLD_TO_BOX);
		def.angle = angle;
		
		for(Vector2 v : vertices)
		{
			v.mul(Global.WORLD_TO_BOX);
		}
		for(Vector2 v : vertices2)
		{
			v.mul(Global.WORLD_TO_BOX);
		}
		PolygonShape poly = new PolygonShape();
		poly.set(vertices);
		PolygonShape poly2 = new PolygonShape();
		poly2.set(vertices2);
		
		body = world.createBody(def);
		body.createFixture(poly, 0);
		body.createFixture(poly2, 0);
		body.setUserData(this);
	}

	/**
	 * Lay ra mot doi tuong vat ly ma khi nhan vat cham vao do thi nhan vat chien thang
	 * @return mot doi tuong vat ly ma khi nhan vat cham vao do thi nhan vat chien thang
	 */
	public Body getTargetPoint()
	{
		Body point;
		BodyDef def = new BodyDef();
		def.type = BodyType.StaticBody;
		def.position.set(this.getPositionBottonCenter().x*Global.WORLD_TO_BOX, this.getPositionBottonCenter().y*Global.WORLD_TO_BOX);
		
		PolygonShape poly = new PolygonShape();
		poly.setAsBox(50*Global.WORLD_TO_BOX, 1*Global.WORLD_TO_BOX);
		
		point = world.createBody(def);
		point.createFixture(poly, 0);
		point.setUserData("targetPoint");
		return point;
	}
}
