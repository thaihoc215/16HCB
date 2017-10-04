package com.G6.Object;


import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.math.Circle;
import com.badlogic.gdx.math.Intersector;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.scenes.scene2d.actions.Actions;

/**
 * Lop dung de the hien qua tao
 * @author Tha^n
 *
 */
public class Apple extends MySprite {

	/**
	 * Khoi tao mot qua tao tai vi tri position
	 * @param atlasRegions textureRegion luu hinh anh qua tao
	 * @param position vi tri qua tao xuat hien
	 * @param isSetLoopAction neu true thi qua tao se duoc setAction scale lien tuc
	 * @param scale dung de phong to, thu nho qua tao truoc khi set action
	 */
	public Apple(AtlasRegion atlasRegions, Vector2 position, boolean isSetLoopAction, float scale) {
		super(atlasRegions, position);
		// TODO Auto-generated constructor stub
		this.setOrigin(this.getWidth()/2, this.getHeight()/2);
		this.scale(scale);
		if(isSetLoopAction)
		{
			this.addAction(Actions.forever(Actions.sequence(Actions.scaleBy(-0.1f, -0.1f, 0.5f), Actions.scaleBy(0.1f, 0.1f, 0.5f))));
		}
	}
	
	/**
	 * Khoi tao mot qua tao tai vi tri position
	 * @param atlasRegions textureRegion luu hinh anh qua tao
	 * @param position vi tri qua tao xuat hien
	 * @param isSetLoopAction neu true thi qua tao se duoc setAction scale lien tuc
	 */
	public Apple(AtlasRegion atlasRegions, Vector2 position, boolean isSetLoopAction) {
		super(atlasRegions, position);
		// TODO Auto-generated constructor stub
		this.setOrigin(this.getWidth()/2, this.getHeight()/2);
		if(isSetLoopAction)
		{
			this.addAction(Actions.forever(Actions.sequence(Actions.scaleBy(-0.1f, -0.1f, 0.5f), Actions.scaleBy(0.1f, 0.1f, 0.5f))));
		}
	}

	/**
	 * Di chuyen qua tao toi toa do (x, y) cho truoc trong khoang thoi gian duration
	 * @param x toa do x
	 * @param y toa do y
	 * @param duration thoi gian di chuyen
	 */
	public void moveTo(float x, float y, float duration)
	{
		this.addAction(Actions.moveTo(x - this.getWidth()/2, y - this.getHeight()/2, 6));
	}
	
	/**
	 * Kiem tra toa do (x, y) co nam trong qua tao hay khong
	 * @param x toa do x
	 * @param y toa do y
	 * @return toa do (x, y) co nam trong qua tao hay khong
	 */
	public boolean isClick(float x, float y)
	{
		if(x > getPositionCenter().x - getWidth()/2 && x < getPositionCenter().x + getWidth()/2)
		{
			if(y > getPositionCenter().y - getHeight()/2 && y < getPositionCenter().y + getHeight()/2)
			{
				return true;
			}
		}
		return false;
	}
	
	/**
	 * Lay ra khung bao quanh hinh qua tao
	 * @return khung bao quanh qua tao
	 */
	public Circle getBound()
	{
		return new Circle(getPositionCenter().x, getPositionCenter().y, getHeight()/2);
	}
	
	/**
	 * Kiem tra dung do voi mot vat the co khung la circle
	 * @param circle khung cua vat the can kiem tra
	 * @return co xay ra dung do giua qua tao va circle hay khong
	 */
	public boolean checCollision(Circle circle)
	{
		return Intersector.overlapCircles(getBound(), circle);
	}
}
