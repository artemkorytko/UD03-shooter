using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    protected NewEnemyAI _ai;
    protected EnemyAnimationController _animator;

    public BaseState (NewEnemyAI ai, EnemyAnimationController animator)
    {
        _ai = ai;
        _animator = animator;
    }
    
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
