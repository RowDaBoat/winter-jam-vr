using UnityEngine;

namespace GanzoAgazapado.Simulator
{
    
    
    public class MouseAimController : MonoBehaviour
    {
        public Vector3 oldMousePosition;

        public Vector2 scale;

        public GameObject head;
        public GameObject hand;

        private void Awake()
        {
            oldMousePosition = Input.mousePosition;
        }

        private void Update()
        {
            var newPosition = Input.mousePosition;
            var delta = newPosition - oldMousePosition;
            oldMousePosition = newPosition;

            var horizontalRotation = delta.x * scale.x;
            var verticalRotation = delta.y * scale.y;

            var rotation = head.transform.localEulerAngles;
            rotation = rotation + new Vector3(verticalRotation, horizontalRotation, 0);

            head.transform.localEulerAngles = rotation;
            hand.transform.localEulerAngles = rotation;

            //  head.transform.Rotate(Vector3.up, horizontalRotation);
            //  head.transform.Rotate(Vector3.right, verticalRotation);
        }
    }
}