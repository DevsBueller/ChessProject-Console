using board;

namespace chess
{
	class King: Piece
	{
		private ChessMatch match;
		public King (Board bd, Color color, ChessMatch match):base(bd, color)
		{
			this.match = match;
		}
		private bool CanMove(Position pos)
		{
			Piece p = Bd.Piece(pos);
			return p == null || p.Color != Color;
		}
		private bool TestTowerforRoque(Position pos)
		{
			Piece p = Bd.Piece(pos);
			return p != null && p is Tower && p.Color == Color && p.QtMovies == 0;
		}
		public override bool[,] PossibleMoves()
		{
			bool[,] mat = new bool[Bd.Linhas, Bd.Colunas];
			Position pos = new Position(0, 0);
			// up
			pos.DefineValue(Position.Linha - 1, Position.Coluna);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				 mat [pos.Linha, pos.Coluna]  = true;
			}
			// ne
			pos.DefineValue(Position.Linha -1 , Position.Coluna +1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			//right
			pos.DefineValue(Position.Linha , Position.Coluna + 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			//se
			pos.DefineValue(Position.Linha + 1, Position.Coluna + 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			//down
			pos.DefineValue(Position.Linha + 1, Position.Coluna);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			//sw
			pos.DefineValue(Position.Linha + 1, Position.Coluna - 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			//left
			pos.DefineValue(Position.Linha, Position.Coluna - 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			//nw
			pos.DefineValue(Position.Linha -1, Position.Coluna - 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			//# Jogada especial Roque
			if(QtMovies == 0  && !match.Check)
			{ //# Jogada especial roque pequeno
				Position PosT1 = new Position(Position.Linha, Position.Coluna + 3);
				if (TestTowerforRoque(PosT1))
				{
					Position p1 = new Position(Position.Linha, Position.Coluna + 1);
					Position p2 = new Position(Position.Linha, Position.Coluna + 2);
					if(Bd.Piece(p1) == null && Bd.Piece(p2)== null)
					{
						mat[Position.Linha, Position.Coluna + 2] = true;
					}
				}
				//# Jogada especial roque grande
				Position PosT2 = new Position(Position.Linha, Position.Coluna - 4);
				if (TestTowerforRoque(PosT2))
				{
					Position p1 = new Position(Position.Linha, Position.Coluna - 1);
					Position p2 = new Position(Position.Linha, Position.Coluna - 2);
					Position p3 = new Position(Position.Linha, Position.Coluna - 3);
					if (Bd.Piece(p1) == null && Bd.Piece(p2) == null && Bd.Piece(p3)==null)
					{
						mat[Position.Linha, Position.Coluna - 2] = true;
					}
				}

			}
			
			return mat;



		}

		public override string ToString()
		{
			return "R";
		}

	}
}
