using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float gravity = -9.81f; // gravidade manual
    private CharacterController controller;
    private Vector3 velocity;
    private int coins = 0;
    public GameObject portal;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.stepOffset = 0f; // impede subir obstáculos automaticamente
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = h * right + v * forward;

        if (movement.magnitude > 1f)
            movement.Normalize();

        // Move horizontalmente
        controller.Move(movement * speed * Time.deltaTime);

        // Rotação
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
        }

        // Gravidade manual
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.1f; // força pequena para manter no chão
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Aplica gravidade
        controller.Move(velocity * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            coins++;
            Debug.Log("Moeda coletada! Total: " + coins);
            Destroy(other.gameObject);
        }
        if (coins > 4)
        {
            portal.SetActive(false);
        }
    }
}
