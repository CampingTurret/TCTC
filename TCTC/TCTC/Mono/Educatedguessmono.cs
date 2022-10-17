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

namespace TCTC.MonoBehaviors
{
    public class Educatedguessmono : MonoBehaviour
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

            if (timer > 10f)
            {

                a = UnityEngine.Random.Range(1, 4);
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
                        player.gameObject.AddComponent<guess5>();
                        timer = 0f;
                        break;
                    case 4:
                        player.gameObject.AddComponent<guess4>();
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
}
