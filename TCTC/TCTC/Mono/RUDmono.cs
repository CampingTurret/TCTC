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
using static System.Net.Mime.MediaTypeNames;
using Photon.Pun.UtilityScripts;
using Photon;

namespace TCTC.MonoBehaviors
{
    public class RUDmono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
            this.health = base.GetComponent<HealthHandler>();
            timer = 0.5f;
            damagecolor = Color.red;
            TUD = false;
            Block componentInParent = base.GetComponentInParent<Block>();
            componentInParent.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(componentInParent.BlockAction, new Action<BlockTrigger.BlockTriggerType>(this.Block));

           
            
            
            
            
        }


        public void Block(BlockTrigger.BlockTriggerType trigger)
        {
            
            TUD = true;
        }
        // set block trigger 
        // then explode player on block

        public void Update()
        {
            if (TUD == true)
            {

                if (timer < 0f)
                {



                    timer = 0.5f;
                    TUD = false;

                    //damage.Set(data.maxHealth * 99f, 0);
                    //this.health.DoDamage(damage, player.transform.position, damagecolor);
                    GameObject detonator = new GameObject("boom");

                    SpawnedAttack x = detonator.AddComponent<SpawnedAttack>();
                    x.spawner = player;
                    x.attackLevel = 0;
                    x.attackID = 0;
                    Explosion q = detonator.AddComponent<Explosion>();
                    q.damage = data.maxHealth * 2 + 100;
                    q.objectForceMultiplier = 4 * data.maxHealth/100;
                    q.range = 10f * data.maxHealth/100;


                    GameObject explosion = explosionCard.GetComponent<Gun>().objectsToSpawn[0].effect;
                    Instantiate(explosion, player.transform.position , player.transform.rotation);
                    Instantiate(detonator, player.transform.position , player.transform.rotation);
                    q.Explode();
                    



                        
                    
                }


                timer = timer - Time.deltaTime;
                
            }
        }


        
        private bool TUD;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;
        private float timer;
        private float timer2;
        private Vector2 damage;
        Color damagecolor;
        private HealthHandler health;
        private readonly GameObject explosionCard = (GameObject)Resources.Load("0 cards/Explosive bullet");

    }
}
