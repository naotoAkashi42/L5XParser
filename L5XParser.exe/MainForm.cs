using System.Xml.Linq;
using Utilities;
using L5XParser.Logic;
using L5XParser.Service;
using System.Diagnostics;

namespace L5XParser.exe
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            var target = FileIo.GetTargetFile("rockwell file |*.L5X");
            if (target == null) return;

            Analayser.OutputProgramInfo(target);
        }
    }
}