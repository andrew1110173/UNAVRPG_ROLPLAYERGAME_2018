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

            StartFollow();
        }

        public void StartFollow()
        {
            for (int index = 0; index < party.Count; index++)
            {
                //vas a seguir a alguien
                if (party[index] != leader)
                {
                    //sigo a quien este delante de mi osea el index que va menos 1, porque es una lista.
                    party[index].Target = party[index - 1].transform;
                }
            }
        }

        public void ChangeHero()
        {

            List<Hero> currentHeroes = new List<Hero>();
            foreach(Hero h in party)
            {
                currentHeroes.Add(h);
            }
            party.Clear();

            foreach(Hero h in currentHeroes)
            {
                if(h != leader)
                {
                    party.Add(h);
                }
            }

            party.Add(leader);

            leader = party[0];

            StartFollow();

        }
    }
}
