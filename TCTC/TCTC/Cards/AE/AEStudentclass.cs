using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using UnityEditor;
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
            UnityEngine.Debug.Log("Initialising TCTC Class");
            while (!(AEStudentclass.card && Statics.card && Dynamics.card && Calc1p1.card && Calc1p2.card && Calc2.card && Linalg.card && DE.card && Propstat.card && Materials.card && MOM.card && Intro1.card && Intro2.card && Thermo.card && Electro.card && ADSEE1.card && ADSEE2.card && Aero1.card && Aero2.card && DAC.card && EAE.card )) yield return null;

            //int[][] x1 = new int[][] { new int[] { 1 }, new int[] { 2 } };
            //int[][] x2 = new int[][] { new int[] { 3 }, new int[] { 4 } };
            //int[][] x3 = generatereqtreeTEST(new List<int[][]> { x1, x2 });
            //UnityEngine.Debug.Log(x3);
         

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
            CardInfo[][] math3 = new CardInfo[][] { new CardInfo[] { DE.card }, new CardInfo[] { Propstat.card } };

            //materials slot (10ECTS) 
            CardInfo[][] matreq = generatereqtree(new List<CardInfo[][]> { math1, mechanics }); //new CardInfo[][] { new CardInfo[] { Statics.card, Calc1p1.card }, new CardInfo[] { Statics.card, Calc1p2.card }, new CardInfo[] { Dynamics.card, Calc1p1.card }, new CardInfo[] { Dynamics.card, Calc1p2.card } };
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
            ClassesRegistry.Register(ADSEE1.card, CardType.Branch, matreq, 1);
            ClassesRegistry.Register(ADSEE2.card, CardType.Branch, matreq, 1);
            CardInfo[][] ADSEE = new CardInfo[][] { new CardInfo[] { ADSEE1.card }, new CardInfo[] { ADSEE2.card } };
            //aerodynamics slot (10 ECTS)
            CardInfo[][] Aeroreq = generatereqtree(new List<CardInfo[][]> { phys1, mechanics, math2});
            ClassesRegistry.Register(Aero1.card, CardType.Branch, Aeroreq, 1);
            ClassesRegistry.Register(Aero2.card, CardType.Branch, Aeroreq, 1);
            CardInfo[][] Aero = new CardInfo[][] { new CardInfo[] { Aero1.card }, new CardInfo[] { Aero2.card } };

            //Flight & Orbital Mechanics and Propulsion (10ECTS)
            CardInfo[][] FOMPreq = generatereqtree(new List<CardInfo[][]> { Aero, math3 });
            ClassesRegistry.Register(PAP.card, CardType.Branch, Aeroreq, 1);
            ClassesRegistry.Register(FOAM.card, CardType.Branch, Aeroreq, 1);
            CardInfo[][] FOMP = new CardInfo[][] { new CardInfo[] { PAP.card }, new CardInfo[] { FOAM.card } };

            //project 1 slot (15 ECTS)
            ClassesRegistry.Register(DAC.card, CardType.Branch, AEStudentclass.card, 1);
            ClassesRegistry.Register(EAE.card, CardType.Branch, AEStudentclass.card, 1);
            CardInfo[][] project1 = new CardInfo[][] { new CardInfo[] { DAC.card }, new CardInfo[] { EAE.card } };
            //project 2 slot (15 ECTS)
            CardInfo[][] prj2req = generatereqtree(new List<CardInfo[][]> { mechanics, math2, project1, intro});
            ClassesRegistry.Register(Systemdes.card, CardType.Branch, prj2req, 1);
            ClassesRegistry.Register(Testandsym.card, CardType.Branch, prj2req, 1);
            CardInfo[][] project2 = new CardInfo[][] { new CardInfo[] { Systemdes.card }, new CardInfo[] { Testandsym.card } };

            //minor (15 ECTS)
            ClassesRegistry.Register(MinorAE.card, CardType.Branch, project2, 1);
            CardInfo[][] Minor = new CardInfo[][] { new CardInfo[] { MinorAE.card } };

            //flight dynamics (15ECTS)
            CardInfo[][] FDrq = generatereqtree(new List<CardInfo[][]> { mechanics, math3, intro, ADSEE, FOMP });
            ClassesRegistry.Register(SIM.card, CardType.Branch, FDrq, 1);
            ClassesRegistry.Register(FlightD.card, CardType.Branch, FDrq, 1);
            CardInfo[][] FD = new CardInfo[][] { new CardInfo[] { FlightD.card }, new CardInfo[] { SIM.card } };

            //DSE (15 ECTS)
            CardInfo[][] DSEreq = generatereqtree(new List<CardInfo[][]> { FD, project2,mat, Minor});
            ClassesRegistry.Register(DSE.card, CardType.Branch, DSEreq, 1);

            //standalone cards
            // -gain subject cards
            //ClassesRegistry.Register(ResitAE.card, CardType.Card, AEStudentclass.card);
            //ClassesRegistry.Register(BonusPointsAE.card, CardType.Card, AEStudentclass.card);
            //TA buffs per ECTS
            //Student teams buffs per ECTS
            UnityEngine.Debug.Log("Finished Initialising TCTC Class");
        }

        public CardInfo[][] generatereqtree(List<CardInfo[][]> Mainlists)
        {
           
            CardInfo[][] finallist = Mainlists[0];
            for (int i = 1; i < Mainlists.Count; i++)
            {
                finallist = combination2lists(finallist, Mainlists[i]);
               
            }
            return finallist;
        }
        public int[][] generatereqtreeTEST(List<int[][]> Mainlists)
        {

            int[][] finallist = Mainlists[0];
            for (int i = 1; i < Mainlists.Count; i++)
            {
               
                finallist = combination2listsTEST(finallist, Mainlists[i]);

            }
            UnityEngine.Debug.Log("TESTING");
            UnityEngine.Debug.Log("0-0 in array:" + finallist[0][0]);
            UnityEngine.Debug.Log("1-0 in array:" + finallist[1][0]);
            UnityEngine.Debug.Log("0-1 in array:" + finallist[0][1]);
            UnityEngine.Debug.Log("1-1 in array:" + finallist[1][1]);
            UnityEngine.Debug.Log("TEST FINISHED");
            return finallist;
        }

        public CardInfo[][] combination2lists(CardInfo[][] List1,CardInfo[][] List2)
        {
            
            CardInfo[][] List3 = new CardInfo[][] {} ;

            for (int i = 0; i < List1.Length; i++)
            {
                
                for (int j = 0; j < List2.Length; j++)
                {

                    CardInfo[] temparr = new CardInfo[] { };
                    var temp = List1[i].ToList();

                    temp.AddRange(List2[j]);
                    temparr = temp.ToArray();
                    List3 = List3.AddToArray(temparr);
                }
            }

            return List3;
        }
        public int[][] combination2listsTEST(int[][] List1, int[][] List2)
        {
            int[][] List3 = new int[][] { };

            for (int i = 0; i < List1.Length; i++)
            {
                for (int j = 0; j < List2.Length; j++)
                {
                    int[] temparr = new int[] {};
                    var temp = List1[i].ToList();
                    
                    temp.AddRange(List2[j]);
                    temparr = temp.ToArray();        
                    List3 = List3.AddToArray(temparr);                                 
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
            ClassesRegistry.Get(ADSEE1.card).Blacklist(ADSEE2.card);
            ClassesRegistry.Get(ADSEE2.card).Blacklist(ADSEE1.card);
            //aerodynamics
            ClassesRegistry.Get(Aero1.card).Blacklist(Aero2.card);
            ClassesRegistry.Get(Aero2.card).Blacklist(Aero1.card);
            //Flight & Orbital Mechanics and Propulsion
            ClassesRegistry.Get(PAP.card).Blacklist(FOAM.card);
            ClassesRegistry.Get(FOAM.card).Blacklist(PAP.card);
            //project1
            ClassesRegistry.Get(DAC.card).Blacklist(EAE.card);
            ClassesRegistry.Get(EAE.card).Blacklist(DAC.card);
            //project 2 slot (15 ECTS)
            ClassesRegistry.Get(Systemdes.card).Blacklist(Testandsym.card);
            ClassesRegistry.Get(Testandsym.card).Blacklist(Systemdes.card);

            //minor (15 ECTS)
            //-single card-
            
            //flight dynamics (15ECTS)
            ClassesRegistry.Get(SIM.card).Blacklist(FlightD.card);
            ClassesRegistry.Get(FlightD.card).Blacklist(SIM.card);

            //DSE (15 ECTS)
            //-single card-

            
            yield break;
        }
    }

}
