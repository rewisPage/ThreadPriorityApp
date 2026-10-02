# Thread Priority Tracker (`frmTrackThread`)

A C# Windows Forms application developed for **IT1811 (Operating Systems / Multithreading)** demonstrating the life cycle of threads, multithreading, and thread priority scheduling using `System.Threading`.

<img width="923" height="659" alt="image" src="https://github.com/user-attachments/assets/2d795bc8-6fb1-46ae-baba-2f2779c1d308" />

<img width="921" height="397" alt="image" src="https://github.com/user-attachments/assets/981ea1e1-49d3-433c-9e44-71b98e00d558" />

---

## 📌 Project Overview

This project showcases how concurrent threads execute, yield, sleep, and terminate based on thread priority levels assigned by the runtime. The GUI triggers the threads, while an allocated native console session displays real-time execution outputs.

### Objectives
* Distinguish a thread from a process.
* Describe and demonstrate multithreading in C#.
* Observe the impact of thread priority settings (`Highest`, `AboveNormal`, `Normal`, `BelowNormal`) and thread synchronization using `.Join()`.

---

## 🛠️ Features & Thread Specifications

### Thread Configuration Matrix

| Thread Identifier | Target Method | Assigned Priority | Loop Count | Sleep Interval |
| :--- | :--- | :--- | :--- | :--- |
| **`threadA`** | `MyThreadClass.Thread1` | `ThreadPriority.Highest` | 3 iterations (0 to 2) | 500 ms (0.5s) |
| **`threadB`** | `MyThreadClass.Thread2` | `ThreadPriority.Normal` | 6 iterations (0 to 5) | 1500 ms (1.5s) |
| **`threadC`** | `MyThreadClass.Thread1` | `ThreadPriority.AboveNormal` | 3 iterations (0 to 2) | 500 ms (0.5s) |
| **`threadD`** | `MyThreadClass.Thread2` | `ThreadPriority.BelowNormal` | 6 iterations (0 to 5) | 1500 ms (1.5s) |

### Key Implementation Details
1. **Dynamic Console Allocation**: Utilizes `[DllImport("kernel32.dll")]` to call `AllocConsole()`, enabling real-time standard output tracking from within a Windows Forms lifecycle.
2. **Deterministic Lifecycle Synchronization**: Uses `.Join()` to halt caller progression until worker threads have safely finished execution.
3. **State Reflection**: Dynamically updates the form interface label (`-Thread Starts-` to `-End of Thread-`).

---

## 📂 Project Structure

```text
├── frmTrackThread.cs          # Form logic, P/Invoke console allocation, thread instantiations
├── frmTrackThread.Designer.cs # UI layout controls (lblStatus, btnRun)
├── MyThreadClass.cs           # Static thread methods (Thread1, Thread2)
├── Program.cs                 # Main application entry point
└── README.md                  # Project documentation
```

---

## 💻 Source Code Reference

### 1. Worker Class (`MyThreadClass.cs`)

```csharp
using System;
using System.Threading;

namespace ThreadPriorityApp
{
    public class MyThreadClass
    {
        public static void Thread1()
        {
            for (int loopCount = 0; loopCount <= 2; loopCount++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + loopCount);
                Thread.Sleep(500);
            }
        }

        public static void Thread2()
        {
            for (int loopCount = 0; loopCount <= 5; loopCount++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process = " + loopCount);
                Thread.Sleep(1500);
            }
        }
    }
}
```

### 2. Main Form Execution (`frmTrackThread.cs`)

```csharp
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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
            lblStatus.Text = "-Thread Starts-";

            Thread threadA = new Thread(new ThreadStart(MyThreadClass.Thread1));
            Thread threadB = new Thread(new ThreadStart(MyThreadClass.Thread2));
            Thread threadC = new Thread(new ThreadStart(MyThreadClass.Thread1));
            Thread threadD = new Thread(new ThreadStart(MyThreadClass.Thread2));

            threadA.Name = "Thread A";
            threadB.Name = "Thread B";
            threadC.Name = "Thread C";
            threadD.Name = "Thread D";

            threadA.Priority = ThreadPriority.Highest;
            threadB.Priority = ThreadPriority.Normal;
            threadC.Priority = ThreadPriority.AboveNormal;
            threadD.Priority = ThreadPriority.BelowNormal;

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            Console.WriteLine("-End of Thread-");
            lblStatus.Text = "-End of Thread-";
        }
    }
}
```

---

## 🖥️ Expected Output

### Console Window Output
```text
-Thread Starts-
Name of Thread: Thread A Process = 0
Name of Thread: Thread C Process = 0
Name of Thread: Thread B Process = 0
Name of Thread: Thread D Process = 0
Name of Thread: Thread C Process = 1
Name of Thread: Thread A Process = 1
Name of Thread: Thread A Process = 2
Name of Thread: Thread C Process = 2
Name of Thread: Thread B Process = 1
Name of Thread: Thread D Process = 1
Name of Thread: Thread D Process = 2
Name of Thread: Thread B Process = 2
Name of Thread: Thread B Process = 3
Name of Thread: Thread D Process = 3
Name of Thread: Thread D Process = 4
Name of Thread: Thread B Process = 4
Name of Thread: Thread D Process = 5
Name of Thread: Thread B Process = 5
-End of Thread-
```

### Windows Form States
* **Initial / Executing**: Shows `-Thread Starts-` above the **Run** button.
* **Finished**: Updates label to `-End of Thread-` immediately after all four joined threads terminate.

---

## ⚙️ How to Run

1. Clone this repository:
   ```bash
   git clone [https://github.com/your-username/ThreadPriorityApp.git](https://github.com/your-username/ThreadPriorityApp.git)
   ```
2. Open the solution (`.sln`) in **Visual Studio 2015 or higher**.
3. Build the project (**Ctrl + Shift + B**).
4. Run the application (**F5**).
5. Click **Run** on the form to spawn the threads and track execution order in the attached console.
