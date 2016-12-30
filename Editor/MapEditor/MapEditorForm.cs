using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CoreGame.Managers;
using CoreGame.Utilities;
using System.IO;
using LitJson;

namespace Editor
{
    public partial class MapEditorForm : Form
    {
        public MapEditorForm()
        {
            InitializeComponent();
        }

        private void assetBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void loadMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "JSON Files (.json)|*.json";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                mapEditor.LoadMap(dialog.FileName, Path.GetFileName(dialog.FileName));
                this.Text = Path.GetFileName("Map Editor - " + Path.GetFileName(dialog.FileName));
            }
        }

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "New Map.json";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ReadJson jsonReader = new ReadJson();
                WriteJson jsonWrite = new WriteJson();
                jsonWrite.WriteData(dialog.FileName, jsonReader.ReadData("Data/MapTemplate.json"));
                mapEditor.LoadMap(dialog.FileName, Path.GetFileName(dialog.FileName));
                this.Text = Path.GetFileName("Map Editor - " + Path.GetFileName(dialog.FileName));
            }
        }
    }
}
