using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using KeyAuth;*/
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PM_BYPASS
{
    public partial class Form2 : Form
    {
        private Point mouseOffset;
        private bool isMouseDown = false;

        public Form2()
        {
            InitializeComponent();

        }

/*        public static api KeyAuthApp = new api(
            name: "",
            ownerid: "",
            secret: "",
            version: ""
        );*/
        private void Form2_Load(object sender, EventArgs e)
        {
            /*KeyAuthApp.init();*/
            this.MouseDown += FormMouseDown;
            this.MouseUp += FormMouseUp;
            this.MouseMove += FormMouseMove;
        }
        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                mouseOffset = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {

                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePos;
            }
        }


        public void CommandLine(string arg)
        {
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + @"\cmd.exe";
            startInfo.Arguments = "/c" + arg;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        private void label14_Click(object sender, EventArgs e)// CLOSE BUTTON
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) // FIREWALL ON
        {
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 8080 Outbound\" dir=out action=block protocol=TCP remoteport=8080");
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 8080 Inbound\" dir=in action=block protocol=TCP localport=8080");
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 443 Outbound\" dir=out action=block protocol=TCP remoteport=443");
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 443 Inbound\" dir=in action=block protocol=TCP localport=443");
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 17500 Outbound\" dir=out action=block protocol=TCP remoteport=17500");
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 17500 Inbound\" dir=in action=block protocol=TCP localport=17500");
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 80 Outbound\" dir=out action=block protocol=TCP remoteport=80");
            CommandLine("netsh advfirewall firewall add rule name=\"Block Port 80 Inbound\" dir=in action=block protocol=TCP localport=80");
            MessageBox.Show("FIREWALL ON!");
        }

        private void button3_Click(object sender, EventArgs e) // EMULATOR START
        {
            string start = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Tencent\MobileGamePC\UI", "InstallPath", "").ToString();
            label12.Text = "STARTING EMULATOR";

            try
            {
                Process.Start(Path.Combine(start, "AndroidEmulatorEx.exe"), "-vm 100");
            }
            catch
            {
                MessageBox.Show("Emulator not found! Please Start it manually");
                label12.Text = "Something went wrong!!";
            }
        }

        private void button1_Click(object sender, EventArgs e) // START GAME
        {
            string currentDirectory = @"C:\Temp\TxGameDownload\MobileGamePCShared";

            byte[] result = { };
            byte[] result1 = { }; 
            byte[] result2 = { };

            SaveFile(currentDirectory, "libbatmodsbp.so", result);
            SaveFile(currentDirectory, "libhdmpve.so", result1);
            SaveFile(currentDirectory, "libHEXORxANDROID.so", result2);

            currentDirectory = @"C:/Temp/TxGameDownload/MobileGamePCShared";

            CommandLine("adb kill-server");
                CommandLine("adb start-server");
                CommandLine("adb shell rm -rf /data/media/0/.backups");
                CommandLine("adb shell rm -rf /data/media/0/BGMI");
                CommandLine("adb shell rm -rf /data/media/0/MidasOversea");
                CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/*.json");
                CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/LobbyBubble");
                CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Lobby");
                CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Login");
                CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/*.sav");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_cache");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_crashrecord");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_crashSight");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_databases");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_flutter");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_geolocation");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_textures");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_webview");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/cache");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/code_cache");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/files/*");
                CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/no_backup");
                CommandLine($"adb push {currentDirectory}./libhdmpve.so /data/app/com.pubg.imobile-1/lib/arm/");
                CommandLine($"adb push{currentDirectory}./libHEXORxANDROID.so /data/app/com.pubg.imobile-1/lib/arm/");
                CommandLine($"adb push {currentDirectory}./libbatmodsbp.so /data/app/com.pubg.imobile-1/lib/arm/");
                // Launch the target application on the Android device
                CommandLine("adb shell am start -n com.pubg.imobile/com.epicgames.ue4.SplashActivity");

            Thread.Sleep(4000);
            MessageBox.Show("BYPASS DONE! ENJOY");
            label12.Text = "ANTICHEAT PATCHED SUCCESSFULLY";
        }
        private static void SaveFile(string directory, string fileName, byte[] content)
            {
                string filePath = Path.Combine(directory, fileName);
                File.WriteAllBytes(filePath, content);
            }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e) // FIREWALL OFF
        {
            MessageBox.Show("FIREWALL OFF!");
        }

        private void button5_Click(object sender, EventArgs e) // safe exit
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("AppMarket"))
                {
                    proc.Kill();
                    proc.Kill();
                }

                foreach (Process proc in Process.GetProcessesByName("AppMarket.exe"))
                {
                    proc.Kill();
                    proc.Kill();
                }

                foreach (Process proc in Process.GetProcessesByName("AndroidEmulatorEx.exe"))
                {
                    proc.Kill();
                    proc.Kill();
                }

                foreach (Process proc in Process.GetProcessesByName("AndroidEmulatorEx"))
                {
                    proc.Kill();
                    proc.Kill();
                }

                MessageBox.Show("SAFE EXIT DONE!");
            }
            catch
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e) // CLEAR LOGS
        {
            CommandLine("adb shell rm -rf /data/media/0/.backups");
            CommandLine("adb shell rm -rf /data/media/0/BGMI");
            CommandLine("adb shell rm -rf /data/media/0/MidasOversea");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/*.json");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/LobbyBubble");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Lobby");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Login");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/*.sav");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_cache");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_crashrecord");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_crashSight");
            CommandLine("adb shell rm -rf /data/data/com.tencent.ig/app_databases");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_flutter");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_geolocation");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_textures");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/app_webview");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/cache");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/code_cache");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/files/*");
            CommandLine("adb shell rm -rf /data/data/com.pubg.imobile/no_backup");
            CommandLine("adb shell rm -rf /storage/emulated/0/mfcache/com.pubg.imobile.cache");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/cache");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Intermediate");
            CommandLine("adb shell rm -rf /storage/emulated/0/Android/data/com.pubg.imobile/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Demos/UserReplay");
            MessageBox.Show("LOGS CLEANED!");

        }

        private void button2_Click_1(object sender, EventArgs e) // RESET EMULATOR
        {

        }

        private void button4_Click_1(object sender, EventArgs e) // RESET GUEST
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    
}
