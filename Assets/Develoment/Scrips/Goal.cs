using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] bool Nob, Sina;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            ManagerFootball Mn = FindObjectOfType<ManagerFootball>();
            if (Nob) Mn.Nob++;
            if (Sina) Mn.Sina++;
            Mn.Goal();
        }
    }
}
