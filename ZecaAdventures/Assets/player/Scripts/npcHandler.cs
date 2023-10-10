using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using System;

public class npcHandler : MonoBehaviour
{
    [SerializeField] GameObject seats;    
    [SerializeField] TextMeshProUGUI npcText;
    public Transform npcsParent;
    public int npcsLeft;
    public Transform seatPosition;
    public GameObject dropPosition;
    public Vector3 seatOffset;
    public GameObject npcOnCarry;
    public bool carryingNpc;

    

    
    
    
    private void Start() {
        
        carryingNpc = false;
        npcsLeft = npcsParent.childCount;
        npcText.text = npcsLeft.ToString();
        
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

    private void dropNpc()
{
    if (!carryingNpc)
    {
        return; // Não está carregando um NPC, então saia da função.
    }

    foreach (Transform seatOBJ in seats.transform)
    {
        seatScript seat = seatOBJ.GetComponent<seatScript>();

        if (seat != null && !seat.occupied)
        {
            // Encontrou um assento vazio, coloque o NPC lá.
            npcOnCarry.transform.position = seatOBJ.transform.position;
            seat.occupied = true;

            // Desativa o collider do NPC (se estiver usando um BoxCollider).
            BoxCollider npcCollider = npcOnCarry.GetComponent<BoxCollider>();
            if (npcCollider != null)
            {
                Destroy(npcCollider);
            }

            // Limpa as variáveis e atualiza a contagem de NPCs.
            npcOnCarry = null;
            carryingNpc = false;
            npcsLeft--;

            npcText.text = npcsLeft.ToString();

            if (npcsLeft == 0)
            {
                npcText.text = npcsLeft.ToString();
                FindObjectOfType<GameManager>().Win();
            }

            break; // Saia do loop assim que o NPC for colocado em um assento.
        }
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
