using System;
using UnityEngine;

namespace GanzoAgazapado
{
    public class GameLogic : MonoBehaviour
    {
        public Action reloadAction;

        public void Reload()
        {
            if (reloadAction != null)
            {
                reloadAction();
            }
        }
    }
}