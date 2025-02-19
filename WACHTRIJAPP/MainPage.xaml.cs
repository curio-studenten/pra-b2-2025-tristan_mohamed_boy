using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BugsOfHorrorXAML
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Voer acties uit wanneer op de knop geklikt is
        private void KnopUpdateInformatie_Click(object sender, RoutedEventArgs e)
        {
            VerwerkWachtrijSensorData();
            VerwerkAttractieStatusData();
        }

        //Bereken de wachtrij tijd
        private void VerwerkWachtrijSensorData()
		{
            //  Roep de methode aan welke de wachttijd berekend.
            int Wachttijd = BerekenWachtTijd();

            //  Gebruik de wachttijd om de tekst in de label 'labelWachttijdMelding' aan te passen.
            this.LabelWachtTijdMelding.Text = $"{Wachttijd} minuten";
        }

        //Bepaal de status van de attractie
        private void VerwerkAttractieStatusData()
		{
            //  Lees het XML AttractieStatus bestand uit welke de data van de karretjes uitleest.
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets\\SensorData\\AttractieStatus.xml");

            //  Selecteer de XML node 'Kar01' en lees vervolgens de waarde binnen het element.
            //  Converteer de statuc-code in een status-beschrijving.
            //  Gebruik de status-beschrijving om de tekst in de label 'labelKar1' aan te passen.
            string node1 = doc.DocumentElement.SelectSingleNode("Kar01").InnerText; // '/Status/' achter kar 01-02-03 verwijderd
            string status1 = ConvertStatus(node1);
            this.LabelKar1.Text = $"Kar 1: {status1}";

            string node2 = doc.DocumentElement.SelectSingleNode("Kar02").InnerText;
            string status2 = ConvertStatus(node2);
            this.LabelKar2.Text = $"Kar 2: {status2}";

            string node3 = doc.DocumentElement.SelectSingleNode("Kar03").InnerText; 
            string status3 = ConvertStatus(node3);
            this.LabelKar3.Text = $"Kar 3: {status3}"; //test kar 3 toegevoegd 19-2-2025
        }

        private int BerekenWachtTijd()
		{
            int WachtTijd = 0;

            //  Lees het XML WachtrijSensoren bestand uit welke meet waar mensen staan te wachten.
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets\\SensorData\\WachtrijSensoren.xml");

            //  Selecteer de XML node 'Sensor01' en lees vervolgens de waarde binnen het element.
            //  Wanneer de sensor geen mensen detecteerd, geef de tot nu to berekende wachttijd terug.
            //  Wanneer de sensor wel mensen detecteerd, bereken de nieuwe wachttijd en ga door naar de volgende sensor.
            string node01 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor01").InnerText;
            if (node01 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 6;                                     // Eerste 2 naar 6 minuten en de rest naar 4 minuten 19-2-2025

            string node02 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor02").InnerText;
            if (node02 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 6;

            string node03 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor03").InnerText;
            if (node03 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node04 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor04").InnerText;
            if (node04 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node05 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor05").InnerText;
            if (node05 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node06 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor06").InnerText;
            if (node06 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node07 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor07").InnerText;
            if (node07 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node08 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor08").InnerText;
            if (node08 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node09 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor09").InnerText;
            if (node09 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node10 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor10").InnerText;
            if (node10 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node11 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor11").InnerText;
            if (node11 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;

            string node12 = doc.DocumentElement.SelectSingleNode("/Sensoren/Sensor12").InnerText;
            if (node12 == "False")
            {
                return WachtTijd;
            }
            WachtTijd += 4;                                                         // 8 tot en met 12 toegevoegd 19-2-2025

            return WachtTijd;
        }

        //  Een methode welke een status-code omzet naar een status-beschrijving
        private string ConvertStatus(string StatusNr)
        {
            if (StatusNr == "1")
            {
                return "uit/instappen";
            }

            if (StatusNr == "2")
            {
                return "Klaar voor vertrek";
            }

            if (StatusNr == "3")
            {
                return "Op avontuur";
            }

            if (StatusNr == "4")
            {
                return "Komt binnen";
            }

            if (StatusNr == "5")
            {
                return "In onderhoud";
            }
                                                    // status nummer 5 toegevoegd 19-2-2025
            return "";
        }
	}
}
