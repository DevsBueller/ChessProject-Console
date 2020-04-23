

namespace board
{
	abstract class Piece
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
		
		public void AddQtMovies()
		{
			QtMovies++;
		}
		public void DecrementQtMovies()
		{
			QtMovies--;
		}
		public bool ExistPossibleMoves()
		{
			bool[,] mat = PossibleMoves();
			for (int i = 0; i < Bd.Linhas; i++)
			{
				for (int j = 0; j < Bd.Colunas; j++)
				{
					if(mat[i, j])
					{
						return true;
					}

				}

			}
			return false;

		}
		public bool PossibleMove(Position pos)
		{
			return PossibleMoves()[pos.Linha, pos.Coluna];
		}
		public abstract bool[,] PossibleMoves();

	}
}
