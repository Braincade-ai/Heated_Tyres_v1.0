/*using System.Collections.Generic;
using UnityEngine;

namespace Road_namespace
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField]
        private int roadStartCount = 5;
        [SerializeField]
        private int minimumStraightRoads = 4;
        [SerializeField]
        private int maximumStraightRoads = 12;
        [SerializeField]
        private GameObject startingRoad;
        [SerializeField]
        private List<GameObject> turnRoads;

        private Vector2 currentRoadLocation = Vector2.zero;
        private Vector2 currentRoadDirection = Vector2.up;
        private GameObject prevRoad;

        private List<GameObject> currentRoads;


        private void Start()
        {
            currentRoads = new List<GameObject>();

            Random.InitState(System.DateTime.Now.Millisecond);

            for (int i = 0; i < roadStartCount; i++)
            {
                SpawnRoad(startingRoad.GetComponent<Roads>());
            }
            SpawnRoad(SelectRandomGameObjectFromList(turnRoads).GetComponent<Roads>());
        }
        private void DeletePreviousRoad()
        {

        }

        public void AddNewDirection(Vector2 direction)
        {
            currentRoadDirection = direction;

            Vector2 roadPlacementScale;
            if (prevRoad.GetComponent<Roads>().type == RoadType.LEFT)
            {
                Vector2 prevRoadSize = new Vector2(prevRoad.GetComponent<Renderer>().bounds.size.x, prevRoad.GetComponent<Renderer>().bounds.size.y);
                Vector2 startingRoadSize = new Vector2(startingRoad.GetComponent<BoxCollider2D>().size.x, startingRoad.GetComponent<BoxCollider2D>().size.y);

                Vector2 combinedSizes = prevRoadSize + (Vector2.one * startingRoadSize.y);

                roadPlacementScale = Vector2.Scale(combinedSizes, currentRoadDirection);

            }
        }
        private void SpawnRoad(Roads roads)
        {

            prevRoad = Instantiate(roads.gameObject, currentRoadLocation + roads.offset, Quaternion.identity);
            currentRoads.Add(prevRoad);

            Vector2 roadSize = Vector2.Scale(prevRoad.GetComponent<Renderer>().bounds.size, currentRoadDirection);
            currentRoadLocation += roadSize + roads.offset;

        }

        private GameObject SelectRandomGameObjectFromList(List<GameObject> list)
        {
            if (list.Count == 0) return null;
            return list[Random.Range(0, list.Count)];

        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Road_namespace
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField]
        private int roadStartCount = 5;
        [SerializeField]
        private int minimumStraightRoads = 4;
        [SerializeField]
        private int maximumStraightRoads = 12;
        [SerializeField]
        private GameObject startingRoad;
        [SerializeField]
        private List<GameObject> turnRoads;

        private Vector2 currentRoadLocation = Vector2.zero;
        private Vector2 currentRoadDirection = Vector2.up;
        private GameObject prevRoad;

        private List<GameObject> currentRoads;

        private void Start()
        {
            currentRoads = new List<GameObject>();

            Random.InitState(System.DateTime.Now.Millisecond);

            for (int i = 0; i < roadStartCount; i++)
            {
                SpawnRoad(startingRoad.GetComponent<Roads>());
            }
            SpawnRoad(SelectRandomGameObjectFromList(turnRoads).GetComponent<Roads>());

            // Start the coroutine to spawn roads every 3 seconds
            StartCoroutine(SpawnRoadsCoroutine());
        }

        private IEnumerator SpawnRoadsCoroutine()
        {
            while (true)
            {
                // Wait for 3 seconds
                yield return new WaitForSeconds(3f);

                // Spawn a new road
                SpawnRoad(SelectRandomGameObjectFromList(turnRoads).GetComponent<Roads>());
            }
        }

        private void DeletePreviousRoad()
        {
            // Implementation for deleting previous road goes here
        }

        private void SpawnRoad(Roads roads)
        {
            prevRoad = Instantiate(roads.gameObject, currentRoadLocation + roads.offset, Quaternion.identity);
            currentRoads.Add(prevRoad);

            Vector2 roadSize = Vector2.Scale(prevRoad.GetComponent<Renderer>().bounds.size, currentRoadDirection);
            currentRoadLocation += roadSize + roads.offset;
        }

        private GameObject SelectRandomGameObjectFromList(List<GameObject> list)
        {
            if (list.Count == 0) return null;
            return list[Random.Range(0, list.Count)];
        }
    }
}
