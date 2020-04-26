using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Function_Maker
{
    class program : Form
    {
        //Form Settings
        private Size form_size = new Size(400,300);
        private Icon form_icon = new Icon("./cue/icon.ico");
        private string form_title = "Function Maker";
        private Boolean form_maximizebox = false;

        //Function Text Box Settings
        private RichTextBox function_box = new RichTextBox();
        private Size function_box_size = new Size(370,20);
        private Point function_box_location = new Point(10,25);
        private string function_box_text = "Place function here!";

        //Function Button
        private Button function_button = new Button();
        private string function_button_text = "OK!";
        private Font function_button_font = new Font("Times New Roman", 9);
        private Point function_button_location = new Point(10,75);

        //Output Label
        private Label output_label = new Label();
        private string output_label_text = "OUTPUT: ";
        private Point output_label_location = new Point(160,75);
        private Font output_label_font = new Font("Times New Roman", 9);

        //Miscellaneous Variables
        private Boolean function_box_check = true;
        private Boolean program_check = false;

        public program() 
        {   
            //Setup for Form
            this.Size = form_size;
            this.Icon = form_icon;
            this.Text = form_title;
            this.MaximizeBox = form_maximizebox;

            //Setup for Output Label
            output_label.Text = output_label_text;
            output_label.Font = output_label_font;
            output_label.Location = output_label_location;

            //Setup for Function Input
            function_box.Size = function_box_size;
            function_box.Location = function_box_location;
            function_box.Text = function_box_text;

            //Setup for Function Button
            function_button.Text = function_button_text;
            function_button.Font = function_button_font;
            function_button.Location = function_button_location;

            //Add components to Form
            this.Controls.Add(function_box);
            this.Controls.Add(function_button);
            this.Controls.Add(output_label);

            //Added Events
            program_size_logger();
            function_box_mouse_hover();
            function_button_output();
        }

        //Events and Methods
        private void program_ClientSizeChanged(Object sender, EventArgs e)
        {
            this.Text = "Size: " + this.Width + " , " + this.Height;
        }

        private void function_box_MouseHover(object sender, System.EventArgs e)
        {
            function_box.Text = "";
            function_box.MouseHover -= new EventHandler(this.function_box_MouseHover);
        }

        private void function_button_Click(object sender, System.EventArgs e)
        {
            output_label.Text = "OUTPUT: " + function_result();
        }

        private void function_button_output()
        {
            function_button.Click += new EventHandler(this.function_button_Click);
        }

        public void function_box_mouse_hover()
        {
            if(function_box_check == true)
            {
                function_box.MouseHover += new EventHandler(this.function_box_MouseHover);
                function_box_check = false;
            }
        }

        public void program_size_logger()
        {
            if(program_check == true)
            {
                this.ClientSizeChanged += new EventHandler(this.program_ClientSizeChanged);
            }

            else
            {
                this.MinimumSize = form_size;
                this.MaximumSize = form_size;
            }
        }

        public int function_result()
        {
            int hin = 0;
            string jin = function_box.Text;
            functions function = new functions();
            
            try
            {
                for(int i = 0; i < jin.Length; i++)
                {

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return hin;
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
