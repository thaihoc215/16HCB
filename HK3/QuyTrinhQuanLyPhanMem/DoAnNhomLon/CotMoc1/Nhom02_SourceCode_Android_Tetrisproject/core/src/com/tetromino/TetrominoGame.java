package com.tetromino;

import com.badlogic.gdx.Application;
import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;

public class TetrominoGame extends Game {


    @Override
    public void create() {
        Gdx.app.setLogLevel(Application.LOG_DEBUG);
        //khoi tao man hinh giao dien
        //goi phuong thuc render()

        setScreen(new GameScreen());
    }

}
