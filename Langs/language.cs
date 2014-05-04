using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CavaPlugin
{
    public partial class Language : Form
    {
        public Language()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            //0 English 
            //1 Dansk 
            //2 Deutsch 
            //3 Français
            //4 Português  
            //5 Русский 
            CPGlobalSettings.Instance.language = comboBox1.SelectedIndex;
            CPGlobalSettings.Instance.Languageselected = true;
            CPGlobalSettings.Instance.Save();
            Close();
        }
    }
}
