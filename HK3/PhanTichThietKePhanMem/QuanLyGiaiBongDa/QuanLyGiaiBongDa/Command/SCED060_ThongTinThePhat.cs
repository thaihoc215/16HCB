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

	partial class SCED060VM_ThongTinThePhat : BaseViewModel
	{

		private ICommand _editThePhatCommand;

		public ICommand EditThePhatCommand
		{
			get
			{
				if (_editThePhatCommand == null)
				{
					_editThePhatCommand = 
						new RelayCommand(ExecuteEditThePhatCommand, CanExecuteEditThePhatCommand);
				}
				return _editThePhatCommand;
			}
		}

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



