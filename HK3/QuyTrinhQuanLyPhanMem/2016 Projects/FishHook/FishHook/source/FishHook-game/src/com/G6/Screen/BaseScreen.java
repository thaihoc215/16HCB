package com.G6.Screen;

import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture.TextureFilter;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.TextureAtlas;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.Skin;

public abstract class BaseScreen implements Screen {
	
	/**
	 * Khung nhin cua camera
	 */
    public static final int VIEWPORT_WIDTH = 800, VIEWPORT_HEIGHT = 480;
    
    /**
     * doi tuong game duoc truyen qua lai giua cac screen, dung de goi ham setScreen(...) de doi man hinh
     */
	protected final Game game;
	
	/**
	 * San khau the hien actor va the hien cac hanh dong cua actor
	 */
	protected final Stage stage;


	/**
	 * ham khoi tao mot screen
	 * @param game doi tuong game
	 */
	public BaseScreen(Game game) {
		this.game = game;
		this.stage = new Stage( 0, 0, true );
	}


	
	@Override
    public void show()
    {
        // set the stage as the input processor
        Gdx.input.setInputProcessor( stage );
    }

    @Override
    public void resize(
        int width,
        int height )
    {
        // resize the stage
        stage.setViewport( width, height, true );
    }

    /**
     * to den man hinh va the hien cac actor va cac hanh dong cua actor
     */
    @Override
    public void render(
        float delta )
    {
        // (1) process the game logic

        // update the actors
        stage.act( delta );

        // (2) draw the result

        // clear the screen with the given RGB color (black)
        Gdx.gl.glClearColor( 0f, 0f, 0f, 1f );
        Gdx.gl.glClear( GL20.GL_COLOR_BUFFER_BIT );

        // draw the actors
        stage.draw();
    }

    @Override
    public void hide() {
    	// TODO Auto-generated method stub
    	
    }
    
    @Override
    public void dispose() {
    	// TODO Auto-generated method stub
    	
    }

    @Override
    public void pause()
    {
    }

    @Override
    public void resume()
    {
    }
}
