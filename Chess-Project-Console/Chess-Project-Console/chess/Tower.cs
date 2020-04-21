using board;

namespace chess
{
	class Tower : Piece
	{
		public Tower(Board tab, Color cor) : base(tab, cor)
		{

		}
		public override string ToString()
		{
			return "T";
		}
	}
}
