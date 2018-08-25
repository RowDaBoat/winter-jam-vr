using System.Collections;
using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class Chaser : Enemy
	{
		public float timeAlive = 10;
		public float speed = 2;

		Vector3 velocity;
		
		void Start()
		{
			Setup();
			StartCoroutine(Despawn());
			StartCoroutine(Move());
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
