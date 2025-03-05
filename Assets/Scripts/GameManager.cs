using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject LoadingScreen;

    protected override void Awake()
    {
        base.Awake();
        // Add your GameManager initialization code here
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("MainScene");
    }

    public void LevelCompleted()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene("MainScene");
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCoroutine());
    }

    private IEnumerator LoadLevelCoroutine()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelScene");
        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive(true);
        }

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        
        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive(false);
        }
    }
}
