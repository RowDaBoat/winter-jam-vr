using System;
using System.Collections;
using GanzoAgazapado.GameLoop;
using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class Chaser : Enemy
	{
		public float timeAlive = 10;
		public float speed = 2;

		Vector3 velocity;
		Player player;

		public void Configure(Player player, Loop loop)
		{
			this.player = player;
			Configure(loop);
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
					loop.Lose();

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
