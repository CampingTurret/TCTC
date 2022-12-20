using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using UnboundLib.Utils;
using System.Collections.ObjectModel;
using ModdingUtils.RoundsEffects;
using ModdingUtils.MonoBehaviours;
using System.Threading;

namespace TCTC.MonoBehaviors
{
    public class Stress2mono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
        }

        public void Update()
        {

            if(spawned == false)
            {
                if(timer > timetildot)
                {
                    Startdamage();
                }
            }

        }

        public void Starttimer()
        {
            spawned = false;
            timer = 0;
        }

        public void Startdamage()
        {

            Stressing x = player.gameObject.AddComponent<Stressing>();
            x.damage = damage;
            spawned = true;

        }




        bool spawned;
        float timer;
        public int damage;
        public int timetildot;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 





    }


    
}
