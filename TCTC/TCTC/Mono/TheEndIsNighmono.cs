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
    public class TheEndIsNighmono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
            this.health = base.GetComponent<HealthHandler>();
            secondstodeath = 20f;
            damagecolor = Color.red;
            
        }

        private void Update()
        {
           dt = Time.deltaTime;
           damage.Set(data.maxHealth*dt*1/secondstodeath,0);

           this.health.DoDamage(damage, player.transform.position,damagecolor);
           

        }





        private Vector2 damage;
        private float secondstodeath;
        private float dt;
        Color damagecolor;
        private HealthHandler health;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 





    }
}
