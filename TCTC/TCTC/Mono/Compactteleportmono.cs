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
    public class Compactteleportermono : HitSurfaceEffect
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
        }

        public override void Hit(Vector2 position, Vector2 normal, Vector2 velocity)
        {
            player.transform.position = position;
            
            
        }

        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun; 





    }
}
