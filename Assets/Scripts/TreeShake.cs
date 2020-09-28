using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    public List<SubElements> treeElements;

    public void ShakeTree()
    {
        foreach (SubElements leaves in treeElements)
        {
            leaves.Shake();
        }
    }
}
