using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject[] imagens;
    public int indexAtual = 0;

    void Start()
    {
        if (imagens.Length == 0)
        {
            Debug.LogWarning("Nenhuma imagem atribuída no MenuController!");
            return;
        }

        for (int i = 0; i < imagens.Length; i++)
        {
            imagens[i].SetActive(i == indexAtual);
        }
    }

    public void BtnChangeImage()
    {
        Debug.Log("Botão clicado! Imagem atual: " + indexAtual);

        if (imagens.Length == 0)
        {
            Debug.LogWarning("Nenhuma imagem atribuída!");
            return;
        }

        imagens[indexAtual].SetActive(false);

        indexAtual++;

        if (indexAtual == 6)
        {
            string cenaNome = "SampleScene";

            if (SceneExists(cenaNome))
            {
                Debug.Log("Carregando cena: " + cenaNome);
                SceneManager.LoadScene(cenaNome);
            }
            else
            {
                Debug.LogError("Cena não encontrada nas Build Settings: " + cenaNome);
            }
            return;
        }

        imagens[indexAtual].SetActive(true);
    }

    private bool SceneExists(string nomeCena)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string nome = System.IO.Path.GetFileNameWithoutExtension(path);
            if (nome == nomeCena)
                return true;
        }
        return false;
    }
}
