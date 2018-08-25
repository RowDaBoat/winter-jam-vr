using GanzoAgazapado.Enemies;
using UnityEngine;

namespace GanzoAgazapado
{
	public class Context : MonoBehaviour
	{
		public Lose lose;
		public Player player;
		public Transform plans;
		
		void Start()
		{
			var enemyFactory = new EnemyFactory(player, lose);

			foreach (var plan in plans.GetComponentsInChildren<SpawnPlan>())
				plan.Configure(enemyFactory);
		}
	}
}
