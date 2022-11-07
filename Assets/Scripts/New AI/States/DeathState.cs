
public class DeathState : BaseState
{
    public DeathState(NewEnemyAI ai, EnemyAnimationController animator) : base(ai, animator)
    {
    }

    public override void Enter()
    {
        _animator.SetDeath();
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }
}
