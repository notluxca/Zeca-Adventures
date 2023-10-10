using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class npcHandler : MonoBehaviour
{
    public Transform seatPosition;
    public GameObject dropPosition;
    public Vector3 seatOffset;
    public GameObject npcOnCarry;
    public bool carryingNpc;

    
    
    
    private void Start() {
        carryingNpc = false;
    }   


    private void Update() {
        if(carryingNpc){
            carryNpc(npcOnCarry);
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
        if(carryingNpc){
            
            // find a free position, drop the npc in
            npcOnCarry.transform.position = dropPosition.transform.position;
            // makes the npc not interectable (not the best aproach)
            Destroy(npcOnCarry.GetComponent<BoxCollider>());
            // reset npc handler
            npcOnCarry = null;
            carryingNpc = false;

        }

    }

    // handle all collisions
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
    
    
}
