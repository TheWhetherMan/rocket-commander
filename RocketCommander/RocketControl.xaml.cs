using System.Runtime.CompilerServices;
using static RocketCommander.Enums;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Speech.Synthesis;
using System.ComponentModel;
using System.Windows;
using System;

namespace RocketCommander
{
    public partial class RocketControl : UserControl, INotifyPropertyChanged
    {
        private List<RocketStates> _rocketStatesCollection;
        public List<RocketStates> RocketStatesCollection
        {
            get { return _rocketStatesCollection; }
            set { _rocketStatesCollection = value; OnPropertyChanged(); }
        }

        private readonly SpeechSynthesizer _speech = new SpeechSynthesizer();

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public RocketControl()
        {
            InitializeComponent();
            Loaded += RocketControl_Loaded;
        }

        private void RocketControl_Loaded(object sender, RoutedEventArgs e)
        {
            _speech.SelectVoice("Microsoft Zira Desktop");

            RocketStatesCollection = new List<RocketStates>();
            foreach (RocketStates state in Enum.GetValues(typeof(RocketStates)))
            {
                RocketStatesCollection.Add(state);
            }
            OnPropertyChanged(nameof(RocketStatesCollection));

            _speech.SpeakAsync("Rocket Control loaded");
        }

        private void ArmButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StateComboBox_Selected(object sender, RoutedEventArgs e)
        {
            //_speech.SpeakAsync(e.ad);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
