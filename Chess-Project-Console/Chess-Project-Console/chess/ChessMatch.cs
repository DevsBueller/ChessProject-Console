
using System.Collections.Generic;


using board;
namespace chess
{
	class ChessMatch
	{
		public Board Bd { get; private set; }
		public int shift { get; private set; }
		public Color currentPlayer { get; private set; }
		public bool Finished { get; private set; }
		private HashSet<Piece> pieces;
		private HashSet<Piece> catched;
		public bool Check { get; private set; }

		public ChessMatch()
		{
			Bd = new Board(8, 8);
			this.shift = 1;
			this.currentPlayer = Color.White;
			Finished = false;
			pieces = new HashSet<Piece>();
			catched = new HashSet<Piece>();
			PutPieces();

		}

		public Piece ExecuteMove(Position origin, Position destination)
		{
			Piece p = Bd.GetPiece(origin);
			p.AddQtMovies();
			Piece catchedPiece = Bd.GetPiece(destination);
			Bd.PutPiece(p, destination);
			if (catchedPiece != null)
			{
				catched.Add(catchedPiece);
			}
			return catchedPiece;
		}
		private void undoMove(Position origin, Position destination, Piece catchedPiece)
		{
			Piece p = Bd.GetPiece(destination);
			p.DecrementQtMovies();
			if (catchedPiece != null)
			{
				Bd.PutPiece(catchedPiece, destination);
				catched.Remove(catchedPiece);
			}
			Bd.PutPiece(p, origin);
		}
		public void MakeMove(Position origin, Position destination)
		{
			Piece catchedPiece = ExecuteMove(origin, destination);
			if (InCheck(currentPlayer))
			{
				undoMove(origin, destination, catchedPiece);
				throw new BoardException("Você não pode se colocar em Xeque");
			}
			if (InCheck(adversaryColor(currentPlayer)))
			{
				Check = true;
			}
			else
			{
				Check = false;
			}
			shift++;
			ChangePlayer();

		}
		public void ValidateOriginPosition(Position pos)
		{
			if (Bd.Piece(pos) == null)
			{
				throw new BoardException("Não existe uma peça na posição de origem escolhida!");
			}
			if (currentPlayer != Bd.Piece(pos).Color)
			{
				throw new BoardException("A peça de origem escolhida não é sua!");
			}
			if (!Bd.Piece(pos).ExistPossibleMoves())
			{
				throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida!");
			}
		}
		public void ValidateDestinationPosition(Position origin, Position destination)
		{
			if (!Bd.Piece(origin).CanMoveTo(destination))
			{
				throw new BoardException("Posição de destino inválida!");
			}

		}
		private void ChangePlayer()
		{
			if (currentPlayer == Color.White)
			{
				currentPlayer = Color.Black;
			}
			else
			{
				currentPlayer = Color.White;
			}
		}
		public HashSet<Piece> CatchedPieces(Color color)
		{
			HashSet<Piece> aux = new HashSet<Piece>();
			foreach (var item in catched)
			{
				if (item.Color == color)
				{
					aux.Add(item);
				}
			}
			return aux;

		}
		public HashSet<Piece> PiecesOnBoard(Color color)
		{
			HashSet<Piece> aux = new HashSet<Piece>();
			foreach (var item in pieces)
			{
				if (item.Color == color)
				{
					aux.Add(item);
				}
			}
			aux.ExceptWith(CatchedPieces(color));
			return aux;
		}
		private Color adversaryColor(Color color)
		{
			if (color == Color.White)
			{
				return Color.Black;
			}
			else
			{
				return Color.White;
			}

		}
		private Piece King(Color color)
		{
			foreach (Piece item in PiecesOnBoard(color))
			{
				if (item is King)
				{
					return item;
				}
			}
			return null;
		}
		public bool InCheck(Color color)
		{
			Piece R = King(color);
			if (R == null)
			{
				throw new BoardException("Não tem a peça Rei no tabuleiro");
			}
			foreach (Piece item in PiecesOnBoard(adversaryColor(color)))
			{
				bool[,] mat = item.PossibleMoves();
				if (mat[R.Position.Linha, R.Position.Coluna])
				{
					return true;
				}

			}
			return false;
		}
		public void PutNewPiece(char coluna, int linha, Piece piece)
		{
			Bd.PutPiece(piece, new ChessPosition(coluna, linha).ToPosition());
			pieces.Add(piece);
		}
		private void PutPieces()
		{
			PutNewPiece('c', 1, new Tower(Bd, Color.White));
			PutNewPiece('c', 2, new Tower(Bd, Color.White));
			PutNewPiece('d', 2, new Tower(Bd, Color.White));
			PutNewPiece('e', 2, new Tower(Bd, Color.White));
			PutNewPiece('e', 1, new Tower(Bd, Color.White));
			PutNewPiece('d', 1, new King(Bd, Color.White));

			PutNewPiece('c', 7, new Tower(Bd, Color.Black));
			PutNewPiece('c', 8, new Tower(Bd, Color.Black));
			PutNewPiece('d', 7, new Tower(Bd, Color.Black));
			PutNewPiece('e', 7, new Tower(Bd, Color.Black));
			PutNewPiece('e', 8, new Tower(Bd, Color.Black));
			PutNewPiece('d', 8, new King(Bd, Color.Black));


		}


	}
}
