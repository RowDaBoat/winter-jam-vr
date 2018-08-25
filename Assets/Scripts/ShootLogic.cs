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

        public void Fire()
        {
            var bullet = GameObject.Instantiate<Bullet>(bulletPrefab);
            bullet.transform.position = gun.transform.position;
            bullet.transform.forward = gun.transform.forward;
            bullet.body.velocity = bullet.transform.forward * velocity;
        }

        [ContextMenu("Fire")]
        public void DebugFire()
        {
            Fire();
        }

    }

}


