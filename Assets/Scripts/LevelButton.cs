using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public Button Button;
    public TextMeshProUGUI LevelText;

    private int level;
    private bool startPressed = false;

    void Awake()
    {
        level = PlayerPrefs.GetInt("Level", 1);
        Button.onClick.RemoveAllListeners();
        Button.onClick.AddListener(OnClick);
    }

    void Start()
    {
        if (level > 10) // TODO: Max level can vary, must be more extensible.
        {
            LevelText.text = "Finished";
        } 
        else if (level == 1)
        {
            LevelText.text = "Start";
        }
        else
        {
            LevelText.text = "Level " + level;
        }
    }

    public void OnClick()
    {
        if (level > 10) // TODO: Max level can vary, must be more extensible.
        {
            GameManager.Instance.ResetGame();
        }
        else if (level == 1 && !startPressed)
        {
            startPressed = true;
            LevelText.text = "Level" + level;
        }
        else
        {
            GameManager.Instance.LoadLevel();
        }
    }

}
