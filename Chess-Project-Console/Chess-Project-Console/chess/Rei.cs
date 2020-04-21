using board;

namespace chess
{
	class Rei: Peca
	{
		public Rei (Tabuleiro tab, Cor cor):base(tab, cor)
		{

		}
		public override string ToString()
		{
			return "R";
		}
	}
}
