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

namespace TCTC.MonoBehaviors
{
    public class Guessmono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
            timer = 0;
            previusbuff = 0;
        }

        private void Update()
        {

            dt = Time.deltaTime;
            timer = timer + dt;

            if (timer > 10f)
            {
                switch(previusbuff)
                {
                    case 0:
                        break;
                    case 1:
                        gun.damage = gun.damage * 2f;
                        
                        break;
                    case 2:
                        gun.damage = gun.damage * 0.5f;
                        break;
                    case 3:
                        gun.ammo = gun.ammo + 2;
                        break;
                    case 4:
                        gun.ammo = gun.ammo - 2;
                        break;
                    case 5:
                        block.autoBlock = true;
                        break;
                    case 6:
                        block.additionalBlocks = block.additionalBlocks-1;
                        break;

                }
                a = UnityEngine.Random.Range(1, 6);
                switch (Math.Floor(Math.Round(a)))
                {
                    case 1:
                        gun.damage = 0.5f * gun.damage;
                        previusbuff = 1;
                        break;
                    case 2:
                        gun.damage = 2f * gun.damage;
                        previusbuff = 2;
                        break;
                    case 3:
                        gun.ammo = gun.ammo - 2;
                        previusbuff = 3;
                        break;
                    case 4:
                        gun.ammo = gun.ammo + 2;
                        previusbuff = 4;
                        break;
                    case 5:
                        block.autoBlock = false;
                        previusbuff = 5;
                        break;
                    case 6:
                        block.additionalBlocks = block.additionalBlocks+1;
                        previusbuff = 6;
                        break;

                }

                timer = 0f;
            }


        }





        private float a;
        private float dt;
        private float timer;
        private float previusbuff;

        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 





    }


    public class Effect1: ReversibleEffect
    {

    }
}
