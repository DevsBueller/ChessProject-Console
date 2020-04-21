

namespace tabuleiro
{
	class Peca
	{
		public Posicao Posicao { get; set; }
		public Cor Cor { get; set; }
		public int QtdMovimentos { get; set; }
		public Tabuleiro Tab { get; set; }

		public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro)
		{
			Posicao = posicao;
			Cor = cor;
			QtdMovimentos = 0;
			Tab = tabuleiro;
		}
	}
}
