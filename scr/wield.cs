using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Function_Maker
{
    public class wield : Form
    {
        public Button wield_button = new Button();
        public RichTextBox wield_text_box = new RichTextBox();

        public string get_maths_input {get; set;}
        private Size wield_text_box_size = new Size(180,20);
        private Point wield_text_box_location = new Point(35, 35);
        private string wield_button_text = "GO!";
        private Font wield_button_font = new Font("Times New Roman", 9);
        private Point wield_button_location = new Point(80, 85);
    
        public wield()
        {
            Form wield = new Form();
            wield.StartPosition = FormStartPosition.CenterScreen;
            wield.Size = new Size(250, 150);
            wield_text_box.Size = wield_text_box_size;
            wield_text_box.Location = wield_text_box_location;
            wield_button.Text = wield_button_text;
            wield_button.Font = wield_button_font;
            wield_button.Location = wield_button_location;

            this.Controls.Add(wield_button);
            this.Controls.Add(wield_text_box);

            wield_button.Click += new EventHandler(this.wield_button_Click);
        }

        private void wield_button_Click(object sender, System.EventArgs e)
        {
            get_maths_input = wield_text_box.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}