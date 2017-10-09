using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyGiaiBongDa.Common
{
    public class MessageBoxUtil
    {
        private const string ERROR_CAPTION = "Error";
        private const string WARNING_CAPTION = "Warning";
        private const string INFOMATION_CAPTION = "Information";
        private const string CONFIRM_CAPTION = "Confimation";

        /// <summary>
        /// MessageTypes
        /// </summary>
        /// <remarks></remarks>
        public enum MessageTypes
        {
            /// <summary>None</summary>
            None = 0,

            /// <summary>Errors</summary>
            Errors = 1,

            /// <summary>Warning</summary>
            Warning = 2,

            /// <summary>Information</summary>
            Information = 3,

            /// <summary>Confirmation</summary>
            Confirmation = 4
        }

        /// <summary>
        /// Show message box depend on captionType
        /// </summary>
        /// <param name="captionType">caption type (Error/Warning/Information/Confirm)</param>
        /// <param name="message">message content</param>
        /// <param name="args">appended strings</param>
        /// <remarks></remarks>
        public static MessageBoxResult ShowMessage(MessageTypes captionType, string message, params object[] args)
        {
            string text = args == null ? message : string.Format(message, args);

            if (captionType == MessageTypes.Errors)
            {
                return MessageBox.Show(text, ERROR_CAPTION, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (captionType == MessageTypes.Warning)
            {
                return MessageBox.Show(text, WARNING_CAPTION, MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (captionType == MessageTypes.Information)
            {
                return MessageBox.Show(text, INFOMATION_CAPTION, MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (captionType == MessageTypes.Confirmation)
            {
                return MessageBox.Show(text, CONFIRM_CAPTION, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            return MessageBoxResult.None;
        }


    }
}
