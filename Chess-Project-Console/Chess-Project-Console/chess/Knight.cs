using board;

namespace chess
{
	class Knight: Piece
	{
		public Knight(Board bd, Color color) : base(bd, color)
		{

		}
		public override string ToString()
		{
			return "C";
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
			pos.DefineValue(Position.Linha - 1, Position.Coluna -2);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			// ne
			pos.DefineValue(Position.Linha - 2, Position.Coluna - 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			
			pos.DefineValue(Position.Linha - 2, Position.Coluna + 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

			
			pos.DefineValue(Position.Linha - 1, Position.Coluna + 2);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}

		
			pos.DefineValue(Position.Linha + 1, Position.Coluna + 2);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			
			pos.DefineValue(Position.Linha + 2, Position.Coluna + 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
		
			pos.DefineValue(Position.Linha + 2, Position.Coluna - 1);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			
			pos.DefineValue(Position.Linha +1, Position.Coluna - 2);
			if (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
			}
			
			return mat;

		}
	}
}
