package com.G6.Object;

import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.scenes.scene2d.Actor;
import com.badlogic.gdx.scenes.scene2d.ui.Image;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.badlogic.gdx.utils.Array;

/**
 * Lop dung de the hien mot Image (actor) voi cac dac tinh bo sung: animation
 * @author Tha^n
 *
 */
public class MySprite extends Image{
	public static float TIME_DURA = 0.1f;
	
	protected Animation m_animation;
	private Vector2 m_position;
	
	private float stateTime = 0;

	
	/**
	 * Tao mot doi tuong tai toa do position
	 * @param atlasRegions danh sach cac hinh anh cua doi tuong
	 * @param position vi tri can the hien
	 */
	public MySprite(Array<AtlasRegion> atlasRegions, Vector2 position)
	{
		super(atlasRegions.get(0));
		this.setPositionCenter(position.x, position.y);
		m_animation = new Animation(TIME_DURA, atlasRegions);
		m_position = position;
	}
	
	/**
	 * Tao mot doi tuong tai toa do position
	 * @param atlasRegion hinh anh cua doi tuong
	 * @param position vi tri can the hien
	 */
	public MySprite(AtlasRegion atlasRegion, Vector2 position) {
		// TODO Auto-generated constructor stub
		super(atlasRegion);

		this.m_position = position;
		this.setPositionCenter(position.x, position.y);
		m_animation = new Animation(TIME_DURA, atlasRegion);
	}

	/**
	 * Ve lai doi tuong trong khoang thoi gian delta
	 * @param delta thoi gian giua hai lan render
	 */
	public void drawAnimation(float delta)
	{
		stateTime += delta;
		this.setDrawable(changRegionToDrawable(m_animation.getKeyFrame(stateTime, true)));
	}
	
	/**
	 * Ve lai doi tuong trong khoang thoi gian delta va setLoop cho animation
	 * @param delta thoi gian giua hai lan render
	 * @param isLoop = true -> animation duoc lap di lap lai, = false -> animation duoc lap dung 1 lan
	 */
	public void drawAnimation(float delta, boolean isLoop)
	{
		stateTime += delta;
		this.setDrawable(changRegionToDrawable(m_animation.getKeyFrame(stateTime, isLoop)));
	}
	
	/**
	 * Thay doi lai hinh anh cua doi tuong
	 * @param region hinh anh can thay doi
	 * @return mot TextureRegionDrawable dung de thay doi hinh anh cho Image
	 */
	protected TextureRegionDrawable changRegionToDrawable(TextureRegion region)
	{
		return new TextureRegionDrawable(region);
	}
	
	
	/**
	 * set lai vi tri cho hinh anh. (vi tri hinh anh la vi tri chinh giua hinh anh)
	 * @param x vi tri x
	 * @param y vi tri y
	 */
	public void setPositionCenter(float x, float y) {
		// TODO Auto-generated method stub
		this.setPosition(x - this.getWidth()/2, y - this.getHeight()/2);
		m_position = new Vector2(x, y);
	}
	
	/**
	 * lay vi tri hinh anh
	 * @return vi tri chinh giua hinh anh
	 */
	public Vector2 getPositionCenter()
	{
		return m_position;
	}
}
