using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasolineCan : MonoBehaviour
{
    public float fuelCount;

    private void OnTriggerEnter(Collider other) {
        print(other.gameObject.tag);
        if(other.gameObject.tag == "Player"){
            GameObject player = other.gameObject;
            player.transform.parent.GetComponent<fuelHandler>().addFuel(fuelCount);
            player.transform.parent.GetComponent<fuelHandler>().canDrive = true;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        print("detected");
        print(other.gameObject.tag);
    }
}
