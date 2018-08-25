using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GanzoAgazapado
{
    public class ShootLogic : MonoBehaviour
    {
        public GameObject gun;
        public Bullet bulletPrefab;
        public float velocity;

        public float cooldown;
        public float cooldownCounter;

        public bool autoFire = false;
        
        public void Fire()
        {
            var bullet = FireBullet();
            bullet.name = "RegularBullet";
        }

        private Bullet FireBullet()
        {
            var bullet = GameObject.Instantiate<Bullet>(bulletPrefab);
            bullet.transform.position = gun.transform.position;
            bullet.transform.forward = gun.transform.forward;
            bullet.body.velocity = bullet.transform.forward * velocity;
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


