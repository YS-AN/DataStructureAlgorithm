using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_MakeRich
{
	public abstract class Scene
	{
		public abstract void StartScene();

		/// <summary>
		/// 씬 초기화
		/// </summary>
		public abstract void InitScene();

		/// <summary>
		/// 화면에 그려짐
		/// </summary>
		public abstract void Render();

		/// <summary>
		/// 데이터 갱신
		/// </summary>
		public abstract void Update();

		public abstract void Close();
	}
}
