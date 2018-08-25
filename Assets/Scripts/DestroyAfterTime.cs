using UnityEngine;

namespace GanzoAgazapado
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public float time;

        public void Start()
        {
            GameObject.Destroy(this.gameObject, time);
        }
    }
}