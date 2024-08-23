using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace PasswordSaver
{
	public partial class Form1 : Form
	{
		public Dictionary<string, string> optionMapping = new Dictionary<string, string>
		{

		};

		public Form1()
		{
			InitializeComponent();

			button1.Text = "Save Password";

			
		

			string jsonPassFile = File.ReadAllText("passwords.json");
			var tempMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonPassFile);

			foreach(var pair in tempMapping ) { optionMapping[pair.Key] = pair.Value;}
			listBox1.Items.AddRange(optionMapping.Keys.ToArray());
			
		}
		
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			string relatedOption = optionMapping[listBox1.SelectedItem.ToString()];
			label1.Text = relatedOption;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != null && textBox2.Text != null && !listBox1.Items.Contains(textBox1.Text) )
			{
				optionMapping.Add(textBox1.Text, textBox2.Text);
				listBox1.Items.Add(textBox1.Text);

				string jsonPassFile = JsonConvert.SerializeObject(optionMapping, Formatting.Indented);
				File.WriteAllText("passwords.json", jsonPassFile);
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
