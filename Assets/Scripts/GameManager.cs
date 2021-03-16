using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void EndGame()
    {
        StartCoroutine(PlayerEndGameAnimation());
    }

    IEnumerator PlayerEndGameAnimation()
    {
        Debug.Log("GAME OVER");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
