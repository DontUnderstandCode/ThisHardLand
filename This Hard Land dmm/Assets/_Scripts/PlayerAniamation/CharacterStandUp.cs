using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStandUp : MonoBehaviour   //THis script is purely for the purposes of starting the character standing up animationwhen the scene opens
{
    GameObject bubbleParent;
    Animator bubbleAnim;

    GameObject charModel;
    Animator charAnim; 

    // Start is called before the first frame update
    void Start()
    {
        bubbleParent = GameObject.Find("SpeechBubbleParent");
        bubbleAnim = bubbleParent.GetComponent<Animator>();

        charModel = GameObject.Find("Lost John");
        charAnim = charModel.GetComponent<Animator>();
        
        charAnim.SetTrigger("triggerStand");   //This sets the animations trigger that makes the character stand up. This animation disables left/right movement through the use of Events

        bubbleAnim.SetTrigger("ouchAD");     //This is the first speech bubble display
    }


}
