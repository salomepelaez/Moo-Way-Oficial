﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbducingOvni : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        if(Input.GetKeyDown(KeyCode.X) || Cow.floating == false)
       {
           animator.SetBool("isAbducing", false);    
       }
    }
}
