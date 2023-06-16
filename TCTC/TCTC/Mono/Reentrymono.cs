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
using ModdingUtils.MonoBehaviours;
using ModdingUtils.Extensions;
using UnboundLib.Networking;
using HarmonyLib;
using UnityEngine.Animations;
using System.Net;
using Photon.Pun;

namespace TCTC.MonoBehaviors
{
    public class Reentrymono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = data.weaponHandler.gun;
            this.health = base.GetComponent<HealthHandler>();
            this.outofbounds =  player.data.GetAdditionalData().outOfBoundsHandler;


        }
        [UnboundRPC]
        static void Entry_sequence(float[] location, int playerID,int mode=-1)
        {
            Player player = null;
            GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < playerlist.Length; i++)
            {
                GameObject Object_with_tag = playerlist[i];
                if (Object_with_tag.GetComponent<Player>().playerID == playerID)
                {
                    player = Object_with_tag.GetComponent<Player>();
                }
            }
            player.GetComponentInParent<PlayerCollision>().IgnoreWallForFrames(2);
            print("Mode selected =" + mode.ToString()); 
            
            switch (mode)
            {
                case -2:
                    //Drop pod (deep rock galactic)
                    Drop_pod drop_Pod = player.gameObject.AddComponent<Drop_pod>();
                    drop_Pod.Set_Position(location[0], location[1], location[2]);
                    break;
                case -1:
                    //Need ideas
                    player.transform.SetXPosition(location[0]);
                    player.transform.SetYPosition(location[1]);
                    player.transform.SetZPosition(location[2]);
                    break;
                case 0:
                    //TP
                    player.transform.SetXPosition(location[0]);
                    player.transform.SetYPosition(location[1]);
                    player.transform.SetZPosition(location[2]);
                    break;
                case 1:
                    //Sky crane
                    player.transform.SetXPosition(location[0]);
                    player.transform.SetYPosition(location[1]+200);
                    player.transform.SetZPosition(location[2]);
                    break;
                case 2:
                    //Parashute
                    Parashute para = player.gameObject.AddComponent<Parashute>();
                    para.Set_Position(location[0], location[1], location[2]);
                    break;
                default:
                    //TP (just in case i mess up)
                    player.transform.SetXPosition(location[0]);
                    player.transform.SetYPosition(location[1]);
                    player.transform.SetZPosition(location[2]);
                    break;

            }
            
        }

        
        public void Update()
        {
           
            outofbounds.enabled = true;
            Vector3 outV = ModdingUtils.Extensions.OutOfBoundsHandlerExtensions.BoundsPointFromWorldPosition(outofbounds, data.transform.position);
            if (outV.y <= 0.2f || outV.y >= 0.9f)
            {
                outofbounds.enabled = false;
               
                if(outV.y < 0.01f)
                {
                    if (player.data.view.IsMine)
                    {
                        float xnew = player.transform.position.x;
                        float ynew = player.transform.position.y;
                        float znew = player.transform.position.z;


                        SpawnPoint[] Spawn_list = GameObject.FindObjectsOfType<SpawnPoint>();
                        List<GameObject> Valid_spawns = new List<GameObject>();
                        LayerMask layermask = LayerMask.GetMask("Player", "Foreground", "PlayerObjectCollider", "Projectile");
                        foreach (SpawnPoint Object_with_tag in Spawn_list)
                        {
                            
                            Vector2 pos = Object_with_tag.transform.position;
                            if (!Physics2D.OverlapCircle(pos,0.05f,layermask))
                            {
                                Valid_spawns.Add(Object_with_tag.gameObject);
                            }
                            else { }
                        }

                        int spawnselected = UnityEngine.Random.Range(0, Valid_spawns.Count);
                        
                        GameObject spawn = Valid_spawns[spawnselected];
                        xnew = spawn.transform.position.x;
                        ynew = spawn.transform.position.y;
                        znew = spawn.transform.position.z;
                        

                        int insertoption;

                        RaycastHit2D hit = Physics2D.Raycast((Vector2)spawn.transform.position, Vector2.up, 200);
                        if (hit.collider)
                        {
                            insertoption = UnityEngine.Random.Range(-2, -1);
                        }
                        else 
                        {
                            insertoption = 2;//UnityEngine.Random.Range(1,2);
                        }

                        NetworkingManager.RPC(typeof(Reentrymono), nameof(Entry_sequence), new object[]
                        {
                            new float[]
                                {
                                    xnew,
                                    ynew,
                                    znew
                                },
                            player.playerID,
                            insertoption
                        });
                    }                    
                }
                           
            }
            if (outV.x >= 1f || outV.x <= 0f || (( 0.9f >= outV.y) && (outV.y >= 0.2f)))
            {
                outofbounds.enabled = true;
            }

        }
        public void Set_Outofbounds()
        {
            if(this.outofbounds == null)
            {
                this.outofbounds = player.data.GetAdditionalData().outOfBoundsHandler;
            }
        }




        private OutOfBoundsHandler outofbounds;
        private HealthHandler health;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;
        public float xpos;
        public float ypos;




    }
    public class Insert_method : MonoBehaviour
    {

        public void Set_Position(float x,float y, float z)
        {
            endpoint = new float[3] { x, y, z };
        }
        
        public virtual void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = data.weaponHandler.gun;
            this.health = base.GetComponent<HealthHandler>();
            this.playerJump = base.GetComponent<PlayerJump>();
            this.playerMovement = base.GetComponent<PlayerMovement>();
            this.playerCollision = base.GetComponentInParent<PlayerCollision>();
            this.gravity = base.GetComponent<Gravity>();
            startup = Animator.StringToHash("Base Layer.Start");
            DropPlayer = Animator.StringToHash("Base Layer.Drop_Player");
            End = Animator.StringToHash("Base Layer.End");
            HoldPlayer = true;

            this.outofbounds = player.data.GetAdditionalData().outOfBoundsHandler;
            if (this.outofbounds == null || player == null || block == null || data == null || gun == null || health == null || playerJump == null || playerMovement == null || playerCollision == null)
            {
                throw new Exception("TCTC: Re-Entry: a player component not found");
            }
            if(player.GetComponents<Insert_method>().Length > 1)
            {
                Destroy(this);
            }
        }

        public virtual void Update()
        {

            if (HoldPlayer)
            {
                playerCollision.IgnoreWallForFrames(2);
                player.transform.SetXPosition(endpoint[0]);
                player.transform.SetYPosition(endpoint[1] + 200);
                player.transform.SetZPosition(endpoint[2]);
            }
            if (vehicle == null || animator == null)
            {
                vehicle = Instantiate(Prefab, new Vector3(endpoint[0], endpoint[1], endpoint[2]), new Quaternion(0, 0, 0, 0));
                animator = vehicle.GetComponent<Animator>();
                animator.SetBool("Start_up", false);
                animator.SetBool("Leave", false );
            }


            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            int currentstate = info.fullPathHash;
            if (currentstate == startup)
            {
                animator.SetBool("Start_up", true);
                HoldPlayer = true;
                player.transform.SetXPosition(endpoint[0]);
                player.transform.SetYPosition(endpoint[1] + HoldYpos);
                player.transform.SetZPosition(endpoint[2]);
                
                Lock_Player_Control();
            }
            else
            {

                if (currentstate == DropPlayer)
                {
                    HoldPlayer = false;
                    Move_player();
                    Unlock_Player_Control();
                    player.GetComponent<CharacterData>().playerVel.SetFieldValue("velocity",new Vector2(0,0));
                    animator.SetBool("Leave", true);
                }
                else
                {
                    if (currentstate == End)
                    {
                        Finish_Insert();
                        Destroy(vehicle);
                        Destroy(this);
                    }
                }
            }
            
        
        }
        public void Lock_Player_Control()
        {
            gun.enabled = false;
            playerMovement.enabled = false;
            playerJump.enabled = false;
            gravity.enabled = false;
            

        }
        public void Unlock_Player_Control()
        {
            gun.enabled = true;
            playerMovement.enabled = true;
            playerJump.enabled = true;
            gravity.enabled = true;
        }
        public void Move_player()
        {

            if(endpoint == null)
            {
                throw new Exception("TCTC: Re-Entry: Endpoint Undefined"); ;
            }
            else
            {
                playerCollision.IgnoreWallForFrames(2);
                player.transform.SetXPosition(endpoint[0]);
                player.transform.SetYPosition(endpoint[1]);
                player.transform.SetZPosition(endpoint[2]);
                
            }

        }

        virtual public void Finish_Insert()
        {

        }
        public float HoldYpos;
        public bool HoldPlayer;
        private int End;
        private int DropPlayer;
        private int startup;
        public float[] endpoint;
        private OutOfBoundsHandler outofbounds;
        private HealthHandler health;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;
        public PlayerMovement playerMovement;
        public PlayerJump playerJump;
        public PlayerCollision playerCollision;
        public GameObject vehicle;
        public Animator animator;
        public GameObject Prefab;
        public Gravity gravity;
        

    }

    public class Drop_pod : Insert_method
    {
        public override void Awake()
        {
            base.Awake();
            Prefab = TCTCards.Drop_Pod;
            HoldYpos = 200;
        }
        

        
    }

    public class Parashute : Insert_method
    {

        public override void Awake()
        {
            base.Awake();
            Prefab = TCTCards.Parashute;
            HoldYpos = 200;
        }
        public override void Update()
        {
            base.Update();
            HoldPlayer = false;
            if (Player_holder == null)
            {
                Player_holder = vehicle.transform.Find("Parashute_sprite/Player_Hook");
            }
            else
            {

                player.transform.position = Player_holder.position;
                player.GetComponent<CharacterData>().playerVel.SetFieldValue("velocity", new Vector2(0, 0));
            }

        }
        private Transform Player_holder;
    }

    public class TP_insert: Insert_method
    {
       
    }

    public class Sky_Crane : Insert_method
    {
        
    }

    
}
