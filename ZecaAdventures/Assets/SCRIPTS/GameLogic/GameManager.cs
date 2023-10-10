using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    
    // camera Handling variables


    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject enchente;
    [SerializeField] GameObject cameraSpot;

    [SerializeField] GameObject blackBackground;
    [SerializeField] GameObject gameOverText;

    bool gameIsOver = false;
    public float menuDelay = 1f;
    public int npcsLeft;

    private void Start() {
        
    }
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

        yield return new WaitForSeconds(.1f);
        FindObjectOfType<Camera>().GetComponent<followPlayer>();
        enchente.SetActive(true);

        // move the camera to the center of map
        mainCamera.GetComponent<followPlayer>().smoothTime = 1;
        mainCamera.GetComponent<followPlayer>().target = cameraSpot.transform;
        mainCamera.GetComponent<Camera>().orthographicSize = 10;
        

        //load game over pannel
        yield return new WaitForSeconds(10f);
        blackBackground.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);

        // SceneManager.LoadScene("GameOver");
        // fade image to black before game goes back to startScene




        }


}