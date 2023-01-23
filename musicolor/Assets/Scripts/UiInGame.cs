using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInGame : MonoBehaviour
{
    private bool isPlaying = false;

    private Flower currentFlower = null;
    public Flower[] flowers;

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void PlayMusic()
    {
        if (isPlaying)
        {
            StopCoroutine(Play());
            StopCoroutine(currentFlower.Play());
            isPlaying = false;
            return;
        }
        isPlaying = true;
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        // Play flower music one by one
        foreach (Flower flower in flowers)
        {
            currentFlower = flower;
            Debug.Log("Play flower");
            yield return StartCoroutine(flower.Play());
        }
    }
}
