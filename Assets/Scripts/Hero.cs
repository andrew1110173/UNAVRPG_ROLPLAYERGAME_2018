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
    Transform other;

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
                transform.LookAt(partyLeader);
                float dist = Vector3.Distance(transform.position, partyLeader.position);
                //Debug.Log("Distance to other: " + dist);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("He chocado :C");
        var left = Vector3.Distance(transform.position, collision.transform.position) > 1.2f;
        var right = Vector3.Distance(transform.position, collision.transform.position) > 1.2f;
        if(left&&right)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.LookAt(partyLeader);
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