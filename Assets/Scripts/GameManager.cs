using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    string menuSceneName;

    [SerializeField]
    GameObject cortinaIn;

    [SerializeField]
    SceneManagementUtilitys sceneManagementUtilitys;

    public void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public IEnumerator CarregaCena(string cena)
    {
        yield return new WaitForSeconds(4);
        cortinaIn.SetActive(true);
        yield return new WaitForSeconds(1);
        sceneManagementUtilitys.SceneName = cena;
        sceneManagementUtilitys.LoadSceneString();
    }
}
