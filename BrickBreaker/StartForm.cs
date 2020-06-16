using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class StartForm : Form
    {
        private Game game;
        public StartForm()
        {
            InitializeComponent();
        }

  
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                string path = string.Empty;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "txt files binary file|*.bin";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        path = openFileDialog.FileName;
                        Stream readStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                        Game.Loaded = true;
                        game = (Game)formatter.Deserialize(readStream);
                        readStream.Close();
                        MessageBox.Show("Game was succefully loaded press Start button to start loaded game");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          

           

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(game);
            this.Hide();
            form.ShowDialog();
        }

        private void EndGameButton_Click(object sender, EventArgs e)

        {
            Application.Exit();
        }
    }
}
