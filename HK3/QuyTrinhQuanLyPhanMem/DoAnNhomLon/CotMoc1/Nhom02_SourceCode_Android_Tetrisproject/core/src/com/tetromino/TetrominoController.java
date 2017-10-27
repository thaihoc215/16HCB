package com.tetromino;

import java.util.HashMap;
import java.util.Map;

public class TetrominoController {

    /**
     * grid tương ứng với 1 khối hình bất kì
     */
    private TetrominoGrid grid;

    public TetrominoController(TetrominoGrid grid) {
        this.grid = grid;
    }

    enum Keys {
        LEFT, RIGHT, DOWN, UP
    }

    static Map<Keys, Boolean> keys = new HashMap<Keys, Boolean>();

    static {
        keys.put(Keys.LEFT, false);
        keys.put(Keys.RIGHT, false);
        keys.put(Keys.DOWN, false);
        keys.put(Keys.UP, false);
    }

    public void leftPressed() {
        keys.get(keys.put(Keys.LEFT, true));
    }

    public void rightPressed() {

        keys.get(keys.put(Keys.RIGHT, true));
    }

    public void downPressed() {

        keys.get(keys.put(Keys.DOWN, true));
    }

    public void upPressed() {

        System.out.println("Add key press");
        keys.get(keys.put(Keys.UP, true));
    }

    public void leftReleased() {

        keys.get(keys.put(Keys.LEFT, false));
    }

    public void rightReleased() {

        keys.get(keys.put(Keys.RIGHT, false));
    }

    public void downReleased() {

        keys.get(keys.put(Keys.DOWN, false));
    }

    public void upReleased() {
        keys.get(keys.put(Keys.UP, false));
    }

    /**
     * The main update method
     **/
    public void update(float delta) {
        processInput();
    }

    /**
     * Change Bob's state and parameters based on input controls
     **/
    private void processInput() {
        if (keys.get(Keys.LEFT)) {
            grid.moveLeft();
        }
        if (keys.get(Keys.RIGHT)) {
//            System.out.println("Press right");
            grid.moveRight();
        }
        if (keys.get(Keys.DOWN)) {
//            System.out.println("Press down");
            grid.moveDown();
        }
        if (keys.get(Keys.UP)) {
//            System.out.println("Press up - rotate khoi hinh");
            grid.rotateClockwise();
            //Only do one rotation per press:
            upReleased();
        }
    }
}
