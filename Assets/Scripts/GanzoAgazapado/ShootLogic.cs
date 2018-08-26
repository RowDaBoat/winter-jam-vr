using UnityEngine;

namespace GanzoAgazapado
{
	public class ShootLogic : MonoBehaviour
	{
		public GameObject gun;
		public Animator gunAnimator;
		public Bullet bulletPrefab;
		public float velocity;

		public float cooldown;
		public float cooldownCounter;

		public bool autoFire = false;

		public void Fire()
		{
			var bullet = FireBullet();
			bullet.name = "RegularBullet";
			gunAnimator.SetTrigger("Shoot");
		}
		
		Bullet FireBullet()
		{
			var bullet = Instantiate(bulletPrefab);
			bullet.FireFrom(gun.transform);
			return bullet;
		}

		public void Update()
		{
			if (autoFire)
			{
				cooldownCounter -= Time.deltaTime;
				if (cooldownCounter < 0)
				{
					var bullet = FireBullet();
					bullet.name = "MachinegunBullet";
					cooldownCounter = cooldown;
				}
			}
		}

		public void SetAutoFire(bool autofire)
		{
			this.autoFire = autofire;
		}

		[ContextMenu("Fire")]
		public void DebugFire()
		{
			Fire();
		}

	}
}