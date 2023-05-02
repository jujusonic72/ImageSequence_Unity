using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSequenceScript : MonoBehaviour
{
    public bool sequenceDone;
    public GameObject enfant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sequenceDone = enfant.GetComponent<SequenceScript>().done;
    }
}
