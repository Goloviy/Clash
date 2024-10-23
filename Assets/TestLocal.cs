using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

public class TestLocal : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    
    
    // Start is called before the first frame update
    void Start()
    {
        var atr = ScriptLocalization.EquipmentOp.Skill_CrossBow_1;
        var str = LocalizationManager.GetTranslation("Key.Skill.BulletSpeed.1");
        var str2 = LocalizationManager.GetTranslation("EquipmentOp/Skill.Sword.1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
