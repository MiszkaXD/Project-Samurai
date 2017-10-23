using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    /*
     *  UWAGA !!!!. 
     *  Przed wszystkim musimy zwiększyć liczbę zmienntych do zapamiętania. To będzie główny cel tej klasy.
     *  To ta klasa ma zapamiętać stany, siłę, możliwości, wektory poruszania, spadania itp...
     *  Pozostałe klasy mają mieć po prostu funkcje takie na jaki cel wskazuje nazwa tej klasy.
     *  Czyli Charakter ma tobić nam za swoistą bazę danych :)
     * 
    */

    public float speed = 5f;
    public bool condition = true; // Stan w jakim jest character true(normalny)/false(ogłuszony)
    public bool onTheGround = true; // Niektóre akcje wymagają bycia na ziemi
    private bool isDead;
    public bool turn;
    public Vector3 clickPoint1;
    public Vector3 clickPoint2;

    public TurnScript turnScript;
    public TurnScript.Action action;
    public ActionInfo AII;
    public ActionMove AM;
    public Weapon W;
    public ActionPickup AP;

    public Animator animator;

    void Start()
    {
        condition = true;
        clickPoint1 = transform.position;
        clickPoint2 = transform.position;
    }
    private void Awake()
    {
        turnScript = GetComponent<TurnScript>();
        turnScript.turnTime = true;
    }

    void Update()
    {
        if (turnScript.turnTime) //Sprawdzamy czas i czy możemy coś kliknąć. To ma blokować zmianę akcji podczas wykonywania.
        {
            if (action != TurnScript.Action.Move && Input.GetMouseButtonDown(0))
            {
                clickPoint1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(clickPoint1);
            }
            checkAction(action);
            if (action == TurnScript.Action.Move && Input.GetMouseButtonDown(0))
            {
                clickPoint2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(clickPoint2);
            }
            if (Input.GetButtonDown("space"))
            {
                turnScript.doTurn(action, transform.position, clickPoint1, clickPoint2);
            }   
        }
    }


    void checkAction(TurnScript.Action action) //Nie mamy rozwijanego menu więc tymczasowo przypisałem do klawiszy
    {
        if (Input.GetButtonDown("z"))
        {
            action = TurnScript.Action.Attack;
            Debug.Log("Wybrano atak");
        }
        else if (Input.GetButtonDown("x") && onTheGround) //Blok oczywiście możemy wykonać tylko na ziemi. Tylko nie jestem pewien czy będziemy to sprawdzać w tym miejscu.
        {
            action = TurnScript.Action.Guard;
            Debug.Log("Wybrano obrone");
        }
        else if (Input.GetButtonDown("c") && onTheGround)
        {
            action = TurnScript.Action.Move;
            Debug.Log("Wybrano ruch");
        }

    }
    void checkIsDead()
    {
        if (isDead)
        {
            GetComponent<Animation>().Stop();
            GetComponent<Animation>().Play("death");
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("death"))
            {
                Destroy(this.gameObject);
                Debug.Log("Animacja śmierci skończona");
            }

        }
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }

        set
        {
            isDead = value;
        }
    }

}
