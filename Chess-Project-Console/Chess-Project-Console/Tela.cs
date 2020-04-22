﻿using board;
using System;
using chess;

namespace Chess_Project_Console
{
	class Tela
	{
		public static void PrintBoard (Board tab)
		{
			
			for (int i = 0; i < tab.Linhas; i++)
			{
				Console.Write(8 - i + " ");
				for (int j = 0; j < tab.Colunas; j++)
				{
					
					if (tab.Piece(i,j) == null)
					{
						Console.Write("- ");
					}
					else
					{
						Tela.PrintPiece(tab.Piece(i, j));
						Console.Write(" ");
					}
				}
				
				Console.WriteLine();
			}
			Console.WriteLine("  a b c d e f g h");
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
			if(piece.Color == Color.White)
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
		}
	}
}
