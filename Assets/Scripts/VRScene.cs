using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GanzoAgazapado
{
    public class VRScene : MonoBehaviour
    {
        public GameObject player;
        
        
        
        
        
        private static VRScene instance;
        public static VRScene Instance
        {
            get
            {
                if (instance == null)
                {
                    if (!SceneManager.GetAllScenes().Any(scene => scene.name == "VRScene"))
                    {
                        SceneManager.LoadScene("VRScene", LoadSceneMode.Additive);
                    }

                    instance = GameObject.FindObjectOfType<VRScene>();
                }

                return instance;
            }
        }
        
        
    }
}