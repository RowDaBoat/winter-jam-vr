using System;
using System.Runtime.CompilerServices;
using GanzoAgazapado.GameLoop;
using UnityEngine;
using UnityEngine.Animations;

namespace GanzoAgazapado.Enemies
{
	public class Enemy : MonoBehaviour
	{
		public event Action OnDeath = delegate {};
		public GameObject fxDeath;

		protected Loop loop;
		bool dead;
		
		public static Enemy Spawn(Enemy prefab, Vector3 position, Transform player) =>
			Instantiate(prefab, position, Rotation(Forward(position, player)));

		public void Configure(Loop loop)
		{
			this.loop = loop;
		}
		
		public void DelegateOnCollisionEnter(Collision other)
		{
			var bullet = other.gameObject.GetComponent<Bullet>();

			if (bullet != null && !dead) {
				if (fxDeath != null)
				{
					GameObject.Instantiate(fxDeath, this.gameObject.transform.position, Quaternion.identity);
				}

				dead = true;
				OnDeath();
				Destroy(gameObject);
				loop.AddScore();
			}
		}

		static Quaternion Rotation(Vector3 forward) => Quaternion.LookRotation(forward, Vector3.up);

		static Vector3 Forward(Vector3 position, Transform player) => (player.position - position).normalized;
	}
}
