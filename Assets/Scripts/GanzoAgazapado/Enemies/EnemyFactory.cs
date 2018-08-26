using GanzoAgazapado.GameLoop;
using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class EnemyFactory
	{
		readonly Player player;
		readonly Loop loop;

		public EnemyFactory(Player player, Loop loop)
		{
			this.player = player;
			this.loop = loop;
		}

		public Enemy Spawn(Enemy spawnEnemy, Spawner spawner)
		{
			var enemy = spawner.Spawn(spawnEnemy, player.transform);

			Shooter shooter;
			Chaser chaser;

			if ((shooter = enemy.GetComponent<Shooter>()) != null) {
				shooter.Configure(loop);
			}

			if ((chaser = enemy.GetComponent<Chaser>()) != null) {
				chaser.Configure(player, loop);
			}

			return enemy;
		}
	}
}
