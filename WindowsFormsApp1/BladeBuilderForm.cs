using System;
using System.Windows.Forms;
using WindowsFormsApp1.Kompas;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class BladeBuilderForm : Form
    {
        private readonly KompasWrapper _kompas;

        public BladeBuilderForm()
        {
            InitializeComponent();
            _kompas = new KompasWrapper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var blade = new Blade(
                ParseControlText(bladeLenght),
                ParseControlText(handleLength),
                ParseControlText(handleBoreDiameter),
                ParseControlText(buttWidth),
                ParseControlText(bladeHeight),
                ParseControlText(grindHeight)
            );
            try
            {
                ModelValidator.Validate(blade);

            }
            catch (ValidationException validationException)
            {
                MessageBox.Show(validationException.Message);
                return;
            }
            _kompas.BuildPart(blade);
        }

        private static double ParseControlText(Control control)
        {
            return string.IsNullOrEmpty(control.Text) ? 0 : double.Parse(control.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _kompas.CloseInvisible();
        }
    }
}