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

            if (Input.GetKey(KeyCode.J))
            {
                var rotationHead = head.transform.localEulerAngles;
                rotationHead = rotationHead + new Vector3(verticalRotation, horizontalRotation, 0);
                head.transform.localEulerAngles = rotationHead;
            }

            if (Input.GetKey(KeyCode.L))
            {
                var rotationHand = hand.transform.localEulerAngles;
                rotationHand = rotationHand + new Vector3(verticalRotation, horizontalRotation, 0);
                hand.transform.localEulerAngles = rotationHand;
            }
        }
    }
}