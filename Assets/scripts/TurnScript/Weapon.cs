using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    /*
     *  Trzeba będzie jakoś ogarnąć system kolizji i wywoływanie go stąd.
     *  Nie wyobrażam sobie sobię sytyłacji w której ktoś biegnie i po prostu nadziewa się na miecz
     *  bez wcześniejszego ataku. ~M
     *  
     *  A i zmieniłem że zamiast każda akcja ma osobną klasę to teraz wszystko zgromadzimy tutaj sprawy dotyczące broni. ~M 
     *  
     *  
     */
    Collider collider = new Collider();
    Animator animator;

    public Weapon() { }

    public void AttackLogic()
    {
        Debug.Log("Attack start");
        collider.enabled = true;

        GetComponent<Animation>().Play("attack_1_01");

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("attack_1_01"))
        {
            collider.enabled = false;
            Debug.Log("Attack end");
        }
    }

    public void GuardLogic()
    {
        Debug.Log("Block start");
        collider.enabled = true;

        GetComponent<Animation>().Play("block");

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("block_1_01"))
        {
            collider.enabled = false;
            Debug.Log("Block end");
        }
    }

    public void ThrowLogic()
    {
        //Na tą chwilę tego nie tykać
    }

}
