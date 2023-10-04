using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHandler : MonoBehaviour
{
    public Transform seatPosition;
    public bool carryingNpc;
    private GameObject npcOnCarry;
    
    
    private void Start() {
        carryingNpc = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "npc"){
            if(!carryingNpc){
                print("devNote: got an npc");
                carryingNpc = true;
                npcOnCarry = other.gameObject;
                getNpc(other.gameObject);
            }
        }
    }

    private void getNpc(GameObject npc){
        // set the npc transform to the back of the tractor
        npc.transform.position = seatPosition.position;
        print("npc position updated");
    }

    private void dropNpc(GameObject npc){

    }

    
    
}
