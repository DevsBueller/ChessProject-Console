

namespace board
{
	class Board
	{
		public int Linhas { get; set; }
		public int Colunas { get; set; }
		private Piece[,] pieces;

		public Board(int linhas, int colunas)
		{
			Linhas = linhas;
			Colunas = colunas;
			this.pieces = new Piece[linhas, colunas];
		}
		public Piece Piece(int linha, int coluna)
		{
			return pieces[linha, coluna];
		}
		public Piece Piece(Position pos)
		{
			return pieces[pos.Linha, pos.Coluna];
		}


		public void PutPiece(Piece p, Position pos)
		{
			if (PositionExist(pos))
			{
				throw new BoadException("Já existe uma peça nessa posição");
			}
				pieces[pos.Linha, pos.Coluna] = p;
				p.Position = pos;
			
		}
		public Piece GetPiece(Position pos)
		{
			if(Piece(pos) == null)
			{
				return null;
			}
			Piece aux = Piece(pos);
			aux.Position = null;
			pieces[pos.Linha, pos.Coluna] = null;
			return aux;



		}
		public bool PositionExist(Position pos)
		{
			PositionValidation(pos);
			return Piece(pos) != null;
		}
		public bool ValidPosition(Position position)
		{
			if (position.Linha < 0 || position.Linha >= Linhas || position.Coluna < 0 || position.Coluna >= Colunas)
			{
				return false;
			}
			return true;
		}
		public void PositionValidation(Position pos)
		{
			if (!ValidPosition(pos))
			{
				throw new BoadException("Posição Inválida!");
			}
		}

	}
}
