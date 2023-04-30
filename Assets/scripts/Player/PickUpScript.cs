using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;

public class PickUpScript : MonoBehaviour
{
    private InventoryScript inventory;

    [SerializeField] private string selectableTag = "Selectable";

    [SerializeField] GameObject PressEToPickUp;

    public float rayLength;

    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryScript>();     

        PressEToPickUp.SetActive(false);
    }

    //Update is called once per frame
    //Checking if Player is picking up or viewing an object that can be picked up using raycast and checking slots
    void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {

            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                
                PressEToPickUp.SetActive(true);
                
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    PickUpObjects pickUpObjects = hit.collider.gameObject.GetComponent<PickUpObjects>();

                        if (pickUpObjects != null)
                        {
                            //call function from pickupobjects script
                            pickUpObjects.Instanciates();
                        }                  
                    }                         
            }
        }
        else
        {
            PressEToPickUp.SetActive(false);
        }
    }
}