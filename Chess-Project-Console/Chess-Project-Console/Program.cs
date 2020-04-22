using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chess;
using board;


namespace Chess_Project_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ChessMatch Match = new ChessMatch();
				while (!Match.Finished)
				{
					try
					{
						Console.Clear();
						Tela.PrintBoard(Match.Bd);
						Console.WriteLine();
						Console.WriteLine("Turno: " + Match.shift);
						Console.WriteLine("Aguardando jogada: " + Match.currentPlayer);

						Console.WriteLine();
						Console.Write("Origem: ");
						Position origin = Tela.ReadChessPosition().ToPosition();
						Match.ValidateOriginPosition(origin);
						Console.Clear();
						bool[,] possiblePositions = Match.Bd.Piece(origin).PossibleMoves();
						Tela.PrintBoard(Match.Bd, possiblePositions);
						Console.WriteLine();
						Console.Write("Destino: ");
						Position destination = Tela.ReadChessPosition().ToPosition();
						Match.ValidateDestinationPosition(origin, destination);

						Match.MakeMove(origin, destination);
					}
					catch (BoardException e)
					{

						Console.WriteLine(e.Message);
						Console.ReadLine();
					}
					

				}

			}
			catch (BoardException e)
			{

				Console.WriteLine(e.Message);
			}
			//ChessPosition ChessPosition = new ChessPosition('c', 7);
			//Console.WriteLine(ChessPosition);
			//Console.WriteLine(ChessPosition.ToPosition());

			Console.ReadLine();

		}
	}
}
