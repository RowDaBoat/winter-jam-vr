using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK.Core.Tracking.CameraRig;

namespace GanzoAgazapado
{
    public class VRScene : MonoBehaviour
    {
	    private static VRScene instance;
        
	    public GameObject player;
        public GameLogic gameLogic;
	    public Gun gun;
	    public BulletTimePowerUp bulletTimePowerUp;

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

                    instance = FindObjectOfType<VRScene>();
                }

                return instance;
            }
        }

        public Camera VRCamera
        {
            get { return GameObject.FindObjectOfType<LinkedAliasAssociationCollection>().HeadsetCamera; }
        }
        
    }
}