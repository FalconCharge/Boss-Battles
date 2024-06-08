using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData Data;

    #region Variables
    public Rigidbody2D rb { get; private set; }

    public bool IsFacingRight { get; private set; }
    public float LastOnGroundTime { get; private set; }

    private Vector2 _moveInput;

    #endregion

    #region CHECK PARAMETERS

    [Header("Checks")]
    [SerializeField] private Transform _groundCheckPoint;

    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        IsFacingRight = true;
    }

    private void Update()
    {
        #region InputHandler
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");

        if (_moveInput.x != 0)  
            CheckDirectionToFace(_moveInput.x > 0);
        #endregion

        #region collision Checks

        if(Physics2D.Raycast(_groundCheckPoint.position,Vector2.down, 1, _groundLayer))
        {
            LastOnGroundTime = 0.1f;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        float targetSpeed = _moveInput.x * Data.runMaxSpeed;

        #region calculate AccelRate
        float accelRate;

        if (LastOnGroundTime > 0)
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount * Data.accelInAir : Data.runDeccelAmount * Data.deccelInAir;
        #endregion


        #region Conserve Momentum
        //We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
        if (Data.doConserveMomentum && Mathf.Abs(rb.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(rb.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
        {
            //Prevent any deceleration from happening, or in other words conserve are current momentum
            //You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
            accelRate = 0;
        }
        #endregion

        //Calculate difference between current velocity and desired velocity
        float speedDif = targetSpeed - rb.velocity.x;
        //Calculate force along x-axis to apply to thr player

        float movement = speedDif * accelRate;

        //Convert this to a vector and apply to rigidbody
        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }
    #region Methods

    private void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (_groundCheckPoint != null)
        {
            Gizmos.color = Color.red; // You can choose any color you want
            Gizmos.DrawRay(_groundCheckPoint.position, Vector3.down * 1);
        }
    }

    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
            Turn();
    }
    #endregion
}
