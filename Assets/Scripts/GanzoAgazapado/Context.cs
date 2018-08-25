using GanzoAgazapado.Enemies;
using GanzoAgazapado.GameLoop;
using UnityEngine;

namespace GanzoAgazapado
{
	public class Context : MonoBehaviour
	{
		public Loop loop;
		public Player player;
		public Transform plans;
		public GameController controller;

		void Start()
		{
			var enemyFactory = new EnemyFactory(player, loop);

			foreach (var plan in plans.GetComponentsInChildren<SpawnPlan>())
				plan.Configure(enemyFactory, loop);
		}
	}
}
