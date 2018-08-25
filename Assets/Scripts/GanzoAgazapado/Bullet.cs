using GanzoAgazapado.Enemies;
using UnityEngine;

namespace GanzoAgazapado
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody body;

	    void OnCollisionEnter(Collision other)
	    {
		    var enemy = other.gameObject.GetComponentInParent<Enemy>();

		    if (enemy != null)
		    	Destroy(gameObject);
	    }
    }
}