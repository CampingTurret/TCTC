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


namespace TCTC.MonoBehaviors
{
    public class Reentrymono : MonoBehaviour
    {
        private void Awake()
        {
            this.player = base.GetComponent<Player>();
            this.block = base.GetComponent<Block>();
            this.data = base.GetComponent<CharacterData>();
            this.gun = base.GetComponent<Gun>();
            this.health = base.GetComponent<HealthHandler>();
            this.outofbounds =  player.data.GetAdditionalData().outOfBoundsHandler;


        }
        static private void Drop_Pod(float[] location, Player player)
        {

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
               
            switch (mode)
            {
                case -2:
                    //Drop pod (deep rock galactic)
                    player.transform.SetXPosition(location[0]);
                    player.transform.SetYPosition(location[1]);
                    player.transform.SetZPosition(location[2]);
                    Drop_Pod(location,player);
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
                    player.transform.SetYPosition(location[1]);
                    player.transform.SetZPosition(location[2]);
                    player.transform.AddYPosition(200);
                    break;
                case 2:
                    //Parashute
                    player.transform.SetXPosition(location[0]);
                    player.transform.SetYPosition(location[1]);
                    player.transform.SetZPosition(location[2]);
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
                                ;
                                print(Object_with_tag.gameObject);
                                Valid_spawns.Add(Object_with_tag.gameObject);
                            }
                            else { }
                        }

                        int spawnselected = UnityEngine.Random.Range(0, Valid_spawns.Count);
                        
                        GameObject spawn = Valid_spawns[spawnselected];
                        xnew = spawn.transform.position.x;
                        ynew = spawn.transform.position.y;
                        znew = spawn.transform.position.z;
                        print(ynew);

                        int insertoption;

                        RaycastHit2D hit = Physics2D.Raycast((Vector2)spawn.transform.position, Vector2.up, 200);
                        if (hit.collider)
                        {
                            print(hit.transform.position.y);
                            insertoption = UnityEngine.Random.Range(-2, 0);
                        }
                        else 
                        {
                            insertoption = UnityEngine.Random.Range(0,2);
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




        private OutOfBoundsHandler outofbounds;
        private HealthHandler health;
        public Block block;
        public Player player;
        public CharacterData data;
        public Gun gun;
        public float xpos;
        public float ypos;




    }
}
