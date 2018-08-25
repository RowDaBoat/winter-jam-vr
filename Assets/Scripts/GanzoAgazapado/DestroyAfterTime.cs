using UnityEngine;

namespace GanzoAgazapado
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public float time;

        public void Start()
        {
            Destroy(gameObject, time);
        }
    }
}