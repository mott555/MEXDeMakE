using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Reflection;

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
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        hardwarePass = (bool)MyMethod(HARDWARE_TEST, 1);
                        if (hardwarePass == false)
                        {
                            Console.WriteLine("Hardware failure.");
                            return;
                        }
                    break;
                    default:
                        throw new Exception("Fix for loop.");
                        break;
                }
            }
            if (hardwarePass)
                Console.WriteLine("Pass.");

            // Get config and other data.
            string config = null;
            List<string> decisions = null;
            List<string> tags = null;
            int workFactor = 1;
            for (int i = 0; i < 5; i++)
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
        const int intGetConfig = -14;
        const int getWorkFactor = 88;
        const int HARDWARE_TEST = 6;
        const string generateRandomNo = "gen";
        const int menu = 567;

        // Other usful constants.
        static string strLiLength = "3";

        /// <summary>
        /// Main method, does most of the app's processing.
        /// 
        /// Easily extensible. Just add to the switch statement.
        /// </summary>
        /// <param name="args">Method arguments.</param>
        /// <returns>Varies, depends on what was in args.</returns>
        static object MyMethod(params object[] args)
        {
            try
            {
                switch ((int)args[0])
                {
                    case 1: // get tags from tdwtf
                        WebClient wc = new WebClient();
                        string data = wc.DownloadString("http://forums.thedailywtf.com/tags/default.aspx");


                        bool tagCouldFound = false;
                        int position = 0;
                        while (!tagCouldFound)
                        {
                            string substring = data.Substring(position, 27);
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
                                while (!liFoudn || liFoudn == false) // Had intermittent issues with ! symbol, so if something goes wrong second part will happen as safeguard.
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

                        break;
                    case -14:
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
                        read.Close();
                        return file;
                        break;
                    case 567:
                        while (true)
                        {
                            List<string> tagList = (List<string>)args[1];
                            List<string> decisionList = (List<string>)args[2];
                            int workFactor = (int)args[3];

                            Console.WriteLine("Please select from these menu items.");
                            Console.WriteLine(" 1: Generate Decision");
                            Console.WriteLine(" 2: Exit");
                            Console.WriteLine();
                            string line = Console.ReadLine();

                            if (line == "1")
                            {
                                Console.Write("Generating decision...");
                                string decision = (string)MyMethod(generateRandomNo, tagList, decisionList, workFactor);
                                Console.WriteLine("Complete.");
                                Console.WriteLine("Decision is");
                                Console.WriteLine("  " + decision);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to the menu.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Welcome to Mott's Enterprise XML Decision-Making Engine (MEXDeMakE).");
                                Console.WriteLine("Copyright © 2013 TJ Mott");
                                Console.WriteLine();
                            }
                            else if (line == "2")
                            {
                                Console.WriteLine("Shutting down...");
                                System.Threading.Thread.Sleep(1500);
                                throw new Exception("Normal application termination");
                            }
                            else
                            {
                                Console.Clear();
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
                        List<string> values = new List<string>();
                        string value2 = "";
                        while (endOfV2 != true)
                        {
                            string substring = configFile1.Substring(position2, 1);
                            if (substring == "\"")
                            {
                                values.Add(value2);
                                value2 = "";
                                endOfV2 = true;
                            }
                            else if (substring == ",")
                            {
                                values.Add(value2);
                                value2 = "";
                            }
                            else
                            {
                                value2 += substring;
                            }
                            position2++;
                        }
                        return values;
                        break;
                    case 42:
                        Console.WriteLine("You just found the answer!");
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
                    default:
                        return null; // Shut up the compiler.
                }
            }
            catch (Exception)
            {
                switch ((string)args[0])
                {
                    case "gen":
                        List<string> tags = (List<string>)args[1];
                        List<string> decisions = (List<String>)(args[2] as List<string>);
                        int workFactor = (int)args[3];

                        // Random class isn't random enough. Use TDWTF tags for additional randomness.
                        Random random = new Random();

                        for (int i = 0; i < Math.Pow(2, workFactor); i++)
                        {
                            MyMethod("dot", i % 100 == 0);
                            for (int k = 0; k < tags.Count; k++)
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
                        }

                        // Random is now random.
                        int tagIndex = random.Next(tags.Count);
                        string randomTag = tags[tagIndex];
                        int randomIndex = randomTag.Length % decisions.Count;
                        string decision = null;
                        for (int i = 0; i < decisions.Count; i++)
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
                string config = (string)MyMethod(-14);
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

                    if (strIncVal == "1" && i == loopLength)
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
    }
}
