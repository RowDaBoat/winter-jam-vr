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
		public Transform fxDeathPosition;

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
				if (fxDeath != null)
				{
					GameObject.Instantiate(fxDeath, fxDeathPosition.position, Quaternion.identity);
				}
				OnDeath();
				Destroy(gameObject);
				loop.AddScore();
			}
		}

		static Quaternion Rotation(Vector3 forward) => Quaternion.LookRotation(forward, Vector3.up);

		static Vector3 Forward(Vector3 position, Transform player) => (player.position - position).normalized;
	}
}
