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
    public class ECTSmono : MonoBehaviour
    {
        private void Awake()
        {
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





    }
}
