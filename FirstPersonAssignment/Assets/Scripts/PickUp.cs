using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    public string Weapon;
    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            switch (Weapon)
            {
                case "Rifle":
                    gm.gameObject.GetComponent<GameManager>().currentWeapon = "Rifle";
                    gm.gameObject.GetComponent<GameManager>().magazine = 15f;
                    break;
                case "Pistol":
                    gm.gameObject.GetComponent<GameManager>().currentWeapon = "Pistol";
                    gm.gameObject.GetComponent<GameManager>().magazine = 5f;
                    break;
                case "MachineGun":
                    gm.gameObject.GetComponent<GameManager>().currentWeapon = "MachineGun";
                    gm.gameObject.GetComponent<GameManager>().magazine = 50f;
                    break;
            }

            gm.gameObject.GetComponent<GameManager>().spawnWeapon();
        }
    }
}
