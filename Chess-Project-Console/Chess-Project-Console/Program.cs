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
					Console.Clear();
					Tela.PrintBoard(Match.Bd);

					Console.WriteLine();
					Console.Write("Origem: ");
					Position origin = Tela.ReadChessPosition().ToPosition();

					Console.Clear();
					bool[,] possiblePositions = Match.Bd.Piece(origin).PossibleMovies();
					Tela.PrintBoard(Match.Bd, possiblePositions);
					Console.WriteLine();
					Console.Write("Destino: ");
					Position destination = Tela.ReadChessPosition().ToPosition();

					Match.ExecuteMove(origin, destination);

				}

			}
			catch (BoadException e)
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
