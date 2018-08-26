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
		float timeScaleBackup;
		float fixedDeltaTimeBackup;

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

		void Awake()
		{
			timeScaleBackup = Time.timeScale;
			fixedDeltaTimeBackup = Time.fixedDeltaTime;
		}
		
		void UpdateMeter()
		{
			meter.fillAmount = (float)kills / requiredKills;
		}

		IEnumerator BulletTime()
		{
			Time.timeScale = timeScale;
			Time.fixedDeltaTime = timeScale;

			gun.NoReloadMode();
			
			yield return new WaitForSecondsRealtime(time);

			gun.NormalMode();

			kills = 0;
			UpdateMeter();
			Time.timeScale = timeScaleBackup;
			Time.fixedDeltaTime = fixedDeltaTimeBackup;
		}

		void OnDestroy()
		{
			Time.timeScale = timeScaleBackup;
			Time.fixedDeltaTime = fixedDeltaTimeBackup;
		}
	}
}
