using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GanzoAgazapado
{
    public class GameController : MonoBehaviour
    {
        public GameObject playerStart;
      
	    public void ReloadAction()
	    {
		    SceneManager.LoadScene(gameObject.scene.name);
	    }
  
        void Awake()
        {
            var scene = VRScene.Instance;
            Invoke("InitializeGame", 0.1f);
        }

        void InitializeGame()
        {
            var scene = VRScene.Instance;
            scene.player.transform.position = playerStart.transform.position;
            scene.player.transform.forward = playerStart.transform.forward;
            scene.gameLogic.reloadAction = ReloadAction;
            var camera = GameObject.FindObjectOfType<Canvas>();
            camera.worldCamera = scene.VRCamera;
            camera.planeDistance = 1;

        }
    }
}