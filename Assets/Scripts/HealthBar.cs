using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] HealthSysterm healthSysterm;

        private void Start()
        {
            healthSysterm.OnHealthChange += HealthSysterm_OnHealthChange;
        }

        private void HealthSysterm_OnHealthChange(object sender, System.EventArgs e)
        {
            UpdateBar();
        }

        public void UpdateBar()
        {
            transform.Find("HealthBar").localScale = new Vector3(healthSysterm.HealthRatio() , 1 ,1);
        }
    }
    
}
