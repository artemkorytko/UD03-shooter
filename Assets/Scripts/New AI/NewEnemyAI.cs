using System;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyAI : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5;
    [SerializeField] private float _healthOnStart = 100f;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Health Health;

    public event Action<NewEnemyAI> OnDie;
    public NavMeshAgent NavAgent => _meshAgent;
    public bool IsHaveTarget => _target;
    
    public IdleState IdleState { get; private set; }
    public RunState RunState{ get; private set; }
    public DeathState DeathState{ get; private set; }
    public ShootingState ShootingState{ get; private set; }
    
    public bool IsAlive { get; private set; }

    private EnemyAnimationController _animationController;
    private NavMeshAgent _meshAgent;
    private bool _isActive;

    private Transform _target;
    private Transform _transform;
    private BaseState _currentState;
    
    public bool IsActive
    {
        get
        {
            return _isActive;
        }

        set
        {
            _isActive = value;
        }
    }
    
    private void Awake()
    {
        _animationController = GetComponent<EnemyAnimationController>();
        _meshAgent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();

        IdleState = new IdleState(this, _animationController);
        RunState = new RunState(this, _animationController);
        DeathState = new DeathState(this, _animationController);
        ShootingState = new ShootingState(this, _animationController);
    }

    private void Update()
    {
        if (!_isActive) return;
        
        _currentState.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            _target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            _target = null;
        }
    }
    
    public void Init(BulletPool pool)
    {
        ChangeState(IdleState);
        IsAlive = true;
        Health.SetMaxValue(_healthOnStart);
        Health.SetCurrentValue(_healthOnStart);
        Health.OnDie += Dead;
        if (_weapon != null) _weapon.Init(pool);
    }

    private void Dead()
    {
        _isActive = false;
        IsAlive = false;
        
        Health.OnDie -= Dead;
        _weapon.SetUnuse();
        
        ChangeState(DeathState);
        OnDie?.Invoke(this);
    }

    public void SetPath()
    {
        _meshAgent.SetDestination(_target.position);
    }

    public void Shoot()
    {
        _weapon.Shoot();
    }

    public void MoveRotation()
    {
        Vector3 direction = _target.position - _transform.position;
        _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
    }

    public bool IsReadyToAttack()
    {
        float stoppingDistance = _meshAgent.stoppingDistance;
        return Vector3.SqrMagnitude(_transform.position - _target.position) < stoppingDistance * stoppingDistance;
    }

    public void ChangeState(BaseState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
