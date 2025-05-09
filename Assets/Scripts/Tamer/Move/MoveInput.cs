using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the player movement
    private Rigidbody2D rb; // Reference to the Rigidbody component
    private TamerInputmap playerInput; // Reference to the TamerInputmap class
    private Vector2 moveInput; // Variable to store the input from the userr

    private void Awake()
    {
        // Get the Rigidbody component attached to the players
        rb = GetComponent<Rigidbody2D>();
        playerInput = new TamerInputmap();
        
        // Habilitar o Action Map
        playerInput.Tamer.Enable();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        moveInput = playerInput.Tamer.Move.ReadValue<Vector2>(); // Get the input from the userr
        // Move the player in the direction of the input
        rb.linearVelocity = moveInput * speed;
            
    }
    
     private void OnEnable()
    {
        playerInput.Tamer.Enable();
    }

    private void OnDisable()
    {
        playerInput.Tamer.Disable();
    }



}
