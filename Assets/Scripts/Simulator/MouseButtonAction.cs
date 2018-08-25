using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Core.Action;

public class MouseButtonAction : BooleanAction
{
	public int buttonId;

	protected virtual void Update()
	{
		Receive(Input.GetMouseButton(buttonId));
	}
}