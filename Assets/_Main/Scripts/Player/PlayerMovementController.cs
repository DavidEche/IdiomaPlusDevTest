using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference attackControl;
    [SerializeField] private CharacterController controller;
    private PlayerAnimatorController animatorController;   
    [SerializeField] private Attack attackPlayer;   

    
    [SerializeField] private float playerSpeed = 4.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private Transform cameraMainTranform;
    [SerializeField] private bool canMove;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private void OnEnable() {
        movementControl.action.Enable();
        attackControl.action.Enable();
    }

    private void OnDisable() {        
        movementControl.action.Disable();
        attackControl.action.Disable();
    }

    public void Initialize(PlayerAnimatorController _animatorController, Attack _attackPlayer){
        animatorController = _animatorController;
        attackPlayer = _attackPlayer;
        canMove = true;
    }
    void Update()
    {
        if(canMove){            
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            Vector2 movement = movementControl.action.ReadValue<Vector2>();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            move = cameraMainTranform.forward * move.z + cameraMainTranform.right * move.x;
            move.y = 0f;
            controller.Move(move * Time.deltaTime * playerSpeed);

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            if(movement != Vector2.zero){
                animatorController.MoveCharacter(true);
                float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTranform.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation,Time.deltaTime * rotationSpeed);
            }else{
                animatorController.MoveCharacter(false);
            }

            if(attackControl.action.triggered){
                canMove = false;
                animatorController.MoveCharacter(false);
                animatorController.PlayerAttack();
                attackPlayer.StartAttack();
                animatorController.endAttack += EndAttack;
            }
        }
    }

    private void EndAttack(){
        animatorController.endAttack -= EndAttack;
        canMove = true;
    }
}
