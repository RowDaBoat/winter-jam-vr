using System;
using System.Collections;
using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class Chaser : Enemy
	{
		public float timeAlive = 10;
		public float speed = 2;

		Vector3 velocity;
		Action damage;
		Player player;

		public void Configure(Action damage, Player player)
		{
			this.damage = damage;
			this.player = player;
		}

		void Start()
		{
			Setup();
			StartCoroutine(Despawn());
			StartCoroutine(Move());
			StartCoroutine(CheckCollision());
		}

		IEnumerator CheckCollision()
		{
			while (true) {
				if (player.CollidedWith(this))
					damage();

				yield return 0;
			}
		}

		void Setup() => velocity = transform.forward * speed;

		IEnumerator Despawn()
		{
			yield return new WaitForSeconds(timeAlive);
			Destroy(gameObject);
		}

		IEnumerator Move()
		{
			while (true) {
				transform.position += velocity * Time.deltaTime;		
				yield return 0;
			}
		}
	}
}
