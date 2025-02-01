using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementUtilitys : MonoBehaviour
{
	public string SceneName;
	public int sceneBuildIndex;
	public GameObject sobreCanva;
	public float currentTime = 0f;
    public float timer;
	public bool active;
	public float tempo = 5f;
	
	public void LoadSceneString()
	{
		SceneManager.LoadScene (SceneName);
	}

	public void LoadSceneStringWithTimer(float tempo)
	{
		Invoke("LoadSceneString",tempo);
	}
	
	public void LoadSceneIndex()
	{
		SceneManager.LoadScene(sceneBuildIndex);
	}
    
	public void ativarCanva()
	{
		sobreCanva.SetActive(true);
	}

	public void ativarCanvaWithTimer(float tempo)
	{
		Invoke("ativarCanva",tempo);
	}

	public void desativarCanva()
	{
		sobreCanva.SetActive(false);
	}

	public void desativarCanvaWithTimer(float tempo)
	{
		Invoke("desativarCanva",tempo);
	}

	public void QuitGame()
    {
        Application.Quit();
        Debug.Log(" Fechou");
    }

	void Start()
    {
        currentTime = 0f;
    }

	void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= timer && active)
        {
            SceneManager.LoadScene (SceneName);
        }
	}
}