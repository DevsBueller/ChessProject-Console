﻿

namespace board
{
	class Piece
	{
		public Position Position { get; set; }
		public Color Color { get; set; }
		public int QtMovies { get; set; }
		public Board Bd { get; set; }

		public Piece(Board board, Color color)
		{
			Position = null;
			Color = color;
			QtMovies = 0;
			Bd = board;
		}
	}
}
