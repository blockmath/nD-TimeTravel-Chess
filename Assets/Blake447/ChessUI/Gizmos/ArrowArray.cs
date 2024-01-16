using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowArray : MonoBehaviour
{
    public StraightArrow TemplateArrow;
    StraightArrow[] ArrowList;


    public void SetArrow(Vector3 start, Vector3 end)
    {
        if (ArrowList == null)
        {
            ArrowList = new StraightArrow[1];
            ArrowList[0] = Instantiate(TemplateArrow);
            ArrowList[0].SetArrow(start, end);
        }
        else
        {
            StraightArrow[] NewArrowList = new StraightArrow[ArrowList.Length + 1];
            System.Array.Copy(ArrowList, 0, NewArrowList, 0, ArrowList.Length);
            NewArrowList[NewArrowList.Length - 1] = Instantiate(TemplateArrow);
            NewArrowList[NewArrowList.Length - 1].SetArrow(start, end);
            ArrowList = NewArrowList;
        }
    }

    public void ClearArrows()
    {
        if (ArrowList != null)
        {
            for (int i = 0; i < ArrowList.Length; i++)
            {
                if (ArrowList[i] != null)
                {
                    Destroy(ArrowList[i].gameObject);
                    ArrowList[i] = null;
                }
            }
            ArrowList = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
