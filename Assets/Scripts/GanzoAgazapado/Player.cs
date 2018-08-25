using GanzoAgazapado.Enemies;
using UnityEngine;

namespace GanzoAgazapado
{
	public class Player : MonoBehaviour
	{
		public float radius = 5f;

		public bool CollidedWith(Chaser chaser) =>
			(chaser.transform.position - transform.position).sqrMagnitude < radius * radius;
	}
}
