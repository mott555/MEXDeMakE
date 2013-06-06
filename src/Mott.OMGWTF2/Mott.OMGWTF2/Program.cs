/* Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)
 * Copyright (C) 2013 mott555
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Mott.OMGWTF2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = (string)MyMethod("i18n", "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)", "english");
            Console.WriteLine((string)MyMethod("i18n", "Welcome to Mott's Enterprise XML Decision-Making Engine (MEXDeMakE).", "english"));
            Console.WriteLine((string)MyMethod("i18n", "Copyright © 2013 mott555", "english"));
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write((string)MyMethod("i18n", "Performing hardware check...", "english"));
            // Sanity checks on hardware. Run multiple times to make sure.
            bool hardwarePass = false;
            for (int i = 0; i < 10; i++)
            {
                hardwarePass = (bool)MyMethod(HARDWARE_TEST, 1);
                if (hardwarePass == false)
                {
                    Console.WriteLine((string)MyMethod("i18n", "Hardware failure.", "english"));
                    return;
                }
            }
            if (hardwarePass)
                Console.WriteLine((string)MyMethod("i18n", "Pass.", "english"));

            // Get config.
            string config = null;
            List<string> decisions = null;
            List<string> tags = null;
            int workFactor = 1;
            int serverPort = 0;
            string server = null;
            string lang = null;
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write((string)MyMethod("i18n", "Loading EnterpriseConfig.xml...", "english"));
                        config = (string)MyMethod(intGetConfig);
                        Console.WriteLine((string)MyMethod("i18n", "Complete.", "english"));
                        break;
                    case 1:
                        Console.Write((string)MyMethod("i18n", "Loading decision values...", "english"));
                        decisions = (List<string>)MyMethod(getDecisionValues, config);
                        Console.WriteLine((string)MyMethod("i18n", "Complete.", "english"));
                        break;
                    case 2:
                        Console.Write((string)MyMethod("i18n", "Loading entropy data set...", "english"));
                        tags = (List<string>)MyMethod(getTags);
                        Console.WriteLine((string)MyMethod("i18n", "Complete.", "english"));
                        break;
                    case 3:
                        Console.Write((string)MyMethod("i18n", "Configuring work factor...", "english"));
                        workFactor = (int)MyMethod(getWorkFactor, config);
                        Console.WriteLine((string)MyMethod("i18n", "Complete.", "english"));
                        break;
                    case 4:
                        serverPort = (int)MyMethod("getPort", config);
                        break;
                    case 5:
                        Console.Write((string)MyMethod("i18n", "Launching server...", "english"));
                        MyMethod("launchServer", serverPort);
                        Console.WriteLine((string)MyMethod("i18n", "Complete.", "english"));
                        break;
                    case 6:
                        server = (string)MyMethod("getServer", config);
                        break;
                    case 7:
                        TcpClient tcp = new TcpClient();
                        tcp.Connect(server, serverPort);
                        NetworkStream nets = tcp.GetStream();
                        myReader = new StreamReader(nets);
                        myWriter = new StreamWriter(nets);
                        break;
                    case 9:
                        lang = (string)MyMethod("getLang", config);
                        break;
                    default: break;
                }
            }

            Console.WriteLine((string)MyMethod("i18n", "Initializing menu...Complete.", "english"));

            Console.WriteLine();
            MyMethod(menu, tags, decisions, workFactor, lang);
        }

        // Easy fix for typoes.
        const bool fasle = false;

        // Method control constants.
        const int getTags = 1;
        const int getDecisionValues = 2;
        const int intGetConfig = 14;
        const int getWorkFactor = 88;
        const int HARDWARE_TEST = 6;
        const int growArray = 9;
        const int INT_GET_TAG_PAGE = 890;
        const int doShutdown = 888;
        const string generateRandomNo = "gen";
        const int menu = 567; // Opens the menu.
        const int pausAndCool = 789;
        static int sleepThenClose = 999999;
        static string getShutdownThread = "shutdownThread";
        static string getShutdownThreadStart = "sts";

        // Other usful constants.
        static string strLiLength = "3";
        const string notUsed = "zzzzz";
        const string tagPage = "http://forums.thedailywtf.com/tags/default.aspx";
        const int INT_TWENTY_SEVEN = 27;
        static DateTime ProgramStart = DateTime.Now;

        /// <summary>
        /// Main method, does most of the app's processing.
        /// 
        /// Easily extensible. Just add to the switch statement.
        /// </summary>
        /// <param name="args">Method arguments.</param>
        /// <returns>Varies, depends on what was in args. Just read the code,
        /// code is the best documentation.</returns>
        static object MyMethod(params object[] args)
        {
            try
            {
                switch ((int)args[0])
                {
                    case 1: // get tags from tdwtf
                        for (int i = 0; i < 1; i++)
                        {
                            WebClient wc = new WebClient();
                            string tagLoc = (string)MyMethod(INT_GET_TAG_PAGE);
                            string data = wc.DownloadString(tagLoc as string);


                            bool tagCouldFound = false;
                            int position = 0;
                            while (!tagCouldFound)
                            {
                                string substring = data.Substring(position, INT_TWENTY_SEVEN).ToLower();
                                if (substring == "<ul class=\"commontagcloud\">")
                                    tagCouldFound = true;
                                position = incrementIntegr(position);
                            }
                            List<string> tags = new List<string>();

                            try
                            {
                                bool liFoudn = false;
                                bool aFound = fasle;
                                bool endOfAFoudn = false;
                                bool boolEndOfTags = false;

                                while (!boolEndOfTags)
                                {
                                    liFoudn = false;
                                    aFound = fasle;
                                    endOfAFoudn = false;
                                    while (!liFoudn || liFoudn == false)
                                    {
                                        string substring = data.Substring(position, int.Parse(strLiLength));
                                        if (substring == "<li")
                                            liFoudn = true;
                                        position = incrementIntegr(position);
                                    }
                                    // Loop while a tag is not found.
                                    while (!aFound)
                                    {
                                        string substring1 = data.Substring(position, int.Parse(2.ToString()));
                                        if (substring1 == "<a")
                                            aFound = true;
                                        position = incrementIntegr(position);
                                    }
                                    // Another loop.
                                    while (!endOfAFoudn)
                                    {
                                        string substring2 = data.Substring(position, 1);
                                        if (substring2 == ">")
                                            endOfAFoudn = true;
                                        position = incrementIntegr(position);
                                    }
                                    string tag = "";

                                    bool end = fasle;
                                    while (!end)
                                    {
                                        char character = data[position];
                                        if (character == '<')
                                            end = !end;
                                        else
                                        {
                                            {
                                                tag += character;
                                            }
                                        }
                                        position = incrementIntegr(position);
                                    }
                                    tags.Add(tag);
                                    if (data.Substring(position).ToString().StartsWith("</ul>"))
                                        boolEndOfTags = true;
                                }
                                return tags;
                            }
                            catch
                            {
                                return tags;
                            }
                        }
                        break;
                    case 22:
                        GC.Collect();
                        break;
                    case 14:
                        string fileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                        int lastSlash = fileName.LastIndexOf('\\');
                        fileName = fileName.Substring(0, lastSlash);
                        fileName = fileName + "\\EnterpriseConfig.xml";
                        StreamReader read = new StreamReader(fileName);
                        string file = "";
                        try
                        {
                            // Can handle files up to 1000 lines
                            for (int anInt = 0; anInt < 1000; anInt++)
                            {
                                file += read.ReadLine();
                            }
                        }
                        catch { }
                        
                        return file;
                        break;
                    case 789:
                        System.Threading.Thread.Sleep(10000);
                        break;
                    case 9:
                        object[] arr = (object[])args[1];
                        object[] arr2 = new object[arr.Length + 1];
                        for (int i = 0; i < arr.Length; i = incrementIntegr(i))
                        {
                            object myItem = arr[i];
                            arr2[i] = myItem;
                        }
                        return arr2;
                        break;
                    case 567:
                        {                            
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string lang = (string)args[4];

                            StringBuilder strings = new StringBuilder();
                            strings.Append((string)MyMethod("i18n", "Please select from these menu items.\n", lang));
                            strings.Append((string)MyMethod("i18n", " 1: Generate Decision\n", lang));
                            strings.Append((string)MyMethod("i18n", " 2: Exit\n", lang));
                            strings.Append((string)MyMethod("i18n", " 3: Show decision values\n", lang));
                            strings.Append((string)MyMethod("i18n", " 4: Show entropy data set\n", lang));
                            strings.Append((string)MyMethod("i18n", " 5: Edit enterprise configuration\n", lang));
                            strings.Append((string)MyMethod("i18n", " 6: Show menu\n", lang));
                            strings.Append((string)MyMethod("i18n", " 7: Show time\n", lang));
                            strings.Append((string)MyMethod("i18n", " 8: About\n", lang));
                            strings.Append((string)MyMethod("i18n", "\n", lang));
                            Console.Write(strings);
                            string line = Console.ReadLine();

                            if (line == "1")
                            {
                                MyMethod(568, tagList, decisionList, workFactor, lang);
                            }
                            if (line == "2")
                            {
                                MyMethod(569);
                            }
                            if (line == "3")
                            {
                                MyMethod(560, tagList, decisionList, workFactor, lang);
                                
                            }
                            if (line == "4")
                            {
                                MyMethod(987654321, tagList, decisionList, workFactor, lang);
                            }
                            if (line == "5")
                            {
                                MyMethod(561, tagList, decisionList, workFactor, lang);
                                
                            }
                            if (line == "6")
                            {
                                MyMethod(562, tagList, decisionList, workFactor, lang);
                                
                            }
                            if (line == "8")
                            {
                                MyMethod(563, tagList, decisionList, workFactor, lang);
                            }
                            else
                            {
                                MyMethod(564, tagList, decisionList, workFactor, lang);
                            }
                        }
                        break;
                    case 568:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string lang1 = (string)args[4];

                            StringBuilder strings = new StringBuilder();
                            strings.Append((string)MyMethod("i18n", "Generating decision...", lang1));
                            Console.Write(strings);

                            myWriter.WriteLine(workFactor);
                            int decisionCount = (int)MyMethod(7764, decisionList);
                            myWriter.WriteLine(decisionCount);
                            try
                            {
                                for (int asdf = 0; asdf < 100000; asdf++)
                                {
                                    string d = decisionList[asdf];
                                    myWriter.WriteLine(d);
                                }
                            }
                            catch { }
                            int tagCount = (int)MyMethod(7764, tagList);
                            myWriter.WriteLine(tagCount);
                            try
                            {
                                for (int asdf = 0; asdf < 100000; asdf++)
                                {
                                    string d = tagList[asdf];
                                    myWriter.WriteLine(d);
                                }
                            }
                            catch { }
                            myWriter.Flush();

                            string decision = myReader.ReadLine();
                            strings = new StringBuilder();
                            strings.Append((string)MyMethod("i18n", "Complete.\n", lang1));
                            strings.Append((string)MyMethod("i18n", "Decision is\n", lang1));
                            strings.Append("  " + decision.ToString() + "\n");
                            strings.Append((string)MyMethod("i18n", "\n", lang1));
                            strings.Append((string)MyMethod("i18n", "Press any key to return to the menu.\n", lang1));
                            Console.Write(strings);
                            Console.ReadKey();
                            MyMethod(notUsed);

                            MyMethod(menu, tagList, decisionList, workFactor, lang1);

                            break;
                        }
                    case 569:
                        {
                            MyMethod(doShutdown);
                            break;
                        }
                    case 560:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string lang2 = (string)args[4];
                            string myConfigFile = (string)MyMethod(intGetConfig);
                            List<string> possibleDecisions = (List<string>)MyMethod(2, myConfigFile);
                            var listEnum = possibleDecisions.GetEnumerator();
                            StringBuilder strings;
                            while (listEnum.MoveNext())
                            {
                                strings = new StringBuilder();
                                strings.Append(listEnum.Current);
                                strings.Append((string)MyMethod("i18n", "\n", lang2));
                                Console.Write(strings);
                            }
                            strings = new StringBuilder();
                            strings.Append((string)MyMethod("i18n", "Press any key to return to the menu.\n", lang2));
                            Console.Write(strings);
                            Console.ReadKey();
                            MyMethod(notUsed);
                            // Console.Write(strings);
                            //Console.ReadKey();
                            MyMethod(notUsed);

                            MyMethod(menu, tagList, decisionList, workFactor, lang2);

                            break;
                        }
                    case 561:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string lang3 = (string)args[4];
                            string fileName1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                            int lastSlash1 = fileName1.LastIndexOf('\\');
                            fileName1 = fileName1.Substring(0, lastSlash1);
                            fileName1 = fileName1 + "\\EnterpriseConfig.xml";
                            Process p = Process.Start("notepad", fileName1);
                            MyMethod(notUsed);
                            // Console.Write(strings);
                            //Console.ReadKey();
                            MyMethod(notUsed);

                            MyMethod(menu, tagList, decisionList, workFactor, lang3);
                            break;
                        }
                    case 562:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string lang4 = (string)args[4];
                            MyMethod(notUsed);
                            MyMethod(menu, tagList, decisionList, workFactor, lang4);

                            break;
                        }
                    case 563:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string lang5 = (string)args[4];
                            // Console.Write(strings);
                            //Console.ReadKey();
                            MyMethod(notUsed);
                            MyMethod(44444, lang5);
                            MyMethod(menu, tagList, decisionList, workFactor, lang5);
                            break;
                        }
                    case 564:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string lang = (string)args[4];
                            MyMethod(notUsed);
                            MyMethod(menu, tagList, decisionList, workFactor, lang);
                            break;
                        }
                    case 15:
                        string configFile = (string)args[1];
                        int position1 = 0;
                        bool bKeyFnd = fasle;
                        while (bKeyFnd != true)
                        {
                            string substring = configFile.Substring(position1, 26);
                            if (substring == "<add key=\"keyIncrementCfg\"")
                                bKeyFnd = true;
                            position1++;
                        }
                        bool valFound = false;
                        while (valFound != true)
                        {
                            string substring = configFile.Substring(position1, 7);
                            if (substring == "value=\"")
                            {
                                valFound = true;
                                position1 += 7;
                            }
                            else
                            {
                                position1++;
                            }
                        }
                        string value = "";
                        bool endOfV = fasle;
                        while (endOfV != true)
                        {
                            string substring = configFile.Substring(position1, 1);
                            if (substring == "\"")
                                endOfV = true;
                            else
                                value += substring;
                            position1++;
                        }
                        return int.Parse(value);
                        break;
                    case 90:
                        Assembly systemAssembly = Assembly.GetAssembly(typeof(String));
                        Type type = systemAssembly.GetType("System.Random");
                        ConstructorInfo ci = type.GetConstructor(new Type[] { });
                        dynamic random = ci.Invoke(null);
                        return random.Next();
                        break;
                    case 91:
                        return incrementIntegr((int)args[1]);
                        break;
                    case 890:
                        return "http://forums.thedailywtf.com/tags/default.aspx";
                        break;
                    case 7764:
                        List<string> theList = (List<string>)args[1];
                        int lsitCount = 0;
                        try
                        {
                            for (int asdf = 0; asdf < 100000; asdf++)
                            {
                                string anItem = theList[asdf];
                                lsitCount++;
                            }
                        }
                        catch { }
                        return lsitCount;
                        break;
                    case getDecisionValues: // get decision values
                        string configFile1 = (string)args[1];
                        int position2 = 0;
                        bool bKeyFnd1 = fasle;
                        while (bKeyFnd1 != true)
                        {
                            string substring = configFile1.Substring(position2, 20);
                            if (substring == "<add key=\"decisions\"")
                                bKeyFnd1 = true;
                            position2++;
                        }
                        bool valFound1 = false;
                        while (valFound1 != true)
                        {
                            string substring = configFile1.Substring(position2, 7);
                            if (substring == "value=\"")
                            {
                                valFound1 = true;
                                position2 += 7;
                            }
                            else
                            {
                                position2++;
                            }
                        }
                        bool endOfV2 = fasle;
                        object[] values = new object[0];
                        string value2 = "";
                        while (endOfV2 != true)
                        {
                            string substring = configFile1.Substring(position2, 1);
                            if (substring == "\"")
                            {
                                values = (object[])MyMethod(growArray, values);
                                values[values.Length - 1] = value2;
                                value2 = "";
                                endOfV2 = true;
                            }
                            else if (substring == ",")
                            {
                                values = (object[])MyMethod(growArray, values);
                                values[values.Length - 1] = value2;
                                value2 = "";
                            }
                            else
                            {
                                value2 += substring;
                            }
                            position2++;
                        }
                        List<string> valuesAsStrings = (List<string>)MyMethod(convToString, values);
                        return valuesAsStrings;
                        break;
                    case 42:
                        Console.WriteLine((string)MyMethod("i18n", "You just found the answer!", "english"));
                        break;
                    case 33333:
                        object[] myArr1 = (object[])args[1];
                        List<string> myStrings = new List<string>();
                        for (int i = 0; i < myArr1.Length; i = (int)MyMethod(91, i))
                        {
                            object objValue = myArr1[i];
                            string strValue = (string)objValue;
                            myStrings.Add(strValue);
                        }
                        return myStrings;
                        break;
                    case 6:
                        int numTests = (int)args[1];
                        for (int testIt = 0; testIt < numTests; testIt++)
                        {
                            if (System.Environment.ProcessorCount < 1)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid processor count, please run this on a computer that has at least one processor.", "english"));
                                return false;
                            }
                            if (System.Environment.TickCount < 0)
                            {
                                throw new Exception((string)MyMethod("i18n", "Computer time problems.", "english"));
                                return false;
                            }
                            if (DateTime.Now < ProgramStart)
                            {
                                throw new Exception((string)MyMethod("i18n", "Computer time problems.", "english"));
                                return false;
                            }
                            // Make sure hardware ALU works.
                            if (1 + 1 != 2)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid math result.", "english"));
                                return false;
                            }
                            if (2 + 2 != 4)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid math result.", "english"));
                                return false;
                            }

                            /*
                             * Always happens, comment out for now.
                            if (3 + 3 != 7)
                            {
                                throw new Exception("Invalid math result.");
                             * return false;
                            }
                             * */
                            if (1 / 1 != 1)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid math result.", "english"));
                                return false;
                            }
                            if (2 / 1 != 2)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid math result.", "english"));
                                return false;
                            }
                            if (2 * 2 != 4)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid math result.", "english"));
                                return false;
                            }
                            if (108 - 10 != 98)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid math result.", "english"));
                                return false;
                            }
                            if (32 - 16 != 16)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid math result.", "english"));
                                return false;
                            }
                            if (true != true)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid boolean result.", "english"));
                                return false;
                            }
                            if (false != false)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid boolean result.", "english"));
                                return false;
                            }
                            if (true == false)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid boolean result.", "english"));
                                return false;
                            }
                            if (fasle == true)
                            {
                                throw new Exception((string)MyMethod("i18n", "Invalid boolean result.", "english"));
                                return false;
                            }

                        }
                        return true;
                        break;
                    case 44444:
                        StringBuilder myString1s = new StringBuilder();
                        string lang6 = (string)args[1];
                        myString1s.AppendLine((string)MyMethod("i18n", "About:", lang6));
                        myString1s.AppendLine((string)MyMethod("i18n", "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)", lang6));
                        myString1s.AppendLine((string)MyMethod("i18n", "Copyright © 2013 mott555. All rights reserved.", lang6));
                        myString1s.AppendLine((string)MyMethod("i18n", "Version 2.1.2", lang6));
                        myString1s.AppendLine((string)MyMethod("i18n", "", lang6));
                        myString1s.AppendLine((string)MyMethod("i18n", "MEXDeMakE is an enterprise-ready decision-making engine built on industry-standard XML and network protocols. Just modify EnterpriseConfig.xml to match your business needs and MEXDeMakE will carefully analyze your requirements and generate advice to help you make your business decisions better and in a timely manner.", lang6));
                        myString1s.AppendLine((string)MyMethod("i18n", "", lang6));
                        myString1s.AppendLine((string)MyMethod("i18n", "Press enter to return to main menu.", lang6));
                        Console.WriteLine(myString1s);
                        Console.ReadLine();
                        break;
                    case 999999:
                        // Give garbate collector chance to run.
                        MyMethod(22);
                        System.Threading.Thread.Sleep(1500);
                        throw new Exception((string)MyMethod("i18n", "Normal application termination", "english"));
                        break;
                    case 100:
                        Stream theStream = (Stream)args[1];
                        StreamReader theReader = new StreamReader(theStream);

                        string strWorkFactor = theReader.ReadLine();
                        string strDecisionCount = theReader.ReadLine();
                        List<string> theDecisions = new List<string>();
                        int theCounter = 0;
                        while (theCounter < int.Parse(strDecisionCount))
                        {
                            theCounter++;
                            theDecisions.Add(theReader.ReadLine());
                        }
                        string strTagCount = theReader.ReadLine();
                        List<string> theTags = new List<string>();
                        while (theCounter < int.Parse(strDecisionCount) + int.Parse(strTagCount))
                        {
                            theCounter++;
                            theTags.Add(theReader.ReadLine());
                        }
                        string theDecision = (string)MyMethod(generateRandomNo, theTags, theDecisions, int.Parse(strWorkFactor));
                        StreamWriter theWriter = new StreamWriter(theStream);
                        theWriter.WriteLine(theDecision);
                        theWriter.Flush();
                        MyMethod(100, theStream);
                        break;
                    case 88:
                        string configFile2 = (string)args[1];
                        int position3 = 0;
                        bool bKeyFnd2 = fasle;
                        while (bKeyFnd2 != true)
                        {
                            string substring = configFile2.Substring(position3, 21);
                            if (substring == "<add key=\"workFactor\"")
                                bKeyFnd2 = true;
                            position3++;
                        }
                        bool valFound2 = false;
                        while (valFound2 != true)
                        {
                            string substring = configFile2.Substring(position3, 7);
                            if (substring == "value=\"")
                            {
                                valFound2 = true;
                                position3 += 7;
                            }
                            else
                            {
                                position3++;
                            }
                        }
                        string value3 = "";
                        bool endOfV3 = fasle;
                        while (endOfV3 != true)
                        {
                            string substring = configFile2.Substring(position3, 1);
                            if (substring == "\"")
                                endOfV3 = true;
                            else
                                value3 += substring;
                            position3++;
                        }
                        return int.Parse(value3);
                        break;
                    case printTags:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            string language = (string)args[4];
                            List<string> myTagValues = tagList.ToList();
                            var myTagEnumerator = myTagValues.GetEnumerator();
                            MyMethod(111111, tagList, decisionList, workFactor, myTagEnumerator, language);
                            
                            break;
                        }
                    case 111111:
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];
                            List<string>.Enumerator myEnumerator = (List<string>.Enumerator)args[4];
                            string lang = (string)args[5];

                            bool hasValue = myEnumerator.MoveNext();
                            if (hasValue == true)
                            {
                                StringBuilder mySb = new StringBuilder();
                                string myTag = myEnumerator.Current;
                                mySb.Append(myTag);
                                mySb.Append("\n");
                                Console.Write(mySb);
                                MyMethod(111111, tagList, decisionList, workFactor, myEnumerator, lang);
                            }
                            else if (hasValue == fasle)
                            {
                                Console.Write((string)MyMethod("i18n", "\n", lang));
                                Console.Write((string)MyMethod("i18n", "Press any key to return to the menu.\n", lang));
                                Console.ReadKey();
                                MyMethod(notUsed);

                                MyMethod(menu, tagList, decisionList, workFactor, lang);
                            }

                            break;
                        }
                    case 888:
                        Console.WriteLine((string)MyMethod("i18n", "Shutting down...", "english"));
                        // Keep UI responsive.
                        System.Threading.ThreadStart ts = (System.Threading.ThreadStart)MyMethod(getShutdownThreadStart);
                        System.Threading.Thread shutdownThread = (System.Threading.Thread)MyMethod(getShutdownThread, ts);
                        shutdownThread.Start();
                        break;
                    default:
                        return null; // Shut up the compiler.
                }
            }
            catch (Exception)
            {
                switch ((string)args[0])
                {
                    case "sts":
                        System.Threading.ThreadStart ts = () => 
                            { 
                                MyMethod(sleepThenClose);
                                MyMethod(sleepThenClose);
                            };
                        return ts;
                        break;
                    case "gen":
                        List<string> tags = (List<string>)args[1];
                        List<string> decisions = (List<String>)(args[2] as List<string>);
                        int workFactor = (int)args[3];

                        Random random = new Random((int)MyMethod(90));
                        for (int i = 0; i < Math.Pow(2, workFactor); i = incrementIntegr(i))
                        {
                            int seed = random.Next();

                            for (int k = 0; k < 30; k++)
                            {
                                int op = random.Next();
                                if (op.ToString().EndsWith("1"))
                                {
                                    int tmpSeed = seed + random.Next();
                                    seed = tmpSeed;
                                }
                                else if (op.ToString().EndsWith("2"))
                                {
                                    int tmpSeed = seed - random.Next();
                                    seed = tmpSeed;
                                }
                                else if (op.ToString().EndsWith("3"))
                                {
                                    string strSeed = seed.ToString();
                                    int index = random.Next(strSeed.Length);
                                    for (int ii = 0; ii < strSeed.Length; ii++)
                                    {
                                        if (ii == index)
                                        {
                                            string str1 = strSeed.Substring(0, ii);
                                            string str2 = strSeed.Substring(ii + 1);
                                            strSeed = str1 + str2;
                                        }
                                    }
                                    if (strSeed == "")
                                        strSeed = "0";
                                    int tmpSeed;
                                    int.TryParse(strSeed, out tmpSeed);
                                    tmpSeed = seed;
                                }
                                else if (op.ToString().EndsWith("4"))
                                {
                                    int tmpSeed = seed + random.Next() - seed;
                                    seed = tmpSeed;
                                }
                                else if (op.ToString().EndsWith("5"))
                                {
                                    int tmpSeed = seed * -1;
                                    seed = tmpSeed;
                                }
                                else if (op.ToString().EndsWith("6"))
                                {
                                    k = 0;
                                }
                                else if (op.ToString().EndsWith("7"))
                                {
                                    string strFloor = Math.Floor((double)seed).ToString();
                                    int dotIndex = strFloor.IndexOf(".");
                                    string strAsInt = "";
                                    bool dotFound = false;
                                    for (int kk = 0; kk < strFloor.Length; kk++)
                                    {
                                        if (kk == dotIndex)
                                        {
                                            dotFound = true;
                                        }
                                        if (dotFound == fasle)
                                        {
                                            strAsInt += strFloor[kk];
                                        }
                                    }
                                    int tmpSeed = int.Parse(strAsInt);
                                    seed = tmpSeed;
                                }
                                else if (op.ToString().EndsWith("8"))
                                {
                                    int tmpSeed = seed + ProgramStart.Second;
                                    seed = tmpSeed;
                                }
                                else
                                {
                                    int tmpSeed = seed / random.Next();
                                    seed = tmpSeed;
                                }
                            }

                            random = new Random(seed + random.Next());
                        }

                        // Random class isn't random enough. Use TDWTF tags for additional randomness.
                        for (int i = 0; i < Math.Pow(2, workFactor); i = incrementIntegr(i))
                        {
                            if (i.ToString().EndsWith("5"))
                            {
                                MyMethod("dot", true);
                            }
                            if (i.ToString().EndsWith("0"))
                            {
                                MyMethod("dot", true);
                            }
                            for (int k = 0; k < tags.Count; k = incrementIntegr(k))
                            {
                                int index = random.Next(tags.Count);
                                string first = tags[k];
                                string second = tags[index];
                                tags[k] = second;
                                tags[index] = first;
                            }

                            int hash = 0;
                            foreach (string tag in tags)
                            {
                                hash += tag.GetHashCode();
                            }
                            hash = (int)Math.Abs(hash);
                            hash = incrementIntegr(hash);
                            random = new Random(hash);

                            // Hardware check, CPU overheating may cause inaccurasy.
                            bool overheat = (bool)MyMethod(6, 1);
                            overheat = !overheat;
                            if (overheat == true)
                            {
                                // Pause for allow CPU can cooldwon.
                                MyMethod(789);
                            }
                        }

                        // Random is now randomer.
                        int tagIndex = random.Next(tags.Count);
                        string randomTag = tags[tagIndex];
                        int randomIndex = randomTag.Length % decisions.Count;
                        string decision = null;
                        for (int i = 0; i < decisions.Count; i = incrementIntegr(i))
                        {
                            if (i == randomIndex)
                                decision = decisions[i];
                            else
                                continue;
                        }
                        return decision;

                        break;
                    case "dot":
                        if ((bool)args[1] != fasle)
                        {
                            Console.Write(".");
                        }
                        break;
                    case notUsed:
                        Console.Clear();
                        break;
                    case "launchServer":
                        MyMethod("launchServerr", args[1]);
                        break;
                    case "getPort":
                        string configFile2 = (string)args[1];
                        int position3 = 0;
                        bool bKeyFnd2 = fasle;
                        while (bKeyFnd2 != true)
                        {
                            string substring = configFile2.Substring(position3, 21);
                            if (substring == "<add key=\"serverPort\"")
                                bKeyFnd2 = true;
                            position3++;
                        }
                        bool valFound2 = false;
                        while (valFound2 != true)
                        {
                            string substring = configFile2.Substring(position3, 7);
                            if (substring == "value=\"")
                            {
                                valFound2 = true;
                                position3 += 7;
                            }
                            else
                            {
                                position3++;
                            }
                        }
                        string value3 = "";
                        bool endOfV3 = fasle;
                        while (endOfV3 != true)
                        {
                            string substring = configFile2.Substring(position3, 1);
                            if (substring == "\"")
                                endOfV3 = true;
                            else
                                value3 += substring;
                            position3++;
                        }
                        return int.Parse(value3);
                        break;
                        break;
                    case "getLang":
                        string configFile3 = (string)args[1];
                        int position4 = 0;
                        bool bKeyFnd3 = fasle;
                        while (bKeyFnd3 != true)
                        {
                            string substring = configFile3.Substring(position4, 15);
                            if (substring == "<add key=\"lang\"")
                                bKeyFnd3 = true;
                            position4++;
                        }
                        bool valFound3 = false;
                        while (valFound3 != true)
                        {
                            string substring = configFile3.Substring(position4, 7);
                            if (substring == "value=\"")
                            {
                                valFound3 = true;
                                position4 += 7;
                            }
                            else
                            {
                                position4++;
                            }
                        }
                        string value4 = "";
                        bool endOfV4 = fasle;
                        while (endOfV4 != true)
                        {
                            string substring = configFile3.Substring(position4, 1);
                            if (substring == "\"")
                                endOfV4 = true;
                            else
                                value4 += substring;
                            position4++;
                        }
                        return value4;
                        break;
                        break;
                    case "i18n":
                        string text = (string)args[1];
                        string lang = (string)args[2];
                        if (text == "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)" && lang == "english")
                        {
                            return "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)";
                        }
                        else if (text == "Hardware failure." && lang == "english")
                        {
                            return "Hardware failure.";
                        }
                        else if (text == "Performing hardware check..." && lang == "english")
                        {
                            return "Performing hardware check...";
                        }
                        else if (text == "Welcome to Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)." && lang == "english")
                        {
                            return "Welcome to Mott's Enterprise XML Decision-Making Engine (MEXDeMakE).";
                        }
                        else if (text == "Copyright © 2013 mott555" && lang == "english")
                        {
                            return "Copyright © 2013 mott555";
                        }
                        else if (text == "Loading EnterpriseConfig.xml..." && lang == "english")
                        {
                            return "Loading EnterpriseConfig.xml...";
                        }
                        else if (text == "Complete." && lang == "english")
                        {
                            return "Complete.";
                        }
                        else if (text == "Pass." && lang == "english")
                        {
                            return "Pass.";
                        }
                        else if (text == "Loading decision values..." && lang == "english")
                        {
                            return "Loading decision values...";
                        }
                        else if (text == "Loading entropy data set..." && lang == "english")
                        {
                            return "Loading entropy data set...";
                        }
                        else if (text == "Configuring work factor..." && lang == "english")
                        {
                            return "Configuring work factor...";
                        }
                        else if (text == "Launching server..." && lang == "english")
                        {
                            return "Launching server...";
                        }
                        else if (text == "Initializing menu...Complete." && lang == "english")
                        {
                            return "Initializing menu...Complete.";
                        }
                        else if (text == "Please select from these menu items.\n" && lang == "english")
                        {
                            return "Please select from these menu items.\n";
                        }
                        else if (text == " 1: Generate Decision\n" && lang == "english")
                        {
                            return " 1: Generate Decision\n";
                        }
                        else if (text == " 2: Exit\n" && lang == "english")
                        {
                            return " 2: Exit\n";
                        }
                        else if (text == " 3: Show decision values\n" && lang == "english")
                        {
                            return " 3: Show decision values\n";
                        }
                        else if (text == " 4: Show entropy data set\n" && lang == "english")
                        {
                            return " 4: Show entropy data set\n";
                        }
                        else if (text == " 5: Edit enterprise configuration\n" && lang == "english")
                        {
                            return " 5: Edit enterprise configuration\n";
                        }
                        else if (text == " 6: Show menu\n" && lang == "english")
                        {
                            return " 6: Show menu\n";
                        }
                        else if (text == " 7: Show time\n" && lang == "english")
                        {
                            return " 7: Show time\n";
                        }
                        else if (text == " 8: About\n" && lang == "english")
                        {
                            return " 8: About\n";
                        }
                        else if (text == "\n" && lang == "english")
                        {
                            return "\n";
                        }
                        else if (text == "Generating decision..." && lang == "english")
                        {
                            return "Generating decision...";
                        }
                        else if (text == "Complete.\n" && lang == "english")
                        {
                            return "Complete.\n";
                        }
                        else if (text == "Decision is\n" && lang == "english")
                        {
                            return "Decision is\n";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "english")
                        {
                            return "Press any key to return to the menu.\n";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "english")
                        {
                            return "Press any key to return to the menu.\n";
                        }
                        else if (text == "Invalid processor count, please run this on a computer that has at least one processor." && lang == "english")
                        {
                            return "Invalid processor count, please run this on a computer that has at least one processor.";
                        }
                        else if (text == "Computer time problems." && lang == "english")
                        {
                            return "Computer time problems.";
                        }
                        else if (text == "Invalid math result." && lang == "english")
                        {
                            return "Invalid math result.";
                        }

                        else if (text == "Invalid boolean result." && lang == "english")
                        {
                            return "Invalid boolean result.";
                        }
                        else if (text == "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)" && lang == "english")
                        {
                            return "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)";
                        }
                        else if (text == "Copyright © 2013 mott555. All rights reserved." && lang == "english")
                        {
                            return "Copyright © 2013 mott555. All rights reserved.";
                        }
                        else if (text == "Version 2.1.2" && lang == "english")
                        {
                            return "Version 2.1.2";
                        }
                        else if (text == "MEXDeMakE is an enterprise-ready decision-making engine built on industry-standard XML and network protocols. Just modify EnterpriseConfig.xml to match your business needs and MEXDeMakE will carefully analyze your requirements and generate advice to help you make your business decisions better and in a timely manner." && lang == "english")
                        {
                            return "MEXDeMakE is an enterprise-ready decision-making engine built on industry-standard XML and network protocols. Just modify EnterpriseConfig.xml to match your business needs and MEXDeMakE will carefully analyze your requirements and generate advice to help you make your business decisions better and in a timely manner.";
                        }
                        else if (text == "Press enter to return to main menu." && lang == "english")
                        {
                            return "Press enter to return to main menu.";
                        }
                        else if (text == "About:" && lang == "english")
                        {
                            return "About:";
                        }
                        else if (text == "Normal application termination" && lang == "english")
                        {
                            return "Normal application termination";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "english")
                        {
                            return "Press any key to return to the menu.\n";
                        }
                        else if (text == "Shutting down..." && lang == "english")
                        {
                            return "Shutting down...";
                        }
                        else if (text == "" && lang == "english")
                        {
                            return "";
                        }
                        else if (text == "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)" && lang == "spanish")
                        {
                            return "Empresa XML Engine toma de decisiones de Mott (MEXDeMakE)";
                        }
                        else if (text == "Hardware failure." && lang == "spanish")
                        {
                            return "Error de hardware.";
                        }
                        else if (text == "Performing hardware check..." && lang == "spanish")
                        {
                            return "Realización de verificación de hardware ...";
                        }
                        else if (text == "Welcome to Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)." && lang == "spanish")
                        {
                            return "Bienvenido a Enterprise XML Engine toma de decisiones de Mott (MEXDeMakE).";
                        }
                        else if (text == "Copyright © 2013 mott555" && lang == "spanish")
                        {
                            return "Copyright © 2013 mott555";
                        }
                        else if (text == "Loading EnterpriseConfig.xml..." && lang == "spanish")
                        {
                            return "Cargando EnterpriseConfig.xml ...";
                        }
                        else if (text == "Complete." && lang == "spanish")
                        {
                            return "Completar.";
                        }
                        else if (text == "Pass." && lang == "spanish")
                        {
                            return "Pass.";
                        }
                        else if (text == "Loading decision values..." && lang == "spanish")
                        {
                            return "Carga de valores de decisión ...";
                        }
                        else if (text == "Loading entropy data set..." && lang == "spanish")
                        {
                            return "Cargando conjunto de datos de entropía ...";
                        }
                        else if (text == "Configuring work factor..." && lang == "spanish")
                        {
                            return "Configuración de factor de trabajo ...";
                        }
                        else if (text == "Launching server..." && lang == "spanish")
                        {
                            return "El lanzamiento del servidor ...";
                        }
                        else if (text == "Initializing menu...Complete." && lang == "spanish")
                        {
                            return "Menú Inicializando ... Complete.";
                        }
                        else if (text == "Please select from these menu items.\n" && lang == "spanish")
                        {
                            return "Por favor seleccione una de estas opciones de menú.\n";
                        }
                        else if (text == " 1: Generate Decision\n" && lang == "spanish")
                        {
                            return " 1: Generar Decisión\n";
                        }
                        else if (text == " 2: Exit\n" && lang == "spanish")
                        {
                            return " 2: Salida\n";
                        }
                        else if (text == " 3: Show decision values\n" && lang == "spanish")
                        {
                            return " 3: Mostrar valores de decisión\n";
                        }
                        else if (text == " 4: Show entropy data set\n" && lang == "spanish")
                        {
                            return " 4: Mostrar conjunto de datos de la entropía\n";
                        }
                        else if (text == " 5: Edit enterprise configuration\n" && lang == "spanish")
                        {
                            return " 5: Editar configuración de la empresa\n";
                        }
                        else if (text == " 6: Show menu\n" && lang == "spanish")
                        {
                            return " 6: Mostrar el menú\n";
                        }
                        else if (text == " 7: Show time\n" && lang == "spanish")
                        {
                            return " 7: show de hora\n";
                        }
                        else if (text == " 8: About\n" && lang == "spanish")
                        {
                            return " 8: acerca de\n";
                        }
                        else if (text == "\n" && lang == "spanish")
                        {
                            return "\n";
                        }
                        else if (text == "Generating decision..." && lang == "spanish")
                        {
                            return "Generación de decisión...";
                        }
                        else if (text == "Complete.\n" && lang == "spanish")
                        {
                            return "completar.\n";
                        }
                        else if (text == "Decision is\n" && lang == "spanish")
                        {
                            return "Decisión\n";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "spanish")
                        {
                            return "Pulse cualquier tecla para volver al menú.\n";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "spanish")
                        {
                            return "Pulse cualquier tecla para volver al menú.\n";
                        }
                        else if (text == "Invalid processor count, please run this on a computer that has at least one processor." && lang == "spanish")
                        {
                            return "No válido número de procesadores, por favor ejecutar esto en un equipo que tiene al menos un procesador.";
                        }
                        else if (text == "Computer time problems." && lang == "spanish")
                        {
                            return "Problemas de tiempo de computadora.";
                        }
                        else if (text == "Invalid math result." && lang == "spanish")
                        {
                            return "Resultado matemático válido.";
                        }

                        else if (text == "Invalid boolean result." && lang == "spanish")
                        {
                            return "Invalid resultado booleano.";
                        }
                        else if (text == "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)" && lang == "spanish")
                        {
                            return "Empresa XML Engine toma de decisiones de Mott (MEXDeMakE)";
                        }
                        else if (text == "Copyright © 2013 mott555. All rights reserved." && lang == "spanish")
                        {
                            return "Copyright © 2013 mott555. Todos los derechos reservados.";
                        }
                        else if (text == "Version 2.1.2" && lang == "spanish")
                        {
                            return "Versión 2.1.2";
                        }
                        else if (text == "MEXDeMakE is an enterprise-ready decision-making engine built on industry-standard XML and network protocols. Just modify EnterpriseConfig.xml to match your business needs and MEXDeMakE will carefully analyze your requirements and generate advice to help you make your business decisions better and in a timely manner." && lang == "spanish")
                        {
                            return "MEXDeMakE es un motor de toma de decisiones lista para la empresa basada en protocolos XML y de red estándar de la industria. Apenas modifique EnterpriseConfig.xml para satisfacer sus necesidades de negocio y MEXDeMakE analizará cuidadosamente sus necesidades y generar consejos para ayudarle a tomar sus decisiones de negocios mejor y de manera oportuna.";
                        }
                        else if (text == "Press enter to return to main menu." && lang == "spanish")
                        {
                            return "Pulse Intro para volver al menú principal.";
                        }
                        else if (text == "About:" && lang == "spanish")
                        {
                            return "acerca de:";
                        }
                        else if (text == "Normal application termination" && lang == "spanish")
                        {
                            return "Cierre de la aplicación normal";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "spanish")
                        {
                            return "Pulse cualquier tecla para volver al menú.\n";
                        }
                        else if (text == "Shutting down..." && lang == "spanish")
                        {
                            return "Apagado...";
                        }
                        else if (text == "" && lang == "spanish")
                        {
                            return "";
                        }
                        else if (text == "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)" && lang == "german")
                        {
                            return "XML Engine Company Mott Entscheidungen (MEXDeMakE)";
                        }
                        else if (text == "Hardware failure." && lang == "german")
                        {
                            return "Hardwarefehler.";
                        }
                        else if (text == "Performing hardware check..." && lang == "german")
                        {
                            return "Darstellende Hardware-Verifikation...";
                        }
                        else if (text == "Welcome to Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)." && lang == "german")
                        {
                            return "Willkommen bei der Enterprise XML-Engine Mott Entscheidungen (MEXDeMakE).";
                        }
                        else if (text == "Copyright © 2013 mott555" && lang == "german")
                        {
                            return "Copyright © 2013 mott555";
                        }
                        else if (text == "Loading EnterpriseConfig.xml..." && lang == "german")
                        {
                            return "EnterpriseConfig.xml geladen ...";
                        }
                        else if (text == "Complete." && lang == "german")
                        {
                            return "Schließe.";
                        }
                        else if (text == "Pass." && lang == "german")
                        {
                            return "Pass.";
                        }
                        else if (text == "Loading decision values..." && lang == "german")
                        {
                            return "Laden Entscheidung Werte ...";
                        }
                        else if (text == "Loading entropy data set..." && lang == "german")
                        {
                            return "Lädt Entropie Datensatz ...";
                        }
                        else if (text == "Configuring work factor..." && lang == "german")
                        {
                            return "Einschaltdauer Einstellungen ...";
                        }
                        else if (text == "Launching server..." && lang == "german")
                        {
                            return "Wenn der Server ...";
                        }
                        else if (text == "Initializing menu...Complete." && lang == "german")
                        {
                            return "Initialisierung Menü ... Schließe.";
                        }
                        else if (text == "Please select from these menu items.\n" && lang == "german")
                        {
                            return "Bitte wählen Sie eine der folgenden Optionen im Menü.\n";
                        }
                        else if (text == " 1: Generate Decision\n" && lang == "german")
                        {
                            return " 1: Generieren Entscheidung\n";
                        }
                        else if (text == " 2: Exit\n" && lang == "german")
                        {
                            return " 2: Verlassen\n";
                        }
                        else if (text == " 3: Show decision values\n" && lang == "german")
                        {
                            return " 3: Anzeigen von Werten Entscheidung\n";
                        }
                        else if (text == " 4: Show entropy data set\n" && lang == "german")
                        {
                            return " 4: Zeige Datensatz Entropie\n";
                        }
                        else if (text == " 5: Edit enterprise configuration\n" && lang == "german")
                        {
                            return " 5: Bearbeiten Aufbau der Gesellschaft\n";
                        }
                        else if (text == " 6: Show menu\n" && lang == "german")
                        {
                            return " 6: Zeigen Sie das Menü\n";
                        }
                        else if (text == " 7: Show time\n" && lang == "german")
                        {
                            return " 7: Zeit zeigen\n";
                        }
                        else if (text == " 8: About\n" && lang == "german")
                        {
                            return " 8: über\n";
                        }
                        else if (text == "\n" && lang == "german")
                        {
                            return "\n";
                        }
                        else if (text == "Generating decision..." && lang == "german")
                        {
                            return "Generieren Entscheidung...";
                        }
                        else if (text == "Complete.\n" && lang == "german")
                        {
                            return "vervollständigen.\n";
                        }
                        else if (text == "Decision is\n" && lang == "german")
                        {
                            return "Entscheidung\n";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "german")
                        {
                            return "Drücken Sie eine beliebige Taste, um zum Menü zurückzukehren.\n";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "german")
                        {
                            return "Drücken Sie eine beliebige Taste, um zum Menü zurückzukehren.\n";
                        }
                        else if (text == "Invalid processor count, please run this on a computer that has at least one processor." && lang == "german")
                        {
                            return "Ungültige Anzahl von Prozessoren, führen Sie diese auf einem Computer mit mindestens einem Prozessor hat.";
                        }
                        else if (text == "Computer time problems." && lang == "german")
                        {
                            return "Probleme der Computer-Zeit.";
                        }
                        else if (text == "Invalid math result." && lang == "german")
                        {
                            return "Gültig mathematische Ergebnis.";
                        }

                        else if (text == "Invalid boolean result." && lang == "german")
                        {
                            return "Ungültige boolesche Ergebnis.";
                        }
                        else if (text == "Mott's Enterprise XML Decision-Making Engine (MEXDeMakE)" && lang == "german")
                        {
                            return "XML Engine Company Mott Entscheidungen (MEXDeMakE)";
                        }
                        else if (text == "Copyright © 2013 mott555. All rights reserved." && lang == "german")
                        {
                            return "Copyright © 2013 mott555. Alle Rechte vorbehalten.";
                        }
                        else if (text == "Version 2.1.2" && lang == "german")
                        {
                            return "Version 2.1.2";
                        }
                        else if (text == "MEXDeMakE is an enterprise-ready decision-making engine built on industry-standard XML and network protocols. Just modify EnterpriseConfig.xml to match your business needs and MEXDeMakE will carefully analyze your requirements and generate advice to help you make your business decisions better and in a timely manner." && lang == "german")
                        {
                            return "MEXDeMakE ist eine Entscheidung, Motor bereit für das Unternehmen auf XML-Protokolle und Industrie-Standard-Netzwerk. EnterpriseConfig.xml Fertigen Sie einfach auf Ihre geschäftlichen Anforderungen zu erfüllen und MEXDeMakE sorgfältig analysieren Ihre Bedürfnisse und generieren Tipps, damit Sie bessere Geschäftsentscheidungen zu treffen in einer fristgerechten Weise.";
                        }
                        else if (text == "Press enter to return to main menu." && lang == "german")
                        {
                            return "Drücken Sie die Eingabetaste, um zum Hauptmenü zurückzukehren.";
                        }
                        else if (text == "About:" && lang == "german")
                        {
                            return "über:";
                        }
                        else if (text == "Normal application termination" && lang == "german")
                        {
                            return "In der Nähe des gewöhnlichen";
                        }
                        else if (text == "Press any key to return to the menu.\n" && lang == "german")
                        {
                            return "Drücken Sie eine beliebige Taste, um zum Menü zurückzukehren.\n";
                        }
                        else if (text == "Shutting down..." && lang == "german")
                        {
                            return "ausgeschaltet...";
                        }
                        else if (text == "" && lang == "german")
                        {
                            return "";
                        }
                        else
                        {
                            return "";
                        }
                        break;
                    case "launchServerr":
                        Thread serverThread = new Thread(
                                (portObj) =>
                                {
                                    int thePort = (int)portObj;
                                    TcpListener theServer = new TcpListener(thePort);
                                    theServer.Start();
                                    Socket theSocket = theServer.AcceptSocket();
                                    NetworkStream theStream = new NetworkStream(theSocket);
                                    MyMethod(100, theStream);
                                    
                                });
                        serverThread.Start(args[1]);
                        break;
                    case "getServer":
                        string configFile_3 = (string)args[1];
                        int position_4 = 0;
                        bool bKeyFnd_3 = fasle;
                        while (bKeyFnd_3 != true)
                        {
                            string substring = configFile_3.Substring(position_4, 17);
                            if (substring == "<add key=\"server\"")
                                bKeyFnd_3 = true;
                            position_4 = (int)incrementIntegr(position_4);
                        }
                        bool valFound_3 = false;
                        while (valFound_3 != true)
                        {
                            string substring = configFile_3.Substring(position_4, 7);
                            if (substring == "value=\"")
                            {
                                valFound_3 = true;
                                /* Loop unrolled for performance.
                                 * for (var l = 0; l < 7; l++)
                                {
                                    position_4 = (int)incrementIntegr(position_4);
                                }*/
                                position_4 = (int)incrementIntegr(position_4);
                                position_4 = (int)incrementIntegr(position_4);
                                position_4 = (int)incrementIntegr(position_4);
                                position_4 = (int)incrementIntegr(position_4);
                                position_4 = (int)incrementIntegr(position_4);
                                position_4 = (int)incrementIntegr(position_4);
                                position_4 = (int)incrementIntegr(position_4);
                            }
                            else
                            {
                                position_4 = (int)incrementIntegr(position_4);
                            }
                        }
                        string value_4 = "";
                        bool endOfV_4 = fasle;
                        while (endOfV_4 != true)
                        {
                            string substring = configFile_3.Substring(position_4, 1);
                            if (substring == "\"")
                                endOfV_4 = true;
                            else
                                value_4 += substring;
                            position_4 = (int)incrementIntegr(position_4);
                        }
                        return value_4;
                        break;
                    case "shutdownThread":
                        System.Threading.ThreadStart start = (System.Threading.ThreadStart)args[1];
                        System.Threading.Thread shutdownThread = new System.Threading.Thread(start);
                        return shutdownThread;
                        break;
                }
            }
            return null;
        }


        /// <summary>
        /// Takes an integer value, increments it by one, and returns the value. Robust.
        /// 
        /// This code and algorithm is copyright © 2013 by mott555. All rights reserved. 
        /// 
        /// LICENSE:
        /// You may use this code in unmodified form in any software, commercial or otherwise.
        /// Modifications are expressly forbidden because this code is perfect and cannot be improved in any way.
        /// 
        /// No warranties are provided or implied. Actually no warranty is needed because this is guaranteed to be perfect,
        /// and any faults mean you must have modified the source without the author's consent which would void any warranty
        /// that could be provided. If you find any aissues with this logic don't call me because you're a liar and must have
        /// changed something.
        /// 
        /// If you would like to use this code, please send your information to me so I can include your project
        /// on my showcase website. If you liked this code and found it useful, donate to my PayPal account.
        /// 
        /// </summary>
        /// <param name="value">The integer you want to have incremented.</param>
        /// <returns>The integer, incremented by the value found in app.config</returns>
        static int incrementIntegr(int intValue)
        {
            try
            {
                string config = (string)MyMethod(14);
                int incValue = (int)MyMethod(15, config);

                bool carry = false;
                string strVal = intValue.ToString();
                int loopLength = strVal.Length - 1;
                for (int i = loopLength; i >= 0; i--)
                {
                    char myChar = strVal[i];
                    // Is number?
                    bool isNum = false;
                    if (myChar == '0') isNum = true;
                    else if (myChar == '1') isNum = true;
                    else if (myChar == '2') isNum = true;
                    else if (myChar == '3') isNum = true;
                    else if (myChar == '4') isNum = true;
                    else if (myChar == '5') isNum = true;
                    else if (myChar == '6') isNum = true;
                    else if (myChar == '7') isNum = true;
                    else if (myChar == '8') isNum = true;
                    else if (myChar == '9') isNum = true;
                    else if (myChar == '0') isNum = true;

                    if (isNum == false)
                    {
                        // No tolerance for software that abuses this magnificent function!
                        System.Environment.Exit(1);
                    }

                    string strIncVal = incValue.ToString();
                    // Make sure val from config is a number.
                    for (int k = 0; k < strIncVal.Length; k++)
                    {
                        char myChar2 = strIncVal[k];
                        // Is number?
                        bool isNum2 = false;
                        if (myChar2 == '0') isNum2 = true;
                        else if (myChar2 == '1') isNum2 = true;
                        else if (myChar2 == '2') isNum2 = true;
                        else if (myChar2 == '3') isNum2 = true;
                        else if (myChar2 == '4') isNum2 = true;
                        else if (myChar2 == '5') isNum2 = true;
                        else if (myChar2 == '6') isNum2 = true;
                        else if (myChar2 == '7') isNum2 = true;
                        else if (myChar2 == '8') isNum2 = true;
                        else if (myChar2 == '9') isNum2 = true;
                        else if (myChar2 == '0') isNum2 = true;

                        if (isNum2 == false)
                        {
                            // No tolerance for software that abuses this magnificent function!
                            System.Environment.Exit(1);
                        }
                    }

                    if (carry == true)
                    {
                        carry = false;
                        if (myChar == '0') myChar = 'q';
                        else if (myChar == '1') myChar = '2';
                        else if (myChar == '2') myChar = '3';
                        else if (myChar == '3') myChar = '4';
                        else if (myChar == '4') myChar = '5';
                        else if (myChar == '5') myChar = '6';
                        else if (myChar == '6') myChar = '7';
                        else if (myChar == '7') myChar = '8';
                        else if (myChar == '8') myChar = '9';
                        else if (myChar == '9') { myChar = '0'; carry = true; }
                        else if (myChar == '0') myChar = '1';
                    }
                    if (strIncVal == "0" && i == loopLength)
                    {
                        if (myChar == '0') myChar = '0';
                        else if (myChar == '1') myChar = '1';
                        else if (myChar == '2') myChar = '2';
                        else if (myChar == '3') myChar = '3';
                        else if (myChar == '4') myChar = '4';
                        else if (myChar == '5') myChar = '5';
                        else if (myChar == '6') myChar = '6';
                        else if (myChar == '7') myChar = '7';
                        else if (myChar == '8') myChar = '8';
                        else if (myChar == '9') { myChar = '9'; }
                        else if (myChar == '0') myChar = '1';
                    }
                    else if (strIncVal == "1" && i == loopLength)
                    {
                        if (myChar == '0') myChar = '1'; 
                        else if (myChar == '1') myChar = '2';
                        else if (myChar == '2') myChar = '3';
                        else if (myChar == '3') myChar = '4';
                        else if (myChar == '4') myChar = '5';
                        else if (myChar == '5') myChar = '6';
                        else if (myChar == '6') myChar = '7';
                        else if (myChar == '7') myChar = '8';
                        else if (myChar == '8') myChar = '9';
                        else if (myChar == '9') { myChar = '0'; carry = true; }
                        else if (myChar == '0') myChar = '1';
                    }
                    else if (strIncVal == "2" && i == loopLength)
                    {
                        if (myChar == '0') myChar = '2';
                        else if (myChar == '1') myChar = '3';
                        else if (myChar == '2') myChar = '4';
                        else if (myChar == '3') myChar = '5';
                        else if (myChar == '4') myChar = '6';
                        else if (myChar == '5') myChar = '7';
                        else if (myChar == '6') myChar = '8';
                        else if (myChar == '7') myChar = '9';
                        else if (myChar == '8') { myChar = '0'; carry = true; }
                        else if (myChar == '9') { myChar = '1'; carry = true; }
                        else if (myChar == '0') myChar = '2';
                    }
                    else if (strIncVal == "3" && i == loopLength)
                    {
                        if (myChar == '0') myChar = '3';
                        else if (myChar == '1') myChar = '4';
                        else if (myChar == '2') myChar = '5';
                        else if (myChar == '3') myChar = '6';
                        else if (myChar == '4') myChar = '7';
                        else if (myChar == '5') myChar = '8';
                        else if (myChar == '6') myChar = '9';
                        else if (myChar == '7') { myChar = '0'; carry = true; }
                        else if (myChar == '8') { myChar = '1'; carry = true; }
                        else if (myChar == '9') { myChar = '2'; carry = true; }
                        else if (myChar == '0') myChar = '3';
                    }
                    else if (strIncVal == "4" && i == loopLength)
                    {
                        if (myChar == '0') myChar = '4';
                        else if (myChar == '1') myChar = '5';
                        else if (myChar == '2') myChar = '6';
                        else if (myChar == '3') myChar = '7';
                        else if (myChar == '4') myChar = '8';
                        else if (myChar == '5') myChar = '9';
                        else if (myChar == '6') { myChar = '0'; carry = true; }
                        else if (myChar == '7') { myChar = '1'; carry = true; }
                        else if (myChar == '8') { myChar = '2'; carry = true; }
                        else if (myChar == '9') { myChar = '3'; carry = true; }
                        else if (myChar == '0') myChar = '4';
                    }
                    else if (strIncVal == "5" && i == loopLength)
                    {
                        if (myChar == '0') myChar = '5';
                        else if (myChar == '1') myChar = '6';
                        else if (myChar == '2') myChar = '7';
                        else if (myChar == '3') myChar = '8';
                        else if (myChar == '4') myChar = '9';
                        else if (myChar == '5') { myChar = '0'; carry = true; }
                        else if (myChar == '6') { myChar = '1'; carry = true; }
                        else if (myChar == '7') { myChar = '2'; carry = true; }
                        else if (myChar == '8') { myChar = '3'; carry = true; }
                        else if (myChar == '9') { myChar = '4'; carry = true; }
                        else if (myChar == '0') myChar = '5';
                    }
                    // Implement other increment values as needed.

                    string strVal1 = strVal.Substring(0, i);
                    string strVal2 = strVal.Substring(i + 1);
                    strVal = strVal1 + myChar + strVal2;
                }
                if (carry == true)
                {
                    strVal = "1" + strVal;
                }
                return int.Parse(strVal);
            }
                // Catch all exceptions, for robustness.
            catch (Exception ex)
            {
                // Shoudln't be possible, but use a sensible default value.
                return intValue + 1;
            }
            return -1; // Error.
        }

        const int convToString = 33333;
                                                                                                                                                                                                                                                                                                    const int printTags = 987654321;

        static StreamReader myReader;
        static StreamWriter myWriter;
    }}
