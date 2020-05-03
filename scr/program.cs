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
        private Size form_size = new Size(400,300);
        private Icon form_icon = new Icon("C:\\Users\\werty\\Downloads\\assets\\projects\\2020-04-21_Function_Maker\\cue\\icon.ico");
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
        private Size output_label_size = new Size(9,15);
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

            string path_one = @"arithmetic.cs";
            string path_two = @"arithmetic.bat";
            string input_one = "using System;\nusing System.IO;\n\nclass arithmetic\n{\n\tstatic void Main()\n\t{\n\t\tstring path_one = @\"arithmetic.txt\";\n\t\tdouble math = (double)("+ maths + ");\n\t\tstring input_one = \"\" + math;\n\t\tStreamWriter output_file_one = new StreamWriter(path_one);\n\t\toutput_file_one.WriteLine(input_one);\n\t\toutput_file_one.Close();\n\t\toutput_file_one.Dispose();\n\t}\n}";
            string input_two = "csc -out:arithmetic.exe arithmetic.cs\n";

            try
            {
                StreamWriter output_file_one = new StreamWriter(path_one);
                output_file_one.WriteLine(input_one);
                output_file_one.Close();
                output_file_one.Dispose();

                StreamWriter output_file_two = new StreamWriter(path_two);
                output_file_two.WriteLine(input_two);
                output_file_two.Close();
                output_file_two.Dispose();

                yield1.StartInfo.FileName = "arithmetic.bat";
                yield1.Start();
                yield1.Close();
                yield1.Dispose();

                yield2.StartInfo.FileName = "arithmetic.exe";
                yield2.Start();
                yield2.WaitForExit();
                yield2.Close();
                yield2.Dispose();
            }
            catch
            {
                output_label.Text = "OUTPUT: " +"``\\:)/``" + " : Not a proper function!\n";
            }

            output_label.Text += "Thinking...";
            Thread.Sleep(2000);

            try
            {
                StreamReader get_output = new StreamReader("arithmetic.txt");
                string input = "";

                while ((input = get_output.ReadLine()) != null)
                {
                    output_label.Text = input;
                }

                output_label.Text = "OUTPUT: " + input; 
            }
            catch (System.Exception em)
            {
                output_label.Text = "OUTPUT: Error:" + em;
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
                count_one[count_two] = "(double)" + input;//------------------------------------------------------------------------------------------------
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
