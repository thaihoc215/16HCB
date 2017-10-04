package com.G6.Object;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.math.Intersector;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.scenes.scene2d.ui.Image;
import com.badlogic.gdx.scenes.scene2d.utils.TextureRegionDrawable;
import com.sun.org.apache.regexp.internal.recompile;
import com.sun.org.apache.xpath.internal.operations.Bool;

public class PlayButton extends Image {
	TextureRegion img;
	public TextureRegion imgClicked;
	public Vector2 position;
	Vector2 size;
	Vector2 sizeScreen;
	public boolean show = true;

	public PlayButton(TextureRegion t, Vector2 pos, Vector2 size,
			Vector2 sizeofScreen) {
		img = t;
		imgClicked = null;
		position = pos;
		this.size = size;
		sizeScreen = sizeofScreen;
		if (show)
			this.setDrawable(new TextureRegionDrawable(img));
		this.setPosition(pos.x, pos.y);
		this.setSize(size.x, size.y);
	}

	public void hideButton() {
		show = false;
		this.setDrawable(null);
	}
	
	public void SetImage(TextureRegion s)
	{
		this.setDrawable(new TextureRegionDrawable(s));
	}

	public void showButton() {
		show = true;
		this.setDrawable(new TextureRegionDrawable(img));
	}

	public void Update() {
		this.setDrawable(new TextureRegionDrawable(img));
	}

	public boolean IsClicked(Vector2 coorTouch) {
		if (show) {
			Rectangle r1 = new Rectangle(coorTouch.x, sizeScreen.y
					- coorTouch.y, 1, 1);
			Rectangle r2 = new Rectangle(position.x, position.y, size.x, size.y);
			if (Intersector.intersectRectangles(r1, r2)) {
				if (imgClicked != null)
					this.setDrawable(new TextureRegionDrawable(imgClicked));
				return true;
			}
		}
		return false;
	}
}
