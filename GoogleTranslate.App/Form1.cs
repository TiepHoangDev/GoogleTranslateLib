using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using GoogleTranslateLib;

namespace GoogleTranslate.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = false;
            var res = await Translate.TranslateText(txtText.Text, (lang)cmbInput.SelectedValue, (lang)cmbOutput.SelectedValue);
            txtResponse.Text = res.ToString();
            txtResponse.AppendText("\n" + JsonConvert.DeserializeObject(res.Response));
            btn.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var lst = Translate.GetLangusges().ToList();
            cmbInput.DisplayMember = "Value";
            cmbInput.ValueMember = "Key";
            cmbInput.DataSource = lst;

            cmbOutput.DisplayMember = "Value";
            cmbOutput.ValueMember = "Key";
            cmbOutput.DataSource = lst.ToList();

            cmbInput.SelectedValue = lang.en;
            cmbOutput.SelectedValue = lang.vi;
        }
    }
}
