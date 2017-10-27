package com.tetromino;


public class BlockDrawable {

	public int x;
	public int y;
	public Tetromino.colors color;
	
	public BlockDrawable(int x, int y, Tetromino.colors color) {
		this.x = x;
		this.y = y;
		this.color = color;
	}
}
