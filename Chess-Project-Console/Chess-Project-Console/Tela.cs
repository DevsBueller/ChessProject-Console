using board;
using System;

namespace Chess_Project_Console
{
	class Tela
	{
		public static void ImprimirTabuleiro (Tabuleiro tab)
		{
			for (int i = 0; i < tab.Linhas; i++)
			{
				for (int j = 0; j < tab.Colunas; j++)
				{
					if (tab.Peca(i,j) == null)
					{
						Console.Write("- ");
					}
					else
					{
						Console.Write(tab.Peca(i,j) + " ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}
