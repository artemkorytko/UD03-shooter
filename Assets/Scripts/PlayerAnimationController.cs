
using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private const string VELOCITY = "Velocity";
    private readonly int Velocity = Animator.StringToHash(VELOCITY);
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetVelocity(float value)
    {
        _animator.SetFloat(Velocity,value);
    }
    
}
