using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using TCTC.MonoBehaviors;
using TCTC.Cards;
using ClassesManagerReborn;
using System.Collections;
using System.ComponentModel;
using TCTC;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using HarmonyLib;

namespace TCTC.Cards.AE
{
    class AEclass : ClassHandler
    {
        internal static string name = "AE";
        public override IEnumerator Init()
        {
            while (!(AEStudentclass.card && Statics.card && Dynamics.card && Calc1p1.card && Calc1p2.card && Calc2.card && Linalg.card)) yield return null;
            
            //base class
            ClassesRegistry.Register(AEStudentclass.card, CardType.Entry);

            //mechanics slot (10 ECTS) 
            ClassesRegistry.Register(Statics.card, CardType.Branch, AEStudentclass.card,1);
            ClassesRegistry.Register(Dynamics.card, CardType.Branch, AEStudentclass.card,1);
            CardInfo[][] mechanics = new CardInfo[][] { new CardInfo[] { Statics.card }, new CardInfo[] { Dynamics.card } };
            //math1 slot (10ECTS) 
            ClassesRegistry.Register(Calc1p1.card, CardType.Branch, AEStudentclass.card, 1);
            ClassesRegistry.Register(Calc1p2.card, CardType.Branch, AEStudentclass.card, 1);
            CardInfo[][] math1 = new CardInfo[][] { new CardInfo[] { Calc1p1.card }, new CardInfo[] { Calc1p2.card } };
            //math2 slot (10ECTS) 
            ClassesRegistry.Register(Calc2.card, CardType.Branch, math1,1);
            ClassesRegistry.Register(Linalg.card, CardType.Branch, math1,1);
            CardInfo[][] math2 = new CardInfo[][] { new CardInfo[] { Calc2.card }, new CardInfo[] { Linalg.card } };

            //math 3 slot (10 ECTS) 
            ClassesRegistry.Register(DE.card, CardType.Branch, math2, 1);
            ClassesRegistry.Register(Propstat.card, CardType.Branch, math2, 1);
            CardInfo[][] math3 = new CardInfo[][] { new CardInfo[] { Calc2.card }, new CardInfo[] { Linalg.card } };

            //materials slot (10ECTS) 
            CardInfo[][] matreq = generatereqtree(new List<CardInfo[][]> {math1, mechanics});
            ClassesRegistry.Register(Materials.card, CardType.Branch, matreq, 1);
            ClassesRegistry.Register(MOM.card, CardType.Branch, matreq, 1);
            CardInfo[][] mat = new CardInfo[][] { new CardInfo[] { MOM.card }, new CardInfo[] { Materials.card } };

            //Intro slot (10ECTS)
            ClassesRegistry.Register(Intro1.card, CardType.Branch, AEStudentclass.card, 1);
            ClassesRegistry.Register(Intro2.card, CardType.Branch, AEStudentclass.card, 1);
            CardInfo[][] intro = new CardInfo[][] { new CardInfo[] { Intro1.card }, new CardInfo[] { Intro2.card } };

            //physics 1 slot (10ECTS)
            ClassesRegistry.Register(Thermo.card, CardType.Branch, math1, 1);
            ClassesRegistry.Register(Electro.card, CardType.Branch, math1, 1);
            CardInfo[][] phys1 = new CardInfo[][] { new CardInfo[] { Thermo.card }, new CardInfo[] { Electro.card } };

            //ADSEE (15ECTS)

            //aerodynamics slot (10 ECTS)

            //Flight & Orbital Mechanics and Propulsion (10ECTS)

            //project 1 slot (15 ECTS)

            //project 2 slot (15 ECTS)

            //minor (15 ECTS)

            //flight dynamics (15ECTS)

            //DSE (15 ECTS)



            //standalone cards
            //resit? (ECTS outside of slots??)
            //Extra credit? (ECTS outside of slots??)
            //TA buffs per ECTS
            //Student teams buffs per ECTS

        }

        public CardInfo[][] generatereqtree(List<CardInfo[][]> Mainlists)
        {
            CardInfo[][]  finallist = new CardInfo[][] {};
            for (int i = 0; i < Mainlists.Count; i++)
            {
                finallist = combination2lists(finallist, Mainlists[i]);

            }
            return finallist;
        }

        public CardInfo[][] combination2lists(CardInfo[][] List1,CardInfo[][] List2)
        {
            CardInfo[][] List3 = new CardInfo[][] {} ;

            for (int i = 0; i < List1.Length; i++)
            {

                for (int j = 0; j < List2.Length; j++)
                {
                    CardInfo[] temp = List1[i];
                    temp.AddRangeToArray(List2[j]);
                    List3.AddToArray(temp);
                }
            }

            return List3;
        }

        public override IEnumerator PostInit()
        {
            //mechanics
            ClassesRegistry.Get(Dynamics.card).Blacklist(Statics.card);
            ClassesRegistry.Get(Statics.card).Blacklist(Dynamics.card);
            //math1
            ClassesRegistry.Get(Calc1p1.card).Blacklist(Calc1p2.card);
            ClassesRegistry.Get(Calc1p2.card).Blacklist(Calc1p1.card);
            //math2
            ClassesRegistry.Get(Calc2.card).Blacklist(Linalg.card);
            ClassesRegistry.Get(Linalg.card).Blacklist(Calc2.card);
            //math3
            ClassesRegistry.Get(DE.card).Blacklist(Propstat.card);
            ClassesRegistry.Get(Propstat.card).Blacklist(DE.card);
            //materials
            ClassesRegistry.Get(MOM.card).Blacklist(Materials.card);
            ClassesRegistry.Get(Materials.card).Blacklist(MOM.card);
            //intro
            ClassesRegistry.Get(Intro1.card).Blacklist(Intro2.card);
            ClassesRegistry.Get(Intro2.card).Blacklist(Intro1.card);
            //physics
            ClassesRegistry.Get(Thermo.card).Blacklist(Electro.card);
            ClassesRegistry.Get(Electro.card).Blacklist(Thermo.card);
            //ADSEE

            yield break;
        }
    }

}
