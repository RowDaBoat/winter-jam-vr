using System.Collections;
using UnityEngine;
using static GanzoAgazapado.CoroutineUtils;

namespace GanzoAgazapado
{
	public class Gun : MonoBehaviour
	{
		public int totalRound = 4;
		public float reloadTime = 3f;
		public ShootLogic shootLogic;

		int round;
		
		public void Shoot()
		{
			round--;
			shootLogic.Fire();
		}
		
		void Start()
		{
			round = 4;
			StartCoroutine(Rounds());
		}

		IEnumerator Rounds() => Wait(() => round == 0)
			.Then(Do(() => Debug.Log("Reloading...")))
			.Then(Wait(reloadTime))
			.Then(Reload())
			.Then(Do(() => Debug.Log("Reloaded!")))
			.Repeat();

		IEnumerator Reload()
		{
			round = totalRound;
			yield return 0;
		}
	}
}
