using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float speed = 3f;
    private CharacterController controller;

    private int coins = 0; // contador de moedas

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
{
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    // Movimento relativo à câmera
    Vector3 forward = Camera.main.transform.forward;
    Vector3 right = Camera.main.transform.right;

    // Mantém movimento no plano XZ
    forward.y = 0f;
    right.y = 0f;
    forward.Normalize();
    right.Normalize();

    Vector3 movement = h * right + v * forward;

    if (movement.magnitude > 1f)
        movement.Normalize();

    controller.Move(movement * speed * Time.deltaTime);

    if (movement != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);
    }
}
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto tem o script Coin
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            coins++;
            Debug.Log("Moeda coletada! Total: " + coins);

            Destroy(other.gameObject); // remove a moeda da cena
        }
    }
}
