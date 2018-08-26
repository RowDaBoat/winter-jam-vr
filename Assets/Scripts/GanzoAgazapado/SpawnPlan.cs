using System;
using System.Collections;
using GanzoAgazapado.Enemies;
using GanzoAgazapado.GameLoop;
using UnityEngine;

namespace GanzoAgazapado
{
	[Serializable]
	public class Spawn
	{
		public Enemy enemy;
		public float nextTime;
		public Spawner spawner;
	}
	
	public class SpawnPlan : MonoBehaviour
	{
		public float planStartTime;
		public Spawn[] plan;
		public bool repeat;
		
		Loop loop;

		EnemyFactory enemyFactory;
		Coroutine run;
		BulletTimePowerUp bulletTimePowerUp;

		public void Configure(EnemyFactory enemyFactory, Loop loop, BulletTimePowerUp bulletTimePowerUp)
		{
			this.enemyFactory = enemyFactory;
			this.bulletTimePowerUp = bulletTimePowerUp;

			loop.OnReady += () => run = StartCoroutine(Run());
			loop.OnStop += () => StopCoroutine(run);
		}

		IEnumerator Run()
		{
			yield return new WaitForSeconds(planStartTime);

			do {
				foreach (var spawn in plan) {
					var enemy = enemyFactory.Spawn(spawn.enemy, spawn.spawner);
					enemy.OnDeath += bulletTimePowerUp.AddKill;
					yield return new WaitForSeconds(spawn.nextTime);
				}
			} while (repeat);
		}
	}
}
