using System;
using UnityEngine;

public abstract class Archer : Hero
{
    protected int arrows;

    protected abstract void Spell();
    protected abstract void BasicAttack();
}

