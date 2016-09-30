using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MADS_GUI
{
    public partial class MainWindow : Form
    {
        readonly string settingsFileLocation = "settings.ini";
        string coreLocation, moduleLocation;
        string[] potentialModules;
        ArrayList confirmedModules = new ArrayList();
        readonly string defaultCoreLocation = AppDomain.CurrentDomain.BaseDirectory; //"T:\\ecalc lab files\\Organized Fixes\\Updates"; //C:\\Users\\Trevor\\Updater\\"; //T:\\ecalc lab files\\Organized Fixes\\Updates";
        readonly string defaultModuleLocation = AppDomain.CurrentDomain.BaseDirectory; //"T:\\ecalc lab files\\Organized Fixes\\Updates"; //C:\\Users\\Trevor\\Updater\\"; //T:\\ecalc lab files\\Organized Fixes\\Updates";
        string[] scripts;
        bool DuplicateWarningShown = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Text = "MADS_GUI " + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
            try
            {
                var settingsFileLines = File.ReadAllLines(this.settingsFileLocation).ToList<string>();
                Regex settingsStmtFormat = new Regex(@"^(?<variableName>.+)\s+=\s+(?<variableValue>.+)$");
                foreach (string line in settingsFileLines)
                {
                    Console.WriteLine("Line: " + line);
                    var settingsStmtMatch = settingsStmtFormat.Match(line);
                    
                    if (settingsStmtMatch.Success)
                    {
                        Console.WriteLine("Variable Name: " + settingsStmtMatch.Groups["variableName"].Value);
                        if (settingsStmtMatch.Groups["variableName"].Value == "core")
                        {
                            Console.WriteLine("Setting Core Location to: " + settingsStmtMatch.Groups["variableValue"].Value);
                            coreLocation = settingsStmtMatch.Groups["variableValue"].Value;
                        }
                        else if (settingsStmtMatch.Groups["variableName"].Value == "modules")
                        {
                            Console.WriteLine("Setting Module Location to: " + settingsStmtMatch.Groups["variableValue"].Value);
                            moduleLocation = settingsStmtMatch.Groups["variableValue"].Value;
                        }
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File Not found, Using default");
                coreLocation = defaultCoreLocation;
                moduleLocation = defaultModuleLocation;
            }
            if (coreLocation == null)
            {
                coreLocation = defaultCoreLocation;
            }
            if (moduleLocation == null)
            {
                moduleLocation = defaultModuleLocation;
            }
            Console.WriteLine("Core Location: " + coreLocation);
            Console.WriteLine("Module Location: " + moduleLocation);
            try
            {
                potentialModules = Directory.GetDirectories(moduleLocation);
                scripts = Directory.GetFiles(coreLocation);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.Windows.Forms.MessageBox.Show("The Directory \"" + moduleLocation + "\" was not found, the program will now quit");
                Application.Exit();
                Environment.Exit(1);
            }
            Regex directoryStmtFormat = new Regex(@"^.*[\\](?<directoryName>.+)$");
            Regex scriptStmtFormat = new Regex(@"^.*[\\]room_(?<roomName>.+).ini$");
            //)((\s*$|\s+[!].*$)|(\s+(?<value>([#][$][0-9]*)|[$][0-9]*|[a-z0-9]*))(\s*$|\s+[!].*$))");
            //var labelStmtMatch = labelStmtFormat.Match(line);
            foreach (string directory in potentialModules)
            {
                Console.WriteLine("Directory: " + directory);
                var instructionStmtMatch = directoryStmtFormat.Match(directory);
                Console.WriteLine("Module Name: " + instructionStmtMatch.Groups["directoryName"].Value);
                if (File.Exists(directory + "\\" + instructionStmtMatch.Groups["directoryName"].Value + ".bat"))
                {
                    confirmedModules.Add(instructionStmtMatch.Groups["directoryName"].Value);
                    avaliableModules.Items.Add(instructionStmtMatch.Groups["directoryName"].Value);
                    Console.WriteLine("Valid Module: " + instructionStmtMatch.Groups["directoryName"].Value);
                }
            }
            foreach (string file in scripts)
            {
                Console.WriteLine("File: " + file);
                var scriptStmtMatch = scriptStmtFormat.Match(file);
                if (scriptStmtMatch.Success)
                {
                    Console.WriteLine("Script Name: " + scriptStmtMatch.Groups["roomName"].Value);
                    rooms.Items.Add(scriptStmtMatch.Groups["roomName"].Value);
                }
            }
            avaliableModules.Sorted = true;
            rooms.Sorted = true;

        }

        private void runningModules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedModules.Items.Contains(avaliableModules.SelectedItem) && !DuplicateWarningShown)
            {
                System.Windows.Forms.MessageBox.Show("You have already added this module\nIt will be added again, however please note that reordering duplicate entries may have undesired effects");
                DuplicateWarningShown = true;
            }
            selectedModules.Items.Add(avaliableModules.GetItemText(avaliableModules.SelectedItem));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedModules.Items.Remove(selectedModules.SelectedItem);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = coreLocation;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var Lines = ScriptRW.readfile(ofd.FileName);
                        selectedModules.Items.Clear();
                        Regex scriptStmtFormat = new Regex(@"^\s(?<args>.*)$");
                        foreach (string line in Lines)
                        {
                            Console.WriteLine("Line: " + line);
                            var instructionStmtMatch = scriptStmtFormat.Match(line);

                            if (instructionStmtMatch.Success)
                            {
                                Console.WriteLine("args: " + instructionStmtMatch.Groups["args"].Value);
                                string[] args = instructionStmtMatch.Groups["args"].Value.Split(' ');
                                foreach (string arg in args)
                                {
                                    selectedModules.Items.Add(arg);
                                }
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        System.Windows.Forms.MessageBox.Show("Unable to Open File\nDetails:\n" + err);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            // only if the first item isn't the current one
            if (runningModules.IndexFromPoint( > 0)
            {
                // add a duplicate item up in the listbox
                runningModules.Items.Add(runningModules.Text, runningModules.ListIndex - 1);
                // make it the current item
                runningModules.ListIndex = (listBox1.ListIndex - 2);
                // delete the old occurrence of this item
                runningModlues.RemoveItem(listBox1.ListIndex + 2);
            }
             */
            MoveUp();

        }

        public void MoveUp()
        {
            MoveItem(-1);
        }

        public void MoveDown()
        {
            MoveItem(1);
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (selectedModules.SelectedItem == null || selectedModules.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = selectedModules.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= selectedModules.Items.Count)
                return; // Index out of range - nothing to do

            object selected = selectedModules.SelectedItem;

            // Removing removable element
            selectedModules.Items.Remove(selected);
            // Insert it in new position
            selectedModules.Items.Insert(newIndex, selected);
            // Restore selection
            selectedModules.SetSelected(newIndex, true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MoveDown();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] modules = new string[selectedModules.Items.Count];
            int i = 0;
            foreach (string module in selectedModules.Items)
            {
                modules[i] = module;
                i++;
            }
            string writenToRooms = "";
            foreach (string room in rooms.CheckedItems)
            {
                    ScriptRW.writefile(coreLocation + "\\" + "room_" + room + ".ini", modules);
                    writenToRooms = writenToRooms + "\"" +room + "\" ";
            }
            System.Windows.Forms.MessageBox.Show("room(s): " + writenToRooms + "has/have been updated with the new configuration");
        }

        private void About_Button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Program: Update Selector\nVersion: " + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion + "\nCreated By: Trevor Buttrey");
            //System.Windows.Forms.MessageBox.Show(FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion);
        }

        private void New_Script_Click(object sender, EventArgs e)
        {
            //TODO: create new room ini file
            // Create a new instance of the Room_Namer class
            Room_Namer NamerForm = new Room_Namer();

            // Show the settings form
            //NamerForm.Show();
            NamerForm.ShowDialog();
            if (NamerForm.textAccepted)
            {
                if (!rooms.Items.Contains(NamerForm.textValue))
                {
                    ScriptRW.createfile(NamerForm.textValue);
                    refresh_room();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Room Already Exists");
                }
            }
            NamerForm.Dispose();
        }
    }
}
