using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
	public abstract class Scene
	{
		/// <summary>
		/// 어떤 게임에 대한 소속인지를 기록하기 위한 변수
		/// </summary>
		protected Game game;

		public Scene(Game game)
		{
			this.game = game;
		}

		/// <summary>
		/// 화면에 그려짐
		/// </summary>
		public abstract void Render();

		/// <summary>
		/// 데이터 갱신
		/// </summary>
		public abstract void Update();
	}
}
