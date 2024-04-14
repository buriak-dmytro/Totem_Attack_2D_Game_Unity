using UnityEngine;

namespace Spawner
{
    public class SpawnPoint : MonoBehaviour
    {
        public void SpawnEnemy(GameObject enemyObject)
        {
            Instantiate(enemyObject, transform.position, Quaternion.identity);
        }
    }
}
