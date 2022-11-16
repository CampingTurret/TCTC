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

namespace TCTC.MonoBehaviors
{
    public class Blindguessmono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
            timer = 0f;
            
        }

        private void Update()
        {

            dt = Time.deltaTime;
            timer = timer + dt;

            if (timer > 5f)
            {

                a = UnityEngine.Random.Range(0.6f, 6.4f);

                
                switch (Math.Floor(Math.Round(a)))
                {
                    case 1:
                        player.gameObject.AddComponent<guess1>();
                        timer = 0f;
                        break;
                    case 2:
                        player.gameObject.AddComponent<guess2>();
                        timer = 0f;
                        break;
                    case 3:
                        player.gameObject.AddComponent<guess3>();
                        timer = 0f;
                        break;
                    case 4:
                        player.gameObject.AddComponent<guess4>();
                        timer = 0f;
                        break;
                    case 5:
                        player.gameObject.AddComponent<guess5>();
                        timer = 0f;

                        break;
                    case 6:
                        player.gameObject.AddComponent<guess6>();
                        timer = 0f;
                        break;

                }

                
            }


        }





        private float a;
        private float dt;
        private float timer;

        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 





    }

    public class guess1 : ReversibleEffect
    {

        public override void OnStart()
        {
            base.gunStatModifier.bulletDamageMultiplier_mult = 4f;
            timer = 5f;
            UIhandelermono UI = player.GetComponent<UIhandelermono>();
            UI.Addsection("DAMAGE+", new Color(0, 1, 0, 1), timer);


           
        }

        public void Update()
        {

            timer = timer - Time.deltaTime;
            if (timer < 0f)
            {
                Destroy();
            }


        }
        
        float timer;
    }
    public class guess2 : ReversibleEffect
    {
        public override void OnStart()
        {
            base.gunStatModifier.bulletDamageMultiplier_mult = 0.3f;
            timer = 5f;
            UIhandelermono UI = player.GetComponent<UIhandelermono>();
            UI.Addsection("DAMAGE-", new Color(1,0, 0, 1), timer);
        }

        public void Update()
        {

            timer = timer - Time.deltaTime;
            if (timer < 0f)
            {
                Destroy();
            }


        }

        float timer;
    }
    public class guess3 : ReversibleEffect
    {
        public override void OnStart()
        {
            base.gunAmmoStatModifier.maxAmmo_add = -10;
            timer = 5f;
            UIhandelermono UI = player.GetComponent<UIhandelermono>();
            UI.Addsection("AMMO-", new Color(1,0,0,1),timer);
            
        }

        public void Update()
        {

            timer = timer - Time.deltaTime;
            if (timer < 0f)
            {
                Destroy();
            }


        }

        float timer;
    }
    public class guess4 : ReversibleEffect
    {
        public override void OnStart()
        {
            base.gunAmmoStatModifier.maxAmmo_add = +10;
            timer = 5f;
            UIhandelermono UI = player.GetComponent<UIhandelermono>();
            UI.Addsection("AMMO+", new Color(0, 1, 0, 1), timer);

        }

        public void Update()
        {

            timer = timer - Time.deltaTime;
            if (timer < 0f)
            {
                Destroy();
            }


        }

        float timer;
    }

    public class guess5 : ReversibleEffect
    {
        public override void OnStart()
        {
            base.gunStatModifier.bursts_add = 10;
            timer = 5f;
            UIhandelermono UI = player.GetComponent<UIhandelermono>();
            UI.Addsection("BULLET+", new Color(0, 1, 0, 1), timer);

        }

        public void Update()
        {

            timer = timer - Time.deltaTime;
            if (timer <  0f)
            {
                Destroy();
            }


        }

        float timer;
    }
    public class guess6 : ReversibleEffect
    {
        public override void OnStart()
        {
            base.gunStatModifier.bursts_add = -6;
            timer = 5f;
            UIhandelermono UI = player.GetComponent<UIhandelermono>();
            UI.Addsection("BULLET-", new Color(1,0, 0, 1), timer);
        }

        public void Update()
        {

            timer = timer - Time.deltaTime;
            if (timer < 0f)
            {
                Destroy();
            }
            timepassed = timepassed + Time.deltaTime;


        }
        
        float timer;
        float timepassed = 0;
       
    }
}
