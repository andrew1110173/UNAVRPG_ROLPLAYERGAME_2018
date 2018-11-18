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

    Transform partyLeader;

    private bool canMoveAsAllie = false;

    private void Start()
    {
        partyLeader = GameManager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();
    }

    protected override void Move()
    {
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
                transform.LookAt(partyLeader);
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
}

