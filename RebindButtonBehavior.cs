using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RebindButtonBehavior : MonoBehaviour
{
	[System.NonSerialized] public TextMeshProUGUI myTextObject;
	public string myActionName;

	private void Awake()
	{
		myTextObject = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
	}

	void OnDisable()
	{
		switch (myActionName)
		{
			case References.yeet:
				References.thePauseMenu.yeetRebindButton = myTextObject;
				break;
			case References.jump:
				References.thePauseMenu.jumpRebindButton = myTextObject;
				break;
			case References.skate:
				References.thePauseMenu.skateRebindButton = myTextObject;
				break;
			case References.forward:
				References.thePauseMenu.forwardRebindButton = myTextObject;
				break;
			case References.backward:
				References.thePauseMenu.backwardRebindButton = myTextObject;
				break;
			case References.left:
				References.thePauseMenu.leftRebindButton = myTextObject;
				break;
			case References.right:
				References.thePauseMenu.rightRebindButton = myTextObject;
				break;
			case References.grab:
				References.thePauseMenu.grabRebindButton = myTextObject;
				break;
			default:
				Debug.Log("No case for loading an action called \"" + myActionName + "\" in ");
				break;
		}

	}

	public void RebindMe()
	{
			SavedSettings.ActionCastToRebind(this);
	}

}
