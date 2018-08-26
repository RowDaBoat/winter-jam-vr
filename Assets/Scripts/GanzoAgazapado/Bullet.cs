using GanzoAgazapado.Enemies;
using UnityEngine;

namespace GanzoAgazapado
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody body;
	    public float velocity;

	    void OnCollisionEnter(Collision other)
	    {
		    var enemy = other.gameObject.GetComponentInParent<Enemy>();

		    if (enemy != null)
		    	Destroy(gameObject);
	    }

	    public void FireFrom(Transform gun)
	    {
		    this.transform.position = gun.position;
		    this.transform.forward = gun.forward;
		    this.body.velocity = gun.forward * velocity;
	    }
    }
}