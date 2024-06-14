using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
    [field: Header("Reference")]
    [field: SerializeField] public EnemySO enemySO { get;protected set; }
    [field: Header("Animation")]
    [field: SerializeField] public EnemyAnimationData animationData { get; protected set; }
    public EnemyStateMachine stateMachine;
    public EnemyState enemyState;

    public Rigidbody2D Rb { get; private set; }

    public Animator Animator { get; private set; }
    

    public bool canFlip { get; set; } 
    public bool isFacingRight { get; set; } = true;

    [field: SerializeField] public bool canTakeDamage { get; set; } = true;

    public bool canAttack { get; set; } = true;
    public bool isSheild;

    public string takeDamageAnim { get; set; }

    public float attackCoolDownTime { get; set; }

    

    public EnemyAttackCheck attackCheck { get; private set; }
    public EnemyShieldTriggerBox shieldTriggerBox { get;private set; }
    [HideInInspector] public float currentAttackDamage;
    [HideInInspector] public string targetTakeDamAnim;

    [SerializeField] private Transform ledgeCheckPoint;
    [SerializeField] private Transform wallCheckPoint;
    [SerializeField] private Transform playerCheckPoint;

    #region State Instance
    public EnemyIdle IdleState { get; private set; }

    public EnemyWalk WalkState { get; private set; }

    public EnemyCombatIdle CombatIdleState { get; private set; }

    public EnemyCombatWalk CombatWalkState { get; private set; }
    public EnemyTakeDamageHard TakeDamageHardState { get; private set; }

    public EnemyTakeDamageNormalState TakeDamageNormalState { get; private set; }

    

    public EnemyAttack1 Attack1State { get; private set; }
    public EnemyShieldState ShieldState { get; private set; }
    #endregion
    // Start is called before the first frame update

    protected void Awake()
    {
        stateMachine = new EnemyStateMachine(this);
       Animator = GetComponentInChildren<Animator>();
        attackCheck= GetComponentInChildren<EnemyAttackCheck>();
        shieldTriggerBox= GetComponentInChildren<EnemyShieldTriggerBox>();
        Rb= GetComponent<Rigidbody2D>();

        #region Generate State Instance
        IdleState = new EnemyIdle(stateMachine,this);
        WalkState = new EnemyWalk(stateMachine, this);
        TakeDamageHardState = new EnemyTakeDamageHard(stateMachine, this);
        TakeDamageNormalState = new EnemyTakeDamageNormalState(stateMachine, this);
        Attack1State = new EnemyAttack1(stateMachine,this);
        

        CombatIdleState = new EnemyCombatIdle(stateMachine, this);
        CombatWalkState = new EnemyCombatWalk(stateMachine, this);
        ShieldState = new EnemyShieldState(stateMachine, this);
        #endregion
    }
    protected void Start()
    {
        stateMachine.ChangeState(IdleState);
        animationData.Initialize();
        //Rb.drag = 10f;
    }

    // Update is called once per frame
    protected void Update()
    {
        stateMachine.LogicUpdate();
    }

    protected void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void TakeDamage(string animationName, float Damage)
    {
        //if (canTakeDamage)
        //{
        //    if(animationName == "TakeDamageNormal")
        //    {
        //        if (!isSheild)
        //        {

        //            stateMachine.ChangeState(stateMachine.TakeDamageNormalState);
        //            Debug.Log("Taka Damage:" + Damage);
        //        }
        //    }
        //    else if (animationName == "TakeDamageHard")
        //    {
        //        stateMachine.ChangeState(stateMachine.TakeDamageHardState);
        //        Debug.Log("Taka Damage:" + Damage);

        //    }
            
        //}
       
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
    public void AnimationComboChange()
    {
        stateMachine.AnimationComboChange();
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

    public virtual bool CheckPlayer(float distance)
    {
        return Physics2D.Raycast(playerCheckPoint.position, transform.right, distance, enemySO.LayerData.PlayerLayer);
    }
    public virtual bool CheckPlayerInRange()
    {
        Collider2D ply = Physics2D.OverlapCircle(transform.position, enemySO.EnemyDetectedData.CheckPlayerRadius, enemySO.LayerData.PlayerLayer);
        return ply !=null;
    }
    public virtual Vector2 PlayerPos()
    {
       Collider2D ply = Physics2D.OverlapCircle(transform.position,enemySO.EnemyDetectedData.CheckPlayerRadius,enemySO.LayerData.PlayerLayer);
        return ply.transform.position;    
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
