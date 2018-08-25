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

		
		void Awake()
		{
			var scene = VRScene.Instance;
			Invoke("InitializeGame", 0.1f);
		}

		void InitializeGame()
		{
			var enemyFactory = new EnemyFactory(player, loop);
			var shootLogic = VRScene.Instance.shootLogic;

			foreach (var plan in plans.GetComponentsInChildren<SpawnPlan>())
				plan.Configure(enemyFactory, loop);

			loop.OnReady += shootLogic.Activate;
			loop.OnStop += shootLogic.Deactivate;
		}
	}
}
