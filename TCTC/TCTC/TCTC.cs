using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using TCTC.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;


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
        public const string Version = "0.2.1"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "TCTC";


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
            instance = this;
        }
    }
}
