/* 
 * Description :
 *  Initial Set of code to copy a set of files and rename them appropriatly
 *  To create a SOW
 * 
 * Author : JGS 
 * 
 */

namespace CreateSowNamespace
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class FileRecordUpdate
    {
        string fileName = Properties.Resources.RegisterLocation;
        string prefix = Properties.Resources.FunctionalSpecPrefix;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName"></param>
        public FileRecordUpdate(string fileName)
        {
            if (string.Empty != fileName)
            {
                this.fileName = fileName;
            }
        }

        /// <summary>
        /// Method to call to update the record with a new line 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="dueBy"></param>
        /// <returns></returns>
        public string update(string customer, string title, string description, string originator ,DateTime dueBy)
        {
            /// Check to see if the file exists and create it if it does not.
            if (!File.Exists(this.fileName))
            {
                string clientHeader = Properties.Resources.HeaderLine + Environment.NewLine;
                File.WriteAllText(this.fileName, clientHeader);
            }

            // to the file which will now exist add the dat aas a new line 
            string functionalSpecAllocatedNumber = prefix+extractNextNumberFromGivenFile();
            string projectDetails = functionalSpecAllocatedNumber + ",\t" + customer + ",\t" + title + ",\t" + description + ",\t" + originator+",\t"+ String.Format("{0:MM/dd/yyyy}", dueBy) + "," + Environment.NewLine;
            File.AppendAllText(this.fileName, projectDetails);
            return functionalSpecAllocatedNumber;
        }

        /// <summary>
        /// Function to extract teh last line in the file and extract the number 
        /// Add one and then return the next specification number 
        /// </summary>
        /// <returns></returns>
        string extractNextNumberFromGivenFile()
        {
            string[] allLines = File.ReadAllLines(this.fileName);
            string lastLine = allLines.Last();
            string[] values = lastLine.Split(',').Select(sValue => sValue.Trim()).ToArray();
            string one = values[0];
            Regex rgx = new Regex(prefix);
            string returned = rgx.Replace(one, string.Empty);
            Int32 nextSpecNumber = Convert.ToInt32(returned);
            nextSpecNumber++;
            return nextSpecNumber.ToString("D4");
        }
    }
}
