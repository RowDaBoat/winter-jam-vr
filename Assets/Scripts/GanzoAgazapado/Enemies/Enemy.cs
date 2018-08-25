using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class Enemy : MonoBehaviour
	{
		public static Enemy Spawn(Enemy prefab, Vector3 position, Transform player) =>
			Instantiate(prefab, position, Rotation(Forward(position, player)));

		static Quaternion Rotation(Vector3 forward) => Quaternion.LookRotation(forward, Vector3.up);

		static Vector3 Forward(Vector3 position, Transform player) => (player.position - position).normalized;

		void OnCollisionEnter(Collision other)
		{
			var bullet = other.gameObject.GetComponent<Bullet>();

			if (bullet != null) {
				Destroy(gameObject);
			}
		}
	}
}
