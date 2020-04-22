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
		private int shift;
		private Color currentPlayer;
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
			Piece p  = Bd.GetPiece(origin);
			p.AddQtMovies();
			Piece catchPiece = Bd.GetPiece(destination);
			Bd.PutPiece(p, destination);
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
