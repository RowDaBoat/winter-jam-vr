using UnityEngine;
using VRTK.Core.Action;

namespace GanzoAgazapado.Simulator
{
    public class KeyboardButtonAction: BooleanAction
    {
        public KeyCode key;

        protected virtual void Update()
        {
            Receive(Input.GetKey(key));
        }
    }
}