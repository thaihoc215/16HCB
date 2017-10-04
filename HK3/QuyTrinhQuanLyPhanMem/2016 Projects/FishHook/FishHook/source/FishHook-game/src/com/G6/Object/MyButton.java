package com.G6.Object;

import com.G6.math.OverlapTester;
import com.badlogic.gdx.graphics.g2d.TextureAtlas.AtlasRegion;
import com.badlogic.gdx.math.Circle;
import com.badlogic.gdx.math.Intersector;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Array;

public class MyButton extends MySprite {

	public MyButton(AtlasRegion atlasRegion, Vector2 position) {
		super(atlasRegion, position);
		// TODO Auto-generated constructor stub
	}

	public Circle getBound()
	{
		return new Circle(this.getPositionCenter(), this.getImageWidth()/2);
	}
	
	public boolean isClick(Vector2 position)
	{
		return OverlapTester.pointInMyCircle(getBound(), position);
	}
}
