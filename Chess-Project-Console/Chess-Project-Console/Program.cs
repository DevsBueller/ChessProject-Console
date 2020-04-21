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
				Board Bd = new Board(8, 8);
				Bd.ColocarPeca(new Tower(Bd, Color.Black), new Position(0, 0));
				Bd.ColocarPeca(new Tower(Bd, Color.Black), new Position(1, 7));
				Bd.ColocarPeca(new King(Bd, Color.Black), new Position(0, 0));
				Tela.ImprimirTabuleiro(Bd);

			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}


			Console.ReadLine();

		}
	}
}
