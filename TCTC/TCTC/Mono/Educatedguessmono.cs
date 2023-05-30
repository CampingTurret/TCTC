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
using UnboundLib.Networking;

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
        [UnboundRPC]
        public static void Spawn_Effect(float range, int playerID)
        {

            Player player = null;
            GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < playerlist.Length; i++)
            {
                GameObject Object_with_tag = playerlist[i];
                if (Object_with_tag.GetComponent<Player>().playerID == playerID)
                {
                    player = Object_with_tag.GetComponent<Player>();
                }

            }
            switch (Math.Floor(Math.Round(range)))
            {
                case 1:
                    player.gameObject.AddComponent<guess1>();
                    break;
                case 2:
                    player.gameObject.AddComponent<guess2>();
                    break;
                case 3:
                    player.gameObject.AddComponent<guess5>();
                    break;
                case 4:
                    player.gameObject.AddComponent<guess4>();
                    break;
            }
        }
        private void Update()
        {

            dt = Time.deltaTime;
            timer = timer + dt;

            if (timer > 5f)
            {
                if (player.data.view.IsMine)
                {
                    a = UnityEngine.Random.Range(0.6f, 4.4f);
                    NetworkingManager.RPC(typeof(Educatedguessmono), nameof(Spawn_Effect), new object[]
                    {
                        a,
                        player.playerID
                    });
                }
                timer = 0f;



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
