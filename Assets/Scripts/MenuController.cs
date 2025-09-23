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

        // só a primeira imagem fica ativa no início
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

        // desativa a imagem atual
        imagens[indexAtual].SetActive(false);

        // avança índice
        indexAtual++;

        // se passou do último
        if (indexAtual == 4)
        {
            string cenaNome = "SampleScene";

            // verifica se a cena existe nas Build Settings
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

        // ativa a próxima
        imagens[indexAtual].SetActive(true);
    }

    // Função para checar se a cena existe
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
