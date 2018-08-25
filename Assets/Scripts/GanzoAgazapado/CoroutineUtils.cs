using System;
using System.Collections;
using UnityEngine;

namespace GanzoAgazapado
{
	public static class CoroutineUtils
	{
		public static IEnumerator Do(Action action)
		{
			action();
			yield return 0;
		}

		public static IEnumerator Wait(float time)
		{
			yield return new WaitForSeconds(time);
		}

		public static IEnumerator Wait(Func<bool> condition)
		{
			yield return new WaitUntil(condition);
		}
		
		public static IEnumerator Then(this IEnumerator first, IEnumerator then)
		{
			yield return first;
			yield return then;
		}

		public static IEnumerator Repeat(this IEnumerator source)
		{
			while (true) {
				yield return source;
				Debug.Log("repeating");
			}
		}
	}
}
