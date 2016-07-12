using UnityEngine;
using System.Collections;

public class FireWorksCreater : MonoBehaviour {

    enum DIRECTION
    {
        LEFT = 1, RIGHT = -1
    }

    [SerializeField, Tooltip("玉を飛ばす方向")]
    DIRECTION direction;

    [SerializeField, Tooltip("玉が飛ぶ速さ")]
    GameObject fireWorksSeed;

    [SerializeField, Tooltip("玉を飛ばす角度")]
    float[] angle = new float[3];

    [SerializeField]
    DataManager dataManager;

    float time;

    FireWorks fireWorks;

    // Use this for initialization
    void Start() {
        time = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!dataManager.IsGameEnd)
        {

            int angleID = Random.Range(0, 3);
            time += Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                RayCast();
            }

            if (time >= 2f)
            {
                Instantiate(fireWorksSeed, this.transform.position, Quaternion.Euler(0, 0, angle[angleID] * (int)direction));
                time = 0f;
            }
        }
    }

    void RayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            GameObject obj = hit.collider.gameObject;
            fireWorks = obj.GetComponent<FireWorks>();
            if (fireWorks != null)
            {
                fireWorks.SetDataManager(dataManager);
                fireWorks.IsUnExploded = false;
            }
        }
    }
}
