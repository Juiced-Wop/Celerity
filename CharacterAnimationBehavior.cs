using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationBehavior : MonoBehaviour
{

    Animator anim;
	PlayerBehavior ourPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
		ourPlayer = References.thePlayer.GetComponent<PlayerBehavior>();
    }

    void Update()
    {
        if (!References.isPaused)
        {
            if (Input.GetKeyDown(ourPlayer.skateButton))
                anim.Play("BoardDown");


            if (Input.GetKey(ourPlayer.skateButton))
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isSkating", true);
            }
            else
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isSkating", false);
            }
        }
    }

    //might be deprecated
    public void PlayAnimation(string animation)
    {
        /*anim.CrossFade(animation, 0.1f);
        anim.SetBool("isIdle", false);
        anim.SetBool("isThumbsUp", true);*/
    }

    public bool WhatIs(string animName)
    {
        return anim.GetBool(animName);
    }

}
