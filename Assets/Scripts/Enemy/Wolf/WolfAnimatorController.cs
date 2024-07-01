using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimatorController
{
    private Animator _animator;
    private Dictionary<WolfAnimationType, int> hashStorage = new Dictionary<WolfAnimationType, int>();

    public Animator Animator => _animator;

    public WolfAnimatorController(Animator animator)
    {
        _animator = animator;
        foreach (WolfAnimationType caType in Enum.GetValues(typeof(WolfAnimationType)))
        {
            hashStorage.Add(caType, Animator.StringToHash(caType.ToString()));
        }
    }

    public void SetBool(WolfAnimationType animationType, bool value)
    {
        _animator.SetBool(hashStorage[animationType], value);
    }

    public void SetFloat(WolfAnimationType animationType, float value)
    {
        _animator.SetFloat(hashStorage[animationType], value);
    }

    public void SetPlay(WolfAnimationType characterAnimationType)
    {
        _animator.Play((hashStorage[characterAnimationType]));
    }

    public void SetTrigger(WolfAnimationType characterAnimationType)
    {
        _animator.SetTrigger((hashStorage[characterAnimationType]));
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
