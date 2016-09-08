using UnityEngine;
using System.Collections;

public class LH_Follows_RH_Mirror : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject headset;
    //the coordinates (x, y, z) in output, z appears to be the variable that would be affected by mirroring in our world. 
    //when the participant is facing the balloons, with both hands at her side, RHz < Headz < LHz
    //So, when RHz > Headz, that means that the right hand has crossed the midline and the left hand will have to cross the midline the other way.

    void Update()
    {
        //if RHz < Headz
        if (rightHand.transform.position.z < headset.transform.position.z)
        {
            //set a temporary variable because you can't set one GameObject's position to the position of another GameObject 
            Vector3 _tmp = leftHand.transform.position;
            //LH(x)=RH(x)
            _tmp.x = rightHand.transform.position.x;
            //LH(y)=RH(y)
            _tmp.y = rightHand.transform.position.y;
            //LH(z)=((absolute value(Headz-RHz))+Headz)
            _tmp.z = Mathf.Abs(headset.transform.position.z - rightHand.transform.position.z) + headset.transform.position.z;
            leftHand.transform.position = _tmp;
        }
            //if RHz > Headz
        if (rightHand.transform.position.z > headset.transform.position.z)
        {
             Vector3 _tmp2 = leftHand.transform.position;
                //LH(x)=RH(x)
             _tmp2.x = rightHand.transform.position.x;
                //LH(y)=RH(y)
             _tmp2.y = rightHand.transform.position.y;
                //LH(z)=(Headz-(absolute value(RHz-Headz)))
             _tmp2.z = headset.transform.position.z-Mathf.Abs(rightHand.transform.position.z - headset.transform.position.z);
             leftHand.transform.position = _tmp2;
        }
            //keep y and z constant; have leftHand follow rightHand in x rotation
        Vector3 tmp = leftHand.transform.localEulerAngles;
        tmp.x = -1 * rightHand.transform.localEulerAngles.x;
        tmp.y = rightHand.transform.localEulerAngles.y;
        tmp.z = rightHand.transform.localEulerAngles.z;

        leftHand.transform.eulerAngles = tmp;
        
    }
}