using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
   private const string SHOOT = "Shoot";
   private const string RUN = "Run";
   private const string IDLE = "Idle";
   private const string DEATH = "Death";

   private readonly int Shoot = Animator.StringToHash(SHOOT);
   private readonly int Run = Animator.StringToHash(RUN);
   private readonly int Idle = Animator.StringToHash(IDLE);
   private readonly int Death = Animator.StringToHash(DEATH);
   
   [SerializeField] private Animator _animator;

   public void SetShoot()
   {
      _animator.SetTrigger(Shoot);
   }
   
   public void SetDeath()
   {
      _animator.SetTrigger(Death);
   }
   
   public void SetIdle()
   {
      _animator.SetTrigger(Idle);
   }

   public void SetRun()
   {
      _animator.SetTrigger(Run);
   }
}
