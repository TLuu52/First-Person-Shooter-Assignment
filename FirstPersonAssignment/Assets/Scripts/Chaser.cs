using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    public float speed = 10.0f;
    public float minDist = 1f;
    public Transform target;
    public GameObject explosion;
    public GameObject loseText;
    public GameObject retryText;


    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Player").transform;       
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        transform.LookAt(target);

        float dist = Vector3.Distance(transform.position, target.position);

        if(dist > minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Destroy(other.gameObject);
            explosion.transform.position = other.transform.position;
            Instantiate(explosion);

            loseText.SetActive(true);
            retryText.SetActive(true);

        }

       }
    }
