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
using System.Threading;

namespace TCTC.MonoBehaviors
{
    public class RUDmono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = data.weaponHandler.gun;
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
            timer = 0.5f;
        }
        // set block trigger 
        // then explode player on block

        public void Update()
        {
            if (TUD == true)
            {

                if (timer < 0f)
                {


                    //reseting parameters
                    timer = 0.5f;
                    TUD = false;

                    //Exposion damage setup:
                    GameObject detonator = new GameObject("boom");
                    
                    SpawnedAttack x = detonator.AddComponent<SpawnedAttack>();
                    x.spawner = player;
                    x.attackLevel = 0;
                    x.attackID = 0;
                    Explosion q = detonator.AddComponent<Explosion>();
                    q.damage = data.maxHealth * 2 + 100;
                    q.objectForceMultiplier = 4 * data.maxHealth/100;
                    q.range = 10f * data.maxHealth/100;
                    detonator.AddComponent<RUDcleanup>();

                    //Explosion visual effect setup:
                    GameObject explosion = explosionCard.GetComponent<Gun>().objectsToSpawn[0].effect;

                    //Boom
                    Instantiate(explosion, player.transform.position , player.transform.rotation);
                    Instantiate(detonator, player.transform.position , player.transform.rotation);
                    q.Explode();

                    health.TakeDamage(new Vector2(data.maxHealth * 2 + 100, data.maxHealth * 2 + 100), player.transform.position,ignoreBlock: true);


                        
                    
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

    public class RUDcleanup : MonoBehaviour 
    {


        public void Update()
        {
            if(timer < 0)
            {
                Destroy(this.gameObject);
            }
            timer = timer - Time.deltaTime;
        }

        float timer = 20f;
    
    }

    

}
