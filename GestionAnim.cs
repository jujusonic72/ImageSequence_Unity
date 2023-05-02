using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GestionAnim : MonoBehaviour
{
    public GameObject animated;
    public Sprite[] UIAnim;
    public Texture2D[] TextureAnim;
    public AudioClip sonAnim;
    public bool playImmediately;
    public bool useAttached;
    public bool disapearEnd;
    // Start is called before the first frame update
    void Start()
    {
        if (playImmediately)//faire jouer l'animation des l'apparition du gameObject
        {
            if (useAttached)
            {
                animated.GetComponent<SequenceScript>().animArray = UIAnim;
                animated.GetComponent<SequenceScript>().textureSequence = TextureAnim;
                if(sonAnim != null)
                {
                    animated.GetComponent<SequenceScript>().son = sonAnim;
                }
            }
            animated.GetComponent<SequenceScript>().disapearEnd = disapearEnd;
            animated.GetComponent<SequenceScript>().Demarrage();
        }
       
    }
    public void Gestion()//lance l'animation
    {
        if (useAttached)
        {
            animated.GetComponent<SequenceScript>().animArray = UIAnim;
            animated.GetComponent<SequenceScript>().textureSequence = TextureAnim;
            if (sonAnim != null)
            {
                animated.GetComponent<SequenceScript>().son = sonAnim;
            }
        }
        
        animated.GetComponent<SequenceScript>().Demarrage();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
