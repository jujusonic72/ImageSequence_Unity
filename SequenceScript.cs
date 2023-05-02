using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
public class SequenceScript : MonoBehaviour
{
    public Image anim;//L'image à modifier
    public bool isMesh;
    public Material ogMat;
    public GameObject meshAnim;
    private Material matAnim;
    public int startFrame = 0;
    private int tac;//l'index de la frame
    public float tic;
    private float boom;
    public Sprite[] animArray;//La séquence d'images
    public Texture2D[] textureSequence;
    public bool loop;
    public AudioClip son;
    private AudioSource source;
    public bool disapearEnd;
    public float nbloop = 0;
    public bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        
        if(gameObject.GetComponent<Image>() == null)//detecte si l'animation est sur un mesh ou une image UI
        {
            isMesh = true;
        }
        else
        {
            isMesh = false;
            anim.color = new Color(anim.color.r, anim.color.g, anim.color.b, 0);//rend l'image trensparente
        }
    }
    private void Awake()
    {
        
    }

    public void Demarrage()
    {
        boom = 1 / tic;
        
        tac = startFrame;
        if (isMesh)//si l'animation est sur un mesh on lui donne un materiel et on lui assossie l'animation
        {
            matAnim = Instantiate(ogMat);
            GetComponent<Renderer>().material = matAnim;
        }
        else//si l'animation est sur une image on remet son opacite a 1
        {
            anim.color = new Color(anim.color.r, anim.color.g, anim.color.b, 1);
        }
        if(son != null)
        {
            source = gameObject.AddComponent<AudioSource>();
            source.PlayOneShot(son, 1);
        }
        InvokeRepeating("LanceAnim", 0f, boom);//On lance l'animation d'introduction avec un taux de rafraichissement préfénini
        
    }
    // Update is called once per frame
    void Update()
    {
                
    }
    
    public void LanceAnim()
    {
        //On défini la nouvelle image à afficher et on cahnge l'index pour le prochain rafraichissement
        if (!isMesh && tac <= animArray.Length - 1)
        {
            done = false;
            anim.enabled = true;
            anim.sprite = animArray[tac];
            anim.preserveAspect = true;
            tac++;
        }
        else if (isMesh && tac <= textureSequence.Length - 1)
        {
            done = false;
            meshAnim.SetActive(true);
            matAnim.mainTexture = textureSequence[tac];
            tac++;
        }
        else if (loop)//si l'animation dois looper
        {
            if(son != null)
            {
                source.PlayOneShot(son, 1);
            }
            tac = startFrame;
            nbloop -= 1;
            if(nbloop <= 0)
            {
                loop = false;
            }
        }
        else if(!loop)//si l'anim est finie on cancel l'animation pour éviter les erreurs
        {
            CancelInvoke();
            if (son != null)
            {
                Destroy(source);
            }
            if (disapearEnd)//si on dois faire disparaitre l'animation une fois qu'elle a fini
            {
                if (isMesh)
                {
                    meshAnim.SetActive(false);
                }
                else
                {
                    anim.enabled = false;
                }
            }
            done = true;
            Debug.Log(done);
            if (SceneManager.GetActiveScene().buildIndex == 0)//Si on est dans la scene d'intro on load la scene de jeu
            {
                SceneManager.LoadScene(1);
            }
            
            return;
        }
        
    }
}
