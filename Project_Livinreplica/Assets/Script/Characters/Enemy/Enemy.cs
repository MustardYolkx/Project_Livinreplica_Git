using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
    [field: Header("Reference")]
    [field: SerializeField] public EnemySO enemySO { get;private set; }
    [field: Header("Animation")]
    [field: SerializeField] public EnemyAnimationData animationData { get; private set; }
    public EnemyStateMachine stateMachine;
    public EnemyState enemyState;

    public Rigidbody2D Rb { get; private set; }

    public Animator Animator { get; private set; }
    public Vector2 movementInput;

    public bool canFlip;
    public bool isFacingRight;

    public bool canTakeDamage;

    public bool canAttack;
    public string takeDamageAnim;

    public float attackCoolDownTime;
    public EnemyAttackCheck attackCheck { get; private set; }
    [HideInInspector] public float currentAttackDamage;
    [HideInInspector] public string targetTakeDamAnim;

    [SerializeField] private Transform ledgeCheckPoint;
    [SerializeField] private Transform wallCheckPoint;
    [SerializeField] private Transform playerCheckPoint;
    // Start is called before the first frame update

    private void Awake()
    {
        stateMachine = new EnemyStateMachine(this);
       Animator = GetComponentInChildren<Animator>();
        attackCheck= GetComponentInChildren<EnemyAttackCheck>();
        Rb= GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
        animationData.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void TakeDamage(string animationName, float Damage)
    {
        if (canTakeDamage)
        {
            if(animationName == "TakeDamageNormal")
            {
                stateMachine.ChangeState(stateMachine.TakeDamageNormalState);
            }
            else if (animationName == "TakeDamageHard")
            {
                stateMachine.ChangeState(stateMachine.TakeDamageHardState);
                
            }
            Debug.Log("Taka Damage:" + Damage);
        }
       
    }

    public void TakeDamage(float Damage)
    {
        throw new System.NotImplementedException();
    }

    #region AnimationMethods
    public void AnimationTransitionEvent()
    {
        stateMachine.AnimationTransitionTrigger();
    }

    public void AnimationEnterEvent()
    {
        stateMachine.AnimationEnterTrigger();
    }

    public void AnimationExitEvent()
    {
        stateMachine.AnimationExitTrigger();
    }
    #endregion

    #region Trigger
    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheckPoint.position, Vector2.down, enemySO.EnemyDetectedData.LedgeDetectDistance,enemySO.LayerData.GroundLayer);
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheckPoint.position, transform.right, enemySO.EnemyDetectedData.GroundDetectDistance, enemySO.LayerData.GroundLayer);
    }
    public virtual bool CheckPlayer()
    {
        return Physics2D.Raycast(playerCheckPoint.position, transform.right, enemySO.EnemyDetectedData.PlayerDetectDistance, enemySO.LayerData.PlayerLayer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        attackCheck.AddDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attackCheck.RemoveDetected(collision);
    }
    #endregion
}
