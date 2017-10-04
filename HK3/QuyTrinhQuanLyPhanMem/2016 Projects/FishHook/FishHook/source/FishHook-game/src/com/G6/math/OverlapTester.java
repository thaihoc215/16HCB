package com.G6.math;

import com.badlogic.gdx.math.Circle;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;

/**
 * Dung de kiem tra va cham
 * @author Tha^n
 *
 */
public class OverlapTester {
	
    /**
     * kiem tra diem p co nam trong hinh tron c hay khong
     * @param c
     * @param p
     * @return
     */
    public static boolean pointInMyCircle(Circle c, Vector2 p) {
        return ((new Vector2(c.x, c.y)).sub(p)).len() < c.radius;
    }
    
    /**
     * kiem tra diem (x, y) co nam trong hinh tron c hay khong
     * @param c
     * @param x
     * @param y
     * @return
     */
    public static boolean pointInMyCircle(Circle c, float x, float y) {
    	return ((new Vector2(c.x, c.y)).sub(new Vector2(x, y))).len() < c.radius;
    }
    
    /**
     * kiem tra diem p co nam trong hinh chu nhat r hay khong
     * @param r
     * @param p
     * @return
     */
    public static boolean pointInMyRectangle(Rectangle r, Vector2 p) {
        return r.x <= p.x && r.x + r.width >= p.x &&
               r.y <= p.y && r.y + r.height >= p.y;
    }
    
    /**
     * kiem tra diem (x, y) co nam trong hinh chu nhat r hay khong
     * @param r
     * @param x
     * @param y
     * @return
     */
    public static boolean pointInMyRectangle(Rectangle r, float x, float y) {
        return r.x <= x && r.x + r.width >= x &&
               r.y <= y && r.y + r.height >= y;
    }
}