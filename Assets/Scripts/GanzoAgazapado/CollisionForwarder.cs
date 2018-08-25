using UnityEngine;
using UnityEngine.Events;

namespace GanzoAgazapado
{
    public class CollisionForwarder : MonoBehaviour
    {
        [System.Serializable]
        public class CollisionData : UnityEvent<Collision>
        {
            
        }
        
        public CollisionData onCollisionEnter;
        
        void OnCollisionEnter(Collision other)
        {
            if (onCollisionEnter != null)
            {
                onCollisionEnter.Invoke(other);
            }
        }
    }
}