using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
	class BoadException : Exception
	{
		public BoadException(string message) : base(message)
		{

		}
	}
}
