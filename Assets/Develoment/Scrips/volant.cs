using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volant : MonoBehaviour
{
    [SerializeField] Transform look;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(look,Vector3.forward);
    }
}
