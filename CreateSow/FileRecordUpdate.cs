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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class FileRecordUpdate
    {
        string fileName = Properties.Resources.RegisterLocation;

        public FileRecordUpdate(string fileName)
        {
            if (string.Empty != fileName)
            {
                this.fileName = fileName;
            }
        }

        public string update(string customer, string title, string description, DateTime dueBy)
        {
            if (!File.Exists(this.fileName))
            {
                string clientHeader = Properties.Resources.HeaderLine + Environment.NewLine;
                File.WriteAllText(this.fileName, clientHeader);
            }

            string[] allLines = File.ReadAllLines(this.fileName);
            string functionalSpecAllocatedNumber = "FS_" + allLines.Length.ToString().PadLeft(4, '0');
            string projectDetails = functionalSpecAllocatedNumber + ",\t" + customer + ",\t" + title + ",\t" + description +",\t"+ String.Format("{0:MM/dd/yyyy}", dueBy) +","+Environment.NewLine;
            File.AppendAllText(this.fileName, projectDetails);
            return functionalSpecAllocatedNumber;
        }

    }
}
