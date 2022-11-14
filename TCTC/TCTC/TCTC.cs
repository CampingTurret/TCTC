using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using TCTC.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using Unity;
using UnityEngine;
using TCTC.MonoBehaviors;

namespace TCTC
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class TCTCards : BaseUnityPlugin
    {
        public static TCTCards instance { get; private set; }
        private const string ModId = "TheCampingTurret.Rounds.TCTC.cards";
        private const string ModName = "TCTCards";
        public const string Version = "1.2.1"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "TCTC";

        private static readonly AssetBundle Bundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("tctc", typeof(TCTCards).Assembly);

        public static GameObject WaffleArt = Bundle.LoadAsset<GameObject>("C_Waffle");
        public static GameObject CoffeeArt = Bundle.LoadAsset<GameObject>("C_Coffee");
        public static GameObject BlindGuessArt = Bundle.LoadAsset<GameObject>("C_BlindGuess");
        public static GameObject EducatedGuessArt = Bundle.LoadAsset<GameObject>("C_EducatedGuess");
        public static GameObject NoGuessWorkArt = Bundle.LoadAsset<GameObject>("C_NoGuessWork");
        public static GameObject signal = Bundle.LoadAsset<GameObject>("TCTCCanvas");
        public static GameObject signalcanvas = Bundle.LoadAsset<GameObject>("TCTCsignal");

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            CustomCard.BuildCard<DesignSpace>();
            CustomCard.BuildCard<Streamlined>();
            CustomCard.BuildCard<Waffle>();
            CustomCard.BuildCard<Coffee>();
            CustomCard.BuildCard<Compactteleporter>();
            CustomCard.BuildCard<Assumption>();
            CustomCard.BuildCard<TheEndIsNigh>();
            CustomCard.BuildCard<Blindguess>();
            CustomCard.BuildCard<Quadroacceleration>();
            CustomCard.BuildCard<Educatedguess>();
            CustomCard.BuildCard<Noguesswork>();
            CustomCard.BuildCard<Class2estimation>();
            CustomCard.BuildCard<RUD>();
            CustomCard.BuildCard<Test>();

            instance = this;
        }
    }
}
