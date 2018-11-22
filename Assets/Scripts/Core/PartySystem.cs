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

        int SelectHero = 0;
        int partyLenght = 0;

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

                foreach (Hero hero in heroes)
                {
                    party.Add(hero);
                    partyLenght++;
                }

            leader = heroes[SelectHero];
        }

        public void ChangeHero()
        {
            Hero[] heroes = GameObject.FindObjectsOfType<Hero>();

            if (SelectHero < (partyLenght-1))
                SelectHero++;
            else if (SelectHero == (partyLenght - 1))
                SelectHero = 0;

            leader = heroes[SelectHero];
        }
    }
}
