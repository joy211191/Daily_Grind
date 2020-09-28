using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    public List<SubElements> treeElements;
    int counter;
    private void Start()
    {
        counter=3;
    }


    public void ShakeTree()
    {
        counter -= 1;
        if (counter > 0)
        {
            foreach (SubElements leaves in treeElements)
            {
                leaves.Shake();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
