using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fuelHandler : MonoBehaviour
{
    [SerializeField] bool useFuelSystem;
    [SerializeField] Slider slider;
    

    public bool canDrive;
    private bool isDriving;


    public float fuel;
    public float initialFuel;
    public float fuelComsuptionRate;

    
    // Start is called before the first frame update
    void Start()
    {
        canDrive = true;
        fuel = initialFuel;    
    }

    // Update is called once per frame
    void Update()
    {
        ConsumeFuel();
        driveCheck();
    }

    void ConsumeFuel(){
        if(useFuelSystem){
            slider.value = fuel;
            if(canDrive){
                if(isDriving){
                    fuel -= fuelComsuptionRate * Time.deltaTime;
                }
                if(fuel <= 0){
                    canDrive = false;
                }
        }        
        }
        
    }


    public void driveCheck(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
            isDriving = true;
        }
        else{
            isDriving = false;
        }   
    }


    // increase player fuel
    public void addFuel(float gasolineAmount){
        if(fuel + gasolineAmount > initialFuel){
            fuel = initialFuel;
        } else{
            fuel += gasolineAmount;
        }
    }

}
