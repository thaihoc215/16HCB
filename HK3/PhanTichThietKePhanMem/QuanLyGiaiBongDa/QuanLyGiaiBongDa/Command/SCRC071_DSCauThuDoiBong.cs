﻿//------------------------------------------------------------------------------
// <auto-generated>
//     text template column for binding
//
//     Auto refresh
// </auto-generated>
//------------------------------------------------------------------------------

using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.ViewModels;
namespace QuanLyGiaiBongDa.ViewModels
{

	partial class SCRC071VM_DSCauThuDoiBong : BaseViewModel
	{

		private ICommand _closeCommand;

		public ICommand CloseCommand
		{
			get
			{
				if (_closeCommand == null)
				{
					_closeCommand = new RelayCommand(ExecuteCloseCommand);
				}
				return _closeCommand;
			}
		}

	}
}



