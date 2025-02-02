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

	[SerializeField]
	bool cenaJackpot;
	
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
		if(cenaJackpot)
		{
			if(GlobalData.bossDisponiveis.Count == 3)
				SceneName = "Roleta1";
			if(GlobalData.bossDisponiveis.Count == 2)
				SceneName = "Roleta2";
			if(GlobalData.bossDisponiveis.Count == 1)
				SceneName = "Roleta3";
		}
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