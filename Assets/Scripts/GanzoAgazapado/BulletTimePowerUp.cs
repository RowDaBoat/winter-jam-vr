using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Core.Data.Attribute;

namespace GanzoAgazapado
{
	public class BulletTimePowerUp : MonoBehaviour
	{
		public float time = 5f;
		public float timeScale;
		public int requiredKills = 10;
		public Gun gun;
		public Image meter;

		int kills;

		public void AddKill()
		{
			if (kills == requiredKills)
				return;

			++kills;
			UpdateMeter();
		}

		public void UsePowerup()
		{
			if (kills == requiredKills)
				StartCoroutine(BulletTime());
		}
		
		void UpdateMeter()
		{
			meter.fillAmount = (float)kills / requiredKills;
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
			UpdateMeter();
			Time.timeScale = backup;
			Time.fixedDeltaTime = bfdt;
		}
	}
}
