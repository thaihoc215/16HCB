package com.tetrisgame.com.tetrisgame.test1;

public class GameType {
	public static GameType EasyFives, ThreesAndFives, Test, Classic;
	
	static {
		EasyFives = new GameType(new FactoryRing(
				new GameScreen.PieceFactory[]{
						new PieceBagFactory(Assets.niceFives),
						new PieceBagFactory(Assets.niceFives),
						new PieceBagFactory(Assets.niceFives), 
						new PieceBagFactory(Assets.threePieces)}),
				"Easy fives, ", "a little help.");
		ThreesAndFives = new GameType(new FactoryRing(
				new GameScreen.PieceFactory[]{
						new PieceBagFactory(Assets.niceFives),
						new PieceBagFactory(Assets.threePieces),
						new PieceBagFactory(Assets.modFives), 
						new PieceBagFactory(Assets.threePieces)}), 
						"Fives, with a", "lot of help.");
		Test = new GameType(new EasyFactory(), ".-.", "");
		Classic = new GameType(new FactoryRing(
				new GameScreen.PieceFactory[]{
						new PieceBagFactory(Assets.threePieces),
						new PieceBagFactory(Assets.fours),
						new PieceBagFactory(Assets.threePieces),
						new PieceBagFactory(Assets.fours),
						new PieceBagFactory(Assets.fours)}), 
						"Threes & Fours.", "Easy, right?");
	}
	
	String title, description;
	GameScreen.PieceFactory factory;
	
	public GameType(GameScreen.PieceFactory p, String t, String d){
		factory = p;
		title = t;
		description = d;
	}
	
	boolean[][] nextPiece(){ return factory.nextPiece(); }
	String title(){ return title; }
	String description(){ return description; }
	
	static final int GRID_WIDTH = 11;
	
	static class EasyFactory implements GameScreen.PieceFactory {
		public boolean[][] nextPiece(){
			boolean easy[][] = new boolean[GRID_WIDTH][GRID_WIDTH];
			for(int i = 0; i < GRID_WIDTH;i++){
				easy[0][i] = true;
				easy[1][i] = true;
				easy[2][i] = true;
				easy[3][i] = true;
			}

			return easy;
		}
	}

	// Evenly, randomly from a predetermined list
	static class PieceBagFactory implements GameScreen.PieceFactory {
		// An array of pieces
		boolean[][][] pieces;
		
		PieceBagFactory(boolean[][][] pieces) {
			this.pieces = pieces;
		}
		
		public boolean[][] nextPiece() {
			return pieces[(int) Math.floor(Math.random() * pieces.length)];			
		}
	}
	
	static class FactoryRing implements GameScreen.PieceFactory {
		GameScreen.PieceFactory[] factories;
		int nextFactory = -1;
		
		public FactoryRing(GameScreen.PieceFactory[] fs){
			factories = fs;
		}

		@Override
		public boolean[][] nextPiece() {
			nextFactory = (nextFactory + 1) % factories.length;
			return factories[nextFactory].nextPiece();
		}
	}
}