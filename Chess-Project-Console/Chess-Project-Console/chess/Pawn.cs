using board;

namespace chess
{
	class Pawn : Piece
	{
		public Pawn(Board bd, Color color) : base(bd, color)
		{

		}
		public override string ToString()
		{
			return "P";
		}
		private bool ExistEnemie(Position pos)
		{
			Piece p = Bd.Piece(pos);
			return p != null && p.Color != Color;
		}
		private bool Free(Position pos)
		{
			return Bd.Piece(pos) == null;
		}

		public override bool[,] PossibleMoves()
		{
			bool[,] mat = new bool[Bd.Linhas, Bd.Colunas];
			Position pos = new Position(0, 0);


			if (Color == Color.White)
			{
				pos.DefineValue(Position.Linha - 1, Position.Coluna);
				if (Bd.ValidPosition(pos) && Free(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
				pos.DefineValue(Position.Linha - 2, Position.Coluna);
				Position p2 = new Position(Position.Linha - 1, Position.Coluna);
				if (Bd.ValidPosition(p2) && Free(p2) && Bd.ValidPosition(pos) && Free(pos) && QtMovies == 0)
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
				pos.DefineValue(Position.Linha - 1, Position.Coluna - 1);
				if (Bd.ValidPosition(pos) && ExistEnemie(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
				pos.DefineValue(Position.Linha - 1, Position.Coluna + 1);
				if (Bd.ValidPosition(pos) && ExistEnemie(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
			}
			else
			{
				pos.DefineValue(Position.Linha + 1, Position.Coluna);
				if (Bd.ValidPosition(pos) && Free(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
				pos.DefineValue(Position.Linha + 2, Position.Coluna);
				Position p2 = new Position(Position.Linha + 1, Position.Coluna);
				if (Bd.ValidPosition(p2) && Free(p2) && Bd.ValidPosition(pos) && Free(pos) && QtMovies == 0)
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
				pos.DefineValue(Position.Linha + 1, Position.Coluna - 1);
				if (Bd.ValidPosition(pos) && ExistEnemie(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
				pos.DefineValue(Position.Linha + 1, Position.Coluna + 1);
				if (Bd.ValidPosition(pos) && ExistEnemie(pos))
				{
					mat[pos.Linha, pos.Coluna] = true;
				}
			}

			return mat;

		}


	}
}



