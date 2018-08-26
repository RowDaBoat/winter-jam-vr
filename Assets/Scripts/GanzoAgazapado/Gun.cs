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
		public AudioSource fireSound;
		public AudioSource reloadSound;

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
			fireSound.Play();
		}
		
		void Start()
		{
			round = 4;
			StartCoroutine(Rounds());
			UpdateCharges();
		}

		IEnumerator Rounds()
		{
			yield return new WaitUntil(() => round == 0);
			
			reloadSound.Play();
			StartCoroutine(ReloadAnim());

			yield return new WaitForSeconds(reloadTime);

			Reload();
			StartCoroutine(Rounds());
		}

		IEnumerator ReloadAnim()
		{
			var chargeTime = reloadTime / (totalRound);

			for (var i = 0; i < totalRound; i++) {
				yield return new WaitForSeconds(chargeTime);
				charges[totalRound - i - 1].material = chargedMaterial;
			}
		}

		void Reload()
		{
			round = totalRound;
			UpdateCharges();
		}

		void UpdateCharges()
		{
			for (var i = 0; i < totalRound; i++)
				charges[i].material = i < round ? chargedMaterial : emptyMaterial;
		}
	}
}
