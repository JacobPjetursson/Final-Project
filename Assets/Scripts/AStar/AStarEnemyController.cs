using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStar {
    public class AStarEnemyController : MonoBehaviour
    {
        public GameObject player;
        public float speed = 5;

        // Performance optimization
        public float pathFindInterval = 1f;
        public float tileResolution = 5f;
        public float optimality = 0.1f;

        // FIXME - hardcoded bounds
        private int maxX_map = 8;
        private int maxY_map = 5;
        private int offset;

        private int width;
        private int height;
        private bool[,] tilemap;
        private TileGrid grid;
        private Vector2 direction;
        private Bounds bounds;

        // Use this for initialization
        void Start()
        {
            this.bounds = GetComponent<BoxCollider2D>().bounds;

            offset = maxX_map;
            width = (maxX_map + offset) * (int)tileResolution;
            height = (maxY_map + offset) * (int)tileResolution;
            direction = new Vector2(0, 0);
            tilemap = new bool[width, height];
            AStar.optimality = this.optimality;

            fillTileMap();
            // create a grid
            grid = new TileGrid(width, height, tilemap);
        }
        /*
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
                Destroy(this.gameObject);
        }
        */
        Vector2 posToTile(Vector2 pos)
        {
            pos.x += offset;
            pos.y += offset;
            pos *= tileResolution;

            Vector2 tilePos = new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
            return tilePos;
        }

        Vector2 tileToPos(Vector2 tilePos)
        {
            tilePos /= tileResolution;
            tilePos.x -= offset;
            tilePos.y -= offset;
            return tilePos;
        }

        void Update()
        {
            StartCoroutine(findPath());
            this.transform.Translate(speed * direction * Time.deltaTime);
        }

        void fillTileMap()
        {
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Obstacle");
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Vector3 pos = tileToPos(new Vector2(i, j));
                    tilemap[i, j] = true;
                    foreach (GameObject wall in walls)
                    {
                        Bounds wallBounds = wall.GetComponent<BoxCollider2D>().bounds;
                        Bounds aiBounds = new Bounds();
                        aiBounds.center = pos;
                        aiBounds.extents = bounds.extents;
                        // Check if bounds from certain position on map would collide with wall
                        if (wallBounds.Intersects(aiBounds))
                        {
                            tilemap[i, j] = false;
                            break;
                        }
                    }
                }
            }
        }

        IEnumerator findPath()
        {
            yield return new WaitForSeconds(pathFindInterval);

            // create source and target points
            player = GameObject.FindGameObjectWithTag("Player");

            Vector2 from_vec = posToTile(this.transform.position);
            //Vector2 to_vec = posToTile(player.transform.position);
            Point fromPoint = new Point((int)from_vec.x, (int)from_vec.y);
            //Point toPoint = new Point((int)to_vec.x, (int)to_vec.y);

            Bounds toBounds = player.GetComponent<BoxCollider2D>().bounds;
            toBounds.center = posToTile(toBounds.center);
            toBounds.extents += this.bounds.extents;
            toBounds.extents *= tileResolution;

            Point firstStep = AStar.FindPath(grid, fromPoint, toBounds);
            if (firstStep == null)
                direction = Vector2.zero;
            else {
                Vector2 dirVec = new Vector2(firstStep.x - fromPoint.x, firstStep.y - fromPoint.y);
                direction = dirVec.normalized;
            }
        }
    }
}