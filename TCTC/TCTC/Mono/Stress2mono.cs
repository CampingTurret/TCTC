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
            this.gun = data.weaponHandler.gun;
        }

        public void Update()
        {

            if(spawned == false)
            {
                if(timer > timetildot)
                {
                    Startdamage();
                }
                timer = timer + Time.deltaTime;
            }

        }

        public void Starttimer()
        {
            data.health = data.maxHealth;
            spawned = false;
            timer = 0;
            if(x!= null)
            {
                Destroy(x);
            }
        }

        public void Startdamage()
        {

            x = player.gameObject.AddComponent<Stressing>();
            x.damage = damage;
            x.health = base.GetComponent<HealthHandler>();
            spawned = true;
            timer = 0;

        }



        private Stressing x;
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
