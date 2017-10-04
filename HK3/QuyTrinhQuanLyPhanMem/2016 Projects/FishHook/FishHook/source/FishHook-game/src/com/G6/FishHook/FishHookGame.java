package com.G6.FishHook;

import com.G6.Screen.LoadingScreen;
import com.badlogic.gdx.Game;
 
public class FishHookGame extends Game
{
	
	@Override
	public void create() {
		// TODO Auto-generated method stub
		setScreen(new LoadingScreen(this));
		
	}
	
	@Override
	public void resize(int width, int height) {
		// TODO Auto-generated method stub
		super.resize(800, 400);
	}
}