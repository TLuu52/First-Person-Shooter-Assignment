using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Reload : MonoBehaviour
{
    public GameObject gm;
    public TextMeshProUGUI ammoCounter;

    private float ammoTotal;
    private float ammoCurrent;
    private float magazine;

    // Start is called before the first frame update
    void Start()
    {
        ammoCounter.SetText(gm.gameObject.GetComponent<GameManager>().ammoCurrent + " / " + gm.gameObject.GetComponent<GameManager>().ammoTotal);
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.SetText(gm.gameObject.GetComponent<GameManager>().ammoCurrent + " / " + gm.gameObject.GetComponent<GameManager>().ammoTotal);

        if (Input.GetKeyDown("r"))
        {
            // Take from total pool --> reset current ammo to max

            while (gm.gameObject.GetComponent<GameManager>().ammoTotal > 0 && gm.gameObject.GetComponent<GameManager>().ammoCurrent < gm.gameObject.GetComponent<GameManager>().magazine)
            {
                gm.gameObject.GetComponent<GameManager>().ammoCurrent++;
                gm.gameObject.GetComponent<GameManager>().ammoTotal--;

            }

            if (gm.gameObject.GetComponent<GameManager>().ammoCurrent > gm.gameObject.GetComponent<GameManager>().magazine)
            {
                gm.gameObject.GetComponent<GameManager>().ammoCurrent = gm.gameObject.GetComponent<GameManager>().magazine;
            }
        }
    }
}
