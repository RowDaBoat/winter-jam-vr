using System;
using System.Collections;
using GanzoAgazapado.Enemies;
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
		public Transform player;
		public Spawn[] plan;

		EnemyFactory enemyFactory;

		public void Configure(EnemyFactory enemyFactory)
		{
			this.enemyFactory = enemyFactory;
		}
		
		void Start()
		{
			StartCoroutine(Run());
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
