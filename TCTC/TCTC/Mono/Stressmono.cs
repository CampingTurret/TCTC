﻿using System;
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
    public class Stressmono : MonoBehaviour
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
            if (x != null)
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



        private Stressing x ;
        bool spawned;
        float timer;
        public int damage;
        public int timetildot;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 





    }


    public class Stressing : ReversibleEffect
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
            timepassed = 0;
        }

        public void Update()
        {
            float dt = Time.deltaTime;
            timepassed = timepassed + dt;

            if (timepassed > 0.1f)
            {
                damagev.Set(timepassed * damage, 0);
                this.health.DoDamage(damagev, player.transform.position, Color.red);
                timepassed = 0;
            }
        }
        private float timepassed;
        private Vector2 damagev;
        public int damage;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;

    }
}
