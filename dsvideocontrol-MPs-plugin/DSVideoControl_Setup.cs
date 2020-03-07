using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvLibrary.Log;
using TvControl;
using TvDatabase;
using TvEngine;


namespace SetupTv.Sections
{ 
    public partial class DSVideoControl_Setup : SetupTv.SectionSettings
    {
        
        
        #region Constructor
        public DSVideoControl_Setup()
        {
            InitializeComponent();
                
        }
        #endregion Constructor

        #region SetupTv.SectionSettings

        public override void OnSectionDeActivated()
        {
            Log.Info("DScontrol: Configuration deactivated");

            DSControl.ToolDirectory = TextBoxpathtoexe.Text ;
            DSControl.SaveSettings();
            base.OnSectionDeActivated();
        }

        public override void OnSectionActivated()
        {
            Log.Info("DScontrol: Configuration activated");

            DSControl.LoadSettings();
            TextBoxpathtoexe.Text = DSControl.ToolDirectory;


            base.OnSectionActivated();
        }

        #endregion SetupTv.SectionSettings
        public void ChooseFolder()
        {
            if (folderBrowserTool.ShowDialog() == DialogResult.OK)
            {
                TextBoxpathtoexe.Text = folderBrowserTool.SelectedPath;
            }
        }


        private void browsebutton_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void folderBrowserTool_HelpRequest(object sender, EventArgs e)
        {
            
        }

        
    }
}
