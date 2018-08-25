using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class EnemyFactory
	{
		readonly Transform player;
		readonly Lose lose;

		public EnemyFactory(Transform player, Lose lose)
		{
			this.player = player;
			this.lose = lose;
		}

		public void Spawn(Enemy spawnEnemy, Vector3 transformPosition)
		{
			var enemy = Enemy.Spawn(spawnEnemy, transformPosition, player);

			Shooter shooter;

			if ((shooter = enemy.GetComponent<Shooter>()) != null) {
				shooter.Configure(lose.Do);
			}
		}
	}
}
