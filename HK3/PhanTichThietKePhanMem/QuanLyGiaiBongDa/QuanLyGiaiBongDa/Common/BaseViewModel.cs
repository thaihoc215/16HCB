/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 13/03/2017 - BaseViewModel.cs
 */
using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.Common
{
    public class BaseViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Arguments passed to the constructor.
        /// </summary>
        protected object[] Args { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected BaseViewModel(params object[] args)
        {
            Args = args;
            //if (RequiredProperties != null) _properties.SetRequiredPropertyNames(RequiredProperties);
            //if (OptionalProperties != null) _properties.SetOptionalPropertiyNames(OptionalProperties);
            InitializeProperties();
        }
        /// <summary>
        /// Initial processing of this screen.
        /// </ summary>
        /// <remarks>
        /// Overrides this method and describes processing only when initial processing (editing initial value of screen item etc) is necessary.
        /// </ remarks>
        protected virtual void InitializeProperties() { }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool? _dialogResult;
        public bool? DialogResult
        {
            get { return _dialogResult; }
            set
            {
                _dialogResult = value;
                OnPropertyChanged("DialogResult");
            }
        }

        /// <summary>
        // / Display of the screen corresponding to this view model.
        /// </ summary>
        /// <remarks>
        /// Normally, setting / calling of this action is unnecessary. It is automatically processed on the framework side by screen transition using [ViewForwarder class].
        /// </ remarks>
        public Action ShowDialogBox { get; set; }

        /// <summary>
        // / Close the view corresponding to this view model.
        /// </ summary>
        /// <remarks>
        /// Normally this action setting is unnecessary. It is automatically set on the framework side by screen transition using [ViewForwarder class].
        /// </ remarks>
        public Action CloseDialogBox { get; set; }

    }
}
