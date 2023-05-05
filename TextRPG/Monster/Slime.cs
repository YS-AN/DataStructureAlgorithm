using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
	internal class Slime : Monster
	{
		public Slime() : base('♨') { }

		public override void MoveAction()
		{
			if (MoveCount++ % 3 == 0)
			{
				return;

			}
			Random random = new Random();
			Move((Direction)random.Next(0, 4));
		}
	}
}
