using UnityEngine;

namespace GanzoAgazapado
{
    public class RigChooser : MonoBehaviour
    {
        public GameObject inEditor;
        public GameObject inDevice;
        void Awake()
        {
            var weAreInEditor = Application.isEditor;
            inEditor.SetActive(weAreInEditor);
            inDevice.SetActive(!weAreInEditor);
        }
    }
}