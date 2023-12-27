namespace Captcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadCaptchaImage();
        }
        String CAPTCHA = "";
        int FAIL = 0;
        private void loadCaptchaImage()
        {
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            CAPTCHA = RandomString(5);
            graphics.DrawString(CAPTCHA, font, Brushes.Green, new Point(0, 0));
            pictureBox1.Image = image;

        }

        private static Random randomS = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[randomS.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadCaptchaImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == CAPTCHA)
            {
                MessageBox.Show("Match Text with Captcha");
            }
            else
            {
                MessageBox.Show("DOes not Match Text with Captcha");
                loadCaptchaImage();
                FAIL++;
                if (FAIL == 3)
                {
                    this.Close();
                }
            }
        }
    
    }
}
