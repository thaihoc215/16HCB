package com.G6.Object;

import java.util.List;

import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Interpolation;
import com.badlogic.gdx.math.Intersector;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.scenes.scene2d.Group;
import com.badlogic.gdx.scenes.scene2d.actions.Actions;
import com.badlogic.gdx.scenes.scene2d.ui.Image;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.badlogic.gdx.utils.Array;

public class ObjectAnimation extends Group {

	Vector2 position;
	Vector2 positionTarget;
	Vector2 size;
	Image img;
	TextureRegion textureRegion;
	Interpolation interpolation;
	public Vector2 sizeScreen;
	List<Vector2> listPoint;// cac diem chuyen dong
	int indexPoint;
	boolean isAnimation = false;

	public boolean EnableChoose=false;
	public float time = 1f;
	public float delta = 0.08f, deltaScale = 1f;

	public ObjectAnimation(TextureRegion texRegions, Vector2 pos, Vector2 size,
			Vector2 posTarget, Interpolation inter, List<Vector2> list,
			float timeMove) {
		super();
		textureRegion = texRegions;
		position = pos;
		this.size = size;
		positionTarget = posTarget;
		interpolation = inter;
		listPoint = list;
		time = timeMove;
		if (list != null)
			indexPoint = 0;
		init();
	}

	void init() {
		img = new Image(textureRegion);
		img.setSize(size.x, size.y);
		addActor(img);
		setPosition(position.x, position.y);
		addAction(Actions.moveTo(positionTarget.x, positionTarget.y, time,
				interpolation));
	}

	void MoveToPoint(Vector2 point) {
		int kt = 0;
		if (position.x > point.x) {
			position.x -= delta;
			kt++;
		}
		if (position.x < point.x) {
			position.x += delta;
			kt++;
		}
		if (kt > 1)
			position.x = point.x;
		kt = 0;
		if (position.y > point.y) {
			position.y -= delta;
			kt++;
		}
		if (position.y < point.y) {
			position.y += delta;
			kt++;
		}
		if (kt > 1)
			position.y = point.y;

	}

	boolean execute=true;
	void executeAnimation() {
		if (listPoint != null&&execute) {
			MoveToPoint(listPoint.get(indexPoint));
			Vector2 v = new Vector2(getX(), getY());
			if (listPoint.get(indexPoint).x == v.x
					&& listPoint.get(indexPoint).y == v.y) {
				indexPoint++;
			}
			if (indexPoint >= listPoint.size())
				indexPoint = 0;
			setPosition(position.x, position.y);
		}
	
	}

	public void Update() {
		Vector2 v = new Vector2(getX(), getY());
		position = v;
		if (v.x == positionTarget.x && v.y == positionTarget.y)
			isAnimation = true;
		if (isAnimation) {
			executeAnimation();

		}

	}

	public void EnableAnimation()
	{
		execute=true;
	}
	
	public void DisableAnimation()
	{
		execute=false;
	}
	
	public void hide() {
		show = false;
	}

	public void show() {
		show = true;
	}

	boolean show = true;

	public boolean IsClicked(Vector2 coorTouch) {
		if (show) {
			Rectangle r1 = new Rectangle(coorTouch.x, sizeScreen.y
					- coorTouch.y, 1, 1);
			Rectangle r2 = new Rectangle(position.x, position.y, size.x, size.y);
			if (Intersector.intersectRectangles(r1, r2)) {
				execute=true;
				return true;
			}
		}
		return false;
	}
}
