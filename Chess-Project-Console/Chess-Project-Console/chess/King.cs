using board;

namespace chess
{
	class King: Piece
	{
		public King (Board bd, Color color):base(bd, color)
		{

		}
		public bool CanMove(Position pos)
		{
			Piece p = Bd.Piece(pos);
			return p == null || p.Color != Color;
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
			return mat;


		}

		public override string ToString()
		{
			return "R";
		}

	}
}
