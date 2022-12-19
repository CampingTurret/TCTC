using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using TCTC.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using Unity;
using UnityEngine;
using TCTC.MonoBehaviors;
using TCTC.Cards.AE;

namespace TCTC
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.classes.manager.reborn", BepInDependency.DependencyFlags.HardDependency)]

    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class TCTCards : BaseUnityPlugin
    {
        public static TCTCards instance { get; private set; }
        private const string ModId = "TheCampingTurret.Rounds.TCTC.cards";
        private const string ModName = "TCTCards";
        public const string Version = "2.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "TCTC";

        private static readonly AssetBundle Bundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("tctc", typeof(TCTCards).Assembly);

        //card art
        public static GameObject WaffleArt = Bundle.LoadAsset<GameObject>("C_Waffle");
        public static GameObject CoffeeArt = Bundle.LoadAsset<GameObject>("C_Coffee");
        public static GameObject BlindGuessArt = Bundle.LoadAsset<GameObject>("C_BlindGuess");
        public static GameObject EducatedGuessArt = Bundle.LoadAsset<GameObject>("C_EducatedGuess");
        public static GameObject NoGuessWorkArt = Bundle.LoadAsset<GameObject>("C_NoGuessWork");
        public static GameObject Class2Art = Bundle.LoadAsset<GameObject>("C_Class2");
        public static GameObject AssumptionArt = Bundle.LoadAsset<GameObject>("C_Assumption");

        //AE art
        public static GameObject StaticsArt = Bundle.LoadAsset<GameObject>("C_Statics");
        public static GameObject DyanmicsArt = Bundle.LoadAsset<GameObject>("C_Dynamics");
        public static GameObject DEArt = Bundle.LoadAsset<GameObject>("C_DE");


        //ui objects
        public static GameObject signal = Bundle.LoadAsset<GameObject>("TCTCsignal");
        public static GameObject signalcanvas = Bundle.LoadAsset<GameObject>("TCTCCanvas");
        

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            CustomCard.BuildCard<DesignSpace>();       //
            CustomCard.BuildCard<Streamlined>();       //
            CustomCard.BuildCard<Waffle>();            //art
            CustomCard.BuildCard<Coffee>();            //art
            CustomCard.BuildCard<Compactteleporter>(); //
            CustomCard.BuildCard<Assumption>();        //art
            CustomCard.BuildCard<TheEndIsNigh>();      //
            CustomCard.BuildCard<Blindguess>();        //art
            CustomCard.BuildCard<Quadroacceleration>();//
            CustomCard.BuildCard<Educatedguess>((card) => Educatedguess.card = card);      //art
            CustomCard.BuildCard<Noguesswork>();       //art
            CustomCard.BuildCard<Class2estimation>((card) => Class2estimation.card = card);//art
            CustomCard.BuildCard<RUD>();               //


            //AE class
            CustomCard.BuildCard<AEStudentclass>((card) => AEStudentclass.card = card);    //
            CustomCard.BuildCard<Statics>((card) => Statics.card = card);                  //art
            CustomCard.BuildCard<Dynamics>((card) => Dynamics.card = card);                //art
            CustomCard.BuildCard<Calc1p1>((card) => Calc1p1.card = card);                  //
            CustomCard.BuildCard<Calc1p2>((card) => Calc1p2.card = card);                  //
            CustomCard.BuildCard<Linalg>((card) => Linalg.card = card);                    //
            CustomCard.BuildCard<Calc2>((card) => Calc2.card = card);                      //
            CustomCard.BuildCard<DE>((card) => DE.card = card);                            //art
            CustomCard.BuildCard<Propstat>((card) => Propstat.card = card);                //
            CustomCard.BuildCard<Materials>((card) => Materials.card = card);              //
            CustomCard.BuildCard<MOM>((card) => MOM.card = card);                          //
            CustomCard.BuildCard<Intro1>((card) => Intro1.card = card);                    //
            CustomCard.BuildCard<Intro2>((card) => Intro2.card = card);                    //
            CustomCard.BuildCard<Thermo>((card) => Thermo.card = card);                    //
            CustomCard.BuildCard<Electro>((card) => Electro.card = card);                  //
            CustomCard.BuildCard<ADSEE1>((card) => ADSEE1.card = card);                    //
            CustomCard.BuildCard<ADSEE2>((card) => ADSEE2.card = card);                    //
            CustomCard.BuildCard<Aero1>((card) => Aero1.card = card);                      //
            CustomCard.BuildCard<Aero2>((card) => Aero2.card = card);                      //



            //CustomCard.BuildCard<Test>();


            instance = this;
        }
    }
}
