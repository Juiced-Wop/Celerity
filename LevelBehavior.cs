using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehavior : MonoBehaviour
{

    private void Awake()
    {
        References.theLevelLogic = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        References.currentEnergyCapsuleCount = References.startingEnergyCapsuleCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void NRGCollect()
	{
		References.playerNRGTracker.SetNRGTrackerDisplay(References.currentEnergyCapsuleCount);
	}

}