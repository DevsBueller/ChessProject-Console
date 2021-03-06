﻿
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
		public Piece vulnerableEnPassant { get; private set; }

		public ChessMatch()
		{
			Bd = new Board(8, 8);
			this.shift = 1;
			this.currentPlayer = Color.White;
			Finished = false;
			vulnerableEnPassant = null;
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

			//#Jogada especial Roque pequeno
			if (p is King && destination.Coluna == origin.Coluna + 2)
			{
				Position tOrigin = new Position(origin.Linha, origin.Coluna + 3);
				Position tDestination = new Position(origin.Linha, origin.Coluna + 1);
				Piece T = Bd.GetPiece(tOrigin);
				T.AddQtMovies();
				Bd.PutPiece(T, tDestination);
			}
			//#Jogada especial Roque Grande
			if (p is King && destination.Coluna == origin.Coluna - 2)
			{
				Position tOrigin = new Position(origin.Linha, origin.Coluna - 4);
				Position tDestination = new Position(origin.Linha, origin.Coluna - 1);
				Piece T = Bd.GetPiece(tOrigin);
				T.AddQtMovies();
				Bd.PutPiece(T, tDestination);
			}
			//#Jogada especial enPassant
			if (p is Pawn)
			{
				if(origin.Coluna != destination.Coluna && catchedPiece == null)
				{
					Position posP;
					if(p.Color == Color.White)
					{
						posP = new Position(destination.Linha + 1, destination.Coluna);
					}
					else
					{
						posP = new Position(destination.Linha - 1, destination.Coluna);
					}
					catchedPiece = Bd.GetPiece(posP);
					catched.Add(catchedPiece);

				}

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

			//#Jogada especial Roque pequeno
			if (p is King && destination.Coluna == origin.Coluna + 2)
			{
				Position tOrigin = new Position(origin.Linha, origin.Coluna + 3);
				Position tDestination = new Position(origin.Linha, origin.Coluna + 1);
				Piece T = Bd.GetPiece(tOrigin);
				T.DecrementQtMovies();
				Bd.PutPiece(T, tDestination);
			}
			//#Jogada especial Roque grande
			if (p is King && destination.Coluna == origin.Coluna - 2)
			{
				Position tOrigin = new Position(origin.Linha, origin.Coluna -4);
				Position tDestination = new Position(origin.Linha, origin.Coluna - 1);
				Piece T = Bd.GetPiece(tOrigin);
				T.DecrementQtMovies();
				Bd.PutPiece(T, tDestination);
			}
			//#Jogada especial En Passant
			if(p is Pawn)
			{
				if(origin.Coluna != destination.Coluna && catchedPiece == vulnerableEnPassant)
				{
					Piece pawn = Bd.GetPiece(destination);
					Position posP;
					if(p.Color == Color.White)
					{
						posP = new Position(3, destination.Coluna);
					}
					else
					{
						posP = new Position(4, destination.Coluna);
					}
					Bd.PutPiece(pawn, posP);
				}
			}
		}
		public void MakeMove(Position origin, Position destination)
		{
			Piece catchedPiece = ExecuteMove(origin, destination);
			if (InCheck(currentPlayer))
			{
				undoMove(origin, destination, catchedPiece);
				throw new BoardException("Você não pode se colocar em Xeque");
			}
			Piece p = Bd.Piece(destination);
			//# Jogada especial promoção
			if(p is Pawn)
			{
				if ((p.Color == Color.White && destination.Linha == 0) || (p.Color == Color.Black && destination.Linha == 7))
				{
					p = Bd.GetPiece(destination);
					pieces.Remove(p);
					Piece queen = new Queen(Bd, p.Color);
					Bd.PutPiece(queen, destination);
					pieces.Add(queen);
				}
			}
			if (InCheck(adversaryColor(currentPlayer)))
			{
				Check = true;
			}
			else
			{
				Check = false;
			}
			if (TestMate(adversaryColor(currentPlayer)))
			{
				Finished = true;
			}
			else
			{
				shift++;
				ChangePlayer();
			}
		

			//#Jogada especial enPassant
			if(p is Pawn &&(destination.Linha == origin.Linha - 2 || destination.Linha == origin.Linha + 2))
			{
				vulnerableEnPassant = p;
			}
			else
			{
				vulnerableEnPassant = null;
			}

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
			if (!Bd.Piece(origin).PossibleMove(destination))
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
				throw new BoardException("Não tem Rei da cor" + color + "no tabuleiro: ");
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
		public bool TestMate(Color color)
		{
			if (!InCheck(color))
			{
				return false;
			}
			foreach (var item in PiecesOnBoard(color))
			{
				bool[,] mat = item.PossibleMoves();
				for (int i = 0; i < Bd.Linhas; i++)
				{
					for (int j = 0; j < Bd.Colunas; j++)
					{
						if (mat[i, j])
						{
							Position origin = item.Position;
							Position destination = new Position(i, j);
							Piece catchedPiece = ExecuteMove(origin, destination);
							bool testCheck = InCheck(color);
							undoMove(origin, destination, catchedPiece);
							if (!testCheck)
							{
								return false;
							}
						}

					}
				}
			}
			return true;
		}
		public void PutNewPiece(char coluna, int linha, Piece piece)
		{
			Bd.PutPiece(piece, new ChessPosition(coluna, linha).ToPosition());
			pieces.Add(piece);
		}
		private void PutPieces()
		{
			PutNewPiece('a', 1, new Tower(Bd, Color.White));
			PutNewPiece('b', 1, new Knight(Bd, Color.White));
			PutNewPiece('c', 1, new Bishop(Bd, Color.White));
			PutNewPiece('d', 1, new Queen(Bd, Color.White));
			PutNewPiece('e', 1, new King(Bd, Color.White, this));
			PutNewPiece('f', 1, new Bishop(Bd, Color.White));
			PutNewPiece('g', 1, new Knight(Bd, Color.White));
			PutNewPiece('h', 1, new Tower(Bd, Color.White));
			PutNewPiece('a', 2, new Pawn(Bd, Color.White, this));
			PutNewPiece('b', 2, new Pawn(Bd, Color.White, this));
			PutNewPiece('c', 2, new Pawn(Bd, Color.White, this));
			PutNewPiece('d', 2, new Pawn(Bd, Color.White, this));
			PutNewPiece('e', 2, new Pawn(Bd, Color.White, this));
			PutNewPiece('f', 2, new Pawn(Bd, Color.White, this));
			PutNewPiece('g', 2, new Pawn(Bd, Color.White, this));
			PutNewPiece('h', 2, new Pawn(Bd, Color.White, this));


			PutNewPiece('a', 8, new Tower(Bd, Color.Black));
			PutNewPiece('b', 8, new Knight(Bd, Color.Black));
			PutNewPiece('c', 8, new Bishop(Bd, Color.Black));
			PutNewPiece('d', 8, new Queen(Bd, Color.Black));
			PutNewPiece('e', 8, new King(Bd, Color.Black, this));
			PutNewPiece('f', 8, new Bishop(Bd, Color.Black));
			PutNewPiece('g', 8, new Knight(Bd, Color.Black));
			PutNewPiece('h', 8, new Tower(Bd, Color.Black));
			PutNewPiece('a', 7, new Pawn(Bd, Color.Black, this));
			PutNewPiece('b', 7, new Pawn(Bd, Color.Black, this));
			PutNewPiece('c', 7, new Pawn(Bd, Color.Black, this));
			PutNewPiece('d', 7, new Pawn(Bd, Color.Black, this));
			PutNewPiece('e', 7, new Pawn(Bd, Color.Black, this));
			PutNewPiece('f', 7, new Pawn(Bd, Color.Black, this));
			PutNewPiece('g', 7, new Pawn(Bd, Color.Black, this));
			PutNewPiece('h', 7, new Pawn(Bd, Color.Black, this));


		}


	}
}
