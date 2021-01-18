using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SensInputFieldBehavior : MonoBehaviour
{

	public bool isHorizontal;
	PauseMenuBehavior myPauseMenuBehavior;

	void Awake()
	{
		if (isHorizontal)
			SavedSettings.horizontalSensInputField = gameObject.GetComponent<TMP_InputField>();
		else
			SavedSettings.verticalSensInputField = gameObject.GetComponent<TMP_InputField>();
	}


	private void OnDisable()
	{
		if (isHorizontal)
			References.thePauseMenu.horizontalSensInputField = gameObject.GetComponent<TMP_InputField>();
		else
			References.thePauseMenu.verticalSensInputField = gameObject.GetComponent<TMP_InputField>();
	}

	public void InputFieldChanged()
	{
			SavedSettings.UpdateSensBasedOnInputField();
	}
}
