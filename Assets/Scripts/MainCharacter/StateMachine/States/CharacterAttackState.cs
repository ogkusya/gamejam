using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : State
{
    private readonly CharacterAnimatorController characterAnimationController;

    public CharacterAttackState(CharacterAnimatorController characterAnimationController)
    {
        this.characterAnimationController = characterAnimationController;
    }

    public override void OnStateEntered()
    {
        characterAnimationController.SetBool(CharacterAnimationType.Attack, true);
    }

    public override void OnStateExited()
    {
        characterAnimationController.SetBool(CharacterAnimationType.Attack, false);
    }
}
