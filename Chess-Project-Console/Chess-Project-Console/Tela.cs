using board;
using System;
using chess;

namespace Chess_Project_Console
{
	class Tela
	{
		public static void PrintBoard(Board tab)
		{
			for (int i = 0; i < tab.Linhas; i++)
			{
				Console.Write(8 - i + " ");
				for (int j = 0; j < tab.Colunas; j++)
				{
					Tela.PrintPiece(tab.Piece(i, j));

				}
				Console.WriteLine();
			}
			Console.WriteLine("  a b c d e f g h");
		}
		public static void PrintBoard(Board tab, bool[,] possiblePositions)
		{
			ConsoleColor orignalBlackground = Console.BackgroundColor;
			ConsoleColor alteredBlackground = ConsoleColor.DarkGray;
			for (int i = 0; i < tab.Linhas; i++)
			{
				Console.Write(8 - i + " ");
				for (int j = 0; j < tab.Colunas; j++)
				{
					if(possiblePositions[i, j])
					{
						Console.BackgroundColor = alteredBlackground;
					}
					else
					{
						Console.BackgroundColor = orignalBlackground;
					}
					Tela.PrintPiece(tab.Piece(i, j));
					Console.BackgroundColor = orignalBlackground;
				}
				Console.WriteLine();
			}
			Console.WriteLine("  a b c d e f g h");
			Console.BackgroundColor = orignalBlackground;
		}
		public static ChessPosition ReadChessPosition()
		{
			string s = Console.ReadLine();
			char coluna = s[0];
			int linha = int.Parse(s[1] + "");
			return new ChessPosition(coluna, linha);
		}
		public static void PrintPiece(Piece piece)
		{
			if (piece == null)
			{
				Console.Write("- ");
			}
			else
			{
				if (piece.Color == Color.White)
				{
					Console.Write(piece);
				}
				else
				{
					ConsoleColor aux = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write(piece);
					Console.ForegroundColor = aux;


				}
				Console.Write(" ");
			}

		}
	}
}
