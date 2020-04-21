using board;

namespace chess
{
	class King: Piece
	{
		public King (Board tab, Color color):base(tab, color)
		{

		}
		public override string ToString()
		{
			return "R";
		}
	}
}
