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
using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;

namespace TCTC.MonoBehaviors
{
    public class ECTSmono : ReversibleEffect
    {
        public override void OnStart()
        {
            SetLivesToEffect(int.MaxValue);
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();

        }



        public int ReturnECTS()
        {
            return ECTS;
        }

        public void IncreaseECTS(int delta)
        {

            ECTS = ECTS + delta;
            ClearModifiers();
            gunStatModifier.damage_mult = (float)Math.Pow(damagemod, ECTS);
            characterDataModifier.maxHealth_mult = (float)Math.Pow(healthmod, ECTS);
           // gunStatModifier.damage_mult = gun.bulletDamageMultiplier * (float)Math.Pow(damagemod, ECTS);
           // characterDataModifier.maxHealth_mult = (float)Math.Pow(healthmod, ECTS);
            ApplyModifiers();
            

            if (ECTS >= 180 && !haton)
            {
                GameObject hat = Instantiate(TCTCards.HatObject, player.transform);
                hat.transform.localPosition = new Vector3(0.25f, 0.35f, 0);
                hat.transform.localScale = new Vector3(0.25f, 0.25f, 1);
                hat.layer = 8;
                haton = true;

            }
        }
        public bool haton = false;
        public GameObject hat;
        public int ECTS;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 
        public CharacterStatModifiers CharacterStatModifiers;
        public float damagemod = 1;
        public float healthmod = 1;





    }

  
}
