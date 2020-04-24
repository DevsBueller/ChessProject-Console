using board;

namespace chess
{
	class Pawn : Piece
	{
		private ChessMatch match;
		public Pawn(Board bd, Color color, ChessMatch match) : base(bd, color)
		{
			this.match = match;
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

				//# Jogada especial enPassant
				if (Position.Linha == 3)
				{
					Position left = new Position(Position.Linha, Position.Coluna - 1);
					if (Bd.ValidPosition(left) && ExistEnemie(left) && Bd.Piece(left) == match.vulnerableEnPassant)
					{
						mat[left.Linha -1, left.Coluna] = true;
					}
					Position right = new Position(Position.Linha, Position.Coluna + 1);
					if (Bd.ValidPosition(right) && ExistEnemie(right) && Bd.Piece(right) == match.vulnerableEnPassant)
					{
						mat[right.Linha-1, right.Coluna] = true;
					}
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
				//# Jogada especial enPassant
				if (Position.Linha == 4)
				{
					Position left = new Position(Position.Linha, Position.Coluna - 1);
					if (Bd.ValidPosition(left) && ExistEnemie(left) && Bd.Piece(left) == match.vulnerableEnPassant)
					{
						mat[left.Linha+1, left.Coluna] = true;
					}
					Position right = new Position(Position.Linha, Position.Coluna + 1);
					if (Bd.ValidPosition(right) && ExistEnemie(right) && Bd.Piece(right) == match.vulnerableEnPassant)
					{
						mat[right.Linha+1, right.Coluna] = true;
					}
				}
			}

			return mat;

		}


	}
}



