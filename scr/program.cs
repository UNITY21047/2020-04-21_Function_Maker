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
    class program : Form
    {
        //Form Settings
        private Size form_size = new Size(400, 150);
        private Icon form_icon = new Icon("C:\\Users\\werty\\Downloads\\assets\\projects\\2020-04-21_Function_Maker\\cue\\icon.ico");
        private string form_title = "Function Maker";
        private Boolean form_maximizebox = false;

        //Function Text Box Settings
        private RichTextBox function_box = new RichTextBox();
        private Size function_box_size = new Size(300,20);
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
        private Size output_label_size = new Size(150,12);
        private Font output_label_font = new Font("Times New Roman", 9);

        //Miscellaneous Variables
        private Boolean function_box_check = true;
        private Boolean program_check = false;

        //Calculator Values
        private string maths = "";

        //Ref. from wield form
        //private static string text_for_wield_text_box = "";
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
            output_label.Size = output_label_size;

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
            Process yield1 = new Process();
            Process yield2 = new Process();

            maths = function_box.Text;

            while(maths.Contains("x"))
            {
                maths = check_for_Xs();
            }

            string path_two = @"arithmetic.bat";
            string path_three = @"arithmetic.cs";
            //string path_four = @"arithmetic.txt";
            StreamWriter output_file_two = new StreamWriter(path_two);
            StreamWriter output_file_three = new StreamWriter(path_three);

            try
            {
                output_file_two.WriteLine("csc -out:arithmetic.exe arithmetic.cs\n");
                output_file_two.Close();
                output_file_two.Dispose();
            }
            catch (System.Exception error_one)
            {
                output_label.Text = "OUTPUT: Error";
                MessageBox.Show("" + error_one);
            }

            try
            {
                output_file_three.WriteLine("class arithmetic{static void Main(){string path_one = @\"arithmetic.txt\";if(File.Exists(\".\\arithmetic.txt\")){File.Delete(\".\\arithmetic.txt\");}double math = (double)(" + maths + "); string input_one = \"\" + math;StreamWriter output_file_one = new StreamWriter(path_one);output_file_one.WriteLine(input_one);output_file_one.Close();output_file_one.Dispose();}}");
                output_file_three.Close();
                output_file_three.Dispose();
            }
            catch (System.Exception error_two)
            {
                output_label.Text = "OUTPUT: Error";
                MessageBox.Show("" + error_two);
            }

            try
            {
                yield1.StartInfo.FileName = ".\\arithmetic.bat";
                yield1.StartInfo.CreateNoWindow = true;
                yield1.Start();
                yield1.WaitForExit();
                yield1.Close();
                yield1.Dispose();
            }
            catch (System.Exception error_three)
            {
                MessageBox.Show("" + error_three);
            }

            try
            {
                yield2.StartInfo.FileName = ".\\arithmetic.exe";
                yield2.StartInfo.CreateNoWindow = true;
                yield2.Start();
                yield2.WaitForExit();
                yield2.Close();
                yield2.Dispose();
            }
            catch (System.Exception error_four)
            {
                MessageBox.Show("" + error_four);
            }

            try
            {
                StreamReader yield3 = new StreamReader("arithmetic.txt");
                string input = yield3.ReadLine();
                output_label.Text = "OUTPUT: " + input;
            }
            catch (System.Exception error_five)
            {
                MessageBox.Show("" + error_five);
            }
        }

        public void function_button_output()
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
        public string check_for_Xs()
        {

            string copy_of_math = maths;
            string[] count_one = new string[copy_of_math.Length];
            int count_two = 0;
            string input = "";


            for (int i = 0; i < copy_of_math.Length; i++)
            {
                count_one[i] = "" + copy_of_math[i];
            }

            while (Array.IndexOf(count_one, "x") != -1)
            {
                try
                {
                    wield yield = new wield();
                    if(yield.ShowDialog() == DialogResult.OK)
                    {
                        input = yield.get_maths_input;
                    }
                }
                catch (System.Exception)
                {
                    input = "0";
                }
                count_two = Array.IndexOf(count_one, "x");
                count_one[count_two] = "(double)" + input;
            }

            copy_of_math = "";

            for (int i = 0; i < count_one.Length; i++)
            {
                copy_of_math += count_one[i];
            }

            return copy_of_math;
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
