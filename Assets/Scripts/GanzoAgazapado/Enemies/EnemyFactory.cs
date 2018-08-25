using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class EnemyFactory
	{
		readonly Player player;
		readonly Lose lose;

		public EnemyFactory(Player player, Lose lose)
		{
			this.player = player;
			this.lose = lose;
		}

		public void Spawn(Enemy spawnEnemy, Vector3 transformPosition)
		{
			var enemy = Enemy.Spawn(spawnEnemy, transformPosition, player.transform);

			Shooter shooter;
			Chaser chaser;

			if ((shooter = enemy.GetComponent<Shooter>()) != null) {
				shooter.Configure(lose.Do);
			}

			if ((chaser = enemy.GetComponent<Chaser>()) != null) {
				chaser.Configure(lose.Do, player);
			}
		}
	}
}
