﻿using UnityEngine;

public class PlayerInventoryAnimationHelper : StateMachineBehaviour {

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        EventManager.TriggerEvent("OnGrabAnimationFinished");
    }
}