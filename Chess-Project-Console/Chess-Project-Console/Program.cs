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
			

			Board Bd  = new Board(8, 8);
			Bd.ColocarPeca(new Tower(Bd, Color.Preta), new Position(0, 0));
			Bd.ColocarPeca(new Tower(Bd, Color.Preta), new Position(1, 3));
			Bd.ColocarPeca(new King(Bd, Color.Preta), new Position(2, 4));
			Tela.ImprimirTabuleiro(Bd);

			Console.ReadLine();

		}
	}
}
