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

		public void Spawn(Enemy spawnEnemy, Vector3 transformPosition)
		{
			var enemy = Enemy.Spawn(spawnEnemy, transformPosition, player.transform);

			Shooter shooter;
			Chaser chaser;

			if ((shooter = enemy.GetComponent<Shooter>()) != null) {
				shooter.Configure(loop.Lose);
			}

			if ((chaser = enemy.GetComponent<Chaser>()) != null) {
				chaser.Configure(loop.Lose, player);
			}
		}
	}
}
