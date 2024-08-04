using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour,IDamagable
{
    [field: Header("Reference")]
    [field:SerializeField] public PlayerSO data { get; private set; }
    [field: Header("Animation")]
    [field:SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    [field: Header("Layer")]
    [field: SerializeField] public PlayerLayerData LayerData { get; private set; }

    

    
    public PlayerResizableBox2DCollider ResizableBox2DCollider { get; private set; }

    
    public Animator Animator { get; private set; }
    public Rigidbody2D Rb{ get; private set; }
    
    public PlayerMovementStateMachine MovementStateMachine { get; private set; }

    public PlayerAttackStateMachine AttackStateMachine { get; private set; }

    public SpriteRenderer spriteRenderer { get; private set; }

    public PlayerInput playerInput { get; private set; }

    public PlayerAttackCheck attackCheck { get; private set; }

    public Collider2D Collider { get; private set; }
    public GameObject takeDamageTrigger; 

    [SerializeField] private Transform groundCheckPoint;

    [HideInInspector]public float currentAttackDamage;
    [HideInInspector] public float currentDamageForce;
    [HideInInspector] public string targetTakeDamAnim;


    private void Awake()
    {
        MovementStateMachine = new PlayerMovementStateMachine(this);
        AttackStateMachine = new PlayerAttackStateMachine(this);
        Animator = GetComponentInChildren<Animator>();
        Rb= GetComponent<Rigidbody2D>();
        ResizableBox2DCollider = GetComponent<PlayerResizableBox2DCollider>();
        Collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        attackCheck = GetComponentInChildren<PlayerAttackCheck>();  
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        AnimationData.Initialize();
        MovementStateMachine.ChangeState(MovementStateMachine.IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        MovementStateMachine.HandleInput();
        MovementStateMachine.LogicUpdate();
        //CheckGround();
        ChangeColliderSize();

        Vector2 capsuleColliderCenterInWorldSpace = ResizableBox2DCollider.Box2DColliderData.Collider.bounds.center;

        Ray downwardsRayFromCapsuleBottom = new Ray(capsuleColliderCenterInWorldSpace - ResizableBox2DCollider.Box2DColliderData.ColliderVerticalExtents, Vector3.down);

        Debug.DrawLine(capsuleColliderCenterInWorldSpace - ResizableBox2DCollider.Box2DColliderData.ColliderVerticalExtents, capsuleColliderCenterInWorldSpace - ResizableBox2DCollider.Box2DColliderData.ColliderVerticalExtents - new Vector2(0, data.GroundedData.GroundToFallRayDistance));
    }
    //void OnDrawGizmos()
    //{
    //    PlayerTriggerColliderData triggerColliderData = ResizableBox2DCollider.TriggerColliderData;

    //    Vector2 groundColliderCenterInWorldSpace = triggerColliderData.GroundCheckCollider.bounds.center;

    //    Collider2D[] overlappedGroundColliders = Physics2D.OverlapBoxAll(groundColliderCenterInWorldSpace, 0.1f * triggerColliderData.GroundCheckCollider.size, 0, LayerData.GroundLayer);


    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireCube(groundColliderCenterInWorldSpace, triggerColliderData.GroundCheckCollider.size);
    //}

    private void FixedUpdate()
    {
         MovementStateMachine.PhysicsUpdate();
    }

    private void ChangeColliderSize()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementStateMachine.OnTriggerEnter(collision);
        attackCheck.AddDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

         MovementStateMachine.OnTriggerExit(collision);
        attackCheck.RemoveDetected(collision);

    }
    #region Animation Methods
    public void AnimationTransitionEvent()
    {
        MovementStateMachine.AnimationTransitionEvent();
    }

    public void AnimationEnterEvent()
    {
        MovementStateMachine.AnimationEnterEvent();
    }

    public void AnimationExitEvent()
    {
        MovementStateMachine.AnimationExitEvent();
    }

    public void AnimationComboStartEvent()
    {
        MovementStateMachine.AnimationComboStartEvent();
    }

    public void AnimationComboEndEvent()
    {
        MovementStateMachine.AnimationComboStopEvent();
    }


    #endregion

    #region Take Damage
    public void TakeDamage(string animationName, float Damage,float damageForce,Vector3 pos)
    {
        if (MovementStateMachine.ReusableData.CanTakeDamage)
        {
            if (animationName == "TakeDamageNormal")
            {
                MovementStateMachine.ChangeState(MovementStateMachine.TakeDamageNormalState);
            }

            Rb.AddForce(new Vector2((transform.position - pos).x,0).normalized * damageForce, ForceMode2D.Impulse);

            //Rb.AddForce((transform.position - pos).normalized * damageForce, ForceMode2D.Impulse);
            //else if (animationName == "TakeDamageHard")
            //{
            //    MovementStateMachine.ChangeState(MovementStateMachine.TakeDamageHardState);

            //}
            Debug.Log("Player Take Damage:" + Damage);
        }
    }
    #endregion

    #region Rigidbody
    public void TurnOffRB()
    {
        
    }
    #endregion

    #region Trigger
    public virtual bool CheckGround()
    {
        return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, data.GroundedData.GroundDetectRange, LayerData.GroundLayer);
    }
    #endregion
}
