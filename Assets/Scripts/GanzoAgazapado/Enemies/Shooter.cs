using System;
using System.Collections;
using GanzoAgazapado.GameLoop;
using UnityEngine;
using static GanzoAgazapado.CoroutineUtils;

namespace GanzoAgazapado.Enemies
{
	public class Shooter : Enemy
	{
		public float waitTime = 10;
		public Color colorStart = Color.green;
		public Color colorEnd = Color.red;
		public Renderer renderer;
		
		Color Color { set { renderer.material.color = value; } }

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

		IEnumerator Shoot()
		{
			loop.Lose();
			yield return 0;
		}
	}
}
