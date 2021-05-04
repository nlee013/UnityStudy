using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightAlgor : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int[] temps = { 5, 8, 3, 6, 9 };
            int[] values = Check(temps);

            for (int i = 0; i < values.Length; i++)
            {
                print(values[i]); // [0,0,2,2,0]
            }
        }
    }

    int[] Check(int[] height)
    {
        int[] nums = new int[height.Length];
        int H_index;

        nums[0] = 0;
        // ±¸Çö
        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] < nums[i + 1])
            {
                 
            }
        }

        return nums;
    }
}
