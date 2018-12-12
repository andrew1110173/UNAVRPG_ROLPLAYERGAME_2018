using System;
using UnityEngine;
using Core.ControlSystem;
using Core.MemorySystem;
using System.Collections.Generic;

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
        gd = GameManager.instance.CurrentGameData;

        imLeader = this == partyLeader.GetComponent<Hero>();
        //Si soy lider, carga la posición del jugador
        if (imLeader)
        {
            transform.position = gd.PlayerPosition;
            transform.GetChild(0).gameObject.SetActive(true); //Si soy el lider activa la virtual camera
        }
        else { transform.GetChild(0).gameObject.SetActive(false); }
    }

    protected override void Move()
    {
        //Update partyLeader
        partyLeader = GameManager.instance.PartySystem.Leader.transform;
        imLeader = this == partyLeader.GetComponent<Hero>();

        if (imLeader)
        {
            transform.GetChild(0).gameObject.SetActive(true); //Activa el virtual camera para este objeto
            transform.Translate(Vector3.forward * ControlSystem.Axis.magnitude * speed * Time.deltaTime);

            if (ControlSystem.Axis != Vector2.zero)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(ControlSystem.Axis.x, 0f, ControlSystem.Axis.y));
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false); //Desactiva el virtual camera para este objetivo
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

            var data = new Dictionary<string, string>();
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