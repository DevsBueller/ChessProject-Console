using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using board;
namespace chess
{
	class ChessMatch
	{
		public Board Bd { get; private set; }
		public int shift { get; private set; }
		public Color currentPlayer { get; private set; }
		public bool Finished { get; private set; }

		public ChessMatch()
		{
			Bd = new Board(8, 8);
			this.shift = 1;
			this.currentPlayer = Color.White;
			Finished = false;
			PutPieces();

		}
		public void ExecuteMove(Position origin, Position destination)
		{
			Piece p = Bd.GetPiece(origin);
			p.AddQtMovies();
			Piece catchPiece = Bd.GetPiece(destination);
			Bd.PutPiece(p, destination);
		}
		public void MakeMove(Position origin, Position destination)
		{
			ExecuteMove(origin, destination);
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
		private void PutPieces()
		{
			Bd.PutPiece(new Tower(Bd, Color.White), new ChessPosition('c', 1).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.White), new ChessPosition('c', 2).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.White), new ChessPosition('d', 2).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.White), new ChessPosition('e', 2).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.White), new ChessPosition('e', 1).ToPosition());
			Bd.PutPiece(new King(Bd, Color.White), new ChessPosition('d', 1).ToPosition());


			Bd.PutPiece(new Tower(Bd, Color.Black), new ChessPosition('c', 7).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.Black), new ChessPosition('c', 8).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.Black), new ChessPosition('d', 7).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.Black), new ChessPosition('e', 7).ToPosition());
			Bd.PutPiece(new Tower(Bd, Color.Black), new ChessPosition('e', 8).ToPosition());
			Bd.PutPiece(new King(Bd, Color.Black), new ChessPosition('d', 8).ToPosition());
		}


	}
}
