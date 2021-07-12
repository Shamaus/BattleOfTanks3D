using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(123);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
