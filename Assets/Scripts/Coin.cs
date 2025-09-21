using UnityEngine;

public class Coin : MonoBehaviour
{
    public float floatAmplitude = 0.2f; // quanto ela sobe acima da posição base
    public float floatSpeed = 1f;       // velocidade do movimento
    public float hoverHeight = 0.9f;    // altura mínima acima do chão

    private Vector3 startPos;

    void Start()
    {
        // posição base da moeda, elevada acima do chão
        startPos = transform.position;
        startPos.y += hoverHeight; // eleva a moeda um pouco
    }

    void Update()
    {
        // PingPong varia de 0 até floatAmplitude, sempre acima do chão
        float newY = startPos.y + Mathf.PingPong(Time.time * floatSpeed, floatAmplitude);
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // girar lentamente
        transform.Rotate(Vector3.up * 50f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Procura o Placar na cena e adiciona uma moeda
        Placar placar = FindObjectOfType<Placar>();
        if (placar != null)
        {
            placar.AdicionarMoeda();
        }

        // Remove a moeda da cena
        Destroy(gameObject);
    }
}
