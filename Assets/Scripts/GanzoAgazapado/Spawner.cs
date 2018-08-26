using System;
using GanzoAgazapado.Waypoints;
using UnityEngine;
using System.Linq;
using GanzoAgazapado.Enemies;

namespace GanzoAgazapado
{
	public class Spawner : MonoBehaviour
	{
		public Enemy Spawn(Enemy spawnEnemy, Transform playerTransform)
		{
			var enemy = Enemy.Spawn(spawnEnemy, transform.position, playerTransform);

			var walker = enemy.GetComponent<SmoothWaypointWalker>();

			if (walker != null)
				walker.current = GetComponentsInChildren<Waypoint>()[1];
			
			return enemy;
		}
		
		void OnDrawGizmos()
		{
			var waypoints = GetComponentsInChildren<Waypoint>();

			foreach (var nextAndCurrent in waypoints.Skip(1).Zip(waypoints, Tuple.Create)) {
				nextAndCurrent.Item2.next = nextAndCurrent.Item1;
			}

			if (waypoints.Length > 0)
				waypoints.Last().next = null;
		}
	}
}
