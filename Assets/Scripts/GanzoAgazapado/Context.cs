using GanzoAgazapado.Enemies;
using UnityEngine;

namespace GanzoAgazapado
{
	public class Context : MonoBehaviour
	{
		public Lose lose;
		public Player player;
		public SpawnPlan[] plans;

		void Start()
		{
			var enemyFactory = new EnemyFactory(player, lose);

			foreach (var plan in plans) {
				plan.Configure(enemyFactory);
			}
		}
	}
}
