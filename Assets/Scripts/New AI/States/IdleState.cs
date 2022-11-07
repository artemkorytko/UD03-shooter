public class IdleState : BaseState
{
    public IdleState(NewEnemyAI ai, EnemyAnimationController animator) : base(ai, animator)
    {
    }

    public override void Enter()
    {
        _animator.SetIdle();
    }

    public override void Update()
    {
        if (_ai.IsHaveTarget)
        {
            _ai.ChangeState(_ai.RunState);
        }
    }

    public override void Exit()
    {
    }
}