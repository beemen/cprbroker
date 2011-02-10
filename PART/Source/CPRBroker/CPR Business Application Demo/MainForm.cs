﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPR_Business_Application_Demo.Business;
using CPR_Business_Application_Demo.Adapters.CPRPersonWS;

namespace CPR_Business_Application_Demo
{
    public partial class MainForm : Form, INotificationListener
    {
        public MainForm()
        {
            InitializeComponent();
            this.mainTabControl.TabPages.Remove(this.personTabPage);
        }


        private void FillPersonResults(PersonBasicStructureType person)
        {
            // General information.
            personFirstNameTextBox.Text = person.RegularCPRPerson.SimpleCPRPerson.PersonNameStructure.PersonGivenName;
            personMiddleNameTextBox.Text = person.RegularCPRPerson.SimpleCPRPerson.PersonNameStructure.PersonMiddleName;
            personSurnameTextBox.Text = person.RegularCPRPerson.SimpleCPRPerson.PersonNameStructure.PersonSurnameName;

            var address = person.Item as DanishAddressStructureType;
            if (address != null)
            {
                AddressLine1TextBox.Text = address.CompletePostalLabel.PostalAddressFirstLineText;
                AddressLine2TextBox.Text = address.CompletePostalLabel.PostalAddressSecondLineText;
                AddressLine3TextBox.Text = address.CompletePostalLabel.PostalAddressThirdLineText;
                AddressLine4TextBox.Text = address.CompletePostalLabel.PostalAddressFourthLineText;
                AddressLine5TextBox.Text = address.CompletePostalLabel.PostalAddressFifthLineText;
                AddressLine6TextBox.Text = address.CompletePostalLabel.PostalAddressSixthLineText;
            }
        }

        private static void FillPersonNameAndAddressResults(PersonNameAndAddressStructureType nameAndAddress)
        {
            //AddressIdentifierCodeType
            //nameAndAddress.
        }


        private void ConsoleWriteLine(string message)
        {
            notificationResultsConsoleTextBox.Text += message + "\n";
        }

        private bool CheckRegistration(bool showMessageBox)
        {
            try
            {
                var adminController = new ApplicationsController(Properties.Settings.Default);
                var applicationRegistration =
                    adminController.ApplicationIsRegistered(Properties.Settings.Default.CPRBrokerWebServiceUrl);
                if (applicationRegistration != null)
                {
                    mainTabControl.Enabled = true;
                    registeredStatusLabel.Text = "Application is registered";
                    if (showMessageBox)
                    {
                        MessageBox.Show(this,
                                        "The application is registered",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    StartWatcher();
                    return true;
                }
                else
                {
                    mainTabControl.Enabled = false;
                    registeredStatusLabel.Text = "Application is Not registered! \n" + Properties.Settings.Default +
                      "\nurl=" + Properties.Settings.Default.CPRBrokerWebServiceUrl;
                    if (showMessageBox)
                    {
                        MessageBox.Show(this,
                                        "The application is not registered or connection failed",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void OpenOptionsForm()
        {
            var optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
            CheckRegistration(false);
        }

        #region Subscription watching
        private void StartWatcher()
        {
            if (Directory.Exists(Properties.Settings.Default.NotificationFileShare))
            {
                if (notificationWatcher == null)
                {
                    notificationWatcher = new FileSystemWatcher(Properties.Settings.Default.NotificationFileShare);
                    notificationWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
                    notificationWatcher.Filter = "*.*";

                    // Add event handlers.
                    notificationWatcher.Changed += new FileSystemEventHandler(OnChanged);
                    notificationWatcher.Created += new FileSystemEventHandler(OnChanged);
                    notificationWatcher.Deleted += new FileSystemEventHandler(OnChanged);

                    // Begin watching.
                    notificationWatcher.EnableRaisingEvents = true;
                }
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            var t = e.ChangeType;
            if (t == WatcherChangeTypes.Created || t == WatcherChangeTypes.Changed)
            {
                var notificationController = new NotificationController();
                notificationController.HandleNotification(Properties.Settings.Default, e.FullPath, this);
            }
        }

        private FileSystemWatcher notificationWatcher = null;

        #endregion


        #region INotificationListener Members

        private delegate void ReportChangedPersonRegistrationIdsDelegate(List<NotificationPerson> changedPersonRegistrationIds);

        public void ReportChangedPersonRegistrationIds(List<NotificationPerson> changedPersonRegistrationIds)
        {
            Invoke(new ReportChangedPersonRegistrationIdsDelegate(ReportChangedPersonRegistrationIdsGuiThread),
                   changedPersonRegistrationIds);
        }

        private void ReportChangedPersonRegistrationIdsGuiThread(List<NotificationPerson> changedPersonRegistrationIds)
        {
            if (notificationsForm == null)
            {
                notificationsForm = new NotificationsForm();
                notificationsForm.FormClosing += ((sender, e) => notificationsForm = null);
            }

            notificationsForm.Show(this);
            notificationsForm.AddNotification(changedPersonRegistrationIds);
        }

        #endregion

        #region Private Members

        private NotificationsForm notificationsForm = null;
        #endregion

        #region Events
        private void CreateTestPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createForm = new CreateTestCitizenForm();
            var dialogResult = createForm.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                var person = createForm.GetPerson();
                var adminController = new ApplicationsController(Properties.Settings.Default);
                var result = adminController.CreateTestCitizen(person);
            }
        }

        private void checkRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckRegistration(true);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!CheckRegistration(false))
                OpenOptionsForm();

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOptionsForm();
        }

        private void personQueryButton_Click(object sender, EventArgs e)
        {
          
        }

        private void subscribeCprButton_Click(object sender, EventArgs e)
        {
            ConsoleWriteLine("Subscribing.....");
            var t = Properties.Settings.Default.NotificationMode;
            var adminController = new SubscriptionsController(Properties.Settings.Default);

            string result = adminController.Subscribe(notificationPersonsTextBox.Lines);
            if (result.Length > 0)
            {
                ConsoleWriteLine("Suceeded!");
                ConsoleWriteLine("Subscription ID: " + result);
            }
            else
            {
                ConsoleWriteLine("FAILED!!!");
            }            
        }

        private void GetServiceInfoButton_Click(object sender, EventArgs e)
        {
            var adminController = new ApplicationsController(Properties.Settings.Default);
            var capabilities = adminController.GetCapabillities();
            InfoText.Text = "";
            foreach (var capability in capabilities)
            {
                InfoText.Text += "Version: " + capability.Version + "\r\n"
                              + "Details: " + capability.Details + "\r\n"
                              + "Functions: " + String.Join("\r\n", capability.Functions.ToArray()) + "\r\n";
            }
        }

        private void BirthDaySubscriptionButton_Click(object sender, EventArgs e)
        {
            var adminController = new SubscriptionsController(Properties.Settings.Default);
            int? age = (int)AgeSpin.Value;
            if (IgnoreAgeCheckBox.Checked)
                age = null;
            var result = adminController.SubscribeBirthdate(age, (int)PriorDaysSpin.Value,
                                                             notificationPersonsTextBox.Lines);
            if (result.Length > 0)
            {
                ConsoleWriteLine("Suceeded!");
                ConsoleWriteLine("Subscription ID: " + result);
            }
            else
            {
                ConsoleWriteLine("FAILED!!!");
            }
        }


        private void ListActiveSubscriptionsButton_Click(object sender, EventArgs e)
        {
            var adminController = new SubscriptionsController(Properties.Settings.Default);
            var activeSubscriptions = adminController.GetActiveSubscriptions();
            Dictionary<string, Dictionary<string, bool>> subscriptionIds = new Dictionary<string, Dictionary<string, bool>>();

            foreach (var subscription in activeSubscriptions)
            {
                Dictionary<string, bool> personRegistrationIds = new Dictionary<string, bool>();
                foreach (var personRegistrationId in subscription.PersonUuids)
                {
                    if (!personRegistrationIds.ContainsKey(personRegistrationId))
                        personRegistrationIds.Add(personRegistrationId, true);
                }
                subscriptionIds.Add(subscription.SubscriptionId, personRegistrationIds);
            }

            notificationResultsConsoleTextBox.Text = "";
            foreach (var personRegistrationSet in subscriptionIds)
            {
                notificationResultsConsoleTextBox.Text += "ID: " + personRegistrationSet.Key + "\r\n";
                foreach (var id in personRegistrationSet.Value.Keys)
                {
                    notificationResultsConsoleTextBox.Text += id;
                }
            }
        }
        #endregion


        private void search_button_Click(object sender, EventArgs e)
        {
            PartAdapter adapter = new PartAdapter(Properties.Settings.Default.CPRBrokerWebServiceUrl);

            Guid personUuid = new Guid(searchuuid.Text);

            var search_results = adapter.Search(Properties.Settings.Default.AdminAppToken, personUuid.ToString());
            ConsoleWriteLine("  looking up uid:" + personUuid);
            search_result.Text = "  result for uid:" + personUuid +"  "+ search_results.Length+ " results :\r\n" + String.Join("\r\n", search_results);         	
        }


        private void cpr_button_Click_1(object sender, EventArgs e)
        {
            uuidTextBox.Text = "tom";

            string personCpr = cpr.Text;

            PartAdapter adapter = new PartAdapter(Properties.Settings.Default.CPRBrokerWebServiceUrl);

            ConsoleWriteLine("  looking up cpr:" + personCpr);
            Guid puid = adapter.GetPersonUuid(Properties.Settings.Default.AdminAppToken, personCpr);
            uuidTextBox.Text = puid.ToString();
            resultXmlTextBox.Text = "  result for cpr:" + personCpr +" : "+ puid + "\r\n";
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            PartAdapter adapter = new PartAdapter(Properties.Settings.Default.CPRBrokerWebServiceUrl);

            Guid personUuid = new Guid(uuidTextBox.Text);
            var personReg = adapter.Read(Properties.Settings.Default.AdminAppToken, personUuid);
            ConsoleWriteLine("  looking up uid:" + personUuid);
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(PartService.RegistreringType1));
            StringWriter w = new StringWriter();
            ser.Serialize(w, personReg);
            
            fornavn.Text = personReg.AttributListe.Egenskab[0].NavnStruktur.PersonNameStructure.PersonGivenName;
            efternavn.Text = personReg.AttributListe.Egenskab[0].NavnStruktur.PersonNameStructure.PersonSurnameName;
            virkningFra.Text = personReg.AttributListe.Egenskab[0].Virkning.FraTidspunkt.Item.ToString();
            virkningTil.Text = personReg.AttributListe.Egenskab[0].Virkning.TilTidspunkt.Item.ToString();
            
            //gade.Text = personReg.AttributListe.RegisterOplysning[0]. CprBorger.FolkeregisterAdresse.DanskAdresse.AddressPostal.StreetName;

            resultXmlTextBox.Text = "  result for uid:" + personUuid + "    \r\n" + w.ToString();
            //    " attributes=" + personReg.AttributListe.Egenskab[0].NavnStruktur.PersonNameStructure.PersonGivenName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void gade_Click(object sender, EventArgs e)
        {

        }

    }
}
