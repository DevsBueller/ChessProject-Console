using board;

namespace chess
{
	class Tower : Piece
	{
		public Tower(Board bd, Color cor) : base(bd, cor)
		{

		}

		public bool CanMove(Position pos)
		{
			Piece p = Bd.Piece(pos);
			return p == null || p.Color != Color;
		}
		public override bool[,] PossibleMovies()
		{
			bool[,] mat = new bool[Bd.Linhas, Bd.Colunas];
			Position pos = new Position(0, 0);
			// up
			pos.DefineValue(Position.Linha -1, Position.Coluna);
			while(Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.Linha = pos.Linha - 1;

			}
			// down
			pos.DefineValue(Position.Linha + 1, Position.Coluna);
			while (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.Linha = pos.Linha + 1;

			}
			// right
			pos.DefineValue(Position.Linha, Position.Coluna+1);
			while (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.Coluna = pos.Coluna + 1;

				
			}
			// right
			pos.DefineValue(Position.Linha, Position.Coluna - 1);
			while (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.Coluna = pos.Coluna - 1;

				
			}
			return mat;
		}




		public override string ToString()
		{
			return "T";
		}
	}
}
