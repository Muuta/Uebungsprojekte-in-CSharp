namespace WinForm02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IDisposable
        // using 

        private void Form1_Load(object sender, EventArgs e)
        {

            Button b = new Button();
            b.Text = "Close";
            b.SetBounds(10, 10, 100, 30);
            b.BackColor = Color.Orange;
            b.Click += B_Click;
            Controls.Add(b);


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button x = new Button();
                    x.Text = (i * 10 + j).ToString();
                    x.Tag = x.Text;
                    x.SetBounds(j*55+10, i*35+50, 50, 30);
                    x.Click += (sender, ea) => {
                        Button btnSender = sender as Button;
                        if(btnSender != null)
                        {
                            // btnSender.Enabled = false;
                            // Controls.Remove(btnSender);
                            if(btnSender.BackColor != Color.White)
                            {
                                btnSender.BackColor = Color.White;
                            }
                            else
                            {
                                btnSender.BackColor = Color.Red;
                            }
                        }
                    };

                    x.MouseMove += X_MouseMove;
                    Controls.Add(x);
                }
            }
        }

        private void X_MouseMove(object? sender, MouseEventArgs e)
        {
            Text = $"{(sender as Button).Tag} : {e.X} {e.Y}";
        }

        private void B_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}