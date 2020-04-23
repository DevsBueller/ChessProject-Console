using board;
using chess;


namespace chess
{
	class Bishop : Piece
	{
		public Bishop(Board bd, Color color) : base(bd, color)
		{

		}
		public override string ToString()
		{
			return "B";
		}
		private bool CanMove(Position pos)
		{
			Piece p = Bd.Piece(pos);
			return p == null || p.Color != Color;
		}

		public override bool[,] PossibleMoves()
		{
			bool[,] mat = new bool[Bd.Linhas, Bd.Colunas];

			Position pos = new Position(0, 0);
			
			// no
			pos.DefineValue(Position.Linha - 1, Position.Coluna -1);
			while (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.DefineValue(pos.Linha - 1, pos.Coluna -1 );

			}

			// ne
			pos.DefineValue(Position.Linha - 1, Position.Coluna + 1);
			while (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.DefineValue(pos.Linha - 1, pos.Coluna + 1); ;

			}

			// se
			pos.DefineValue(Position.Linha + 1, Position.Coluna + 1);
			while (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.DefineValue(pos.Linha + 1, pos.Coluna + 1);


			}

			// so
			pos.DefineValue(Position.Linha + 1, Position.Coluna - 1);
			while (Bd.ValidPosition(pos) && CanMove(pos))
			{
				mat[pos.Linha, pos.Coluna] = true;
				if (Bd.Piece(pos) != null && Bd.Piece(pos).Color != Color)
				{
					break;
				}
				pos.DefineValue(pos.Linha + 1, pos.Coluna - 1);


			}
			return mat;

		}
	}
}
