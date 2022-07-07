namespace TextPx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TextPxImage textPx = new();
        Bitmap b = null;
        Bitmap b2 = null;
        string s = "";
        private void conversionButton1(object sender, EventArgs e)
        {
            string contents = File.ReadAllText(textBox1.Text);
            b = textPx.TPx_to_image(contents);
            pictureBox1.BackgroundImage = b;
            button2.Enabled = true;
        }
        private void conversionButton2(object sender, EventArgs e)
        {
            string contents = textPx.Image_to_TPx((Bitmap)b2);
            s = contents;
            button3.Enabled = true;
        }

        private void saveImg(object sender, EventArgs e)
        {
            b.Save(textBox2.Text);
            button2.Enabled = false;
            b = null;
        }
        private void saveTPx(object sender, EventArgs e)
        {
            File.WriteAllText(textBox3.Text, s);
            button3.Enabled = false;
            s = "";
        }

        private void prev(object sender, EventArgs e)
        {
            b2 = (Bitmap)Image.FromFile(textBox4.Text);
            pictureBox2.BackgroundImage = b2;
        }
    }
}