using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    public List<SubElements> treeElements;

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (SubElements leaves in treeElements)
        {
            leaves.Shake();
        }
    }
}
