using board;
using System;

namespace Chess_Project_Console
{
	class Tela
	{
		public static void ImprimirTabuleiro (Board tab)
		{
			for (int i = 0; i < tab.Linhas; i++)
			{
				for (int j = 0; j < tab.Colunas; j++)
				{
					if (tab.Piece(i,j) == null)
					{
						Console.Write("- ");
					}
					else
					{
						Console.Write(tab.Piece(i,j) + " ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}
