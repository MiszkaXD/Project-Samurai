using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TurnScript : MonoBehaviour
{
    public enum Action // Teoretyczne enum powinien być poza klasą ale wsadziłem go tutaj by inne klasy też mogły go wykorzystać.
    { // Jak wszystkie klasy będą bazować na tym samym enumie to będzie łatwiej to ogarnąć.
        Info,
        Move,
        Guard,
        Attack,
        Throw,
        Pickup,
        Processing
    }

    public ActionInfo AII;
    public ActionMove AM;
    public Weapon W;
    public ActionPickup AP;

    public bool turnTime; //True - kiedy można wykonać ruch, False - wykonywanie akcji

    void Awake()
    {
        AM = GetComponent<ActionMove>();
        W = GetComponent<Weapon>();
        Debug.Assert(AM != null);
        Debug.Assert(W != null);
    }

    public void doTurn(Action action, Vector3 position, Vector3 clickpoint1, Vector3 clickPoint2)
    {
        turnTime = false; //Przed odtworzeniem ustawiwamy blokadę przycisków.
        AM.MoveLogic(clickpoint1, position); //Na początku zawsze musi być wykonany jakiś ruch.
        switch (action)
        {
            case Action.Info:
                //Tool Tips, Pause, ext. Nie będziemy tego na tą chwilę rozwijać. Może to kiedyś wykorzystamy choć niesądze.
                //   AII.InfoLogic();
                break;
            case Action.Attack:
                //Damage step, assigning attackers and taking actions.
                W.AttackLogic();
                break;
            case Action.Guard:
                //Guard from attack and advantages.
                W.GuardLogic();
                break;
            case Action.Move:
                //Move logic and anything pertaining to movement actions with characters.
                AM.MoveLogic(clickPoint2, clickpoint1);
                break;
            case Action.Throw:
                //Weapon throw, some weapon can't be throw
                W.ThrowLogic();
                break;
            case Action.Pickup:
                //Interactions with Dropped weapons
                //AP.PickupLogic();
                break;
            default:
                break;
        }
        turnTime = true; //Po odtworzeniu odblokujemy przyciski
    }

    public bool TurnTime
    {
        get
        {
            return turnTime;
        }

        set
        {
            turnTime = value;
        }
    }
}