using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("OnEnable Function");
    }

    private void OnDisable()
    {
        
    }

    private void Awake()
    {
        Debug.Log("Awake Function");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Function");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Function");
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("On Collision: " + col.gameObject.name);
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("On Trigger: " + col.name);
    }
}
