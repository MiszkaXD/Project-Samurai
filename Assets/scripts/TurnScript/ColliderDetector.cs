using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour {

    Character character;
    new Animation animation;
    void Start()
    {
        character = GetComponent<Character>();
    }

    void OnCollisonEnter(Collider col1, Collider col2)
    {
        if ((col1.gameObject.name == "sword(1)" && col2.gameObject.name == "character_body(2)") || (col1.gameObject.name == "sword(2)" && col2.gameObject.name == "character_body(1)"))
        {
            character.IsDead = true;  
        } else if (col1.gameObject.name == "sword(1)" && col2.gameObject.name == "sword(2)") //Muszę to podzielić na rozróżnianie blok i atak
        { // Jeszcze nie mam pojęcia jak będzie wyglądać multi. Dlatego nazwałem miecze (1) i (2) ~M
            GetComponent<Animation>().Stop(); //Zatrzymywanie animacji chyba tak wygląda ~M
            GetComponent<Animation>().Play("repulse"); //Po natknięniu na miecz powinna uruchomić się animacja odbicia.
        }   else {     }
        // Czegoś jeszcze brakuje na tą chwilę? ~M
    }

    
}
