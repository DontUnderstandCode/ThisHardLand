using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanStalkInteraction : MonoBehaviour
{
    Animator beanAnim;

    GameObject waterObj;
    ParticleSystem waterDrop;

    Collider beanCollider;

    GameObject bubbleParent;
    Animator bubbleAnim;

    // Start is called before the first frame update
    void Start()
    {
        bubbleParent = GameObject.Find("SpeechBubbleParent");
        bubbleAnim = bubbleParent.GetComponent<Animator>();

        beanAnim = GetComponent<Animator>();

        waterObj = GameObject.Find("WaterDrop");
        waterDrop = waterObj.GetComponent<ParticleSystem>();

        beanCollider = GetComponent< Collider > ();
    }

    private void OnCollisionEnter(Collision beanColl)
    {
        if(beanColl.gameObject.name == "Player")
        {
            StartBeanInteraction();
        }
    }

    void StartBeanInteraction()
    {
        beanAnim.SetTrigger("beanGrow");
        waterDrop.Play();
    }


    void MentionPlant()
    {
        bubbleAnim.SetTrigger("waterPlant");
        beanCollider.enabled = false;
    }
}
