using UnityEngine;
using System.Collections;

public class SirenAfterTime : MonoBehaviour
{
  public AudioSource sirenSound;
  void Start()
  {
    StartCoroutine(SirenTime());
  }

  IEnumerator SirenTime()
  {
    yield return new WaitForSeconds(170f);
      sirenSound.Play();
    
    yield return new WaitForSeconds(110f);
      sirenSound.Play();
  }

}