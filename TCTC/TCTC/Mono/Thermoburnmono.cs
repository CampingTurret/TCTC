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
    public class Thermoburnmono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = data.weaponHandler.gun;
            this.health = base.GetComponent<HealthHandler>();
            damagecolor = Color.red;
            timepassed = 0;
            timeinstant = 0;


        }

        private void Update()
        {
            dt = Time.deltaTime;
            timepassed = timepassed + dt;
            timeinstant = timeinstant + dt;

            if (timepassed > 0.1f)
            {
                damage.Set( timepassed * 5, 0);
                this.health.DoDamage(damage, player.transform.position, damagecolor);
                timepassed = 0;
            }

            if (timeinstant > 3)
            {
                Destroy(this);
            }


        }




        private float timeinstant;
        private Vector2 damage;
        private float secondstodeath;
        private float dt;
        Color damagecolor;
        private float timepassed;
        private HealthHandler health;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 





    }

    public class Thermomono : HitEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer = null)
        {
            if (damagedPlayer != null)
            {

                damagedPlayer.gameObject.AddComponent<Thermoburnmono>();

            }
            
        }
    }
}
