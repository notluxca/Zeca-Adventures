using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject _endingSceneTransition;

    bool gameIsOver = false;
    public float menuDelay = 1f;

    
    public void GameOver()
    {
        if(gameIsOver==false)
        {
            gameIsOver=true;
            Debug.Log("Game Over");
            StartCoroutine("gameOverSequence");
        }
    }

    IEnumerator gameOverSequence()
    {

        print("hello bitch");
        yield return new WaitForSeconds(.1f);
        _endingSceneTransition.SetActive(true);
        
        // 
        //load game over pannel
        // SceneManager.LoadScene("GameOver");



    // fade image to black before game goes back to startScene
    // Color c = renderer.material.color;
    // for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
    // {
    //     c.a = alpha;
    //     renderer.material.color = c;
    //     yield return new WaitForSeconds(.1f);
    // }
    }


}