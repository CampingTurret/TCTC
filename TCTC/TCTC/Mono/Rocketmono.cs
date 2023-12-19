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
using TurretsPhysicsPatch;

namespace TCTC.MonoBehaviors
{
    public class Rocketmono : MonoBehaviour
    {
        public MoveTransform move;

        public Vector3 accel;

        private void Start()
        {
            move = this.GetComponentInParent<MoveTransform>();
            accel = move.velocity.normalized * 50;
            move.add_constant_acceleration(accel, 0.1f);
        }
    }
}
