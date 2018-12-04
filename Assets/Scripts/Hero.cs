using System;
using UnityEngine;
using Core.ControlSystem;
using Core.MemorySystem;

public abstract class Hero : Character
{
    [SerializeField]
    protected string lore;
    [SerializeField]
    protected Sprite icon;
    /*
    [SerializeField]
    private new bool imLeader = false;
    */

    Transform partyLeader;
    [SerializeField]
    Transform target;

    private bool canMoveAsAllie = false;

    GameData gd;

    private void Start()
    {
        partyLeader = GameManager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();
        gd = MemorySystem.Load;
        if(imLeader)
        transform.position = gd.PlayerPosition;
        Debug.Log(gd.PlayerName);
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
            canMoveAsAllie = Vector3.Distance(transform.position, target.position) > 1.2f;
            if (canMoveAsAllie)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                transform.LookAt(target);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name =="CheckPoint" && imLeader)
        {
            Debug.Log("Partida Guardada");

            var data = new System.Collections.Generic.Dictionary<string, string>();
            data["PosX"] = transform.position.x.ToString();
            data["PosZ"] = transform.position.z.ToString();
            data["Hero"] = transform.name;
            MemorySystem.Save(new GameData(data));
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

    public new bool ImLeader
    {
        get
        {
            return imLeader;
        }
    }

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    /*public bool BeingFollowed
    {
        get
        {
            return beingFollowed;
        }

        set
        {
            beingFollowed = value;
        }
    }*/
}