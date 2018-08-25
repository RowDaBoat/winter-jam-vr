using System.Runtime.CompilerServices;
using GanzoAgazapado.GameLoop;
using UnityEngine;
using UnityEngine.Animations;

namespace GanzoAgazapado.Enemies
{
	public class Enemy : MonoBehaviour
	{
		protected Loop loop;

		public static Enemy Spawn(Enemy prefab, Vector3 position, Transform player) =>
			Instantiate(prefab, position, Rotation(Forward(position, player)));

		public void Configure(Loop loop)
		{
			this.loop = loop;
		}
		
		public void DelegateOnCollisionEnter(Collision other)
		{
			var bullet = other.gameObject.GetComponent<Bullet>();

			if (bullet != null) {
				Destroy(gameObject);
				loop.AddScore();
			}
		}

		static Quaternion Rotation(Vector3 forward) => Quaternion.LookRotation(forward, Vector3.up);

		static Vector3 Forward(Vector3 position, Transform player) => (player.position - position).normalized;
	}
}
