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

	partial class SCED080VM_ThemCauThuDoiBong : BaseViewModel
	{

		private ICommand _openAddCauThuCommand;

		public ICommand OpenAddCauThuCommand
		{
			get
			{
				if (_openAddCauThuCommand == null)
				{
					_openAddCauThuCommand = new RelayCommand(ExecuteOpenAddCauThuCommand);
				}
				return _openAddCauThuCommand;
			}
		}

		private ICommand _xoaCauThuCommand;

		public ICommand XoaCauThuCommand
		{
			get
			{
				if (_xoaCauThuCommand == null)
				{
					_xoaCauThuCommand = 
						new RelayCommand(ExecuteXoaCauThuCommand, CanExecuteXoaCauThuCommand);
				}
				return _xoaCauThuCommand;
			}
		}

		private ICommand _setDoiTruongCommand;

		public ICommand SetDoiTruongCommand
		{
			get
			{
				if (_setDoiTruongCommand == null)
				{
					_setDoiTruongCommand = 
						new RelayCommand(ExecuteSetDoiTruongCommand, CanExecuteSetDoiTruongCommand);
				}
				return _setDoiTruongCommand;
			}
		}

		private ICommand _addCauThuCommand;

		public ICommand AddCauThuCommand
		{
			get
			{
				if (_addCauThuCommand == null)
				{
					_addCauThuCommand = 
						new RelayCommand(ExecuteAddCauThuCommand, CanExecuteAddCauThuCommand);
				}
				return _addCauThuCommand;
			}
		}

		private ICommand _canCelAddCauThuCommand;

		public ICommand CanCelAddCauThuCommand
		{
			get
			{
				if (_canCelAddCauThuCommand == null)
				{
					_canCelAddCauThuCommand = new RelayCommand(ExecuteCanCelAddCauThuCommand);
				}
				return _canCelAddCauThuCommand;
			}
		}

		private ICommand _chooseAvaCommand;

		public ICommand ChooseAvaCommand
		{
			get
			{
				if (_chooseAvaCommand == null)
				{
					_chooseAvaCommand = 
						new RelayCommand(ExecuteChooseAvaCommand, CanExecuteChooseAvaCommand);
				}
				return _chooseAvaCommand;
			}
		}

	}
}



