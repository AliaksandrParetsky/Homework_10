using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private byte resetMovingAnim = 0;
    public bool Anim {  get; set; }

    private Rigidbody2D rb;
    public Rigidbody2D Rigidbody2D { get { if (rb == null) rb = GetComponent<Rigidbody2D>(); return rb; } }

    private Animator animator;
    public Animator AnimTor {  get { if (animator == null) animator = GetComponentInChildren<Animator>(); return animator; } } 

    private InputManager inputManager;
    public InputManager InputManager {  get { if (inputManager == null) inputManager = GetComponent<InputManager>(); return inputManager; } }


    private void FixedUpdate()
    {
        Move(InputManager.Input);
    }

    public void Move(Vector2 input)
    {
        Vector2 movement = new Vector2(input.x, input.y);
        movement = movement * movementSpeed * Time.fixedDeltaTime;
        movement = Vector3.ClampMagnitude(movement, movementSpeed);

        float isoX = movement.x - movement.y;
        float isoY = (movement.x + movement.y) / 2;

        Rigidbody2D.velocity = new Vector2(isoX, isoY);

        SetAnim();
    }

    private void SetAnim()
    {
        if (InputManager.Input.y > 0 || InputManager.Input.y < 0)
        {
            AnimTor.SetFloat("MoveX", resetMovingAnim);

            AnimTor.SetFloat("MoveY", InputManager.Input.y);
        }

        if (InputManager.Input.x > 0 || InputManager.Input.x < 0)
        {
            AnimTor.SetFloat("MoveY", resetMovingAnim);

            AnimTor.SetFloat("MoveX", InputManager.Input.x);
        }

        if (InputManager.Input.x == 0 && InputManager.Input.y == 0)
        {
            AnimTor.SetFloat("MoveY", resetMovingAnim);
            AnimTor.SetFloat("MoveX", resetMovingAnim);

            float zero = InputManager.Input.x + InputManager.Input.y;
            AnimTor.SetFloat("Idle", zero);
        }
    }
}
