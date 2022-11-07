public class ShootingState : BaseState
{
    public ShootingState(NewEnemyAI ai, EnemyAnimationController animator) : base(ai, animator)
    {
    }

    public override void Enter()
    {
        _animator.SetShoot();
    }

    public override void Update()
    {
        if (!_ai.IsReadyToAttack())
        {
            _ai.ChangeState(_ai.RunState);
        }
        else
        {
            _ai.MoveRotation();
            _ai.Shoot();
        }
    }

    public override void Exit()
    {
        
    }
}
