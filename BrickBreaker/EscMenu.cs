using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BrickBreaker
{
    public partial class EscMenu : Form
    {

        private Game game;
        public EscMenu(Game game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (game != null)
            {
                try
                {
                   
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "Binary files(*.bin)|*.bin";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {

                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(stream, game);
                        stream.Close();
                        MessageBox.Show("Game was successfuly saved");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
