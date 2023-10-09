using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class npcHandler : MonoBehaviour
{
    public Transform seatPosition;
    public Transform dropPosition;
    public Vector3 seatOffset;
    public bool carryingNpc;
    private GameObject npcOnCarry;

    
    
    
    private void Start() {
        carryingNpc = false;
    }   


    private void Update() {
        if(carryingNpc){
            carryNpc(npcOnCarry);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "npc"){
            if(!carryingNpc){
                carryingNpc = true;
                npcOnCarry = other.gameObject;
                getNpc(other.gameObject);
            }
        }
        else if(other.gameObject.tag == "dropZone"){
            dropNpc();
        }
    }


    private void carryNpc(GameObject npc){
        
            npc.transform.position = seatPosition.position + seatOffset;
        
    }

    private void getNpc(GameObject npc){
        // set the npc transform to the back of the tractor
        npc.transform.position = seatPosition.position;
        print("npc position updated");
    }

    private void dropNpc(){
        // get npc inside the school
        npcOnCarry.transform.position = dropPosition.transform.position;
        // reset npc handler
        carryingNpc = false;

    }

    
    
}
