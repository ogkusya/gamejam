using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController
{
    private Animator _animator;
    private Dictionary<CharacterAnimationType, int> hashStorage = new Dictionary<CharacterAnimationType, int>();

    public Animator Animator => _animator;

    public CharacterAnimatorController(Animator animator)
    {
        _animator = animator;
        foreach (CharacterAnimationType caType in Enum.GetValues(typeof(CharacterAnimationType)))
        {
            hashStorage.Add(caType, Animator.StringToHash(caType.ToString()));
        }
    }

    public void SetBool(CharacterAnimationType animationType, bool value)
    {
        _animator.SetBool(hashStorage[animationType], value);
    }

    public void SetFloat(CharacterAnimationType animationType, float value)
    {
        _animator.SetFloat(hashStorage[animationType], value);
    }

    public void SetPlay(CharacterAnimationType characterAnimationType)
    {
        _animator.Play((hashStorage[characterAnimationType]));
    }

    public void SetTrigger(CharacterAnimationType characterAnimationType)
    {
        _animator.SetTrigger((hashStorage[characterAnimationType]));
    }

    public void ResetTrigger(CharacterAnimationType characterAnimationType)
    {
        _animator.ResetTrigger((hashStorage[characterAnimationType]));
    }

    public bool IsAnimationPlay(string animationStateName)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(animationStateName);
    }

    public float NormalizedAnimationPlayTime()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
