using System;
using System.Collections.Generic;
using UnityEngine;
namespace Core.PartySystem
{
    [Serializable]
    public class PartySystem
    {
        [SerializeField]
        List<Hero> party = new List<Hero>();

        [SerializeField]
        Hero leader;

        public List<Hero> Party
        {
            get
            {
                return party;
            }
        }

        public Hero Leader
        {
            get
            {
                return leader;
            }
        }

        public void StartParty()
        {
            Hero[] heroes = GameObject.FindObjectsOfType<Hero>();
            foreach(Hero hero in heroes)
            {
                party.Add(hero);
            }

            leader = heroes[0];
        }
    }
}
