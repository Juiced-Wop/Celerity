using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NRGTrackerBehavior : MonoBehaviour
{

	TextMeshProUGUI myText;

	private void Awake()
	{
		References.playerNRGTracker = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		myText = gameObject.GetComponent<TextMeshProUGUI>();
		myText.text = 0.ToString("D2") + "/" + References.startingEnergyCapsuleCount.ToString("D2");
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetNRGTrackerDisplay(int numberLeft)
	{
		int numberCollected = References.startingEnergyCapsuleCount - numberLeft;
		myText.text = numberCollected.ToString("D2") + "/" + References.startingEnergyCapsuleCount.ToString("D2");
	}

	public void Disable()
	{
		gameObject.SetActive(false);
	}

	public void Enable()
	{
		gameObject.SetActive(true);
	}

}