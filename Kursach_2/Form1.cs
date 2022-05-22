using Kursach_2.Managers;

namespace Kursach_2
{
    public partial class Form1 : Form
    {
        List<Port> list = new List<Port>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host;
            int portStart;
            int portStop;
            int threads;

            string ip = textBox1.Text;
            host = ip;

            string startPort = textBox2.Text;

            int number1;
            bool resultStart = Int32.TryParse(startPort, out number1);

            if (resultStart)
            {
                portStart = int.Parse(startPort);
            }
            else
            {
                MessageBox.Show("Try Again NOOOOOB!!");
                return;
            }

            string endPort = textBox3.Text;

            int number2;
            bool resultEnd = Int32.TryParse(endPort, out number2);

            if (resultEnd)
            {
                portStop = int.Parse(endPort);
            }
            else
            {
                MessageBox.Show("Try Again NOOOOOB!!");
                return;
            }

            string threadsToRun = textBox4.Text;

            int number3;
            bool resultThreads = Int32.TryParse(threadsToRun, out number3);

            if (resultThreads)
            {
                threads = int.Parse(threadsToRun);
            }
            else
            {
                MessageBox.Show("Try Again NOOOOOB!!");
                return;
            }

            if (resultStart == true && resultEnd == true)
            {
                try
                {
                    portStart = int.Parse(startPort);
                    portStop = int.Parse(endPort);
                }
                catch
                {
                    return;
                }
            }
            if (resultThreads == true)
            {
                try
                {
                    threads = int.Parse(threadsToRun);
                }
                catch
                {
                    return;
                }
            }

            PortScanner ps = new PortScanner(host, portStart, portStop);
            list = ps.start(threads);
            dataGridView1.DataSource = list;
            MessageBox.Show("Scan finished!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}