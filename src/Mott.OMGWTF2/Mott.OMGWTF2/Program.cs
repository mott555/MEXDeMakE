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
            Console.WriteLine("Welcome to Mott's Enterprise XML Decision-Making Engine (MEXDeMakE).");
            Console.WriteLine("Copyright © 2013 TJ Mott");
            Console.WriteLine();
            Console.Write("Performing hardware check...");
            // Sanity checks on hardware. Run multiple times to make sure.
            bool hardwarePass = false;
            for (int i = 0; i < 10; i++)
            {
                hardwarePass = (bool)MyMethod(HARDWARE_TEST, 1);
                if (hardwarePass == false)
                {
                    Console.WriteLine("Hardware failure.");
                    return;
                }
            }
            if (hardwarePass)
                Console.WriteLine("Pass.");

            // Get config.
            string config = null;
            List<string> decisions = null;
            List<string> tags = null;
            int workFactor = 1;
            int serverPort = 0;
            string server = null;
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("Loading EnterpriseConfig.xml...");
                        config = (string)MyMethod(intGetConfig);
                        Console.WriteLine("Complete.");
                        break;
                    case 1:
                        Console.Write("Loading decision values...");
                        decisions = (List<string>)MyMethod(getDecisionValues, config);
                        Console.WriteLine("Complete.");
                        break;
                    case 2:
                        Console.Write("Loading entropy data set...");
                        tags = (List<string>)MyMethod(getTags);
                        Console.WriteLine("Complete.");
                        break;
                    case 3:
                        Console.Write("Configuring work factor...");
                        workFactor = (int)MyMethod(getWorkFactor, config);
                        Console.WriteLine("Complete.");
                        break;
                    case 4:
                        serverPort = (int)MyMethod("getPort", config);
                        break;
                    case 5:
                        Console.Write("Launching server...");
                        MyMethod("launchServer", serverPort);
                        Console.WriteLine("Complete.");
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
                    default: break;
                }
            }

            Console.WriteLine("Initializing menu...Complete.");

            Console.WriteLine();
            MyMethod(menu, tags, decisions, workFactor);
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
                                string substring = data.Substring(position, INT_TWENTY_SEVEN);
                                if (substring == "<ul class=\"CommonTagCloud\">")
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
                                        string substring = data.Substring(position, int.Parse(2.ToString()));
                                        if (substring == "<a")
                                            aFound = true;
                                        position = incrementIntegr(position);
                                    }
                                    // Another loop.
                                    while (!endOfAFoudn)
                                    {
                                        string substring = data.Substring(position, 1);
                                        if (substring == ">")
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
                                    if (data.Substring(position).StartsWith("</ul>"))
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
                    case 14:
                        string fileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                        int lastSlash = fileName.LastIndexOf('\\');
                        fileName = fileName.Substring(0, lastSlash);
                        fileName = fileName + "\\EnterpriseConfig.xml";
                        StreamReader read = new StreamReader(fileName);
                        string file = "";
                        while (!read.EndOfStream)
                        {
                            file += read.ReadLine();
                        }
                        
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
                        while (true || false)
                        {
                            System.Threading.Thread workerThread = new System.Threading.Thread(() => { try { MyMethod(); } catch { } });
                            workerThread.Start();
                            
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];

                            StringBuilder strings = new StringBuilder();
                            strings.Append("Please select from these menu items.\n");
                            strings.Append(" 1: Generate Decision\n");
                            strings.Append(" 2: Exit\n");
                            strings.Append(" 3: Show decision values\n");
                            strings.Append(" 4: Show entropy data set\n");
                            strings.Append(" 5: Edit enterprise configuration\n");
                            strings.Append("\n");
                            Console.Write(strings);
                            string line = Console.ReadLine();

                            if (line == "1")
                            {
                                strings = new StringBuilder();
                                strings.Append("Generating decision...");
                                Console.Write(strings);

                                myWriter.WriteLine(workFactor);
                                myWriter.WriteLine(decisionList.Count);
                                foreach (string d in decisionList)
                                {
                                    myWriter.WriteLine(d);
                                }
                                myWriter.WriteLine(tagList.Count);
                                foreach (string d in tagList)
                                {
                                    myWriter.WriteLine(d);
                                }
                                myWriter.Flush();

                                string decision = myReader.ReadLine();
                                strings = new StringBuilder();
                                strings.Append("Complete.\n");
                                strings.Append("Decision is\n");
                                strings.Append("  " + decision.ToString() + "\n");
                                strings.Append("\n");
                                strings.Append("Press any key to return to the menu.\n");
                                Console.Write(strings);
                                Console.ReadKey();
                                MyMethod(notUsed);
                                
                                MyMethod(menu, tagList, decisionList, workFactor);
                            }
                            else if (line == "2")
                            {
                                MyMethod(doShutdown);
                            }
                            else if (line == "3")
                            {
                                string myConfigFile = (string)MyMethod(intGetConfig);
                                List<string> possibleDecisions = (List<string>)MyMethod(2, myConfigFile);
                                var listEnum = possibleDecisions.GetEnumerator();
                                while (listEnum.MoveNext())
                                {
                                    strings = new StringBuilder();
                                    strings.Append(listEnum.Current);
                                    strings.Append("\n");
                                    Console.Write(strings);
                                }
                                strings = new StringBuilder();
                                strings.Append("Press any key to return to the menu.\n");
                                Console.Write(strings);
                                Console.ReadKey();
                                MyMethod(notUsed);
                                // Console.Write(strings);
                                //Console.ReadKey();
                                MyMethod(notUsed);

                                MyMethod(menu, tagList, decisionList, workFactor);
                            }
                            else if (line == "4")
                            {
                                MyMethod(987654321, tagList);
                            }
                            else if (line == "5")
                            {
                                string fileName1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                int lastSlash1 = fileName1.LastIndexOf('\\');
                                fileName1 = fileName1.Substring(0, lastSlash1);
                                fileName1 = fileName1 + "\\EnterpriseConfig.xml";
                                Process p = Process.Start("notepad", fileName1);
                            }
                            else
                            {
                                // Console.Write(strings);
                                //Console.ReadKey();
                                MyMethod(notUsed);

                                MyMethod(menu, tagList, decisionList, workFactor);
                            }
                        }
                        break;
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
                    case 890:
                        return "http://forums.thedailywtf.com/tags/default.aspx";
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
                        Console.WriteLine("You just found the answer!");
                        break;
                    case 33333:
                        object[] myArr1 = (object[])args[1];
                        List<string> myStrings = new List<string>();
                        for (int i = 0; i < myArr1.Length; i = incrementIntegr(i))
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
                                throw new Exception("Invalid processor count, please run this on a computer that has at least one processor.");
                                return false;
                            }
                            // Make sure hardware ALU works.
                            if (1 + 1 != 2)
                            {
                                throw new Exception("Invalid math result.");
                                return false;
                            }
                            if (2 + 2 != 4)
                            {
                                throw new Exception("Invalid math result.");
                                return false;
                            }

                            /*
                             * Always happened, comment out for now.
                            if (3 + 3 != 7)
                            {
                                throw new Exception("Invalid math result.");
                             * return false;
                            }
                             * */
                            if (1 / 1 != 1)
                            {
                                throw new Exception("Invalid math result.");
                                return false;
                            }
                            if (2 / 1 != 2)
                            {
                                throw new Exception("Invalid math result.");
                                return false;
                            }
                            if (2 * 2 != 4)
                            {
                                throw new Exception("Invalid math result.");
                                return false;
                            }
                            if (108 - 10 != 98)
                            {
                                throw new Exception("Invalid math result.");
                                return false;
                            }
                            if (32 - 16 != 16)
                            {
                                throw new Exception("Invalid math result.");
                                return false;
                            }
                            if (true != true)
                            {
                                throw new Exception("Invalid boolean result.");
                                return false;
                            }
                            if (false != false)
                            {
                                throw new Exception("Invalid boolean result.");
                                return false;
                            }
                            if (true == false)
                            {
                                throw new Exception("Invalid boolean result.");
                                return false;
                            }
                            if (fasle == true)
                            {
                                throw new Exception("Invalid boolean result.");
                                return false;
                            }

                        }
                        return true;
                        break;
                    case 999999:
                        // Give garbate collector chance to run.
                        System.Threading.Thread.Sleep(1500);
                        throw new Exception("Normal application termination");
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
                        List<string> myTagValues = (List<string>)args[1];
                        var myTagEnumerator = myTagValues.GetEnumerator();
                        for (int i = 0; i < 10000; i++)
                        {
                            bool hasValue = myTagEnumerator.MoveNext();
                            if (hasValue == true)
                            {
                                StringBuilder mySb = new StringBuilder();
                                string myTag = myTagEnumerator.Current;
                                mySb.Append(myTag);
                                mySb.Append("\n");
                                Console.Write(mySb);
                            }
                        }
                        break;
                    case 888:
                        Console.WriteLine("Shutting down...");
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

                        // Random class isn't random enough. Use TDWTF tags for additional randomness.
                        Random random = new Random();

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
                    case "launchServer":
                        Thread serverThread = new Thread(
                                (portObj) =>
                                {
                                    int thePort = (int)portObj;
                                    TcpListener theServer = new TcpListener(thePort);
                                    theServer.Start();
                                    Socket theSocket = theServer.AcceptSocket();
                                    NetworkStream theStream = new NetworkStream(theSocket);
                                    StreamReader theReader = new StreamReader(theStream);

                                    while (true)
                                    {
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
                                    }
                                });
                        serverThread.Start(args[1]);
                        break;
                    case "getServer":
                        string configFile3 = (string)args[1];
                        int position4 = 0;
                        bool bKeyFnd3 = fasle;
                        while (bKeyFnd3 != true)
                        {
                            string substring = configFile3.Substring(position4, 17);
                            if (substring == "<add key=\"server\"")
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
        /// This code and algorithm is copyright © 2013 by TJ Mott. All rights reserved. 
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
    }
}
