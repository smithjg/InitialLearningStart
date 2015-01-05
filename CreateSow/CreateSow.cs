/* 
 * Description :
 *  The Code that Drives the Actions initiated by the Form 
 *  for Creating a new Statement of work
 *  Creates a new directory and copies the relevant elements to it
 *  Updates the Functional Specification Register which is a CSV.
 * 
 * Author : JGS 
 * 
 */

namespace CreateSowNamespace
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    /// <summary>
    /// The Main Code that goes behind the Form
    /// </summary>
    public partial class CreateSow : Form
    {
        string sourceDir = Properties.Resources.SOURCE_DIR;
        string destinationDir = Properties.Resources.DEST_DIR;
        string Customer = Properties.Resources.Customer;
        string FSNumber = Properties.Resources.FSNumberToken;
        string Title = Properties.Resources.Title;
        string shortProjectDescription = "Default as none provided";
        string projectOriginator = string.Empty;
        DateTime dueDate = DateTime.Now;
        bool dateTimePickerSet = false;
        const string errorString = "Source directory does not exist or could not be found: ";

        /// <summary>
        /// Form initialisation 
        /// </summary>
        public CreateSow()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now.AddDays(10);
        }

        /// <summary>
        /// Property to determine if the Project due time is acceptable
        /// The due date needs to have been set and be longer than 10 days hence.
        /// </summary>
        bool dateTimeAcceptable 
        {  
            get 
            {
                bool retval = (this.dateTimePickerSet == true) && (dueDate > DateTime.Now.AddDays(10));
                return retval ; 
            }  
        }

        /// <summary>
        /// Executed on the Button Click
        /// Creates a new directory appropriatly named 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void button1_Click(object sender, EventArgs e)
        {
            string customer = this.textBoxCustomer.Text;
            string title = this.textBoxProjectTitle.Text;
            

            // check that there is a valid entry for due date and the Title and customer before creating the sow
            if ((true == dateTimeAcceptable) 
                && (!String.IsNullOrEmpty(customer) 
                && (!String.IsNullOrEmpty(title))))
            {
                try
                {
                    // Create an instance of the Sender - default to the Trakm8Projects source 
                    sendemail sendMail = new sendemail(string.Empty,string.Empty,string.Empty);

                    // create a default file record updater 
                    FileRecordUpdate fileRecordUpdate = new FileRecordUpdate(string.Empty);
                    this.fsNumbertextbox.Text = fileRecordUpdate.update(customer, title, shortProjectDescription, projectOriginator,dueDate);

                    string customerTitle = givenCustomerAndTitleReturnDirectoryName(customer, title, this.fsNumbertextbox.Text);

                    // do the directory copy and then disable the button and send the email
                    DirectoryCopy(sourceDir, customerTitle, true);

                    // disable the buttons until further notice
                    this.bCreateSow.Enabled = false;
                    this.dateTimePickerSet = false;

                    // send the email saying its done 
                    sendMail.SendEmail(customer, title, dueDate.ToShortDateString(), shortProjectDescription, this.fsNumbertextbox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                string errorMessage = "Date of Project completion";
                if (this.dateTimeAcceptable)
                {
                    errorMessage = (String.IsNullOrEmpty(customer)) ? "customer" : "title";
                }
                MessageBox.Show("Please check entry for " + errorMessage);
            }
        }

        /// <summary>
        /// Function used in renaming a directory
        /// Replaces the defined token with the defined specific name 
        /// </summary>
        /// <param name="destinationDir">The Name of the Template Directory</param>
        /// <param name="name">Name to insert in Directory Name</param>
        /// <param name="token">Token to be replaced with Name</param>
        /// <returns>Name of new Directory</returns>
        string replaceToken(string destinationDir, string name, string token)
        {
            Regex rgx = new Regex(token);
            return rgx.Replace(destinationDir, name);
        }

        /// <summary>
        /// Create a directory name befitting the new project 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        string givenCustomerAndTitleReturnDirectoryName(string customer, string title,string fsNumber)
        {
            string result = replaceToken(destinationDir, customer, Customer);
            string result1 = replaceToken(result, title, Title);
            string result2 = replaceToken(result1, fsNumber, FSNumber);
            return result2;
        }

        /// <summary>
        /// Function that is used to encapsulate the renaming and copying of a directory
        /// To a new location to create the statement of work 
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Check that the directory to copy actually exists 
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(errorString + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    bool skip = false;
                    if ((subdir.Name == "emails") && (!this.checkBoxEmails.Checked)) { skip = true; }
                    if ((subdir.Name == "Test Plan") && (!this.checkBoxTestPlan.Checked)) { skip = true; }
                    if ((subdir.Name == "Plan") && (!this.checkBoxPlan.Checked)) { skip = true; }
                    if ((subdir.Name == "Technical Details") && (!this.checkBoxTSoW.Checked)) { skip = true; }

                    if (skip == false)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
        }

        /// <summary>
        /// Function called as part of the form Load
        /// </summary>
        /// <param name="sender">Not Used </param>
        /// <param name="e">not used </param>
        void Form1_Load(object sender, EventArgs e)
        {
            this.resetScreen();
        }

        /// <summary>
        /// Function that is called if the text box for "Project Title" is changed 
        /// Reset the ability to create a new Statement of work 
        /// </summary>
        /// <param name="sender">Text Box Id</param>
        /// <param name="e">not used </param>
        void textBoxProjectTitle_TextChanged(object sender, EventArgs e)
        {
            this.resetScreen();
        }

        /// <summary>
        /// Function that is called if the text box for "customer" is changed 
        /// Reset the ability to create a new Statement of work 
        /// </summary>
        /// <param name="sender">Text Box Id</param>
        /// <param name="e">not used </param>
        void textBoxCustomer_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Actions on the change of the Project description 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void projectDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            this.shortProjectDescription = ((TextBox)sender).Text;
        }

        /// <summary>
        /// Actions on the Setting of a date using the Date Picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dueDate = this.dateTimePicker1.Value;
            dateTimePickerSet = true; 
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.projectOriginator = ((TextBox)sender).Text;
        }

        void resetScreen()
        {
            // Enable the SoW create Button
            this.bCreateSow.Enabled = true;
            this.textBoxCustomer.Text = "Trakm8";
            this.projectDescriptionTextBox.Text = string.Empty;
            this.originatorTextBox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now.AddDays(10);
            this.dateTimePickerSet = false;
        }
    }
}
