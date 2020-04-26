using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Function_Maker
{
    class program : Form
    {
        //Form Settings
        private Size form_size = new Size(500,250);

        //Title Settings
        private Label title = new Label();
        private string title_text = "FUNCTION";
        private Font title_font = new Font("Times New Roman", 12);
        private Point title_location = new Point(10,30);

        //Function Text Box Settings
        private RichTextBox function_box = new RichTextBox();
        private Size function_box_size = new Size(370,30);
        private Point function_box_location = new Point(10,80);

        //Function Button
        private Button function_button = new Button();
        private string function_button_text = "OK!";
        private Font function_button_font = new Font("Times New Roman", 9);
        private Point function_button_location = new Point(10,150);
        //private Size function_button_size = new Size(80,30);

        public program() 
        {   
            //Setup for Form
            this.Size = form_size;

            //Setup for Title
            title.Text = title_text;
            title.Font = title_font;
            title.Location = title_location;

            //Setup for Function Input
            function_box.Size = function_box_size;
            function_box.Location = function_box_location;

            //Setup for Function Button
            function_button.Text = function_button_text;
            function_button.Font = function_button_font;
            function_button.Location = function_button_location;
            //function_button.Size = function_box_size;

            //Add components to Form
            this.Controls.Add(function_box);
            this.Controls.Add(title);
            this.Controls.Add(function_button);

            //Added Events
            this.ClientSizeChanged += new EventHandler(this.program_ClientSizeChanged);
        }

        //Events and Methods
        private void program_ClientSizeChanged(Object sender, EventArgs e)
        {
            this.Text = "Size: " + this.Width + " , " + this.Height;
        }
        //---------------------------------------------------------------- //

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new program());
        }
    }
}
