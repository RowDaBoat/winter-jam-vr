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

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            var horizontalRotation = Input.GetAxis("Mouse X") * scale.x;
            var verticalRotation = Input.GetAxis("Mouse Y") * scale.y;

            var rotation = head.transform.localEulerAngles;
            rotation = rotation + new Vector3(verticalRotation, horizontalRotation, 0);

            head.transform.localEulerAngles = rotation;
            hand.transform.localEulerAngles = rotation;
        }
    }
}