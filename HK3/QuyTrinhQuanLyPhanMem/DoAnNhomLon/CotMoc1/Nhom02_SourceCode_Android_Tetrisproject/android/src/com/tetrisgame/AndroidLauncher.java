package com.tetrisgame;

import android.os.Bundle;

import com.badlogic.gdx.backends.android.AndroidApplication;
import com.badlogic.gdx.backends.android.AndroidApplicationConfiguration;

public class AndroidLauncher extends AndroidApplication {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        AndroidApplicationConfiguration config = new AndroidApplicationConfiguration();
//		initialize(new MainGame(), config);
//		initialize(new com.tetrisgame.com.tetrisgame.test1.TetrisGame(), config);

//		config.useGL20 = false;

        initialize(new com.tetromino.TetrominoGame(), config);
    }
}
