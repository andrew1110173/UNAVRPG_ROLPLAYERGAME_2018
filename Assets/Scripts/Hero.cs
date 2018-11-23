using System;
using UnityEngine;
using Core.ControlSystem;

public abstract class Hero : Character
{
    [SerializeField]
    protected string lore;
    [SerializeField]
    protected Sprite icon;
    [SerializeField]
    private bool imLeader = false;
    bool beingFollowed = false;

    Transform partyLeader;
    Transform target;

    private bool canMoveAsAllie = false;

    private void Start()
    {
        partyLeader = GameManager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();
    }

    protected override void Move()
    {
        //Update partyLeader
        partyLeader = GameManager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();

        if (imLeader)
        {
            transform.Translate(Vector3.forward * ControlSystem.Axis.magnitude * speed * Time.deltaTime);

            if (ControlSystem.Axis != Vector2.zero)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(ControlSystem.Axis.x, 0f, ControlSystem.Axis.y));
            }
        }
        else
        {
            canMoveAsAllie = Vector3.Distance(transform.position, partyLeader.position) > 1.2f;
            if (canMoveAsAllie)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                //transform.LookAt(partyLeader);
                for (int i = 1; i < GameManager.instance.PartySystem.Party.Count;i++)
                {
                    if(!GameManager.instance.PartySystem.Party[i - 1].BeingFollowed)
                    {
                        GameManager.instance.PartySystem.Party[i - 1].BeingFollowed = true;
                        transform.LookAt(GameManager.instance.PartySystem.Party[i - 1].transform);
                    }
                    
                }
            }
        }
    }


    //[SerializeField]
    //Inventory inventory;

    protected override void Recover(int health)
    {
        base.Recover(health);
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }

    public bool CanMoveAsAllie
    {
        get
        {
            return canMoveAsAllie;
        }
    }

    public bool ImLeader
    {
        get
        {
            return imLeader;
        }
    }

    public bool BeingFollowed
    {
        get
        {
            return beingFollowed;
        }

        set
        {
            beingFollowed = value;
        }
    }
}