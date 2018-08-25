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
		public Renderer[] charges;
		public Material chargedMaterial;
		public Material emptyMaterial;

		int round;

		bool activated;

		public void Activate() { activated = true; }
		
		public void Deactivate() { activated = false; }

		public void Shoot()
		{
			if (!activated || round == 0)
				return;

			round--;
			shootLogic.Fire();
			UpdateCharges();
		}
		
		void Start()
		{
			round = 4;
			StartCoroutine(Rounds());
			UpdateCharges();
		}

		IEnumerator Rounds() => Wait(() => round == 0)
			.Then(Do(() => Debug.Log("Reloading...")))
			.Then(Wait(reloadTime))
			.Then(Reload())
			.Then(Do(() => Debug.Log("Reloaded!")))
			.Then(Do(() => StartCoroutine(Rounds())));

		IEnumerator Reload()
		{
			round = totalRound;
			UpdateCharges();
			yield return 0;
		}

		void UpdateCharges()
		{
			for (var i = 0; i < totalRound; i++)
				charges[i].material = i < round ? chargedMaterial : emptyMaterial;
		}
	}
}
