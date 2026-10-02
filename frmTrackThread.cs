using System.Runtime.InteropServices;

namespace ThreadPriorityApp
{
    public partial class frmTrackThread : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        public frmTrackThread()
        {
            InitializeComponent();
            AllocConsole();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Console.WriteLine("-Thread Starts-");


            // Define child threads pointing to MyThreadClass static methods
            Thread threadA = new Thread(new ThreadStart(MyThreadClass.Thread1));
            Thread threadB = new Thread(new ThreadStart(MyThreadClass.Thread2));
            Thread threadC = new Thread(new ThreadStart(MyThreadClass.Thread1));
            Thread threadD = new Thread(new ThreadStart(MyThreadClass.Thread2));

            // Assign thread names
            threadA.Name = "Thread A";
            threadB.Name = "Thread B";
            threadC.Name = "Thread C";
            threadD.Name = "Thread D";

            // Assign thread priorities according to instructions
            threadA.Priority = ThreadPriority.Highest;
            threadB.Priority = ThreadPriority.Normal;
            threadC.Priority = ThreadPriority.AboveNormal;
            threadD.Priority = ThreadPriority.BelowNormal;

            // Start all threads
            lblStatus.Text = "Excecuting . . .";
            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            // Wait for all threads to terminate using Join()
            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            // Update UI and Console after threads terminate
            Console.WriteLine("-End of Thread-");
            lblStatus.Text = "End of Thread";
        }
    }
}
