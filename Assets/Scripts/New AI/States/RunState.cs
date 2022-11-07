using UnityEngine;

public class RunState : BaseState
{
    private const float STOP_DISTANCE = 70f;
    
    public RunState(NewEnemyAI ai, EnemyAnimationController animator) : base(ai, animator)
    {
    }

    public override void Enter()
    {
        _animator.SetRun();
    }

    public override void Update()
    {
        if (_ai.IsHaveTarget)
        {
            _ai.SetPath();
            if (_ai.IsReadyToAttack())
            {
                _ai.ChangeState(_ai.ShootingState);
            }
        }else if (Vector3.SqrMagnitude(_ai.NavAgent.pathEndPosition - _ai.transform.localPosition) < STOP_DISTANCE)
        {
            _ai.ChangeState(_ai.IdleState);
        }
        
    }

    public override void Exit()
    {
        
    }
}
