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

    [SerializeField] GameObject whiteBackground;
    [SerializeField] GameObject winText;


    [SerializeField] GameObject blackBackground;
    [SerializeField] GameObject gameOverText;

    bool gameIsOver = false;
    public float menuDelay = 1f;
    public int npcsLeft;

    private void Start() {
        // StartCoroutine("winSequence"); // debug
        Application.targetFrameRate = 60;
    }

    public void Win(){
        Debug.Log("Game Won");
Debug.Log("Game Won");
        StartCoroutine("winSequence");
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P)){
            StartCoroutine("winSequence");
        }
        if(Input.GetKeyDown(KeyCode.O)){
            StartCoroutine("gameOverSequence");
        }
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

    }


        IEnumerator winSequence()
        {

        Destroy(FindObjectOfType<Timer>());
        yield return new WaitForSeconds(.1f);
        FindObjectOfType<Camera>().GetComponent<followPlayer>();
        enchente.SetActive(true);

        // move the camera to the center of map
        mainCamera.GetComponent<followPlayer>().smoothTime = 1;
        mainCamera.GetComponent<followPlayer>().target = cameraSpot.transform;
        mainCamera.GetComponent<Camera>().orthographicSize = 10;


        //load game over pannel
        yield return new WaitForSeconds(10f);
        whiteBackground.SetActive(true);
        yield return new WaitForSeconds(1f);
        winText.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
        // destroy timer script so game wont load lose sequence after the win
        }


}