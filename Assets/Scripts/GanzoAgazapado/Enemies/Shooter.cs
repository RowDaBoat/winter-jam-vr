using System;
using System.Collections;
using UnityEngine;

namespace GanzoAgazapado.Enemies
{
	public class Shooter : Enemy
	{
		public float waitTime = 10;
		public Color colorStart = Color.green;
		public Color colorEnd = Color.red;
		public Renderer renderer;
		
		Color Color { set { renderer.material.color = value; } }
		Action damage;
		
		public void Configure(Action damage)
		{
			this.damage = damage;
		}
		
		void Start()
		{
			StartCoroutine(Wait(waitTime).Then(Shoot()));
			StartCoroutine(LerpColor(colorStart, colorEnd, waitTime));
		}

		IEnumerator LerpColor(Color color1, Color color2, float time)
		{
			for (var t = 0f; t < time; t += Time.deltaTime) {
				Color = Color.Lerp(color1, color2, (t / time) * (t / time) * (t / time));
				yield return 0;
			}

			Color = color2;
		}

		IEnumerator Wait(float time)
		{
			yield return new WaitForSeconds(time);
		}

		IEnumerator Shoot()
		{
			damage();
			yield return 0;
		}
	}

	public static class CoroutinesEx
	{
		public static IEnumerator Then(this IEnumerator first, IEnumerator then)
		{
			yield return first;
			yield return then;
		}
	}
}
