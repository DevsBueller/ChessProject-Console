

namespace board
{
	class Peca
	{
		public Posicao Posicao { get; set; }
		public Cor Cor { get; set; }
		public int QtdMovimentos { get; set; }
		public Tabuleiro Tab { get; set; }

		public Peca(Tabuleiro tabuleiro, Cor cor)
		{
			Posicao = null;
			Cor = cor;
			QtdMovimentos = 0;
			Tab = tabuleiro;
		}
	}
}
