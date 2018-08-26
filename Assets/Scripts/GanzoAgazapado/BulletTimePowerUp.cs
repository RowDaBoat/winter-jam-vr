using System.Collections;
using UnityEngine;

namespace GanzoAgazapado
{
	public class BulletTimePowerUp : MonoBehaviour
	{
		public float time = 5f;
		public float timeScale;
		public int requiredKills = 10;
		public Gun gun;

		int kills;

		public void AddKill()
		{
			if (++kills == requiredKills)
				StartCoroutine(BulletTime());
		}

		IEnumerator BulletTime()
		{
			var backup = Time.timeScale;
			var bfdt = Time.fixedDeltaTime;

			Time.timeScale = timeScale;
			Time.fixedDeltaTime = timeScale;

			gun.NoReloadMode();
			
			yield return new WaitForSecondsRealtime(time);

			gun.NormalMode();

			kills = 0;
			Time.timeScale = backup;
			Time.fixedDeltaTime = bfdt;
		}
	}
}
