using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GanzoAgazapado
{
    public class GameController : MonoBehaviour
    {
        public GameObject playerStart;
        
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
        }

        private void ReloadAction()
        {
           SceneManager.LoadScene(this.gameObject.scene.name);
        }
    }
}