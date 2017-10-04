package com.G6.Object;

import com.G6.assets.Global;
import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.math.MathUtils;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.Body;
import com.badlogic.gdx.physics.box2d.BodyDef;
import com.badlogic.gdx.physics.box2d.CircleShape;
import com.badlogic.gdx.physics.box2d.Joint;
import com.badlogic.gdx.physics.box2d.PolygonShape;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.physics.box2d.BodyDef.BodyType;
import com.badlogic.gdx.physics.box2d.joints.RevoluteJoint;
import com.badlogic.gdx.physics.box2d.joints.RevoluteJointDef;

/**
 * Lop the hien cau bap benh
 * @author Tha^n
 *
 */
public class Seesaw extends MySprite {

	/**
	 * doi tuong vat ly world
	 */
	World world;
	
	/**
	 * Doi tuong vat ly cua bap benh
	 */
	Body body;
	
	/**
	 * Khoi tao cau bap benh tai mot vi tri position
	 * @param atlasRegions hinh anh cau bap benh
	 * @param position vi tri
	 */
	public Seesaw(AtlasRegion atlasRegions, Vector2 position) {
		super(atlasRegions, position);
		// TODO Auto-generated constructor stub
		this.setOrigin(getWidth()/2, getHeight()/2);
	}
	
	
	/**
	 * Khoi tao doi tuong vat ly cho cau bap benh
	 * @param world doi tuong vat ly world
	 */
	public void init(World world)
	{
		// tao diem tua
		BodyDef def = new BodyDef();
		def.position.set(getPositionCenter().x*Global.WORLD_TO_BOX, getPositionCenter().y*Global.WORLD_TO_BOX +0.15f);
		def.type = BodyType.StaticBody;
		
		CircleShape cirShape = new CircleShape();
		cirShape.setRadius(5*Global.WORLD_TO_BOX);
		
		Body circleBody = world.createBody(def);
		circleBody.createFixture(cirShape, 0);
		
		// tao seesaw
		BodyDef defSeesaw = new BodyDef();
		defSeesaw.position.set(getPositionCenter().x*Global.WORLD_TO_BOX, getPositionCenter().y*Global.WORLD_TO_BOX);
		defSeesaw.type = BodyType.DynamicBody;
		defSeesaw.gravityScale = 2f;
		defSeesaw.linearDamping = 2;
		
		PolygonShape polySeesaw = new PolygonShape();
		polySeesaw.setAsBox(100*Global.WORLD_TO_BOX, 10*Global.WORLD_TO_BOX);
		body = world.createBody(defSeesaw);
		body.createFixture(polySeesaw, 0);
		
		PolygonShape poly1 = new PolygonShape();
		poly1.setAsBox(10*Global.WORLD_TO_BOX, 15*Global.WORLD_TO_BOX, new Vector2(-90*Global.WORLD_TO_BOX, - 30*Global.WORLD_TO_BOX), 0);
		PolygonShape poly2 = new PolygonShape();
		poly2.setAsBox(10*Global.WORLD_TO_BOX, 15*Global.WORLD_TO_BOX, new Vector2(90*Global.WORLD_TO_BOX, - 30*Global.WORLD_TO_BOX), 0);
		
//		PolygonShape poly1 = new PolygonShape();
//		Vector2[] vpoly1 = {new Vector2(-140, -52), 
//				new Vector2(-117, -52),
//				new Vector2(-100, -8),
//				new Vector2(-140, -8)};
//		mul(vpoly1, 0.01f);
//		poly1.set(vpoly1);
//		PolygonShape poly2 = new PolygonShape();
//		Vector2[] vpoly2 = {new Vector2(126, -50), 
//				new Vector2(145, -50),
//				new Vector2(145, 2),
//				new Vector2(100, 2)};
//		mul(vpoly2, 0.01f);
//		poly2.set(vpoly2);
		body.createFixture(poly1, 10);
		body.createFixture(poly2, 10);
		body.setUserData(this);
		
		// tao lien ket
		RevoluteJointDef revoluteJointDef = new RevoluteJointDef();
		revoluteJointDef.bodyA = circleBody;
		revoluteJointDef.bodyB = body;
		revoluteJointDef.collideConnected = false;
		revoluteJointDef.localAnchorA.set(new Vector2(0, 0));
		revoluteJointDef.localAnchorB.set(new Vector2(0, 0*Global.WORLD_TO_BOX));

		revoluteJointDef.lowerAngle = -30*MathUtils.degreesToRadians;
		revoluteJointDef.upperAngle = 30*MathUtils.degreesToRadians;
		revoluteJointDef.enableLimit = true;
		
		Joint j = world.createJoint(revoluteJointDef);
	}
	
	/**
	 * Thay doi lai vi tri cua cau bap benh
	 */
	public void update()
	{
		setPositionCenter(body.getPosition().x*100, body.getPosition().y*100 - 25);
		setRotation(body.getAngle()*MathUtils.radiansToDegrees);
	}
	
	
	@Override
	public void setPositionCenter(float x, float y) {
		// TODO Auto-generated method stub
		super.setPositionCenter(x, y);
	}

	/**
	 * Nhan mot luong mul cho cac vs
	 * @param vs mot mang cac vector2
	 * @param mul luong mul can nhan
	 */
	void mul(Vector2[] vs, float mul)
	{
		for(Vector2 v : vs)
		{
			v = v.mul(mul);
		}
	}
}
