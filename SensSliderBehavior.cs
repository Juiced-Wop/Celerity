using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensSliderBehavior : MonoBehaviour
{

	public bool isHorizontal;

	void Awake()
	{
		if (isHorizontal)
			SavedSettings.horizontalSensSlider = gameObject.GetComponent<Slider>();
		else
			SavedSettings.verticalSensSlider = gameObject.GetComponent<Slider>();
	}

	void OnDisable()
	{
		if (isHorizontal)
			References.thePauseMenu.horizontalSensSlider = gameObject.GetComponent<Slider>();
		else
			References.thePauseMenu.verticalSensSlider = gameObject.GetComponent<Slider>();
	}

	public void SliderMoved()
	{
		SavedSettings.UpdateSensBasedOnSlider();
	}

}

//																															<|*_*|>