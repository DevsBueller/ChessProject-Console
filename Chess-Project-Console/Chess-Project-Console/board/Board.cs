

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
		public void ColocarPeca(Piece p, Position pos)
		{
			pieces[pos.Linha, pos.Coluna] = p;
			p.Position = pos;
		}
	}
}
