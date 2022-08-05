using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject Apple;

    private float posX;
    private float posZ;
    private float posY;

    public void Update()
    {
        SpawnApple();
    }
    public void SpawnApple()
    {
        if (GameObject.Find("Apple(Clone)") == null && GameObject.Find("Apple") == null)
        {
            posX = Random.Range(-5, 30);
            posZ = Random.Range(-5, 30);
            posY = 0.2f;
            Vector3 pos = new Vector3(posX, posY, posZ);
            Instantiate(Apple, pos, Quaternion.identity);
            
        }
    }
}
