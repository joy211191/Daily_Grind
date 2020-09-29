using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    public AudioSource source;
    public AudioClip chop;
    public AudioClip fall;
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
            source.clip = chop;
            source.PlayOneShot(chop, 1);
            foreach (SubElements leaves in treeElements)
            {
                leaves.Shake();
            }
        }
        else
        {
            source.clip = fall;
            source.PlayOneShot(fall, 1);
            Invoke("DestroyObject",0.2f);
        }
    }

    void DestroyObject() {
        Destroy(gameObject);
    }
}
