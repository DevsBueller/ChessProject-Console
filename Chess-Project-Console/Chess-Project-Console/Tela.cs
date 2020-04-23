using board;
using System;
using chess;
using System.Collections.Generic;

namespace Chess_Project_Console
{
	class Tela
	{
		public static void PrintMatch(ChessMatch match)
		{
			Tela.PrintBoard(match.Bd);
			Console.WriteLine();
			PrintCatchedPieces(match);
			Console.WriteLine();
			Console.WriteLine("Turno: " + match.shift);
			Console.WriteLine("Aguardando jogada: " + match.currentPlayer);
			if (match.Check)
			{
				Console.WriteLine("XEQUE!");
			}

		}
		public static void PrintCatchedPieces(ChessMatch match)
		{
			Console.WriteLine("Peças capturadas");
			Console.Write("Brancas: ");
			PrintSet(match.CatchedPieces(Color.White));
			Console.WriteLine();
			Console.Write("Pretas: ");
			ConsoleColor aux = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;
			PrintSet(match.CatchedPieces(Color.Black));
			Console.ForegroundColor = aux;
			Console.WriteLine();
		}
		public static void PrintSet(HashSet<Piece> set)
		{
			Console.Write("[");
			foreach (var item in set)
			{
				Console.Write(item + " ");
			}
			Console.Write("]");

		}
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
					if (possiblePositions[i, j])
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
