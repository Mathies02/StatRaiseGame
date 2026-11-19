using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Counter References")]
    public Clickable assets;
    public Clickable jobRank;
    public Clickable connections;

    public int amountToReach;
    public int amountToLose = 1000;
    public int innerValue = 50;
    public int innerValueWinAmount = 100;

    [Header("Scene Settings")]
    public string sceneToLoad;
    public string winScene;
    public string loseScene;

    private bool sceneLoaded = false;

    void Update()
    {
        if (innerValue >= innerValueWinAmount)
        {
            SceneManager.LoadScene(winScene);
        }

        if (assets == null || jobRank == null || connections == null)
            return;

        if (assets.counter >= amountToReach &&
            jobRank.counter >= amountToReach &&
            connections.counter >= amountToReach)
        {
            LoadNextScene();
        }

        if (assets.counter >= amountToLose &&
            jobRank.counter >= amountToLose &&
            connections.counter >= amountToLose)
        {
            SceneManager.LoadScene(loseScene);
        }
    }

    void LoadNextScene()
    {
        if (sceneLoaded)
            return;

        sceneLoaded = true;

        Debug.Log("Loading scene: " + sceneToLoad);

        SceneManager.LoadScene(sceneToLoad);
    }
}