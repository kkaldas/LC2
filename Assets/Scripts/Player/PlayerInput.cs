﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] PlayerWalk playerWalk;
    [SerializeField] PlayerAnimationManager playerAnim;
    [SerializeField] PlayerAttack playerAttack;

    KeyCode previousLastMovementKeyPressed;

    private void Start()
    { //player starts looking to down, like if had pressed S key
        previousLastMovementKeyPressed = KeyCode.S;
    }

    void Update()
    {
        InputInfo inputInfo = new InputInfo(previousLastMovementKeyPressed);

        ManageWalk(inputInfo);
        ManageAnimations(inputInfo);
        ManageAttacks(inputInfo);

        previousLastMovementKeyPressed = inputInfo.GetLastMovementKeyPressed();
    }


    void ManageWalk(InputInfo inputInfo)
    {
        playerWalk.InformIfJustOneMovementKeyIsPressed(inputInfo.IsJustOneMovementKeyPressed());
        playerWalk.Walk(inputInfo.GetW(), inputInfo.GetS(), inputInfo.GetA(), inputInfo.GetD());
    }

    void ManageAnimations(InputInfo inputInfo)
    {
        playerAnim.InformIfJustOneMovementKeyIsPressed(inputInfo.IsJustOneMovementKeyPressed());
        playerAnim.AnimateWalk(inputInfo.GetW(), inputInfo.GetS(), inputInfo.GetA(), inputInfo.GetD());
        playerAnim.AnimateAttack(inputInfo.GetAttackInput());
    }

    void ManageAttacks(InputInfo inputInfo)
    {
        if (inputInfo.GetAttackInput())
        {
            playerAttack.Attack(inputInfo.GetLastMovementKeyPressed());
        }
    }

}
