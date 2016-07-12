using UnityEngine;
using System.Collections;

public class FireWorks : MonoBehaviour {
    [SerializeField,Tooltip("花火が不発になる高さ")]
    float deadLine;

    [SerializeField,Tooltip("これより低い場所では花火は爆発しない")]
    float borderLine;

    //花火が登っていく速さ
    [SerializeField]
    float speed;

    [SerializeField, Tooltip("成功したときに発生させるパーティクル")]
    GameObject fireWorks;

    [SerializeField,Tooltip("失敗したときに発生させるパーティクル")]
    GameObject smoke;

    DataManager dataManager;

    GameObject instantiateObj;

    //花火が不発かどうか
    private bool isUnExploded;
    public bool IsUnExploded
    {
        get { return isUnExploded; }
        set {isUnExploded = value; }
    }

    // Use this for initialization
    void Start () {
        isUnExploded = true;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0, speed, 0);

        if (isUnExploded)
        {
            //不発状態のままデッドライン超えたら煙を生成
            if (transform.position.y > deadLine)
            {
                Destroy(this.gameObject);
                Instantiate(smoke, this.transform.position, Quaternion.Euler(0, 0, 0));
            }
        }
        else
        {
            //不発状態でない玉がボーダーライン超えていたらその場に花火を生成
            if (transform.position.y > borderLine)
            {
                Destroy(this.gameObject);
                dataManager.AddScore((int)this.transform.position.y);
                Instantiate(fireWorks, this.transform.position, Quaternion.Euler(0, 0, 0));

            }
        }
    }

    public void SetDataManager(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }
}
