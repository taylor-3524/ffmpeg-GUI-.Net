using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ffmpeg_GUI
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }
        RunCmd runcmd = new RunCmd();
        private static string path = @"./";
        DirectoryInfo folder = new DirectoryInfo(path);
        static bool flag = false;
        static bool flagOrigin = false;
        static bool flagExport = false;
        private void Form1_Load(object sender, EventArgs e)
        {

           
            foreach (FileInfo file in folder.GetFiles("*.exe"))
            {
                if (file.Name.Equals("ffmpeg.exe"))
                {
                    flag = true;
                }
                Console.WriteLine(file.Name);
            }
            if (flag)
            {
                MessageBox.Show("请将本程序（仅ffmpeg-GUI.exe单个程序）拷贝至需要编辑的媒体文件目录中！\n请确保 C:\\Windows\\System32 下有 ffmpeg.exe 文件！\n否则请将压缩包内的 ffmpeg.exe 移动至C:\\Windows\\System32");
            }
     
        }

        private void label1_Click(object sender, EventArgs e)
        {
              
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "状态：执行中...";
            flagOrigin = false;
            flagExport = false;
            string start = textBox1.Text;
            string end = textBox2.Text;
            string origin = textBox3.Text;
            string export = textBox4.Text;
            string commond;
            commond = "ffmpeg -ss " + start + " -to " + end + " -accurate_seek -i " + origin + " -codec copy -avoid_negative_ts 1 " + export;
            string output;
         
            foreach (FileInfo file in folder.GetFiles("*.*"))
            {
                if (file.Name.Equals(origin))
                {
                    flagOrigin = true;
                }
                if (file.Name.Equals(export))
                {
                    flagExport = true;
                }
                Console.WriteLine(file.Name);
            }

            if (flagOrigin){
                if (!flagExport){
                
                runcmd.run(commond, out output);
                MessageBox.Show("操作完成！");
                
                }else{
                    MessageBox.Show("目标文件已存在\n拒绝操作！");
                   
                }
            }else{
                MessageBox.Show("未找到媒体文件:" + origin + "\n请检查文件名及后缀是否正确");
            }
            label6.Text = "状态：空闲";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://blog.xn--i8s168f.cn/archives/441/");
        }

        private void change_Click(object sender, EventArgs e)
        {
            string end = textBox2.Text;
            textBox1.Text = end;
            textBox2.Text = "";
            textBox4.Text = "";
        }


        }
}
