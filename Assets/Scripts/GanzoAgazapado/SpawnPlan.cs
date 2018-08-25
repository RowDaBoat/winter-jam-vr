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
		Loop loop;

		EnemyFactory enemyFactory;
		Coroutine run;

		public void Configure(EnemyFactory enemyFactory, Loop loop)
		{
			this.enemyFactory = enemyFactory;

			loop.OnReady += () => run = StartCoroutine(Run());
			loop.OnStop += () => StopCoroutine(run);
		}

		IEnumerator Run()
		{
			yield return new WaitForSeconds(planStartTime);

			foreach (var spawn in plan) {
				enemyFactory.Spawn(spawn.enemy, spawn.spawner.transform.position);
				yield return new WaitForSeconds(spawn.nextTime);
			}
		}
	}
}
