package com.tetromino;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input.Keys;
import com.badlogic.gdx.InputMultiplexer;
import com.badlogic.gdx.InputProcessor;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.input.GestureDetector;
import com.badlogic.gdx.math.Vector2;

public class GameScreen implements Screen, InputProcessor, GestureDetector.GestureListener {

    /**
     * Grid ứng với khối gạch
     */
    private TetrominoGrid grid;
    /**
     * Render hiển thị màn hình
     */
    private TetrominoGridRenderer renderer;
    /**
     * Controller điều khiển grid
     */
    private TetrominoController controller;
    /**
     * Vector tại điểm chạm bắt đầu
     */
    private Vector2 _startTouchVect = new Vector2();

    SpriteBatch sb;
    BitmapFont bf;
    String msg = "Score: ";

    /**
     * Constructor
     */
    public GameScreen() {
        sb = new SpriteBatch();
        bf = new BitmapFont();


    }

    @Override
    public void render(float delta) {
        // render lien tuc de tao ra cac khoi vuong va man hinh
        Gdx.gl.glClearColor(0.1f, 0.1f, 0.1f, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
        //phuong thuc từ class hỗ trợ get các phím bấm mũi tên
        controller.update(delta);
        //mac dinh lien tuc moveDown(di chuyển khổi gạch xuống dưới với 1 tốc độ)
        grid.update(delta);
        //render giao dien, ve cac khoi, goi su kien cua cac khoi gach
        renderer.render(delta);

        //Ve khung chu, diem so
        sb.begin();
        bf.setColor(Color.BLUE);
        bf.getData().setScale(3f);
        bf.draw(sb, msg + grid.get_score(), 10, 1500);
        sb.end();

    }

    @Override
    public void resize(int width, int height) {
        // TODO Auto-generated method stub

    }

    @Override
    public void show() {
        // TODO Auto-generated method stub
        grid = new TetrominoGrid();
        //render khoi grid (có thể là random, chưa check)
        //Có thể áp dụng để sau này hiển thị grid sắp tới
        renderer = new TetrominoGridRenderer(grid);
        //Khoi tao truyen grid vao controller de khi co su kien thay doi trong controller thi grid se anh huong theo
        controller = new TetrominoController(grid);
        //implement su kien cua man hinh
        InputMultiplexer im = new InputMultiplexer();
        GestureDetector gd = new GestureDetector(this);
        im.addProcessor(gd);
        im.addProcessor(this);
        Gdx.input.setInputProcessor(im);
    }

    @Override
    public void hide() {
        // TODO Auto-generated method stub

    }

    @Override
    public void pause() {
        // TODO Auto-generated method stub

    }

    @Override
    public void resume() {
        // TODO Auto-generated method stub

    }

    @Override
    public void dispose() {
        // TODO Auto-generated method stub

    }

    @Override
    public boolean keyDown(int keycode) {
        if (keycode == Keys.LEFT)
            controller.leftPressed();
        if (keycode == Keys.RIGHT)
            controller.rightPressed();
        if (keycode == Keys.DOWN)
            controller.downPressed();
        if (keycode == Keys.UP)
            controller.upPressed();
        return true;
    }

    @Override
    public boolean keyUp(int keycode) {
        if (keycode == Keys.LEFT)
            controller.leftReleased();
        if (keycode == Keys.RIGHT)
            controller.rightReleased();
        if (keycode == Keys.DOWN)
            controller.downReleased();
        if (keycode == Keys.UP)
            controller.upReleased();
        return true;
    }

    private boolean _isTap = true;

    @Override
    public boolean keyTyped(char character) {
        // TODO Auto-generated method stub
        return false;
    }


    @Override
    public boolean touchDown(int screenX, int screenY, int pointer, int button) {
        // TODO Auto-generated method stub
        if (!_isTap)
            _startTouchVect.set(screenX, screenY);
//        System.out.println(screenX + ":" + screenY);
//        System.out.println(lastTouch + ":" + screenY);
        return true;
    }

    @Override
    public boolean touchUp(int screenX, int screenY, int pointer, int button) {
        controller.leftReleased();
        controller.rightReleased();
        controller.downReleased();
        System.out.println("touch up: " + screenX + "+" + screenY);
        _isTap = false;
        return true;
    }

    @Override
    public boolean touchDragged(int screenX, int screenY, int pointer) {
        if (!_isTap) {
            System.out.println("Touch drag");
            Vector2 newTouch = new Vector2(screenX, screenY);
            Vector2 delta = newTouch.cpy().sub(_startTouchVect);
            if (delta.x < 0) {
                controller.leftPressed();
            } else if (delta.x > 0) {
                controller.rightPressed();
            }
            _startTouchVect = newTouch;
        }

        return true;
    }

    @Override
    public boolean mouseMoved(int screenX, int screenY) {
        // TODO Auto-generated method stub
        return false;
    }

    @Override
    public boolean scrolled(int amount) {
        // TODO Auto-generated method stub
        return false;
    }


    //Implement gesture event
    @Override
    public boolean touchDown(float x, float y, int pointer, int button) {
        return false;
    }

    @Override
    public boolean tap(float x, float y, int count, int button) {
        controller.leftReleased();
        controller.rightReleased();
        controller.downReleased();
        if (count == 2) {
            System.out.println("Double tap press");
            _isTap = true;
            return true;
        } else if (count == 1) {
            System.out.println("Tap press");
            controller.upPressed();
            _isTap = true;
            return true;
        }
        return true;
    }

    @Override
    public boolean longPress(float x, float y) {
        return false;
    }

    @Override
    public boolean fling(float velocityX, float velocityY, int button) {
        return false;
    }

    @Override
    public boolean pan(float x, float y, float deltaX, float deltaY) {
        return false;
    }

    @Override
    public boolean panStop(float x, float y, int pointer, int button) {
        return false;
    }

    @Override
    public boolean zoom(float initialDistance, float distance) {
        return false;
    }

    @Override
    public boolean pinch(Vector2 initialPointer1, Vector2 initialPointer2, Vector2 pointer1, Vector2 pointer2) {
        return false;
    }

    @Override
    public void pinchStop() {

    }
}
